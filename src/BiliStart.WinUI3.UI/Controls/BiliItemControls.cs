using CommunityToolkit.Mvvm.Input;
using IAppContracts.Controls;
using Microsoft.UI.Xaml.Controls;
using System;

namespace BiliStart.WinUI3.UI.Controls;

public partial class BiliItemControls : ListView, IBiliItemControls
{
    private ScrollViewer _sviewer { get; set; }

    protected override void OnApplyTemplate()
    {
        this._sviewer = (ScrollViewer)this.GetTemplateChild("ScrollViewer");
        SetEvent();
        base.OnApplyTemplate();
    }

    private void SetEvent()
    {
        this._sviewer.ViewChanged += Viewer_ViewChanged;
    }

    bool Flage = false;

    private async void Viewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
    {
        double verticalOffset = _sviewer.VerticalOffset;
        _sviewer.ViewChanged -= Viewer_ViewChanged;
        var sv = sender as ScrollViewer;
        if (sv.VerticalOffset > 10)
            Flage = true;
        else
            Flage = false;
        var flage = sv.VerticalOffset + sv.ViewportHeight;
        if (sv.ExtentHeight - flage < 5 && sv.ViewportHeight != 0)
        {
            if (this.AddDataCommand == null)
                return;
            if (AddDataCommand is AsyncRelayCommand asynccommand)
            {
                await asynccommand.ExecuteAsync(parameter: this.Paramter);
            }
            else if (AddDataCommand is RelayCommand command)
            {
                command.Execute(parameter: this.Paramter);
            }
            else
            {
                AddDataCommand.Execute(Paramter);
            }
            _sviewer.ChangeView(null, verticalOffset - 50, null);
        }
        _sviewer.ViewChanged += Viewer_ViewChanged;
    }
}
