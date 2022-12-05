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
using food_ordering_app.Helpers;

namespace food_ordering_app.Services
{
    public class CategoryDataService
    {
        HttpClient client;
        ApiConnectHelper host;
        public CategoryDataService()
        {
            client = new HttpClient();
            host = new ApiConnectHelper();
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var res = await client.GetStringAsync(host.ENV_HOST + "categories");
            var categories = JsonConvert.DeserializeObject<List<Category>>(res);
            return categories;
        }
    }
}
