using food_ordering_app.Model;
using food_ordering_app.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace food_ordering_app.ViewModels
{
    public class ProductDetailViewModel : BaseViewModel
    {
        private FoodItem _SelectedFoodItem;
        public FoodItem SelectedFoodItem
        {
            set
            {
                _SelectedFoodItem = value;
                OnPropertyChanged();
            }
            get
            {
                return _SelectedFoodItem;
            }
        }

        private int _TotalQuantity;
        public int TotalQuantity
        {
            set
            {
                this._TotalQuantity = value;
                if(this._TotalQuantity < 0)
                {
                    this._TotalQuantity = 0;
                }
                if (this._TotalQuantity > 10)
                {
                    this._TotalQuantity -= 1;
                }
                OnPropertyChanged();
            }
            get
            {
                return _TotalQuantity;
            }
        }

        public Command IncrementOrderComand { get; set; }
        public Command DecrementOrderComand { get; set; }
        public Command AddToCartCommand { get; set; }
        public Command HomeCommand { get; set; }
        public ProductDetailViewModel(FoodItem foodItem)
        {
            SelectedFoodItem = foodItem;
            TotalQuantity = 0;
            IncrementOrderComand = new Command(() => IncrementOrder());
            DecrementOrderComand = new Command(() => DecrementOrder());
            AddToCartCommand = new Command(() => AddToCart());
            HomeCommand = new Command(() => GoToHomeAsync());
        }

        private void GoToHomeAsync()
        {
            Application.Current.MainPage = new MainPage();
        }

        private void IncrementOrder()
        {
            TotalQuantity++;
        }
        private void DecrementOrder()
        {
            TotalQuantity--;
        }
        private async void AddToCart()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            try {
                CartItem ci = new CartItem()
                {
                    ProductId = SelectedFoodItem._id,
                    ProductName = SelectedFoodItem.name,
                    Image = SelectedFoodItem.imageUrl,
                    Price = SelectedFoodItem.price,
                    Quantity = TotalQuantity
                };
                var item = cn.Table<CartItem>().ToList()
                    .FirstOrDefault(c => c.ProductId == SelectedFoodItem._id);
                if(item == null)
                {
                    cn.Insert(ci);
                }
                else
                {
                    item.Quantity += TotalQuantity;
                    cn.Update(item);
                }
                cn.Commit();
                cn.Close();
                await Application.Current.MainPage.DisplayAlert("Thông báo", "Thêm vào giỏ hàng thành công", "OK");
                Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Lỗi", ex.Message, "OK");
            }
            finally
            {
                cn.Close();
            }
        }
       
    }
}
