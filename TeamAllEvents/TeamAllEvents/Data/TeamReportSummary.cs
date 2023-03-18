using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TeamAllEvents.Data
{
    class TeamReportSummary
    {
        public int EntryNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<BowlerReportSummary> Bowlers { get; set; } = new List<BowlerReportSummary>(8);

        public int TeamTotal()
        {
            return Bowlers.Sum(f => f.TeamScore);
        }

        public int DoublesTotal()
        {
            return Bowlers.Sum(f => f.DoublesScore);
        }

        public int SinglesTotal()
        {
            return Bowlers.Sum(f => f.SinglesScore);
        }

        public int AverageTotal()
        {
            return Bowlers.Sum(f => f.Ave);
        }

        public int Total()
        {
            return Bowlers.Sum(f => f.Total());
        }
    }
}
