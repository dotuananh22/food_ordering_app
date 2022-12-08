using System;
using System.Collections.Generic;
using System.Text;

namespace food_ordering_app.Model
{
    public class ItemOrderDetail
    {
        public string _id { get; set; }
        public string productId { get; set; }
        public string quantity { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string price { get; set; }
        public string categoryName { get; set; }
    }
}
