using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace mySupperClub
{
	public class BillItem
	{
        public string Id { get; set; }

        public string Name {  get; set; }

        public decimal Cost { get; set; }

        public string EventId { get; set; }

        public string UserId { get; set; }

        [Version]
        public string Version { get; set; }
    }
}

