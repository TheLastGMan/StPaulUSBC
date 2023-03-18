using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TeamAllEvents.Data;

namespace TeamAllEvents
{
				class Parser
				{
								private bool IsOnlyCharacterArray(char character, string line)
								{
												var lcpy = line.Replace(" ", "").Trim();
												return lcpy.All(f => f == character);
								}

								public List<BowlerInfo> LoadBowlers(string inputFilePath)
								{
												var results = new List<BowlerInfo>();
												const string regexExpression = "(\"(.*)\"|(\\w*)),(\\d+),(\\d+),(\"?.*\"?),(\\d+),(\\d+),\"?(\\d*,?\\d*)\"?";
												const int groupCount = 10;
												var regEx = new Regex(regexExpression, RegexOptions.Singleline | RegexOptions.Compiled);

												//Header/Format: "Name, ...",  Entry #, Roster #, "Event", Squad #, Average, Score
												//these are small files, read all into memory
												var lines = File.ReadAllLines(inputFilePath).Skip(1).ToArray();
												for (int i = 0; i < lines.Length; i++)
												{
																//setup
																var line = lines[i];

																//skip empty row
																if (IsOnlyCharacterArray(',', line))
																				continue;

																//try this in case something funny happens
																try
																{
																				//check group validation count
																				var groups = regEx.Matches(line);
																				if (groups.Count != 1 && groups[0].Length != groupCount)
																								throw new Exception($"invalid bowler format");

																				//parse bowler
																				var bg = groups[0].Groups;
																				var currentBowler = new BowlerInfo()
																				{
																								Name = bg[2].Value,
																								SquadNumber = int.Parse(bg[7].Value),
																								Average = int.Parse(bg[8].Value)
																				};

																				//split out event
																				var currentEvent = new EventInfo()
																				{
																								EntryNumber = int.Parse(bg[4].Value),
																								Event = bg[6].Value,
																								RosterNumber = int.Parse(bg[5].Value),
																								Score = bg[9].Value.Trim().Length == 0 ? 0 : int.Parse(bg[9].Value.Replace(",", "")),
																				};

																				//check if we have a new bowler to add
																				if (results.Count == 0 || (currentBowler.Name.Length > 0 && currentBowler.Name != results.Last().Name))
																								results.Add(currentBowler);

																				//skip squads of 0
																				if (currentBowler.SquadNumber == 0)
																								continue;

																				//add event info
																				currentEvent.Bowler = results.Last();
																				results.Last().Events.Add(currentEvent);
																}
																catch (Exception ex)
																{
																				throw new Exception($"Unable to parse bowler at line: { i + 2 } | for input { Environment.NewLine } >> { line } { Environment.NewLine } >> Reason: { ex.Message }");
																}
												}
												return results;
								}

								public List<EntryInfo> LoadDivisions(string inputFilePath, IList<BowlerInfo> bowlers)
								{
												var results = new List<EntryInfo>();
												const string regexExpression = "\"?(.*)\"?,(\\d+),\"?(\\d*,?\\d+)\"?";
												const int groupCount = 3;
												var regEx = new Regex(regexExpression, RegexOptions.Singleline | RegexOptions.Compiled);

												//Header/Format: "Name Name", Entry Number
												//these are small files, read all into memory
												var lines = File.ReadAllLines(inputFilePath).Skip(1).ToArray();
												for (int i = 0; i < lines.Length; i++)
												{
																//setup
																var line = lines[i];

																//try this in case something funny happens
																try
																{
																				//check group validation count
																				var groups = regEx.Matches(line);
																				if (groups.Count != 1 && groups[0].Length != groupCount)
																								throw new Exception($"Invalid division format");

																				//parse division
																				var bg = groups[0].Groups;
																				var division = new EntryInfo()
																				{
																								TeamName = bg[1].Value,
																								EntryNumber = int.Parse(bg[2].Value)
																				};

																				//add bowlers to division
																				foreach (var bowler in bowlers.Where(f => f.Events.Any(g => g.EntryNumber == division.EntryNumber)))
																								division.Bowlers.Add(bowler);

																				results.Add(division);
																}
																catch (Exception ex)
																{
																				throw new Exception($"Unable to parse divison at line: { i + 2 } | for input { Environment.NewLine } >> { line } { Environment.NewLine } >> Reason: { ex.Message }");
																}
												}
												return results;
								}
				}
}
