using BooksApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Models;
using BooksApp.Http;

namespace BooksApp
{
    public class HttpUpdatesData : IUpdatesData
    {
        private string endPointUrl;

        public HttpUpdatesData(string endPointUrl)
        {
            this.endPointUrl = endPointUrl;
        }

        public async Task<IEnumerable<UpdateModel>> All()
        {
            IEnumerable<UpdateModel> updates = await HttpRequester
                .Get<IEnumerable<UpdateModel>>(this.endPointUrl);
            return updates;
        }

        public void Comment(int id, string text)
        {
            throw new NotImplementedException();
        }

        public void Like(int id)
        {
            throw new NotImplementedException();
        }
    }
}
