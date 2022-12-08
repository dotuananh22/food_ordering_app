using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using food_ordering_app.Model;
using Xamarin.Forms;
using System.Threading.Tasks;
using food_ordering_app.Views;
using food_ordering_app.Services;

namespace food_ordering_app.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
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
        public CartViewModel()
        {
            CartItems = new ObservableCollection<UserCartItem>();
            LoadItem();
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
            foreach(var item in items)
            {
                CartItems.Add(new UserCartItem()
                {
                    CartItemId=item.CartItemId,
                    ProductId=item.ProductId,
                    ProductName=item.ProductName,
                    Image = item.Image,
                    Price = item.Price,
                    Quantity= item.Quantity,
                    Cost = item.Price*item.Quantity,
                });
                TotalCost = TotalCost + (item.Price * item.Quantity);
            }
        }

    }
}
