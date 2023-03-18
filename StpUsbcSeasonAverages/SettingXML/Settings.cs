using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StpUsbcSeasonAverages
{
    [XmlRoot]
    public class Settings
    {
        [XmlElement]
        public string Season { get; set; } = String.Empty;

        [XmlElement]
        public string YearbookCSV
        {
            get { return _YearbookCSV.Replace("{0}", Season); }
            set { _YearbookCSV = value; }
        }
        private string _YearbookCSV = String.Empty;

        [XmlElement]
        public string YearbookUploadOutputFile
        {
            get { return _YearbookUploadOutputFile.Replace("{0}", Season); }
            set { _YearbookUploadOutputFile = value; }
        }
        private string _YearbookUploadOutputFile = String.Empty;

        [XmlElement]
        public Booklet Booklet { get; set; } = new Booklet();

        [XmlElement]
        public AveragePage AveragePage { get; set; } = new AveragePage();
    }
}
