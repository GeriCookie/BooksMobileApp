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
    public sealed partial class MyBooks : Page
    {
        public MyBooks()
        {
            this.InitializeComponent();
        }

        private void OnWantToReadButtonClick(object sender, RoutedEventArgs e)
        {
            AppShell shell = Windows.UI.Xaml.Window.Current.Content as AppShell;
            shell.AppFrame.Navigate(typeof(BooksWantToRead));
        }

        private void OnCurrentlyReadingButtonClick(object sender, RoutedEventArgs e)
        {
            AppShell shell = Windows.UI.Xaml.Window.Current.Content as AppShell;
            shell.AppFrame.Navigate(typeof(BooksCurrentlyReading));
        }

        private void OnReadButtonClick(object sender, RoutedEventArgs e)
        {
            AppShell shell = Windows.UI.Xaml.Window.Current.Content as AppShell;
            shell.AppFrame.Navigate(typeof(BooksRead));
        }
    }
}
