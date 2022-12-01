﻿using Firebase.Database;
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
using System.Diagnostics;
using Xamarin.Forms;

namespace food_ordering_app.Services
{
    public class UserService
    {
        HttpClient  client;
        public UserService()
        {
            client = new HttpClient();
        }
        public async Task<Message> RegisterUser(string uname, string pass, string address, string telephone)
        {
            if (uname.Length <= 0 || pass.Length <= 0 || address.Length <= 0 || telephone.Length <= 0)
            {
                Message newMessage = new Message()
                {
                    errorCode = "100",
                    message = "Vui lòng điền đầy đủ thông tin"
                };
                return newMessage;
            }
            var user = new
            {
                userName = uname,
                password = pass,
                address = address,
                telephone = telephone,
            };
            JsonContent content = JsonContent.Create(user);
            var res = await client.PostAsync("http://192.168.2.91:3500/users", content);       
            var data = await res.Content.ReadAsStringAsync();
            Message result = JsonConvert.DeserializeObject<Message>(data);
            return result;          
        }
        public async Task<User> LoginUser(string uname, string pass)
        {
            var user = new
            {
                userName = uname,
                password = pass,
            };
            JsonContent content = JsonContent.Create(user);
            var res = await client.PostAsync("http://192.168.2.91:3500/users/login", content);
            var result = await res.Content.ReadAsStringAsync();
            Debug.WriteLine("check user", result);
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<User>(result);
            }
            else { return null; }
           
        }
    }
}
