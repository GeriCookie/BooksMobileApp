using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Data.Contracts;
using System.Collections.ObjectModel;

namespace BooksApp.ViewModels.Pages
{
    public class SearchResultPageViewModel : ViewModelBase
    {
        private const int MinPatternLength = 3;
        private bool areBooksLoading;
        private ObservableCollection<BookViewModel> books;
        private string pattern;
        private ISearchData searchData;

        public SearchResultPageViewModel(ISearchData searchData)
        {
            this.searchData = searchData;
            this.books = new ObservableCollection<BookViewModel>(); 
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

        public string Pattern
        {
            get
            {
                return this.pattern;
            }
            set
            {
                if (this.pattern == value)
                {
                    return;
                }
                this.pattern = value;
                this.RaisePropertyChanged("Pattern");
                if (this.pattern.Length >= MinPatternLength)
                {
                    this.Refresh();
                }
            }
        }

        private async void Refresh()
        {
            this.AreBooksLoading = true;
            var models = (await this.searchData.Search(this.Pattern));
            this.Books = models
                .Select(model => BookViewModel.FromModel(model));
            this.AreBooksLoading = false;
        }
    }
}
