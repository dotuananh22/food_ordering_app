using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace food_ordering_app.Model
{
    public class Cart
    {
        public string UserName { get; set; }
        public int CartId { get; set; }
        public List<CartItem> CartItems { get; set; }

    }
}
