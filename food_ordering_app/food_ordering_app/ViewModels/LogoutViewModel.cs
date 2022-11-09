using food_ordering_app.Services;
using food_ordering_app.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace food_ordering_app.ViewModels
{
    public class LogoutViewModel :BaseViewModel
    {

        private int _UserCartItemCount;
        public int UserCartItemCount
        {
            set
            {
                _UserCartItemCount = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserCartItemCount;
            }
        }

        private bool _IsCartExists;
        public bool IsCartExists
        {
            set
            {
                _IsCartExists = value;
                OnPropertyChanged();
            }
            get
            {
                return _IsCartExists;
            }
        }

        public Command LogoutCommand { get; set; }
        public Command GoToCartCommand { get; set; }
        public LogoutViewModel()
        {
            UserCartItemCount = new CartItemService().GetUserCartCount();
            IsCartExists = (UserCartItemCount > 0) ? true : false;
            LogoutCommand = new Command(async () => await LogoutAsync());
            GoToCartCommand = new Command(async () => await GoToCartAsync());
        }

        private async Task GoToCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async Task LogoutAsync()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
            Preferences.Remove("Username");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LoginView());
        }
    }
}
