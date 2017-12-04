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
    public class EventListViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public EventListViewModel(Group selectedGroup, INavigation navigation) : base(navigation)
        {
            group = selectedGroup;
        }

        private Group group;

        private ObservableCollection<Event> eventList;

        public ObservableCollection<Event> Events
        {
            get { return eventList; }
            set
            {
                eventList = value;
                NotifyPropertyChanged("Events");
            }
        }

        public void Load()
        {
            //escape if already loaded
            if (Events != null)
                return;

            IsLoading = true;
            App.GetSupperClubService().GetEvents(group.Id).ContinueWith((e => {
                if (e.Exception == null)
                {
                    var result = e.Result;
                    Events = new ObservableCollection<Event>(result);
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
