using System;
using System.Collections.Generic;
using System.Text;

namespace TeamAllEvents.Data
{
				class BowlerReportSummary
				{
								public string Name { get; set; } = string.Empty;
								public int Ave { get; set; }
								public int TeamScore { get; set; }
								public int DoublesScore { get; set; }
								public int SinglesScore { get; set; }

								public int Total()
								{
												return TeamScore + DoublesScore + SinglesScore;
								}
				}
}
