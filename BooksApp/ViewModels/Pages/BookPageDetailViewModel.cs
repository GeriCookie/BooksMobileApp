using BooksApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.ViewModels.Pages
{
    public class BookPageDetailViewModel : ViewModelBase
    {
        private DetailBookViewModel book;
        private IDetailBookData detailBookData;
        private string bookdID;

        public BookPageDetailViewModel(IDetailBookData detailBookData)
        {
            this.detailBookData = detailBookData;
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
            var book = (await this.detailBookData.GetBook(this.BookID));
            this.Book = DetailBookViewModel.FromModel(book);
        }
    }
}
