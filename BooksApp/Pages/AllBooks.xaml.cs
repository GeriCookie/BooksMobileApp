namespace BooksApp.Pages
{
    using Data;
    using Data.Contracts;
    using ViewModels;
    using Windows.UI.Xaml.Controls;

    public sealed partial class AllBooks : Page
    {
        public AllBooks()
        {
            this.InitializeComponent();
            IBooksData booksData = new HttpBooksData(App.baseServerUrl + "/books");
            this.ViewModel = new BooksPageViewModel(booksData);
        }

        public BooksPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as BooksPageViewModel;
            }
            private set
            {
                this.DataContext = value;
            }
        }
    }
}
