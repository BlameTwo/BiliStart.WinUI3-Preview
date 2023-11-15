
using CommunityToolkit.Mvvm.ComponentModel;
using IAppContracts;
using Microsoft.UI.Windowing;

namespace ViewModels.ToolViewModels;

public partial class ToolRootViewModel:ObservableRecipient
{
    public ToolRootViewModel(IWindowManager windowManager)
    {
        IsActive = true;
        WindowManager = windowManager;
        
    }

    [RelayCommand]
    void Loaded()
    {
        this.WindowManager.ChangedMinWidth(500);
        this.WindowManager.ChangedMinHeight(250);
        this.WindowManager.SetWindowSize(500, 1000);
        this.WindowManager.SetWindowResizable(true); 
        if (WindowManager.GetAppWindow().Presenter is OverlappedPresenter opr)
        {
            //这里关闭最大化和最小化按钮
            opr.IsMaximizable = true;
            opr.IsMinimizable = true;
        }
    }

    public IWindowManager WindowManager { get; }
}