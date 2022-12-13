using food_ordering_app.Model;
using food_ordering_app.Services;
using food_ordering_app.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace food_ordering_app.ViewModels
{
    public class CheckoutViewModel : BaseViewModel
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

        private string _id;
        public string id
        {
            set
            {
                _id = value;
                OnPropertyChanged();
            }
            get
            {
                return _id;
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

        private string _Telephone;
        public string Telephone
        {
            set
            {
                _Telephone = value;
                OnPropertyChanged();
            }
            get
            {
                return _Telephone;
            }
        }

        public ObservableCollection<UserCartItem> CartItems { get; set; }
        public decimal _TotalCost;
        public decimal TotalCost
        {
            set
            {
                _TotalCost = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalCost;
            }
        }

        public decimal _TotalItems;
        public decimal TotalItems
        {
            set
            {
                _TotalItems = value;
                OnPropertyChanged();
            }
            get
            {
                return _TotalItems;
            }
        }

        public Command PlcaeOrderCommand { get; set; }

        private async Task PlcaeOrderAsync()
        {
            //code to place order
            Message result = await new OrderService().PlaceOrderAsync(Address, Telephone) as Message;
            if (result.errorCode == "0")
            {
                RemoveItemsFromCart();
                await Application.Current.MainPage.Navigation.PushModalAsync(new OrdersView(result.message));
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Đặt hàng", result.message, "Ok");
            }
        }

        private void RemoveItemsFromCart()
        {
            var cis = new CartItemService();
            cis.RemoveItemsFromCart();
        }

        private void LoadItem()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var items = cn.Table<CartItem>().ToList();
            CartItems.Clear();
            foreach (var item in items)
            {
                CartItems.Add(new UserCartItem()
                {
                    CartItemId = item.CartItemId,
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    Image = item.Image,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Cost = item.Price * item.Quantity,
                });
                TotalCost = TotalCost + (item.Price * item.Quantity);
            }
        }

        public CheckoutViewModel()
        {
            //username
            var uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
                Username = "Guest";
            else
                Username = uname;
            //address
            var address = Preferences.Get("Address", String.Empty);
            if (String.IsNullOrEmpty(address))
                Address = "Địa chỉ";
            else
                Address = address;
            //userId
            var userId = Preferences.Get("UserId", String.Empty);
            if (String.IsNullOrEmpty(address))
                id = "id";
            else
                id = userId;
            //telephone
            var telephone = Preferences.Get("Telephone", String.Empty);
            if (String.IsNullOrEmpty(address))
                Telephone = "So Dien Thoai";
            else
                Telephone = telephone;

            CartItems = new ObservableCollection<UserCartItem>();
            LoadItem();
            PlcaeOrderCommand = new Command(async () => await PlcaeOrderAsync());
        }
    }
}
