using Views.Models.PgcViewControl;

namespace Views.UserControls.PgcControls;

public delegate void PgcViewControlPageSelectionedDelegate(object source, object SelectionItem);

public sealed partial class PgcPagesControl : PagesControl
{
    internal PgcViewControlPageSelectionedDelegate PgcViewControlPageSelectionedHandle;

    public event PgcViewControlPageSelectionedDelegate ViewControlPageSelectioned
    {
        add => PgcViewControlPageSelectionedHandle += value;
        remove => PgcViewControlPageSelectionedHandle -= value;
    }

    public PgcPagesControl()
    {
        this.InitializeComponent();
    }

    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (PgcViewControlPageSelectionedHandle != null)
            PgcViewControlPageSelectionedHandle.Invoke(this.ViewModel, e.AddedItems[0]);
    }
}
