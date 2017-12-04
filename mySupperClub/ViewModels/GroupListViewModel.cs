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
    public class GroupListViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public GroupListViewModel(INavigation navigation) : base(navigation)
        { }

        private ObservableCollection<Group> groupList;

        public ObservableCollection<Group> Groups
        {
            get { return groupList; }
            set
            {
                groupList = value;
                NotifyPropertyChanged("Groups");
            }
        }

        public void Load()
        {
            //escape if already loaded
            if (Groups != null)
                return;

            IsLoading = true;
            App.GetSupperClubService().GetGroups().ContinueWith((g => {
                if (g.Exception == null)
                {
                    var result = g.Result;
                    Groups = new ObservableCollection<Group>(result);
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
