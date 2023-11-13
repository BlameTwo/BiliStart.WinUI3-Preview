using IAppExtension.Contract;
using Microsoft.UI.Xaml;
using WinUIEx;

namespace IAppContracts
{
    public class BiliApplication : Application, IAppService
    {
        private bool _contentLoaded;

        public WindowEx MainWindow { get; set; }
        public string ServiceID { get; set; } = "BIliApp";
    }
}
