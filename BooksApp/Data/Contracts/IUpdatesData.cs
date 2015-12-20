using BooksApp.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksApp.Data.Contracts
{
    public interface IUpdatesData
    {
        Task<IEnumerable<UpdateModel>> All();
        void Like(int id);
        void Comment(int id, string text);
    }
}
