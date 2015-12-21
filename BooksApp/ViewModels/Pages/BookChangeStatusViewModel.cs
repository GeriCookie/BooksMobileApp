using BooksApp.Data.Contracts;

namespace BooksApp.ViewModels.Pages
{
    public class BookChangeStatusViewModel : ViewModelBase
    {
        private IChangeStatusData changeStatusData;
        private string bookdID;
        private DetailBookViewModel book;

        public BookChangeStatusViewModel(IChangeStatusData changeStatusData)
        {
            this.changeStatusData = changeStatusData;
        }

        public string BookID
        {
            get
            {
                return this.bookdID;
            }
            set
            {
                if (this.bookdID == value)
                {
                    return;
                }
                this.bookdID = value;
                this.RaisePropertyChanged("BookID");
                this.Refresh();

            }
        }

        public DetailBookViewModel Book
        {
            get
            {
                return this.book;
            }
            set
            {
                this.book = value;
                this.RaisePropertyChanged("Book");
            }
        }

        private async void Refresh()
        {
            var book = (await this.changeStatusData.GetBook(this.BookID));
            this.Book = DetailBookViewModel.FromModel(book);
        }

        internal async void ChangeStatus(string status, string bookId)
        {
            await this.changeStatusData.ChangeStatus(status, bookId);        
        }
    }
}
