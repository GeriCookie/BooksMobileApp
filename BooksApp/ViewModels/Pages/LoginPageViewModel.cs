namespace BooksApp.ViewModels.Pages
{
    public class LoginPageViewModel : ViewModelBase
    {
        private bool isUserLoggedIn;

        public LoginPageViewModel(bool isUserLoggedIn)
        {
            this.IsUserLoggedIn = isUserLoggedIn;
        }

        public bool IsUserLoggedIn
        {
            get
            {
                return this.isUserLoggedIn;
            }
            set
            {
                if (this.isUserLoggedIn == value)
                {
                    return;
                }

                this.isUserLoggedIn = value;
                this.RaisePropertyChanged("IsUserLoggedIn");
            }
        }
    }
}