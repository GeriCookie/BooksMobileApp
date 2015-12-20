using BooksApp.Pages;
using Windows.UI.Xaml.Controls;

namespace BooksApp
{
    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            this.InitializeComponent();
        }

        public Frame AppFrame
        {
            get
            {
                return this.tehFrame;
            }
        }

        private void OnHomeAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(MainPage));
        }

        private void OnMyBooksAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(MyBooks));
        }

        private void OnAllBookAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(AllBooks));
        }

        private void OnSearchAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var pattern = this.tbSearch.Text;
            this.AppFrame.Navigate(typeof(SearchPage), pattern);
        }
        
        private void OnLoginAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(LoginPage));
        }
        private void OnRegisterAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(RegisterPage));
        }

        private void OnAddBookAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(AddBook));
        }
    }
}
