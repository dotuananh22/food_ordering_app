using System;
using System.Collections.Generic;
using System.Text;

namespace food_ordering_app.Model
{
    public class Order
    {
        public string OrderId { get; set; }
        public string Username { get; set; }
        public decimal TotalCost { get; set; }
    }
}
