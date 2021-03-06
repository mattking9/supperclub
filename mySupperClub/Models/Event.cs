﻿using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace mySupperClub
{
	public class Event
	{
		public string Id { get; set; }
		
		public string LocationName { get; set; }

        public DateTime EventDate { get; set; }

        public string GroupId { get; set; }

        public ICollection<BillItem> BillItems { get; set; }

        [Version]
        public string Version { get; set; }
	}
}

