using System;
using System.Collections.Generic;
using System.Text;

namespace TeamAllEvents.Data
{
    class BowlerInfo
    {
        public string Name { get; set; } = string.Empty;
        public int SquadNumber { get; set; }
        public int Average { get; set; }
        public List<EventInfo> Events { get; } = new List<EventInfo>(4);
    }
}
