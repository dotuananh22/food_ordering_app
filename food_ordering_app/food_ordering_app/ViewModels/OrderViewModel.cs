using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace food_ordering_app.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public Command HomeCommand { get; set; }

        public OrderViewModel()
        {
            HomeCommand = new Command(() => GoToHomeAsync());
        }

        private void GoToHomeAsync()
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}
