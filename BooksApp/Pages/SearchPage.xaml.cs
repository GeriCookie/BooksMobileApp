using BooksApp.Data;
using BooksApp.Data.Contracts;
using BooksApp.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BooksApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchPage : Page
    {
        public SearchPage()
        {
            this.InitializeComponent();
            ISearchData searchData = new HttpSearchData(App.baseServerUrl + "/search");
            this.ViewModel = new SearchResultPageViewModel(searchData);
        }

        public SearchResultPageViewModel ViewModel
        {
            get
            {
                return this.DataContext as SearchResultPageViewModel;
            }
            private set
            {
                this.DataContext = value;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                this.ViewModel.Pattern = e.Parameter.ToString();
            }
            base.OnNavigatedTo(e);
        }
    }
}
