using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApp.Data.Contracts;

namespace BooksApp.ViewModels.Pages
{
    public class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<UpdateViewModel> updates;
        private IUpdatesData updatesData;

        public MainPageViewModel(IUpdatesData updatesData)
        {
            this.updates = new ObservableCollection<UpdateViewModel>();
            this.updatesData = updatesData;
            this.Refresh();
        }

        private async void Refresh()
        {
            this.Updates = (await this.updatesData.All())
                .Select(model => UpdateViewModel.FromModel(model));
        }

        public IEnumerable<UpdateViewModel> Updates
        {
            get
            {
                return this.updates;
            }
            set
            {
                this.updates.Clear();
                foreach (var item in value)
                {
                    this.updates.Add(item);
                }
            }
        }
    }
}
