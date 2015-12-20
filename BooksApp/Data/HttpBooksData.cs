using BooksApp.Data.Contracts;
using BooksApp.Http;
using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.Data
{
    public class HttpBooksData : IBooksData
    {
        private string endPointUrl;

        public HttpBooksData(string endpointUrl)
        {
            this.endPointUrl = endpointUrl;
        }

        public async Task<IEnumerable<BookModel>> All()
        {
            IEnumerable<BookModel> books = await HttpRequester
                .Get<IEnumerable<BookModel>>(this.endPointUrl);
            return books;
        }
    }
}
