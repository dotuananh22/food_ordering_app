using food_ordering_app.Model;
using food_ordering_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace food_ordering_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserOrderView : ContentPage
    {
        UserOrderViewModel uovm;
        public UserOrderView()
        {
            InitializeComponent();
            uovm = new UserOrderViewModel();
            this.BindingContext = uovm;

        }
        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private async void ListViewCartItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedOrder = e.CurrentSelection.FirstOrDefault() as UserOrder;
            await Navigation.PushAsync(new DetailOrderView(selectedOrder._id));
        }
    }
}