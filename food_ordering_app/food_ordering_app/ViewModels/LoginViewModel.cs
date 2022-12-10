using food_ordering_app.Model;
using food_ordering_app.Services;
using food_ordering_app.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace food_ordering_app.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }
        }

        private string _Password;
        public string Password
        {
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Password;
            }
        }

        private User _Result;
        public User Result
        {
            set
            {
                this._Result = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Result;
            }
        }

        public Command LoginCommand { get; set; }
        public Command TapCommand { get; set; }



        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            TapCommand = new Command(async () => await TapCommandAsync());
        }

        private async Task TapCommandAsync()
        {
            _ = Application.Current.MainPage.Navigation.PushAsync(new RegisterPage());
        }

        private async Task LoginCommandAsync()
        {
            try
            {
                var userService = new UserService();
                User Result = new User();
                Result = await userService.LoginUser(Username, Password);
                if(Result == null)
                {
                    await Application.Current.MainPage.DisplayAlert("Thông báo", "Tên đăng nhập hoặc mật khẩu không chính xác", "OK");
                    return;
                }
                Preferences.Set("Username", Result.userName);
                Preferences.Set("Address", Result.address);
                Preferences.Set("Telephone", Result.telephone);
                Preferences.Set("UserId", Result._id);
                Application.Current.MainPage = new MainPage();              
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }          
        }
    }
}
