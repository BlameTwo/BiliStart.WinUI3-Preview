namespace IAppContracts.Controls;

public interface IContentPopup
{
    /// <summary>
    /// 内部执行方法，打开
    /// </summary>
    void Showed();

    /// <summary>
    /// 内部执行方法，关闭
    /// </summary>
    void Hide();
}
