using food_ordering_app.Model;
using food_ordering_app.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace food_ordering_app.ViewModels
{
    public class UserOrderViewModel : BaseViewModel
    {
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
        public ObservableCollection<UserOrder> userOrders { get; set; }
        public UserOrderViewModel()
        {
            var userId = Preferences.Get("UserId", String.Empty);
            if (String.IsNullOrEmpty(userId))
                id = "id";
            else
                id = userId;
            userOrders = new ObservableCollection<UserOrder>();
            GetUserOrders(id);
        }
        private async void GetUserOrders( string userId)
        {
            var data = await new OrderService().GetOrderByUserId(userId);
            userOrders.Clear();

            foreach (var item in data)
            {
                userOrders.Add(item);
            }
        }
    }

}
