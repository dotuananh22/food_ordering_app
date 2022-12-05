using Firebase.Database;
using Firebase.Database.Query;
using food_ordering_app.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace food_ordering_app.Services
{
    public class CategoryDataService
    {
        HttpClient client;
        public CategoryDataService()
        {
            client = new HttpClient();
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var res = await client.GetStringAsync("http://192.168.1.9:3500/categories");
            var categories = JsonConvert.DeserializeObject<List<Category>>(res);
            return categories;
        }
    }
}
