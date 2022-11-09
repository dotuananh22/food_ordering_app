using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using food_ordering_app.Helpers;
using food_ordering_app.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace food_ordering_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void ButtonCategories_Clicked(object sender, EventArgs e)
        {
            var acd = new AddCategoryData();
            await acd.AddCategoriesAsync();
        }

        private async void ButtonProducts_Clicked(object sender, EventArgs e)
        {
            var afd = new AddFoodItemData();
            await afd.AddFoodItemAsync();
        }

        private void CartProducts_Clicked(object sender, EventArgs e)
        {
            var cct = new CreateCartTable();
            if (cct.CreateTable())
            {
                DisplayAlert("success", "OK", "OK");
            }
            else
            {
                DisplayAlert("error", "error", "OK");

            }
        }
    }
}