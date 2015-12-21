
namespace BooksApp
{
    using Data;
    using Pages;
    using System;
    using ViewModels;
    using Windows.ApplicationModel;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    sealed partial class App : Application
    {
        public const string baseServerUrl = "http://localhost:3000/api";

        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            BooksDbContext.InitAsync();
        }

        public static string AuthenticationToken { get; private set; }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            //Frame rootFrame = Window.Current.Content as Frame;
            AppShell shell = Window.Current.Content as AppShell;

            //if (rootFrame == null)
            if (shell == null)
            {
                //rootFrame = new Frame();
                shell = new AppShell();
                //rootFrame.NavigationFailed += OnNavigationFailed;
                shell.AppFrame.NavigationFailed += OnNavigationFailed;
                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                }

                Window.Current.Content = shell;
            }

            //Login
            // if user is logged in -> main page
            //else login
            if (shell.AppFrame.Content == null)
            {
                shell.AppFrame.Navigate(typeof(AllBooks), e.Arguments);
            }
            Window.Current.Activate();

            this.GetUserToken();
            //Check if auth key is available
            //AuthKey variable
        }

        public async void GetUserToken()
        {
            AuthenticationToken = await BooksDbContext.GetUserToken();
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }

        
    }
}
