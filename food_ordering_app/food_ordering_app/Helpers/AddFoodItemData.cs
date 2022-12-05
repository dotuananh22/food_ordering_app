using Firebase.Database;
using Firebase.Database.Query;
using food_ordering_app.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace food_ordering_app.Helpers
{
    public class AddFoodItemData
    {
        FirebaseClient client;
        public List<FoodItem> FoodItems { get; set; }

        public AddFoodItemData()
        {
            client = new FirebaseClient("https://foodorderingapp-d61a2-default-rtdb.firebaseio.com/");
           
        }

      
    }
}
