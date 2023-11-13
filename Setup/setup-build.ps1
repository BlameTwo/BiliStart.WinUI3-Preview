$scriptpath = $PSScriptRoot
$innoSetupExe = Read-Host "请输入 Inno Setup 编译器的位置（例如：C:\Program Files (x86)\Inno Setup 6\ISCC.exe）："
$sdkurl ="https://aka.ms/windowsappsdk/1.3/1.3.230724000/windowsappruntimeinstall-x64.exe"
if (-not [string]::IsNullOrEmpty($innoSetupExe)) {
    Write-Host "请选择编译版本："
    Write-Host "1. x64（目前仅对x64平台发布）"
    $choice = Read-Host "请输入选项编号："
    if ($choice -eq "1") {
        $scriptPath = Join-Path $scriptpath "Win-x64\x64-Script.iss"
        Write-Host "开始下载依赖项目"
        $outputPath = Join-Path $PSScriptRoot "/Win-x64/WindowsAppRuntimeInstall.exe"
        $wc = New-Object System.Net.WebClient
        $wc.DownloadFile($sdkurl, $outputPath)
        Write-Host "Windows App Runtime 安装文件已下载到：$outputPath"
    } 
    else
    {
       Write-Host "Error value"
       Exit	
    }
    $innoSetupFolder = Split-Path -Path $innoSetupExe
    Set-Location $innoSetupFolder
    & $innoSetupExe $scriptPath
    Set-Location -Path $PSScriptRoot
    Write-Host "已经在选择的平台文件夹中生成安装exe，请进入选择的编译版本的Output文件夹中查看"
} else {
    Write-Host "未提供有效的 Inno Setup 编译器位置。"
}
Read-Host "请按任意键退出"

