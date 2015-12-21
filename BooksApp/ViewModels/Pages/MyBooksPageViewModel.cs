using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Data.Contracts;
using System.Collections.ObjectModel;

namespace BooksApp.ViewModels.Pages
{
    public class MyBooksPageViewModel :ViewModelBase
    {
        private IMyBooksData myBooksData;
        private ObservableCollection<DetailBookViewModel> books;
        private bool areBooksLoading;

        public MyBooksPageViewModel(IMyBooksData myBooksData)
        {
            this.myBooksData = myBooksData;
            this.books = new ObservableCollection<DetailBookViewModel>();
            this.Refresh();
        }

        private async void Refresh()
        {
            this.AreBooksLoading = true;
            var models = (await this.myBooksData.AllBooks());
            this.Books = models
                .Select(model => DetailBookViewModel.FromModel(model));
            this.AreBooksLoading = false;

        }

        public IEnumerable<DetailBookViewModel> Books
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

