using food_ordering_app.Model;
using food_ordering_app.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace food_ordering_app.ViewModels
{

    public class DetailOrderViewModel : BaseViewModel
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
        public ObservableCollection<ItemOrderDetail> ItemOrderDetails { get; set; }
        public DetailOrderViewModel(string orderId)
        {
            id = orderId;
            ItemOrderDetails = new ObservableCollection<ItemOrderDetail>();
            GetDetailOrders(id);
        }
        private async void GetDetailOrders(string orderId)
        {
            var data = await new OrderService().GetDetailOrder(orderId);
            ItemOrderDetails.Clear();

            foreach (var item in data)
            {
                ItemOrderDetails.Add(item);
            }
        }



    }
}
