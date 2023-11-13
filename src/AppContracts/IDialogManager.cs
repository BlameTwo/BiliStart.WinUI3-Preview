namespace IAppContracts;

public interface IDialogManager
{
    /// <summary>
    /// 登录窗口
    /// </summary>
    public void ShowLogin();

    /// <summary>
    /// Token窗口
    /// </summary>
    public void ShowToken();

    public void ShowDownload();

    public void ShowDownloadItemSession(string guid);
}
