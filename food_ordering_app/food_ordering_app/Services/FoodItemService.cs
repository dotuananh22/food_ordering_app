using Firebase.Database;
using Firebase.Database.Query;
using food_ordering_app.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;

namespace food_ordering_app.Services
{
    public class FoodItemService
    {
        HttpClient client;

        public FoodItemService()
        {
            client = new HttpClient();
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(string categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = await client.GetStringAsync("http://192.168.1.9:3500/foodItems/" + categoryID.ToString());
            var result = JsonConvert.DeserializeObject<List<FoodItem>>(items);
            foreach (var item in result)
            {
                foodItemsByCategory.Add(item);
            }
            return foodItemsByCategory;
        }

        public async Task<ObservableCollection<FoodItem>> GetLatestFoodItemsAsync()
        {
            var latestFoodItems = new ObservableCollection<FoodItem>();
            var items = await client.GetStringAsync("http://192.168.1.9:3500/foodItems/find-last-foodItems");
            var result = JsonConvert.DeserializeObject<List<FoodItem>>(items);

            foreach (var item in result)
            {
                latestFoodItems.Add(item);
            }
            return latestFoodItems;
        }
    }
}
