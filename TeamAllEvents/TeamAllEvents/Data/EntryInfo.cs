using System;
using System.Collections.Generic;
using System.Text;

namespace TeamAllEvents.Data
{
    class EntryInfo
    {
        public string TeamName { get; set; } = string.Empty;
        public int EntryNumber { get; set; }

        public IList<BowlerInfo> Bowlers { get; set; } = new List<BowlerInfo>();
    }
}
