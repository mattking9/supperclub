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
    public partial class EventList
    {
        public EventList()
        {
            InitializeComponent();
        }

        public EventList(Group group) : this()
        {
            this.BindingContext = new EventListViewModel(group, this.Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((EventListViewModel)BindingContext).Load();
        }

        protected void Event_Tapped(object sender, ItemTappedEventArgs e)
        {
            Event eventItem = e.Item as Event;
            Navigation.PushAsync(
                new BillItemList(eventItem));
        }
    }
}
