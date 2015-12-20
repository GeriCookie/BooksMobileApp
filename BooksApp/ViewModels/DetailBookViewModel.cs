using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.ViewModels
{
    public class DetailBookViewModel
    {
        public string Author { get; private set; }
        public string CoverUrl { get; private set; }
        public string Id { get; private set; }
        public int? Pages { get; private set; }
        public int? Rating { get; private set; }
        public IEnumerable<ReviewModel> Reviews { get; private set; }
        public string Title { get; private set; }

        public static DetailBookViewModel FromModel(DetailBookModel model)
        {
            return new DetailBookViewModel()
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                Rating = model.Rating,
                CoverUrl = model.CoverUrl,
                Pages = model.Pages,
                Reviews = model.Reviews

            };
        }
    }
}
