using System;
using System.Collections.Generic;
using System.Text;

namespace TeamAllEvents.Data
{
    class EventInfo
    {
        public int EntryNumber { get; set; }
        public int RosterNumber { get; set; }
        public string Event { get; set; } = string.Empty;
        public int Score { get; set; }

        public BowlerInfo Bowler { get; set; }
    }
}
