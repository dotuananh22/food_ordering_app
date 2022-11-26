using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using food_ordering_app.Model;
using Firebase.Database.Query;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace food_ordering_app.Services
{
    public class UserService
    {
        HttpClient  client;

        public UserService()
        {
            client = new HttpClient();
        }

        public async Task<bool> RegisterUser(string uname, string pass)
        {
            var user = new
            {
                userName = uname,
                password = pass,
            };
            JsonContent content = JsonContent.Create(user);
            var res = await client.PostAsync("http://192.168.1.5:3500/users", content);
            if(!res.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> LoginUser(string uname, string pass)
        {
            var user = new
            {
                userName = uname,
                password = pass,
            };
            JsonContent content = JsonContent.Create(user);
            var res = await client.PostAsync("http://192.168.1.5:3500/users/login", content);
            if (!res.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
    }
}
