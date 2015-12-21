using BooksApp.Data;
using BooksApp.Data.Contracts;
using BooksApp.ViewModels.Pages;
using Windows.UI.Xaml.Controls;

namespace BooksApp.Pages
{
    public sealed partial class BooksWantToRead : Page
    {
        public BooksWantToRead()
        {
            this.InitializeComponent();
            IMyBooksData myBooksData = new HttpMyBooksData(App.baseServerUrl + "/mybooks/to-read");
            this.ViewModel = new MyBooksPageViewModel(myBooksData);
        }

        public MyBooksPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as MyBooksPageViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
