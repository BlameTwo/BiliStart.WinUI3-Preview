using App.Models.AppTabView;
using CommunityToolkit.Mvvm.Messaging;
using IAppContracts.TabViewContract;
using Microsoft.UI.Xaml;
using System.Reflection.PortableExecutable;

namespace IAppInterface.Services;

public class TabViewService : ITabViewService
{
    public TabViewService(ITabUserControlService tabUserControlService)
    {
        TabUserControlService = tabUserControlService;
    }

    public void AddItemView(TabViewItem tabViewItem)
    {
        this._view.TabItems.Add(tabViewItem);
    }

    Microsoft.UI.Xaml.Controls.TabView _view;

    public ITabUserControlService TabUserControlService { get; }

    public void RegisterView(Microsoft.UI.Xaml.Controls.TabView view)
    {
        this._view = view;
        SetEvent();
    }

    public void GoToView(TabViewArgs key,object paramter=null)
    {
        if (GetOwnerView(key, out var value))
        {
            var result = TabUserControlService.AddViewControl(key.ViewKey,paramter);
            this._view.TabItems.Add(
                new TabViewItem()
                {
                    Header = key.Header,
                    Tag = key.ServiceKey,
                    Content = result,
                    IsClosable = key.IsCloseVisibility,
                    IconSource = new FontIconSource
                    {
                        FontFamily = new FontFamily("Segoe Fluent Icons"),
                        Glyph = key.Icon
                    }
                }
            );
            this._view.SelectedIndex = _view.TabItems.Count - 1;
            WeakReferenceMessenger.Default.Send<TabLengthChangedMessager>(new(true));
        }
        else
        {
            //如果服务存在的话就选中当前这个服务
            this._view.SelectedItem = value;
        }
    }

    /// <summary>
    /// 在本服务中查找已存在的对象
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public bool GetOwnerView(TabViewArgs key, out object view)
    {
        foreach (var item in _view.TabItems)
        {
            if (item is TabViewItem viewitem)
            {
                if (viewitem.Tag != null&&viewitem.Tag.ToString() == key.ServiceKey)
                {
                    view = viewitem;
                    return false;
                }
            }
        }
        view = null;
        return true;
    }

    public bool UpDateTitle(string key,string newHeader)
    {
        foreach (var item in _view.TabItems)
        {
            if (item is TabViewItem viewitem)
            {
                if (viewitem.Tag != null && viewitem.Tag.ToString() == key)
                {
                    viewitem.Header = newHeader;
                    return true;
                }
            }
        }
        return false;
    }

    public void UpDateProgressRing(string key,Visibility visibility)
    {
        foreach (var item in _view.TabItems)
        {
            if (item is not TabViewItem viewitem) return;
            if (viewitem.Tag != null && viewitem.Tag.ToString() == key)
            {
                Lib.Helper.TabView.SetTabProgressRingAction(viewitem,visibility);
            }
        }
    }

    public void UpDateIcon(string key, IconSource source)
    {
        foreach (var item in _view.TabItems)
        {
            if (item is not TabViewItem viewitem) return;
            if (viewitem.Tag != null && viewitem.Tag.ToString() == key)
            {
                viewitem.IconSource = source;
                break;
            }
        }
    }

    private void SetEvent()
    {
        _view.TabCloseRequested += _view_TabCloseRequested;
    }

    private void _view_TabCloseRequested(Microsoft.UI.Xaml.Controls.TabView sender, TabViewTabCloseRequestedEventArgs args)
    {
        if((args.Item as TabViewItem).Content is ITabModel tabModel)
        {
            tabModel.UnregisterViewModel();
        } 
        (args.Item as TabViewItem).Content = null;
        _view.TabItems.Remove(args.Item);
        GC.Collect();
    }
}
