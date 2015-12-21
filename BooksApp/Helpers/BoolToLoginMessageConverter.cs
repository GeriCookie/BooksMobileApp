namespace BooksApp.Helpers
{
    using System;
    using Windows.UI.Xaml.Data;

    public class BoolToLoginMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boolValue = (bool)value;
            return boolValue ? "You are Logged In" : "Login";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
