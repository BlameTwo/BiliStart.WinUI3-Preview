namespace Views.UserControls;

public sealed partial class PlayerRelatesControl : PlayerRelates
{
    public PlayerRelatesControl()
    {
        this.InitializeComponent();
    }

    private void ListView_ItemClick(object sender, ItemClickEventArgs e)
    {
        (this.DataContext as IPlayerRelatesViewModel).ClickChanged((ViewConverter.Models.PlayerRelatesVideo)e.ClickedItem);
    }
}
