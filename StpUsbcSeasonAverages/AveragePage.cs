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
    public class AveragePage
    {
        [XmlElement]
        public Margin Margins { get; set; }

        [XmlElement]
        public float FontSize { get; set; }

        [XmlElement]
        public int CenterColumnIndex { get; set; }

        [XmlElement]
        public int RowsPerPage { get; set; }

        [XmlArrayItem("Header")]
        public BookletHeader[] Headers { get; set; } = new BookletHeader[] { };
    }
}
