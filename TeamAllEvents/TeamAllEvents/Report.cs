using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeamAllEvents.Data;

namespace TeamAllEvents
{
				class Report
				{
								public const string EventName_Singles = "Singles";
								public const string EventName_Doubles = "Doubles";
								public const string EventName_Team = "Team";

								public IList<IGrouping<int, TeamReportSummary>> GenerateStandings(IList<BowlerInfo> bowlers, IList<EntryInfo> entries)
								{
												var results = new List<TeamReportSummary>(entries.Count);
												foreach (var entry in entries)
												{
																try
																{
																				//create entry
																				var teamEntry = new TeamReportSummary
																				{
																								EntryNumber = entry.EntryNumber,
																								Name = entry.TeamName
																				};

																				//assign bowlers to team, with scores
																				//var entryRoster = entry.Bowlers.Where(f => f.Events.Select(g => g.EntryNumber).Contains(teamEntry.EntryNumber)).OrderBy(f => f.Events.First(g => g.EntryNumber == teamEntry.EntryNumber).RosterNumber).ToList();
																				var entryRoster = entry.Bowlers.Where(f => f.Events.Any(g => g.Event == EventName_Team && g.EntryNumber == teamEntry.EntryNumber)).OrderBy(f => f.Events.First(g => g.Event == EventName_Team && g.EntryNumber == teamEntry.EntryNumber).RosterNumber);
																				foreach (var rosterEntry in entryRoster)
																				{
																								var bowlerEntry = new BowlerReportSummary()
																								{
																												Name = rosterEntry.Name,
																												Ave = rosterEntry.Average
																								};

																								//load other scores across any entry
																								bowlerEntry.SinglesScore = rosterEntry.Events.FirstOrDefault(f => f.Event == EventName_Singles)?.Score ?? 0;
																								bowlerEntry.DoublesScore = rosterEntry.Events.FirstOrDefault(f => f.Event == EventName_Doubles)?.Score ?? 0;
																								bowlerEntry.TeamScore = rosterEntry.Events.FirstOrDefault(f => f.Event == EventName_Team)?.Score ?? 0;

																								//add to team
																								teamEntry.Bowlers.Add(bowlerEntry);
																				}

																				results.Add(teamEntry);
																}
																catch (Exception ex)
																{
																				throw new Exception($"Unable to generate team standings: reason: { ex.Message }");
																}
												}

												var gresults = results.OrderByDescending(f => f.Total()).GroupBy(f => f.Bowlers.Count).OrderByDescending(f => f.Key).ToList();
												return gresults;
								}

								public IList<string> CSVReport(IList<IGrouping<int, TeamReportSummary>> entryGroups, int validTeamSize)
								{
												var results = new List<string>();

												foreach (var entries in entryGroups)
												{
																//if null, show all groups, otherwise filter by the team size
																if (validTeamSize == 0)
																				results.Add($"PLAYERS,{entries.Key},,,,,,,,");
																else if (validTeamSize != entries.Key)
																				continue;

																//output team
																results.Add(",Entry,Position");
																for (int i = 1; i <= entries.Count(); i++)
																{
																				var team = entries.ElementAt(i - 1);

																				try
																				{
																								results.Add($",{ team.EntryNumber },{ i },\"{ team.Name }\",Ave,Team,Dbls,Sngls,Total,");
																								foreach (var bowler in team.Bowlers)
																												results.Add($",,,\"{ bowler.Name }\",{ bowler.Ave },{ bowler.TeamScore },{ bowler.DoublesScore },{ bowler.SinglesScore},{ bowler.Total() },");
																								results.Add($",,,,{ team.AverageTotal() },{ team.TeamTotal() },{ team.DoublesTotal() },{ team.SinglesTotal() },{ team.Total() },");
																								results.Add(",,,,,,,,,");
																								results.Add(",,,,,,,,,");
																				}
																				catch (Exception ex)
																				{
																								throw new Exception($"Unable to generate CSV report for team: { team.Name } | reason: { ex.Message }");
																				}
																}
												}

												results = results.Take(results.Count - 2).ToList();
												return results;
								}
				}
}