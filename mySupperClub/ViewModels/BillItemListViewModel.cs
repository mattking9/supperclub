using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace mySupperClub.ViewModels
{
    public class BillItemListViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public BillItemListViewModel(Event selectedEvent, INavigation navigation) : base(navigation)
        {
            eventItem = selectedEvent;
        }

        private Event eventItem;

        private ObservableCollection<BillItem> billItemList;

        public ObservableCollection<BillItem> BillItems
        {
            get { return billItemList; }
            set
            {
                billItemList = value;
                NotifyPropertyChanged("BillItems");
            }
        }

        public void Load()
        {
            //escape if already loaded
            if (BillItems != null)
                return;

            IsLoading = true;
            App.GetSupperClubService().GetBillItems(eventItem.Id).ContinueWith((e => {
                if (e.Exception == null)
                {
                    var result = e.Result;
                    BillItems = new ObservableCollection<BillItem>(result);
                }
                else
                {
                    //alert to exception
                }
                IsLoading = false;
            }));
        }

    }
}
