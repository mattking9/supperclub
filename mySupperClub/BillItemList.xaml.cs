using mySupperClub.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace mySupperClub
{
    public partial class BillItemList : ContentPage
    {
        private Event eventItem;

        public BillItemList()
        {
            InitializeComponent();
        }

        public BillItemList(Event selectedEventItem) : this()
        {
            this.BindingContext = new BillItemListViewModel(selectedEventItem, this.Navigation);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ((BillItemListViewModel)BindingContext).Load();
        }

        // Data methods
        async Task AddItem(BillItem item)
        {
            //await App.GetSupperClubService().AddBillItem(item);
            //todoList.ItemsSource = await App.GetSupperClubService().GetBillItems(eventItem.Id);
        }


        public async void OnAdd(object sender, EventArgs e)
        {
           // var todo = new BillItem { LocationName = newItemName.Text, EventId = eventItem.Id };
            //await AddItem(todo);

            //newItemName.Text = string.Empty;
            //newItemName.Unfocus();
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
            ((BillItemListViewModel)BindingContext).Load();
        }

        
    }
}

