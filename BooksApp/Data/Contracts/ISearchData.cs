using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data.Contracts
{
    public interface ISearchData
    {
        Task<IEnumerable<BookModel>> Search(string pattern);
    }
}
