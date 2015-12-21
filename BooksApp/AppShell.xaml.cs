using BooksApp.Data;
using BooksApp.Pages;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace BooksApp
{
    public sealed partial class AppShell : Page
    {
        public AppShell()
        {
            this.InitializeComponent();
        }

        public Frame AppFrame
        {
            get
            {
                return this.tehFrame;
            }
        }

        private void OnHomeAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(MainPage));
        }

        private void OnMyBooksAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(MyBooks));
        }

        private void OnAllBookAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(AllBooks));
        }

        private async void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var patterns = await BooksDbContext.GetAllPatternsAsync();
            var dropDownList = new List<string>();
            foreach (string pattern in patterns)
            {
                if (pattern.Contains(sender.Text))
                {
                    dropDownList.Add(pattern);
                }
            }

            sender.ItemsSource = dropDownList;
        }
        
        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            sender.Text = args.SelectedItem.ToString();
        }
        
        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            string pattern = string.Empty;
            if (args.ChosenSuggestion != null)
            {
                pattern = args.ChosenSuggestion.ToString();
            }
            else
            {
                pattern = args.QueryText;
            }
            
            await BooksDbContext.AddPattern(pattern);

            this.SearchDecreaseWidth.Begin();
            this.AppFrame.Navigate(typeof(SearchPage), pattern);
        }

        private async void OnLoginAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var userToken = await BooksDbContext.GetUserToken();
            bool isLoggedIn = userToken != null;
            this.AppFrame.Navigate(typeof(LoginPage), isLoggedIn);
        }

        private void OnRegisterAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(RegisterPage));
        }

        private async void OnLogoutAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var userToken = await BooksDbContext.GetUserToken();
            bool isLoggedIn = userToken != null;
            this.AppFrame.Navigate(typeof(LogoutPage), isLoggedIn);
        }

        private void AutoSuggestBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.SearchIncreaseWidth.Begin();
        }
    }
}
