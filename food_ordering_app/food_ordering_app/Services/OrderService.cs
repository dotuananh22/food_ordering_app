﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using food_ordering_app.Helpers;
using food_ordering_app.Model;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace food_ordering_app.Services
{
    public class OrderService
    {
        HttpClient client;
        ApiConnectHelper host;
        public OrderService()
        {
            client = new HttpClient();
            host = new ApiConnectHelper();
        }
        
        public async Task<Message> PlaceOrderAsync(string address, string telephone)
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var data = cn.Table<CartItem>().ToList();
            var user = Preferences.Get("UserId", "Guest");
            decimal totalCost = 0;
            foreach (var item in data)
            {
                totalCost += item.Price * item.Quantity;
            }
            List<OrderDetails> listOrderDetail = new List<OrderDetails>();
          
            var order = new
            {
                userId = user,
                total = totalCost,
                address = address,
                telephone = telephone,
            };
            JsonContent dataSent = JsonContent.Create(order);
            var resOrder = await client.PostAsync(host.ENV_HOST + "orders", dataSent);
            var resOrderContent = await resOrder.Content.ReadAsStringAsync();
            Message resultOrder = JsonConvert.DeserializeObject<Message>(resOrderContent);

            if(resultOrder.errorCode == "0")
            {
                foreach (var item in data)
                {
                    OrderDetails od = new OrderDetails()
                    {
                        orderId = resultOrder.message,
                        productId = item.ProductId,
                        quantity = item.Quantity,
                    };
                    listOrderDetail.Add(od);
                }
                var dataOrderDetailsSent = new
                {
                    arrOrderDetail = listOrderDetail
                };
                JsonContent dataOrderDetailsSentJson = JsonContent.Create(dataOrderDetailsSent);
                await client.PostAsync(host.ENV_HOST + "order-detail", dataOrderDetailsSentJson);
            }
            return resultOrder;
        }
        public async Task<ObservableCollection<UserOrder>> GetOrderByUserId(string userId)
        {
            var data = new ObservableCollection<UserOrder>();
            var resUserOrderData = await client.GetStringAsync(host.ENV_HOST + "orders/"+ userId.ToString());
            var resultUserOrder = JsonConvert.DeserializeObject<ObservableCollection<UserOrder>>(resUserOrderData);
            return resultUserOrder;
        }

        public async Task<ObservableCollection<ItemOrderDetail>> GetDetailOrder(string orderId)
        {
            var data = new ObservableCollection<ItemOrderDetail>();
            var resItemsOrderDetail = await client.GetStringAsync(host.ENV_HOST + "order-detail/" + orderId.ToString());
            var resultItemsOrderDetail = JsonConvert.DeserializeObject<ObservableCollection<ItemOrderDetail>>(resItemsOrderDetail);
            return resultItemsOrderDetail;
        }
    }
}
