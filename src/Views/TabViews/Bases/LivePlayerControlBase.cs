using App.Models.AppTabView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views.TabViews.Bases
{
    public class LivePlayerControlBase: TabViewItemControl<ViewModels.AppTabViewModels.LivePlayerViewModel>
    {
        public override void GoParamter(object value)
        {

            this.ViewModel.RefershDataAsync(long.Parse(value.ToString()??"1"));
            base.GoParamter(value);
        }


        public override void UnregisterViewModel()
        {
            this.ViewModel.Element.CloseAsync();
            this.ViewModel.TokenSource.Cancel();
            base.UnregisterViewModel();
        }
    }
}
