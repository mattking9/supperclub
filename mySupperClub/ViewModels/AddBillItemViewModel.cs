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
    public class AddBillItemViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public AddBillItemViewModel(Event selectedEvent, ObservableCollection<BillItem> selectedbillItems, INavigation navigation) : base(navigation)
        {
            thisEvent = selectedEvent;
            billItems = selectedbillItems;
                        
            SaveItemCommand = new DelegateCommand(ExecuteSaveItem, CanExecuteSaveItem);
        }

        private string name;
        private decimal cost;
        private Event thisEvent;
        private ObservableCollection<BillItem> billItems;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public decimal Cost
        {
            get
            {
                return cost;
            }

            set
            {
                cost = value;
                NotifyPropertyChanged("Cost");
            }
        }        

        public void Load()
        {
        }

        public ICommand SaveItemCommand { get; set; }

        public async void ExecuteSaveItem(object parameter)
        {

            var newItem = await App.GetSupperClubService().AddBillItem(
                new BillItem { Name = Name, Cost = Cost, EventId = "5TFE695B-4840-46D9-AB43-1F46855C18D6", UserId = "6TRE695B-4840-46D9-AB43-1F46855C1Y67" });

            billItems.Add(newItem);

            //move back to the page they were on before bidding
            await Navigation.PopAsync();

        }

        public bool CanExecuteSaveItem(object parameter)
        {
            return true;
        }

    }
}
