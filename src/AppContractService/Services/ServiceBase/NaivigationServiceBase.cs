using Microsoft.UI.Xaml.Controls;

namespace AppContractService.Services.ServiceBase;

public class NavigationServiceBase : INavigationService
{
    #region 私有变量
    Frame _baseFrame = null;
    object oldparamter = null;
    #endregion
    public bool? CanBack => _baseFrame.CanGoBack;

    public NavigationServiceBase(IPageService pageService)
    {
        PageService = pageService;
    }

    public Frame BaseFrame
    {
        get
        {
            if (_baseFrame == null)
                RegisterNavigationEvent();
            return _baseFrame;
        }
        set
        {
            UnRegisterNavigationEvent();
            _baseFrame = value;
            RegisterNavigationEvent();
        }
    }

    public IPageService PageService { get; }

    private void UnRegisterNavigationEvent()
    {
        if (_baseFrame != null && NavigatedEvent != null)
            _baseFrame.Navigated -= NavigatedEvent;
    }

    private void RegisterNavigationEvent()
    {
        if(_baseFrame!=null)
            _baseFrame.Navigated += NavigatedEvent;
    }

    public event NavigatedEventHandler NavigatedEvent;

    public void GoBack() => _baseFrame.GoBack();

    public void GoForward() => _baseFrame.GoForward();

    public bool NavigationTo(string pagekey, object parameter = null, bool clearnavigation = false)
    {
        var pagetype = PageService.GetPage(pagekey);
        var pagevm = PageService.GetPageVM(pagekey);
        bool navigated = false;
        AppNavigationPageArgs args = new() { Paramter = parameter, ViewModel = pagevm };
        if (
            _baseFrame != null
            && (
                _baseFrame.Content?.GetType() != pagetype
                || parameter != null && !parameter.Equals(oldparamter)
            )
        )
        {
            _baseFrame.Tag = clearnavigation;
            navigated = _baseFrame.Navigate(pagetype, args, new DrillInNavigationTransitionInfo());
            oldparamter = parameter;
            return navigated;
        }
        navigated = false;
        return navigated;
    }
}
