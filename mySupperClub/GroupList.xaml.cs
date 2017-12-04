using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using mySupperClub.ViewModels;
using mySupperClub;

namespace mySupperClub
{
    public partial class GroupList
    {
        public GroupList()
        {
            InitializeComponent();
            this.BindingContext = new GroupListViewModel(this.Navigation);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((GroupListViewModel)BindingContext).Load();
        }

        protected void Group_Tapped(object sender, ItemTappedEventArgs e)
        {
            Group group = e.Item as Group;
            Navigation.PushAsync(
                new EventList(group));
        }
    }
}
