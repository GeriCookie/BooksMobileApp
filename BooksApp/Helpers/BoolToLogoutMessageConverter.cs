namespace BooksApp.Helpers
{
    using System;
    using Windows.UI.Xaml.Data;

    public class BoolToLogoutMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boolValue = (bool)value;
            return boolValue ? "Logout" : "You are not Logged In";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
