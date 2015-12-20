using BooksApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.ViewModels
{
    public class BooksPageViewModel: ViewModelBase
    {
        private ObservableCollection<BookViewModel> books;
        private IBooksData booksData;
        private bool areBooksLoading;

        public BooksPageViewModel(IBooksData booksData)
        {
            this.booksData = booksData;
            this.books = new ObservableCollection<BookViewModel>();
            this.Refresh();
        }

        private async void Refresh()
        {
            this.AreBooksLoading = true;
            var models = (await this.booksData.All());
            this.Books = models
                .Select(model => BookViewModel.FromModel(model));
            this.AreBooksLoading = false;

        }

        public IEnumerable<BookViewModel> Books
        {
            get
            {
                return this.books;
            }
            set
            {
                this.books.Clear();
                foreach (var item in value)
                {
                    this.books.Add(item);
                }
            }
        }

        public bool AreBooksLoading
        {
            get
            {
                return this.areBooksLoading;
            }
            set
            {
                if (this.areBooksLoading == value)
                {
                    return;
                }
                this.areBooksLoading = value;
                this.RaisePropertyChanged("AreBooksLoading");
            }
        }
    }
}
