using BooksApp.Data.Contracts;
using BooksApp.ViewModels;
using BooksApp.ViewModels.Pages;
using Windows.UI.Xaml.Controls;


namespace BooksApp.Pages
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            IUpdatesData updatesData = new HttpUpdatesData(App.baseServerUrl + "/updates");
            this.ViewModel = new MainPageViewModel(updatesData);
            
        }

        public MainPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as MainPageViewModel;
            }
            private set
            {
                this.DataContext = value;
            }
        }
    }
}
