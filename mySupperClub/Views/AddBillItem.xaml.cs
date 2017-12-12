using mySupperClub.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mySupperClub
{
    public partial class AddBillItem
    {

        public AddBillItem()
        {
            InitializeComponent();
        }

        public AddBillItem(Event selectedEvent, ObservableCollection<BillItem> billItems) : this()
        {
            this.BindingContext = new AddBillItemViewModel(selectedEvent, billItems, this.Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((AddBillItemViewModel)BindingContext).Load();
        }

        

        // Event handlers
        public async void OnSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var todo = e.SelectedItem as BillItem;
            //if (Device.OS != TargetPlatform.iOS && todo != null)
            //{
            //    // Not iOS - the swipe-to-delete is discoverable there
            //    if (Device.OS == TargetPlatform.Android)
            //    {
            //        await DisplayAlert(todo.LocationName, "Press-and-hold to complete task " + todo.LocationName, "Got it!");
            //    }
            //    else
            //    {
            //        // Windows, not all platforms support the Context Actions yet
            //        if (await DisplayAlert("Mark completed?", "Do you wish to complete " + todo.LocationName + "?", "Complete", "Cancel"))
            //        {
            //            //await CompleteItem(todo);
            //        }
            //    }
            //}

            //// prevents background getting highlighted
            //todoList.SelectedItem = null;
        }

        // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview/#context
        public async void OnComplete(object sender, EventArgs e)
        {
        //    var mi = ((MenuItem)sender);
        //    var todo = mi.CommandParameter as BillItem;
        //    //await CompleteItem(todo);
        }

        // http://developer.xamarin.com/guides/cross-platform/xamarin-forms/working-with/listview/#pulltorefresh
        public async void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                await RefreshItems();
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }

            if (error != null)
            {
                await DisplayAlert("Refresh Error", "Couldn't refresh data (" + error.Message + ")", "OK");
            }
        }

        private async Task RefreshItems()
        {
            ((AddBillItemViewModel)BindingContext).Load();
        }

        
    }
}

