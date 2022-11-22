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
        public Command GoHomeCommand { get; set; }
        public LogoutViewModel()
        {
            UserCartItemCount = new CartItemService().GetUserCartCount();
            IsCartExists = (UserCartItemCount > 0) ? true : false;
            LogoutCommand = new Command(() =>  LogoutAsync());
            GoHomeCommand = new Command(() =>  GoHomeAsync());
        }

        private void LogoutAsync()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
            Preferences.Remove("Username");
            Application.Current.MainPage = new LoginView();
        }

        private void GoHomeAsync()
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}
