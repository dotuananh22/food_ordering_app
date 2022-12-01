using food_ordering_app.Model;
using food_ordering_app.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace food_ordering_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var cct = new CreateCartTable();
            cct.CreateTable();
            string uname = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(uname))
            {
                MainPage = new NavigationPage(new LoginView());
            }
            else
            {
                MainPage = new MainPage();
            }
        }

        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
