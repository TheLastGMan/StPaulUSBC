using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StpUsbcSeasonAverages
{
    class SettingReader
    {
        private static readonly string _settingsFileName = "Settings.xml";

        public static Settings ReadSettings()
        {
            var des = new System.Xml.Serialization.XmlSerializer(typeof(Settings));
            var settings = (Settings)des.Deserialize(System.Xml.XmlReader.Create(_settingsFileName));
            return settings;
        }
    }
}
