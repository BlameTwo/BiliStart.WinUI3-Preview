using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AppContractService.Services;

public sealed class FFmpegFormatService : IFFmpegFormatService
{
    public bool IsSupportEnable => Support();

    public string FFmpegFolder { get; set; }

    public async Task StartBiliHEVCProcess(
        string audio,
        string video,
        string outputpath,
        IProgress<(string, double)> progress
    )
    {
        await Task.Run(async () =>
        {
            if (!IsSupportEnable)
                return;
            TimeSpan totalDuration = TimeSpan.Zero;
            TimeSpan currentDuration = TimeSpan.Zero;
            //转换视频默认的音频质量为128k，可能需要更改
            var ffmpegCommand =
                $"-i {audio} -i {video} -progress -y -c:v copy -c:a aac -strict experimental -b:a 128k {outputpath}";
            progress.Report(("创建转换参数", 0.0));
            var ffmpegPath = Path.Combine(FFmpegFolder, "ffmpeg.exe");
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = $"-Command \"{ffmpegPath} {ffmpegCommand}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            progress.Report(("创建初始进程(ffmpeg.exe)", 0.0));
            using (Process pslProcess = new())
            {
                pslProcess.StartInfo = startInfo;
                pslProcess.ErrorDataReceived += (sender, data) =>
                {
                    double progressvalue = 0.0;
                    if (!string.IsNullOrEmpty(data.Data))
                    {
                        string durationPattern = @"Duration: (\d{2}:\d{2}:\d{2}\.\d{2})";
                        string progressPattern = @"time=([^bitrate]+)";

                        Match durationMatch = Regex.Match(data.Data, durationPattern);
                        if (durationMatch.Success)
                        {
                            if (totalDuration == TimeSpan.Zero)
                                totalDuration = TimeSpan.Parse(durationMatch.Groups[1].Value);
                        }
                        Match progressMatch = Regex.Match(data.Data, progressPattern);
                        if (progressMatch.Success)
                        {
                            currentDuration = TimeSpan.Parse(progressMatch.Groups[1].Value);
                            progressvalue =
                                currentDuration.TotalSeconds / totalDuration.TotalSeconds * 100;
                            Debug.WriteLine($"Progress: {progress:F2}%");
                            progress.Report(("进度：", progressvalue));
                        }
                    }
                };
                pslProcess.Start();
                pslProcess.BeginOutputReadLine();
                pslProcess.BeginErrorReadLine();
                await pslProcess.WaitForExitAsync();
                progress.Report(($"退出进程:{pslProcess.Id}", -1.0));
            }
        });
    }


    bool Support()
    {
        if (
            File.Exists(Path.Combine(FFmpegFolder, "swscale-5.dll"))
            && File.Exists(Path.Combine(FFmpegFolder, "swresample-3.dll"))
            && File.Exists(Path.Combine(FFmpegFolder, "ffprobe.exe"))
            && File.Exists(Path.Combine(FFmpegFolder, "ffplay.exe"))
            && File.Exists(Path.Combine(FFmpegFolder, "ffmpeg.exe"))
            && File.Exists(Path.Combine(FFmpegFolder, "avutil-56.dll"))
            && File.Exists(Path.Combine(FFmpegFolder, "avformat-58.dll"))
            && File.Exists(Path.Combine(FFmpegFolder, "avfilter-7.dll"))
            && File.Exists(Path.Combine(FFmpegFolder, "avdevice-58.dll"))
            && File.Exists(Path.Combine(FFmpegFolder, "avcodec-58.dll"))
        )
        {
            return true;
        }
        return false;
    }
}
