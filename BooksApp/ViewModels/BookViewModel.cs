using BooksApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp.ViewModels
{
  public class BookViewModel : ViewModelBase
  {
    public string Author { get; protected set; }
    public string CoverUrl { get; protected set; }
    public string Id { get; protected set; }
    public int? Pages { get; protected set; }
    public int? Rating { get; protected set; }
    public string Title { get; protected set; }

    public string Description { get; set; }

    public static BookViewModel FromModel(BookModel model)
    {
      return new BookViewModel()
      {
        Id = model.Id,
        Title = model.Title,
        Author = model.Author,
        Rating = model.Rating,
        CoverUrl = model.CoverUrl,
        Pages = model.Pages,
        Description = model.Description
      };
    }
  }
}
