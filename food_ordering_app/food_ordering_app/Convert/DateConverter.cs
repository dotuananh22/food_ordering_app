using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace food_ordering_app.Convert
{
    class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var datetime = (DateTime)value;
            return datetime.ToString("dddd, dd MMMM yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
