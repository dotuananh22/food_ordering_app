using food_ordering_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace food_ordering_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersView : ContentPage
    {
        OrderViewModel ovm;
        public OrdersView(string id)
        {
            InitializeComponent();
            LabelName.Text = "Xin chào " + Preferences.Get("Username", "Guest") + " ,";
            LabelOrderID.Text = id;
            ovm = new OrderViewModel();
            this.BindingContext = ovm;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}