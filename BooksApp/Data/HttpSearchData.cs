using BooksApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Models;
using BooksApp.Http;

namespace BooksApp.Data
{
    public class HttpSearchData : ISearchData
    {
        private string url;

        public HttpSearchData(string url)
        {
            this.url = url;
        }

        public async Task<IEnumerable<BookModel>> Search(string pattern)
        {
            var endpointUrl = this.url + "?pattern=" + pattern;
            var books = await HttpRequester.Get<IEnumerable<BookModel>>(endpointUrl);
            return books;
        }
    }
}
