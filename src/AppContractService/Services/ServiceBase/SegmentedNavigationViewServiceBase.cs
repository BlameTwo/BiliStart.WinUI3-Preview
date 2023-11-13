using CommunityToolkit.WinUI.Controls;
using IAppContracts.SegmentedContract;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace AppContractService.Services.ServiceBase;

public class SegmentedNavigationViewServiceBase : ISegmentedNavigationView
{
    public SegmentedNavigationViewServiceBase(INavigationService navigationService,IPageService pageService)
    {
        NavigationService = navigationService;
        PageService = pageService;
    }

    public INavigationService NavigationService { get; }
    public IPageService PageService { get; }

    public IList<object> GetItems()
    {
        if (_segmented != null)
            return _segmented.Items;
        else
            throw new UIException("请在使用GetItems前注册视图",_segmented,this);
    }

    Segmented _segmented = null;

    public void RegisterView(Segmented control)
    {
        this._segmented = control;
        _segmented.SelectionChanged += _segmented_SelectionChanged;
    }


    public void UnRegisterView()
    {
        if (_segmented == null) return;
        _segmented.SelectionChanged -= _segmented_SelectionChanged;
        _segmented = null;
    }

    public void NavigationPage(int index)
    {
        _segmented.SelectedIndex = index;
    }

    private void _segmented_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var result =  e.AddedItems[0];
        if(result is SegmentedItem item)
        {
            var key = Lib.Helper.NavigationTo.GetNavigationTo(item);
            var paramter = Paramter.GetNavigationToParamter(item);
            NavigationService.NavigationTo(key, paramter);

        }
    }

}
