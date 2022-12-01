using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace food_ordering_app.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                _Username = value;
                OnPropertyChanged();
            }
            get
            {
                return _Username;
            }
        }

        private string _id;
        public string id
        {
            set
            {
                _id = value;
                OnPropertyChanged();
            }
            get
            {
                return _id;
            }
        }

        private string _Address;
        public string Address
        {
            set
            {
                _Address = value;
                OnPropertyChanged();
            }
            get
            {
                return _Address;
            }
        }

        private string _Telephone;
        public string Telephone
        {
            set
            {
                _Telephone = value;
                OnPropertyChanged();
            }
            get
            {
                return _Telephone;
            }
        }


        public UserViewModel()
        {

            //username
            var uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
                Username = "Guest";
            else
                Username = uname;
            //address
            var address = Preferences.Get("Address", String.Empty);
            if (String.IsNullOrEmpty(address))
                Address = "Địa chỉ";
            else
                Address = address;
            //userId
            var userId = Preferences.Get("UserId", String.Empty);
            if (String.IsNullOrEmpty(address))
                id = "id";
            else
                id = userId;
            //telephone
            var telephone = Preferences.Get("Telephone", String.Empty);
            if (String.IsNullOrEmpty(address))
                Telephone = "Soo Dien Thoai";
            else
                Telephone = telephone;
        }
    }
}
