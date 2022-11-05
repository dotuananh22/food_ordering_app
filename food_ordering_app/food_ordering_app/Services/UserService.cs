using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using food_ordering_app.Model;
using Firebase.Database.Query;

namespace food_ordering_app.Services
{
    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient("https://foodorderingapp-d61a2-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> IsUserExists(string uname)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string uname, string pass)
        {
            if (await IsUserExists(uname) == false)
            {
                await client.Child("Users")
                    .PostAsync(new User()
                    {
                        Username = uname,
                        Password = pass
                    });
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(string uname, string pass)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == uname)
                .Where(u => u.Object.Password == pass).FirstOrDefault();

            return (user != null);
        }
    }
}
