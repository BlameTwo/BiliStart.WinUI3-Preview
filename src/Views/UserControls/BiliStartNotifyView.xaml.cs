using System.IO;
using Views.Models;
using WinUIEx;

namespace Views.UserControls;

public sealed partial class BiliStartNotifyView : BiliStartNotifyControl
{
    public BiliStartNotifyView()
    {
        this.InitializeComponent();
        Loaded += BiliStartNotifyView_Loaded;
    }

    private void BiliStartNotifyView_Loaded(object sender, RoutedEventArgs e)
    {
        using (FileStream fs = File.OpenRead(FilePath.AppPath + "/Assets/icon.ico"))
        {
            //用资源的方式去加载
            baricon.Icon = new System.Drawing.Icon(fs);
        }
    }
}
