using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.ViewModels
{
  public class DetailBookViewModel : BookViewModel
  {
    public IEnumerable<string> Genres { get; private set; }

    public IEnumerable<ReviewModel> Reviews { get; private set; }

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
        Reviews = model.Reviews,
        Genres = model.Genres,
        Description = model.Description
      };
    }
  }
}
