using BooksApp.Data;
using BooksApp.Data.Contracts;
using BooksApp.ViewModels;
using BooksApp.ViewModels.Pages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace BooksApp.Pages
{
  public sealed partial class SearchPage : Page
  {
    public SearchPage()
    {
      this.InitializeComponent();
      ISearchData searchData = new HttpSearchData(App.baseServerUrl + "/search");
      this.ViewModel = new SearchResultPageViewModel(searchData);
    }

    public SearchResultPageViewModel ViewModel
    {
      get
      {
        return this.DataContext as SearchResultPageViewModel;
      }
      private set
      {
        this.DataContext = value;
      }
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      if (e.Parameter != null)
      {
        this.ViewModel.Pattern = e.Parameter.ToString();
      }
      base.OnNavigatedTo(e);
    }
    private void OnBookTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
    {

      var textBlock = e.OriginalSource;
      if (textBlock is TextBlock)
      {
        var btn = textBlock as DependencyObject;
        while (btn != null && !(btn is Button))
        {
          btn = VisualTreeHelper.GetParent(btn);
        }

        var buttonTag = (btn as Button).Tag.ToString();
        if (buttonTag == "viewBook")
        {
          var book = (btn as Button).DataContext as BookViewModel;
          AppShell shell = Windows.UI.Xaml.Window.Current.Content as AppShell;
          shell.AppFrame.Navigate(typeof(BookPageDetails), book.Id);
        }
      }
    }
  }
}
