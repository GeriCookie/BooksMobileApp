namespace BooksApp.Pages
{
    using Imgur.API.Authentication.Impl;
    using Imgur.API.Endpoints.Impl;
    using System;
    using System.Threading.Tasks;
    using Windows.Media.Capture;
    using Windows.Storage;
    using Windows.Storage.Pickers;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using BooksApp.Http;
    using BooksApp.Models;

    public sealed partial class AddBook : Page
    {
        private const string CLIENT_ID = "457c8b9e4aee5a6";
        private const string CLIENT_SECRET = "23a2a454eeffe7cc46f5afa682da21df769711ad";
        
        public AddBook()
        {
            this.InitializeComponent();
        }
        
        private async void UploadPictureOnClick(object sender, RoutedEventArgs e)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.ViewMode = PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

            StorageFile picture = await picker.PickSingleFileAsync();

            this.LoadingAnimation.Visibility = Visibility.Visible;
            this.Submit.IsEnabled = false;

            string link = await this.UploadInCloud(picture);

            this.CoverPath.Text = link;
            this.LoadingAnimation.Visibility = Visibility.Collapsed;
            this.Submit.IsEnabled = true;
        }

        private async void CapturePictureOnClick(object sender, RoutedEventArgs e)
        {
            var camera = new CameraCaptureUI();

            var photo = await camera.CaptureFileAsync(CameraCaptureUIMode.Photo);
            if (photo != null)
            {
                this.LoadingAnimation.Visibility = Visibility.Visible;
                this.Submit.IsEnabled = false;

                string link = await this.UploadInCloud(photo);

                this.CoverPath.Text = link;
                this.LoadingAnimation.Visibility = Visibility.Collapsed;
                this.Submit.IsEnabled = true;
            }
        }

        private async void SubmitOnClick(object sender, RoutedEventArgs e)
        {
            //server does not require a token ??
            //var token = await BooksDbContext.GetUserToken();
            var endpointUrl = App.baseServerUrl + "/books";

            var addBookRequestModel = new AddBookRequestModel
            {
                Title = this.TitleTextBox.Text,
                //Author = this.AuthorTextBox.Text == string.Empty ? null : this.AuthorTextBox.Text,
                //Description = this.DescriptionTextBox.Text == string.Empty ? null : this.DescriptionTextBox.Text,
                //Pages = this.PagesTextBox.Text == string.Empty ? new Nullable<int>() : int.Parse(this.PagesTextBox.Text),
                CoverUrl = this.CoverPath.Text
            };

            object response = await HttpRequester.Post<object>(endpointUrl, addBookRequestModel);
            
            this.Result.Text = response.ToString();
        }

        private async Task<string> UploadInCloud(StorageFile file)
        {
            byte[] fileBytes = null;
            using (IRandomAccessStreamWithContentType stream = await file.OpenReadAsync())
            {
                fileBytes = new byte[stream.Size];
                using (DataReader reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(fileBytes);
                }
            }

            var client = new ImgurClient(CLIENT_ID, CLIENT_SECRET);
            var endpoint = new ImageEndpoint(client);
            var image = await endpoint.UploadImageBinaryAsync(fileBytes);
            return image.Link;
        }
    }
}
