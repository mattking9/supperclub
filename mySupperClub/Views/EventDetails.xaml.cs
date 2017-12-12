using mySupperClub.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mySupperClub
{
    public partial class EventDetails
    {

        public EventDetails()
        {
            InitializeComponent();
        }

        public EventDetails(Event selectedEventItem) : this()
        {
            this.BindingContext = new EventDetailsViewModel(selectedEventItem, this.Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((EventDetailsViewModel)BindingContext).Load();
        }
    }
}

