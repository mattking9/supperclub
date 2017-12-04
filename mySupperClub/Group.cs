using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace mySupperClub
{
	public class Group
	{
        public string Id { get; set; }

		public string Name { get; set; }

        [Version]
        public string Version { get; set; }
	}
}

