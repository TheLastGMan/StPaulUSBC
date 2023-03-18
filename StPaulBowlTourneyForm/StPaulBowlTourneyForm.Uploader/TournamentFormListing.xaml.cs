using Microsoft.Win32;
using StPaulBowlTourneyForm.Core.FTP;
using StPaulBowlTourneyForm.Core.Settings;
using StPaulBowlTourneyForm.Uploader.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	/// Interaction logic for TournamentFormListing.xaml
	/// </summary>
	public partial class TournamentFormListing : UserControl, INotifyPropertyChanged
	{
		public TournamentFormListing()
		{
			InitializeComponent();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		private void raisePropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		public delegate Destination UploadDestinationRequestEventHandler();
		public event UploadDestinationRequestEventHandler UploadRequested;

		public Tournament ActiveTournament
		{
			get { return _ActiveTournament; }
			set
			{
				if (value == null)
					value = new Tournament();

				_ActiveTournament = value;
				raisePropertyChanged(nameof(ActiveTournament));

				UploadInfos = _ActiveTournament.Forms.Select(f => new UploadInfo() { DisplayName = f.DisplayName, TargetFile = System.IO.Path.Combine(_ActiveTournament.BaseFolder, f.FileName) }).ToList();
			}
		}
		private Tournament _ActiveTournament = new Tournament();

		public List<UploadInfo> UploadInfos
		{
			get { return _UploadInfos; }
			set
			{
				if (value == null)
					value = new List<UploadInfo>();

				_UploadInfos = value;
				raisePropertyChanged(nameof(UploadInfos));
			}
		}
		private List<UploadInfo> _UploadInfos = new List<UploadInfo>();

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//ftp access
			var ftp = new Core.FTP.Uploader(UploadRequested());
			Destination dest = UploadRequested();

			new Task(() =>
			{
				//upload files
				foreach (var upInfo in UploadInfos)
				{
					if (!String.IsNullOrEmpty(upInfo.SourceFile))
					{
						var fi = new FileInfo(upInfo.SourceFile);
						if (fi.Exists)
						{
							Dispatcher.Invoke(() => upInfo.Message = "Uploading...");
							try
							{
								string result = ftp.UploadFile(new FileUpload(fi, upInfo.TargetFile));
								upInfo.Message = $"Completed: { result.Replace(Environment.NewLine, " * ") }";
								upInfo.SourceFile = String.Empty;
							}
							catch (Exception ex)
							{
								upInfo.Message = "Error: " + ex.Message;
							}
						}
					}
				}
			}).Start();
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			var fileSelect = new OpenFileDialog();
			fileSelect.DefaultExt = ".pdf";
			fileSelect.Filter = "PDF Files (*.pdf)|*.pdf";
			fileSelect.CheckFileExists = true;
			fileSelect.Multiselect = false;

			var record = UploadInfos.First(f => f.DisplayName == ((DynamicButtonX)sender).DisplayName);
			if (fileSelect.ShowDialog() == true)
				record.SourceFile = fileSelect.FileName;
			else
				record.SourceFile = String.Empty;
			record.Message = String.Empty;
		}
	}
}
