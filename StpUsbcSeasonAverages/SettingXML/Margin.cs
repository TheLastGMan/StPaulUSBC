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
    public class Margin
    {
        [XmlAttribute]
        public float InTop { get; set; }

        [XmlAttribute]
        public float InBottom { get; set; }

        [XmlAttribute]
        public float InRight { get; set; }

        [XmlAttribute]
        public float InLeft { get; set; }
    }
}
