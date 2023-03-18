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
    public class BookletHeader
    {
        [XmlAttribute]
        public string Text { get; set; }

        [XmlAttribute]
        public float Width { get; set; }

        [XmlAttribute]
        public Alignment Align { get; set; }
    }
}
