using System;
using BooksApp.Models;

namespace BooksApp.ViewModels
{
    public class UpdateViewModel:ViewModelBase
    {
        public DateTime Date { get; private set; }
        public string Id { get; private set; }
        public string Text { get; private set; }
        public string User { get; private set; }

        public static UpdateViewModel FromModel(UpdateModel model)
        {
            return new UpdateViewModel()
            {
                Id = model.Id,
                Text = model.UpdateText,
                Date = model.Date,
                User = model.User
            };
        }
    }
}