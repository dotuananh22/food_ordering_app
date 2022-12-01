using food_ordering_app.Model;
using food_ordering_app.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Threading.Tasks;
using food_ordering_app.Views;

namespace food_ordering_app.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
            get
            {
                return _Username;
            }
        }

        private string _Address;
        public string Address
        {
            set
            {
                _Address = value;
                OnPropertyChanged();
            }
            get
            {
                return _Address;
            }
        }

        private int _UserCartItemsCount;
        public int UserCartItemsCount
        {
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
            get
            {
                return _UserCartItemsCount;
            }
        }

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<FoodItem> LatestItems { get; set; }

        public Command ViewCartCommand { get; set; }
        public Command LogoutCommand { get; set; }
        
        public ProductsViewModel()
        {
            var uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
                Username = "Guest";
            else
                Username = uname;

            Address = Preferences.Get("Address", String.Empty);

            UserCartItemsCount = new CartItemService().GetUserCartCount();

            Categories = new ObservableCollection<Category>();
            LatestItems = new ObservableCollection<FoodItem>();

            ViewCartCommand = new Command(async () => await ViewCartAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());

            GetCategories();
            GetLatestItems();
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }
        private async Task LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        private async void GetCategories()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item  in data)
            {
                Categories.Add(item);
            }
        }

        private async void GetLatestItems()
        {
            var data = await new FoodItemService().GetLatestFoodItemsAsync();
            LatestItems.Clear();
            foreach (var item in data)
            {
                LatestItems.Add(item);
            }
        }
    }
}
