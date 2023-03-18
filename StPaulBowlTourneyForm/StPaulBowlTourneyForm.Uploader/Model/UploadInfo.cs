using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StPaulBowlTourneyForm.Uploader.Model
{
	public class UploadInfo : INotifyPropertyChanged
	{
		public string DisplayName
		{
			get { return _DisplayName; }
			set { _DisplayName = value; notify(nameof(DisplayName)); }
		}
		private string _DisplayName = String.Empty;

		public string SourceFile
		{
			get { return _SourceFile; }
			set { _SourceFile = value; notify(nameof(SourceFile)); }
		}
		private string _SourceFile = String.Empty;

		public string Message
		{
			get { return _Message; }
			set { _Message = value; notify(nameof(Message)); }
		}
		private string _Message = String.Empty;

		public string TargetFile
		{
			get { return _TargetFile; }
			set { _TargetFile = value; notify(nameof(TargetFile)); }
		}
		private string _TargetFile = String.Empty;


		public event PropertyChangedEventHandler PropertyChanged;
		private void notify(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}
	}
}
