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
    public class HttpChangeStatusData : IChangeStatusData
    {
        private string url;

        public HttpChangeStatusData(string url)
        {
            this.url = url;
        }

        public async Task ChangeStatus(string status, string bookId)
        {
            var endpointUrl = this.url + "/mybooks";
            var data = new ChangeStatusRequestModel()
            {
                BookId = bookId,
                Status = status
            };
            await HttpRequester.Put<object>(endpointUrl, data, new Dictionary<string, string> {
                {
                    "x-auth-key",App.AuthenticationToken
                }
            });
        }

        public async Task<DetailBookModel> GetBook(string id)
        {
            var endpointUrl = this.url + "/books/" + id;
            DetailBookModel book = await HttpRequester.Get<DetailBookModel>(endpointUrl);
            return book;
        }
    }
}
