using food_ordering_app.Model;
using food_ordering_app.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace food_ordering_app.ViewModels
{
    public class RegisterViewModel : BaseViewModel
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

        private string _Address;
        public string Address
        {
            set
            {
                this._Address = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Address;
            }
        }

        private string _Telephone;
        public string Telephone
        {
            set
            {
                this._Telephone = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Telephone;
            }
        }

        public Command RegisterCommand { get; set; }
        public Command TapCommand { get; set; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
            TapCommand = new Command(async () => await TapCommandAsync());
        }

        private async Task TapCommandAsync()
        {
            _ = Application.Current.MainPage.Navigation.PopAsync();
        }

        private async Task RegisterCommandAsync()
        {         
            try
            {
                var userService = new UserService();
                Message Result = new Message();
                Result = await userService.RegisterUser(Username, Password, Address, Telephone);
                if (Result.errorCode == "0")
                {
                    await Application.Current.MainPage.DisplayAlert("Thành công",
                      Result.message, "OK");
                    return;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Lỗi", Result.message, "OK");
                }
                                                    
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }          
        }
    }
}
