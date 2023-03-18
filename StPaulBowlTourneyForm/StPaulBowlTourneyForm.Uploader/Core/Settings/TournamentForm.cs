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
	public class TournamentForm
	{
		[XmlAttribute]
		public string DisplayName { get; set; } = String.Empty;
		[XmlAttribute]
		public string FileName { get; set; } = String.Empty;
	}
}
