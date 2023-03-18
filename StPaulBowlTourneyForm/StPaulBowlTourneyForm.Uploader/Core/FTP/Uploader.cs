using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StPaulBowlTourneyForm.Core.Settings;
using System.Net;
using System.IO;

namespace StPaulBowlTourneyForm.Core.FTP
{
	public class Uploader
	{
		public Uploader(Destination connectionSetting)
		{
			Destination = connectionSetting;
		}

		public Destination Destination { get; private set; }

		private string createUrl(FileUpload info)
		{
			//protocol setup
			string url = "";
			if (Destination.FtpSite.ToLower().StartsWith("ftp://"))
				url += Destination.FtpSite;
			else
				url += $"ftp://{ Destination.FtpSite }";

			//path between host/root folder
			if (!url.EndsWith("/"))
				url += "/";

			//root folder
			url += Destination.RootFolder;
			if (!url.EndsWith("/"))
				url += "/";

			//destination folder
			url += info.DestinationPath;
			url = url.Replace('\\', '/');

			//give full path to URL
			return url;
		}

		public string UploadFile(FileUpload file)
		{
			//validate
			if (!file.SourceFile.Exists)
				throw new Exception("Source file must exist");

			//create connection

			var request = (FtpWebRequest)WebRequest.Create(createUrl(file));
			request.Method = WebRequestMethods.Ftp.UploadFile;

			//specify login
			request.Credentials = new NetworkCredential(Destination.Username, Destination.Password);

			//load to stream
			using (var sr = new StreamReader(file.SourceFile.FullName, true))
			{
				var requestStream = request.GetRequestStream();
				byte[] data = new byte[sr.BaseStream.Length];
				sr.BaseStream.Read(data, 0, (int)sr.BaseStream.Length);
				requestStream.Write(data, 0, data.Length);
				requestStream.Close();
			}

			//load response
			var response = (FtpWebResponse)request.GetResponse();
			return response.StatusDescription;
		}

		public string[] UploadFiles(FileUpload[] files)
		{
			return files.AsParallel().AsOrdered().Select(f => UploadFile(f)).ToArray();
		}
	}
}
