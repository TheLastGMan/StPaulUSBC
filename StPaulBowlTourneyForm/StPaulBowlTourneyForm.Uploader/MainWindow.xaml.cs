using StPaulBowlTourneyForm.Core.Serializer;
using StPaulBowlTourneyForm.Core.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StPaulBowlTourneyForm.Uploader
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private SettingRoot _formXml = new SettingRoot();

		public MainWindow()
		{
			InitializeComponent();
			Startup();
		}

		public void Startup()
		{
			try
			{
				string xmlPath = "TournamentForms.xml";
#if !DEBUG
				xmlPath = "http://www.stpaulusbc.org/uploads/applications/tourneyformuploader/TournamentForms.xml";
#endif
				using (var sr = new StreamReader(xmlPath))
					_formXml = new XML().DeserializeXml<SettingRoot>(sr.BaseStream);

				//load form view
				TournamentNames.Tournaments = _formXml.Tournaments.Select(f => f.Name).OrderBy(f => f).ToList();
				if (TournamentNames.Tournaments.Any())
					TournamentListing_TourneyClicked(TournamentNames.Tournaments[0]);

				//add event handler
				TournamentForms.UploadRequested += () => { return _formXml.Destination; };
			}
			catch(Exception ex)
			{
				errorMessage(ex.Message);
				this.Close();
			}
		}

		private void TournamentListing_TourneyClicked(string tourneyName)
		{
			var tournament = _formXml.Tournaments.FirstOrDefault(f => f.Name == tourneyName);
			if (tournament == null)
				errorMessage($"Tournament Not Found: {tourneyName}");
			else
				TournamentForms.ActiveTournament = tournament;
		}

		private void errorMessage(string msg)
		{
			MessageBox.Show(msg, "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
}
