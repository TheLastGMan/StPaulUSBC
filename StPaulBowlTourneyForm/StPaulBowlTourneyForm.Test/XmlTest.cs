using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StPaulBowlTourneyForm.Core.Settings;
using System.IO;
using StPaulBowlTourneyForm.Core.Serializer;

namespace StPaulBowlTourneyForm.Test
{
	[TestClass]
	public class XmlTest
	{
		[TestMethod]
		public void CreateXmlTest()
		{
			var root = new SettingRoot();
			root.Destination = new Destination() { FtpSite = "ftp://ftp.stpaulusbc.org/", Username = "test", Password = "test", RootFolder = "Uploads" };
			root.Tournaments.Add(new Tournament() { Name = "MyT1", BaseFolder = "TestTourney1", Forms = new List<TournamentForm>() { new TournamentForm() { DisplayName = "Singles", FileName = "singles.pdf" }, new TournamentForm() { DisplayName = "HDCP", FileName = "hahaHDCP.pdf" } } });
			root.Tournaments.Add(new Tournament() { Name = "City Open", BaseFolder = "CityOpen", Forms = new List<TournamentForm>() { new TournamentForm() { DisplayName = "Doubles", FileName = "mydouble.pdf" } } });

			using (var sw = new StreamWriter("test.xml"))
			{
				var data = new XML().SerializeXml(root);
				sw.BaseStream.Write(data, 0, data.Length);
			}
		}
	}
}
