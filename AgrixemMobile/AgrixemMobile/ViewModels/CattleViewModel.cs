using AgrixemMobile.Models;
using System.Diagnostics;

namespace AgrixemMobile.ViewModels
{
    public class CattleViewModel
    {
        private Cattle cattle;
        public CattleViewModel()
        {
        }
        public async void GetCow()
        {
            cattle = await App.AgrixemManager.GetCattleAsync(1);
        }

   
    }
}
