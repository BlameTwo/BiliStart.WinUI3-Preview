namespace Views.UserControls;

public sealed partial class PlayerPagesControl : PlayerPages
{
    public PlayerPagesControl()
    {
        this.InitializeComponent();
    }

    public override void ViewModelChanged()
    {
        if (!this.IsLoaded) return;
        if(ViewModel.PlayerPages != null)
        {
            pagesView.ItemsSource = ViewModel.PlayerPages;
            if(ViewModel.SpaceCid != 0)
            {
                for (int i = 0; i < ViewModel.PlayerPages.Count; i++)
                {
                    if (ViewModel.PlayerPages[i].Cid == ViewModel.SpaceCid)
                        pagesView.SelectedIndex = i;
                }
            }
            else
            {
                pagesView.SelectedIndex = 0;
            }
        }
    }

    private PageSelectionDelegate PageSelectionHandle;

    public event PageSelectionDelegate PageSelectionEvent
    {
        add { this.PageSelectionHandle += value; }
        remove { this.PageSelectionHandle -= value; }
    }

    public delegate void PageSelectionDelegate(object source, ViewPage value);

    private void ListView_SelectionChanged(
        object sender,
        Microsoft.UI.Xaml.Controls.SelectionChangedEventArgs e
    )
    {
        if (e.AddedItems[0] is ViewPage view && PageSelectionHandle != null)
        {
            this.PageSelectionHandle.Invoke(this, view);
        }
    }
}
