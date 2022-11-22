using System;
using System.Collections.Generic;
using System.Text;

namespace food_ordering_app.ViewModels
{
    public class HeaderContentViewModel : BaseViewModel
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
    }
}
