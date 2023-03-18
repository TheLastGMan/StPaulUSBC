using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StPaulBowlTourneyForm.Core.Settings
{
	[XmlRoot("Setting")]
	public class SettingRoot
	{
		public Destination Destination { get; set; } = new Destination();

		public List<Tournament> Tournaments { get; set; } = new List<Tournament>();
	}
}
