using BooksApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.ViewModels.Pages
{
    public class BookPageDetailViewModel: ViewModelBase
    {
        private DetailBookViewModel book;
        private string bookID;
        private IDetailBookData detailBookData;

        public BookPageDetailViewModel(IDetailBookData detailBookData)
        {
            this.detailBookData = detailBookData;
            this.book = new DetailBookViewModel();
            //this.Refresh();
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
                RaisePropertyChanged("Book");
            }
        }

        public string BookID
        {
            get
            {
                return this.bookID;
            }
            set
            {
                if (this.bookID == value)
                {
                    return;
                }
                this.bookID = value;
                this.RaisePropertyChanged("BookId");
                this.Refresh();
            }
        }

        private async void Refresh()
        {
            var book = (await this.detailBookData.GetBook(this.BookID));
            this.Book = DetailBookViewModel.FromModel(book);
        }
    }
}
