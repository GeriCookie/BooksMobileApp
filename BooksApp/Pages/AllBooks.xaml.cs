namespace BooksApp.Pages
{
    using Data;
    using Data.Contracts;
    using ViewModels;
    using ViewModels.Pages;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media;
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

        private void OnBookTapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {

            var textBlock = e.OriginalSource;
            if (textBlock is TextBlock)
            {
                var btn = textBlock as DependencyObject;
                while (btn != null && !(btn is Button))
                {
                    btn = VisualTreeHelper.GetParent(btn);
                }

                var buttonTag = (btn as Button).Tag.ToString();
                if (buttonTag == "viewBook")
                {
                    var book = (btn as Button).DataContext as BookViewModel;
                    AppShell shell = Windows.UI.Xaml.Window.Current.Content as AppShell;
                    shell.AppFrame.Navigate(typeof(BookPageDetails), book.Id);
                }
            }
        }
    }
}
