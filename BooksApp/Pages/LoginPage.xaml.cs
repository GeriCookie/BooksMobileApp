namespace BooksApp.Pages
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using BooksApp.Data;
    using BooksApp.Http;
    using BooksApp.Models;

    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
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
            }
            else
            {
                var userToken = new TokenModel
                {
                    authKey = response.AuthKey
                };

                await BooksDbContext.AddUserToken(userToken);

                this.ResultBlock.Text = "You are Logged In";
            }
        }
    }
}