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
    public class HttpMyBooksData : IMyBooksData
    {
        private string url;

        public HttpMyBooksData(string url)
        {
            this.url = url;
        }

        public async Task<IEnumerable<DetailBookModel>> AllBooks()
        {
            IEnumerable<DetailBookModel> books = await HttpRequester
                .Get<IEnumerable<DetailBookModel>>(this.url, new Dictionary<string, string> {
                {
                    "x-auth-key",App.AuthenticationToken
                }
            });
            return books;
        }
    }
}
