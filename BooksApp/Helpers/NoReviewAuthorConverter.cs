using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace BooksApp.Helpers
{
  public class NoReviewAuthorConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      if (targetType != typeof(string))
      {
        return null;
      }

      if (value == null || string.IsNullOrEmpty(value.ToString().Trim()))
      {
        return "Unknown author";
      }
      return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      throw new NotImplementedException();
    }
  }
}
