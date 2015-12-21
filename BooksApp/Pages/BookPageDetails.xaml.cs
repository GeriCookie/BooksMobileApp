namespace BooksApp.Pages
{
  using Data;
  using Data.Contracts;
  using ViewModels.Pages;
  using Windows.UI.Xaml.Controls;
  using Windows.UI.Xaml.Navigation;

  public sealed partial class BookPageDetails : Page
  {
    public BookPageDetails()
    {
      this.InitializeComponent();
      IDetailBookData detailBookData = new HttpDetailBookData(App.baseServerUrl);
      this.ViewModel = new BookPageDetailViewModel(detailBookData);
    }

    public BookPageDetailViewModel ViewModel
    {
      get
      {
        return this.DataContext as BookPageDetailViewModel;
      }
      set
      {
        this.DataContext = value;
      }
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      if (e.Parameter != null)
      {
        this.ViewModel.BookID = e.Parameter.ToString();
      }
      base.OnNavigatedTo(e);
    }

    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      var item = e.AddedItems[0];
      //TODO navigate to page with genres
    }

    private void OnBackAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
      if (this.Frame.CanGoBack)
      {
        this.Frame.GoBack();
      }
    }
  }
}
