namespace BooksApp.Helpers
{
    using System;
    using Windows.UI.Xaml.Data;

    public class BoolToIsEnabledLogOutConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType != typeof(bool))
            {
                return null;
            }

            var boolValue = (bool)value;
            return boolValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
