using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StPaulBowlTourneyForm.Core.Settings
{
	public class Destination
	{
		public string FtpSite { get; set; } = String.Empty;
		public string Username { get; set; } = String.Empty;
		public string Password { get; set; } = String.Empty;
		public string RootFolder { get; set; } = String.Empty;
	}
}
