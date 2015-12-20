namespace BooksApp.Helpers
{
  using System;
  using Windows.UI.Xaml.Data;

  public class NoRatingConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      if (targetType != typeof(string))
      {
        return null;
      }
      var rating = (int?)value;

      if (!rating.HasValue)
      {
        return "No rating";
      }

      return rating.Value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      throw new NotImplementedException();
    }
  }
}
