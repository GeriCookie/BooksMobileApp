namespace BooksApp.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    using BooksApp.Data;
    using BooksApp.Http;
    using BooksApp.Models;
    using ViewModels.Pages;

    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        public LoginPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as LoginPageViewModel;
            }
            private set
            {
                this.DataContext = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.ViewModel = new LoginPageViewModel((bool)e.Parameter);
        }

        private async void LoginOnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(this.PasswordTextBox.Password))
            {
                this.ResultBlock.Text = "Enter username and password please";
                return;
            }

            var endpointUrl = App.baseServerUrl + "/users/auth";

            var loginRequestModel = new LoginRequestModel
            {
                Username = this.UsernameTextBox.Text,
                Password = this.PasswordTextBox.Password
            };

            LoginResponseModel response = await HttpRequester.Put<LoginResponseModel>(endpointUrl, loginRequestModel);

            if (response.Message != null)
            {
                this.ResultBlock.Text = response.Message;
                this.ViewModel.IsUserLoggedIn = false;
            }
            else
            {
                await BooksDbContext.AddUserToken(response.AuthKey);
                this.ViewModel.IsUserLoggedIn = true;
                AppShell shell = Windows.UI.Xaml.Window.Current.Content as AppShell;
                shell.AppFrame.Navigate(typeof(AllBooks));
            }
        }
    }
}