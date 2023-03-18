using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StpUsbcSeasonAverages
{
    public class BowlerInfo
    {
        public string LastName { get; set; } = String.Empty;
        public string FirstName { get; set; } = String.Empty;
        public string MI { get; set; } = String.Empty;
        public string Suffix { get; set; } = String.Empty;
        public string USBC_Id { get; set; } = String.Empty;
        public string Average { get; set; } = String.Empty;
        public string Games { get; set; } = String.Empty;
        public string Hand { get; set; } = String.Empty;
        public string League { get; set; } = String.Empty;
        public string Season { get; set; } = String.Empty;

        public bool Valid
        {
            get
            {
                return !String.IsNullOrEmpty(USBC_Id);
            }
        }

        public string Name
        {
            get
            {
                if (String.IsNullOrEmpty(LastName))
                    return String.Empty;


                string name = LastName + ", " + FirstName;
                if (!String.IsNullOrEmpty(MI))
                    name += " " + MI;
                if (!String.IsNullOrEmpty(Suffix))
                    name += ", " + Suffix;
                return name;
            }
        }
    }
}
