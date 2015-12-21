using BooksApp.Data;
using BooksApp.Data.Contracts;
using BooksApp.ViewModels.Pages;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

using System.Linq;
using BooksApp.ViewModels;

namespace BooksApp.Pages
{
    public sealed partial class BookChangeStatus : Page
    {
        public BookChangeStatus()
        {
            this.InitializeComponent();
            IChangeStatusData changeStatusData = new HttpChangeStatusData(App.baseServerUrl);
            this.ViewModel = new BookChangeStatusViewModel(changeStatusData);
        }

        public BookChangeStatusViewModel ViewModel
        {
            get
            {
                return this.DataContext as BookChangeStatusViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                this.ViewModel.BookID = e.Parameter.ToString();
            }
            base.OnNavigatedTo(e);
        }

        private void OnAddToShelfClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

            var radioButton = this.panelRadioButtons.Children
                                                    .Select(child => (RadioButton)child)
                                                    .FirstOrDefault(rb => rb.IsChecked.Value);
            var status = radioButton.Content.ToString();
            var book = radioButton.DataContext as DetailBookViewModel;

            this.ViewModel.ChangeStatus(status, book.Id);
        }
    }
}
