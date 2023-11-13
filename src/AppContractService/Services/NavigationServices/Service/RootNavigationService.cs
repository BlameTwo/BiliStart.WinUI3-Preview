namespace AppContractService.Services.NavigationServices.Service;

public sealed class RootNavigationService : NavigationServiceBase
{
    public RootNavigationService(IPageService pageService)
        : base(pageService) 
    {
        this.NavigatedEvent += RootNavigationService_NavigatedEvent;
    }

    public void BackMain()
    {
        while (true)
        {
            if (!IsMain)
            {
                this.GoBack();
                continue;
            }
            break;
        }
    }

    bool IsMain = false;

    private void RootNavigationService_NavigatedEvent(object sender, NavigationEventArgs e)
    {
        //当前页面是否是MainPage
        IsMain = e?.Content?.GetType().FullName == typeof(ShellPage).FullName;
    }
}
