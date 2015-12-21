using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace BooksApp.Helpers
{
  public class NoImageConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      if (targetType != typeof(ImageSource))
      {
        return null;
      }

      if (value == null || string.IsNullOrEmpty(value.ToString().Trim()))
      {
        return new BitmapImage(new Uri("http://www.enviroscent.com/c.1222543/shopflow-1-04-0/img/no_image_available.jpeg"));
      }
      return new BitmapImage(new Uri(value.ToString()));
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      throw new NotImplementedException();
    }
  }
}
