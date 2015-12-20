﻿using BooksApp.Pages;
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

        private void OnAddBookAppBarButtonClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.AppFrame.Navigate(typeof(AllBooks));
        }
    }
}