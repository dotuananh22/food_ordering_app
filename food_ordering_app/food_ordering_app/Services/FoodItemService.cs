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
using food_ordering_app.Helpers;

namespace food_ordering_app.Services
{
    public class FoodItemService
    {
        HttpClient client;
        ApiConnectHelper host;
        public FoodItemService()
        {
            client = new HttpClient();
            host = new ApiConnectHelper();
        }

        public async Task<ObservableCollection<FoodItem>> GetFoodItemsByCategoryAsync(string categoryID)
        {
            var foodItemsByCategory = new ObservableCollection<FoodItem>();
            var items = await client.GetStringAsync(host.ENV_HOST + "foodItems/" + categoryID.ToString());
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
            var items = await client.GetStringAsync(host.ENV_HOST + "foodItems/find-last-foodItems");
            var result = JsonConvert.DeserializeObject<List<FoodItem>>(items);

            foreach (var item in result)
            {
                latestFoodItems.Add(item);
            }
            return latestFoodItems;
        }
    }
}
