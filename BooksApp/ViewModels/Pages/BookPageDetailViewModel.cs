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
        private IDetailBookData detailBookData;

        public BookPageDetailViewModel(IDetailBookData detailBookData)
        {
            this.detailBookData = detailBookData;
            this.Refresh();
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
            }
        }

        private void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
