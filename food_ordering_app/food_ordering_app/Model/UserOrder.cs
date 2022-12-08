using System;
using System.Collections.Generic;
using System.Text;

namespace food_ordering_app.Model
{
    public class UserOrder
    {
        public string _id { get; set; }
        public string userName { get; set; }
        public string total { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
        public string status { get; set; }
        public string createdAt { get; set; }
    }
}
