namespace BooksApp.Pages
{
    using Http;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using Models;

    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }
        
        private async void RegisterOnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(this.PasswordTextBox.Password) ||
                string.IsNullOrWhiteSpace(this.PasswordConfirmTextBox.Password))
            {
                this.ResultBlock.Text = "Plese enter username and password";
                return;
            }

            if (this.PasswordConfirmTextBox.Password != this.PasswordTextBox.Password)
            {
                this.ResultBlock.Text = "Passwords are not equal";
                return;
            }
            
            var endpointUrl = App.baseServerUrl + "/users";

            var registerRequestData = new RegisterRequestModel
            {
                Username = this.UsernameTextBox.Text,
                Password = this.PasswordTextBox.Password
            };
            
            RegisterResponseModel response = await HttpRequester.Post<RegisterResponseModel>(endpointUrl, registerRequestData);

            if (response.Error != null)
            {
                this.ResultBlock.Text = response.Error;
            }
            else
            {
                this.ResultBlock.Text = "You are registred";
            }
        }
    }
}