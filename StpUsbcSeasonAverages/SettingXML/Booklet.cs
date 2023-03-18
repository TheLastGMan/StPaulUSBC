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
    public class Booklet
    {
        [XmlElement]
        public string CoverFile { get; set; } = String.Empty;

        [XmlElement]
        public string BackFile { get; set; } = String.Empty;

        [XmlElement]
        public string FooterFile { get; set; } = String.Empty;

        [XmlElement]
        public string BlankFile { get; set; } = String.Empty;

        [XmlElement]
        public string OutputFile { get; set; } = String.Empty;
    }
}
