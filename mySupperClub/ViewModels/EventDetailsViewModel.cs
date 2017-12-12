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
    public class EventDetailsViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public EventDetailsViewModel(Event selectedEvent, INavigation navigation) : base(navigation)
        {
            eventItem = selectedEvent;
            AddItemCommand = new DelegateCommand(ExecuteAddItem, (o) => { return true; });
        }

        private Event eventItem;

        private ObservableCollection<BillItem> billItemList;
        private ObservableCollection<string> diners;
        private decimal myTotal;
        private decimal total;

        public ObservableCollection<BillItem> BillItems
        {
            get { return billItemList; }
            set
            {
                billItemList = value;
                CalculateTotals();
                NotifyPropertyChanged("BillItems");
            }
        }

        public ObservableCollection<string> Diners
        {
            get { return diners; }
            set
            {
                diners = value;
                NotifyPropertyChanged("Diners");
            }
        }

        public Event Event
        {
            get { return eventItem; }
            set
            {
                eventItem = value;
                NotifyPropertyChanged("Event");
            }
        }

        public decimal MyTotal
        {
            get { return myTotal; }
            set
            {
                myTotal = value;
                NotifyPropertyChanged("MyTotal");
            }
        }

        public decimal Total
        {
            get { return total; }
            set
            {
                total = value;
                NotifyPropertyChanged("Total");
            }
        }

        public void CalculateTotals()
        {
            MyTotal = billItemList.Where(bi => bi.UserId != null).Sum(bi => bi.Cost);
            Total = billItemList.Sum(bi => bi.Cost);
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

        public ICommand AddItemCommand { get; set; }

        public async void ExecuteAddItem(object parameter)
        {
            await Navigation.PushAsync(
                new AddBillItem(Event, BillItems));

        }
    }
}
