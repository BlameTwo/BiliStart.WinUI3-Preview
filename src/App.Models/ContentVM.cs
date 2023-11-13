using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace App.Models;

public abstract class ContentVM<IViewModel> : UserControl
    where IViewModel : class
{
    public IViewModel ViewModel
    {
        get { return (IViewModel)GetValue(ViewModelProperty); }
        set { SetValue(ViewModelProperty, value); }
    }

    public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
        "ViewModel",
        typeof(IViewModel),
        typeof(ContentVM<IViewModel>),
        new PropertyMetadata(
            null,
            (s, e) =>
            {
                if (e.NewValue == null)
                    return;
                var obj = (s as ContentVM<IViewModel>);
                //更换ViewModel(恼
                obj.DataContext = e.NewValue;
                obj.ViewModelChanged();
            }
        )
    );

    /// <summary>
    /// VM加载完毕的一个抽象方法
    /// </summary>
    public abstract void ViewModelChanged();
}
