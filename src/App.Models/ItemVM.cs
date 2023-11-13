using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace App.Models;

public abstract class ItemVM<T> : Control 
{
    public T ViewModel
    {
        get { return (T)GetValue(ViewModelProperty); }
        set { SetValue(ViewModelProperty, value); }
    }

    public static readonly DependencyProperty ViewModelProperty =
        DependencyProperty.Register("ViewModel", typeof(T), typeof(ItemVM<T>), new PropertyMetadata(null));
}

