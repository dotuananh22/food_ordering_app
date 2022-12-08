using System;
using System.Collections.Generic;
using System.Text;

namespace food_ordering_app.Model
{
    public class Order
    {
        public string _id { get; set; }
        public string userId { get; set; }
        public decimal total { get; set; }
        public bool status { get; set; }
    }
}
