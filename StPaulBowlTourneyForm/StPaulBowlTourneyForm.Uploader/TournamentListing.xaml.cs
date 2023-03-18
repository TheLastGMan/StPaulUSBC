using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	/// Interaction logic for TournamentListing.xaml
	/// </summary>
	public partial class TournamentListing : UserControl, INotifyPropertyChanged
	{
		public delegate void TourneyClickedEventHandler(string tourneyName);
		public event TourneyClickedEventHandler TourneyClicked;
		public event PropertyChangedEventHandler PropertyChanged;

		public TournamentListing()
		{
			InitializeComponent();
		}

		private void raisePropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		private void raiseTourneyClicked(string name)
		{
			TourneyClicked?.Invoke(name);
		}

		public List<string> Tournaments
		{
			get { return _tournaments; }
			set
			{
				if (value == null)
					value = new List<string>();

				_tournaments = value;
				raisePropertyChanged(nameof(Tournaments));
			}
		}
		private List<string> _tournaments = new List<string>() { "T1", "T2" };

		private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			var label = (Label)sender;
			string tourneyName = label.Content.ToString();
			raiseTourneyClicked(tourneyName);
		}
	}
}
