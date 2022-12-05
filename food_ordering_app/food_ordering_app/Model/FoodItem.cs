using System;
using System.Collections.Generic;
using System.Text;

namespace food_ordering_app.Model
{
    public class FoodItem
    {
        public int _id { get; set; }
        public string imageUrl { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string rating { get; set; }
        public decimal price { get; set; }
        public int categoryID { get; set; }
    }
}
