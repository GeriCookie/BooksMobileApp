namespace BooksApp.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    using BooksApp.Data;
    using BooksApp.Http;
    using BooksApp.Models;
    using ViewModels.Pages;

    public sealed partial class LogoutPage : Page
    {
        public LogoutPage()
        {
            this.InitializeComponent();
        }

        public LogoutPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as LogoutPageViewModel;
            }
            private set
            {
                this.DataContext = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.ViewModel = new LogoutPageViewModel((bool)e.Parameter);
        }

        private async void LogoutOnClick(object sender, RoutedEventArgs e)
        {
            var connection = BooksDbContext.GetDbConnectionAsync();
            await BooksDbContext.DelateUserToken(connection);
            AppShell shell = Windows.UI.Xaml.Window.Current.Content as AppShell;
            shell.AppFrame.Navigate(typeof(AllBooks));
        }
    }
}
