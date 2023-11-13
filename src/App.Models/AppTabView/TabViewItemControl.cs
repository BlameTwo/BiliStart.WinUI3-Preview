using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using System;

namespace App.Models.AppTabView;

public abstract class TabViewItemControl<IViewModel> : UserControl, ITabModel
    where IViewModel : class
{
    public TabViewItemControl()
    {
        this.TokenSource = new();
        this.Transitions = new Microsoft.UI.Xaml.Media.Animation.TransitionCollection()
        {
            new EntranceThemeTransition(),
        };
    }

    public virtual void RegisterViewModel(object vm)
    {
        this.ViewModel = (IViewModel)vm;
    }

    public virtual void UnregisterViewModel()
    {
        this.ViewModel = null;
        GC.Collect();
    }

    public virtual void GoParamter(object value)
    {

    }

    public System.Threading.CancellationTokenSource TokenSource { get; }

    public IViewModel ViewModel
    {
        get { return (IViewModel)GetValue(ViewModelProperty); }
        set { SetValue(ViewModelProperty, value); }
    }
    public virtual void OnViewModelChanged()
    {

    }

    // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
        "ViewModel",
        typeof(IViewModel),
        typeof(TabViewItemControl<IViewModel>),
        new PropertyMetadata(null,OnViewModelChanged)
    );

    private static void OnViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as TabViewItemControl<IViewModel>).DataContext = e.NewValue;
        (d as TabViewItemControl<IViewModel>).OnViewModelChanged();
    }
}
