namespace BooksApp.Helpers
{
  using System;
  using Windows.UI.Xaml.Data;

  public class NoDescriptionConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      if (targetType != typeof(string))
      {
        return null;
      }

      if (value == null || string.IsNullOrEmpty(value.ToString().Trim()))
      {
        return "No description";
      }

      var description = value.ToString();

      return description.Substring(0, Math.Min(400, description.Length));
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      throw new NotImplementedException();
    }
  }
}
