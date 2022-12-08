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
    public partial class DetailOrderView : ContentPage
    {
        DetailOrderViewModel dovm;
        public DetailOrderView( string orderId)
        {
            InitializeComponent();
            dovm = new DetailOrderViewModel(orderId);
            this.BindingContext = dovm;
        }
    }
}