using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StPaulBowlTourneyForm.Core.FTP
{
	public class FileUpload
	{
		public FileUpload(FileInfo sourceFile, string destinationPath)
		{
			SourceFile = sourceFile;
			DestinationPath = destinationPath;
		}

		public FileInfo SourceFile { get; private set; }
		public string DestinationPath { get; private set; } = String.Empty;
	}
}
