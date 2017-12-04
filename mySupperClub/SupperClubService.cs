using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace mySupperClub
{
    public partial class SupperClubService
    {
        private static MobileServiceClient azClient;

        public SupperClubService(string serviceBaseUri)
        {
            azClient = new MobileServiceClient(serviceBaseUri);
        }

        public MobileServiceUser CurrentClient
        {
            get { return azClient.CurrentUser; }
        }

        public async Task<IEnumerable<Group>> GetGroups()
        {
            var table = azClient.GetTable<Group>();
            //eventually this will be filtered by user id
            return await table.ReadAsync();
        }

        public async Task<IEnumerable<Event>> GetEvents(string groupId)
        {
            var table = azClient.GetTable<Event>();
            var query = table.Where(e => e.GroupId == groupId);
            return await table.ReadAsync(query);
        }

        public async Task<IEnumerable<BillItem>> GetBillItems(string eventId)
        {
            var table = azClient.GetTable<BillItem>();
            var query = table.Where(bi => bi.EventId == eventId);
            return await table.ReadAsync(query);
        }

        public async Task<BillItem> AddBillItem(BillItem newBillItem)
        {
            var table = azClient.GetTable<BillItem>();
            await table.InsertAsync(newBillItem);
            return newBillItem;
        }
    }
}
