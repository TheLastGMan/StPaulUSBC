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
	public class Tournament
	{
		[XmlElement("Form", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
		public List<TournamentForm> Forms { get; set; } = new List<TournamentForm>();

		[XmlAttribute]
		public string Name { get; set; } = String.Empty;
		[XmlAttribute]
		public string BaseFolder { get; set; } = String.Empty;
	}
}
