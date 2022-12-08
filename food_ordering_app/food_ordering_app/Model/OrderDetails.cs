using System;
using System.Collections.Generic;
using System.Text;

namespace food_ordering_app.Model
{
    public class OrderDetails
    {
        public string _id { get; set; }
        public string orderId { get; set; }
        public string productId { get; set; }
        public int quantity { get; set; }
    }
}
