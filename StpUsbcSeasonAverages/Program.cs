using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace StpUsbcSeasonAverages
{
    class Program
    {
        private static Settings settings = null;

        static void Main(string[] args)
        {
            settings = SettingReader.ReadSettings();
            var pgm = new Program();

            //convert file to be imported to web
            Console.WriteLine(@"Creating upload file");
            Console.WriteLine(@"Expecting: {Name (LastName, FirstName[ MI][, Suffix]), National ID, Average with Hand, Games, League}");
            pgm.CreateUploadFile(new FileInfo(settings.YearbookCSV), new FileInfo(settings.YearbookUploadOutputFile), settings.Season);

            Console.WriteLine("");
            Console.WriteLine(@"Creating average booklet");
            pgm.CreateBooklet(new FileInfo(settings.Booklet.CoverFile), new FileInfo(settings.Booklet.BackFile), new FileInfo(settings.Booklet.FooterFile), new FileInfo(settings.Booklet.OutputFile), new FileInfo(settings.YearbookCSV), settings.Season);

            Console.WriteLine("");
            Console.WriteLine(@"Finding bowlers on most leagues");
            var bowlers = pgm.GreatestLeagueBowlers(new FileInfo(settings.YearbookCSV), settings.Season);
            Console.WriteLine(@"Most Leagues: " + bowlers.First().Value.Count);
            foreach (var bi in bowlers)
                Console.WriteLine(bi.Key.PadRight(12, ' ') + " | " + bi.Value.First().Name);

            Console.WriteLine("");
            Console.WriteLine(@"Loading leagues bowled spread");
            var spread = pgm.LeaguesBowledSpread(new FileInfo(settings.YearbookCSV), settings.Season);
            foreach (var sp in spread.OrderBy(f => f.Key))
                Console.WriteLine(sp.Key.ToString().PadRight(3, ' ') + " : " + sp.Value);

            Console.WriteLine();
            Console.WriteLine("Done, press any key to continue...");
            Console.Read();
        }

        public IDictionary<int, int> LeaguesBowledSpread(FileInfo inputFile, string season)
        {
            var spread = new Dictionary<int, int>();

            foreach (var bi in LoadBowlers(inputFile, season))
                if (spread.ContainsKey(bi.Count))
                    spread[bi.Count] += 1;
                else
                    spread.Add(bi.Count, 1);

            return spread;
        }

        public IDictionary<string, IReadOnlyList<BowlerInfo>> GreatestLeagueBowlers(FileInfo inputFile, string season)
        {
            var bowlers = new Dictionary<string, IReadOnlyList<BowlerInfo>>();

            foreach (var bi in LoadBowlers(inputFile, season))
            {
                if (bowlers.Count == 0)
                {
                    //first entry
                    bowlers.Add(bi.First().USBC_Id, bi.ToList());
                }
                else if (bi.Count == bowlers.First().Value.Count)
                {
                    //same count, add
                    bowlers.Add(bi.First().USBC_Id, bi.ToList());
                }
                else if (bi.Count > bowlers.First().Value.Count)
                {
                    //new highest
                    bowlers.Clear();
                    bowlers.Add(bi.First().USBC_Id, bi.ToList());
                }
            }

            return bowlers;
        }

        /// <summary>
        /// Loads the CSV of bowler averages
        /// {Name (LastName, FirstName[ MI][, Suffix]), National ID, Average with Hand, Games, League}
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="season"></param>
        /// <returns></returns>
        private IEnumerable<BowlerInfo> LoadFile(FileInfo inputFile, string season)
        {
            using (var sr = new StreamReader(inputFile.FullName))
            {
                bool header = true;
                string line = String.Empty;
                while (!String.IsNullOrEmpty((line = sr.ReadLine())))
                {
                    //check for header
                    if (header)
                    {
                        header = false;
                        continue;
                    }

                    //split into parts
                    string[] parts = line.Split(',');
                    if (parts[0].Trim().Length != 0)
                    {
                        //get name and resize parts
                        string name = parts[0];
                        int idx = 1;
                        while (idx < parts.Length)
                        {
                            name += "," + parts[idx];
                            if (parts[idx].Contains('"'))
                                break;

                            idx += 1;
                        }
                        idx += 1;

                        name = name.Trim('"');

                        parts = new string[] { name }.Concat(parts.Skip(idx)).ToArray();
                    }

                    //map to output
                    //split name into parts
                    string[] nameParts = parts[0].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    string lastName = String.Empty;
                    string mi = String.Empty;
                    string suffix = String.Empty;
                    string firstName = String.Empty;

                    //load parts if a first name exists
                    if (nameParts.Length > 0)
                    {
                        lastName = nameParts[0].Trim();
                        suffix = nameParts.Length >= 3 ? nameParts[2].Trim() : String.Empty;

                        //, Dorinda (DeeDee) L
                        string[] fNames = nameParts[1].Trim().Split(' ');
                        if (fNames.Length > 1 && fNames.Last().Trim().Length == 1)
                        {
                            mi = fNames.Last().Trim();
                            firstName = String.Join(" ", fNames.Take(fNames.Length - 1));
                        }
                        else
                        {
                            firstName = nameParts[1].Trim();
                        }
                    }

                    //parse hand from averages
                    string avg = parts[2].Replace(" ", "").Replace("R", "");
                    string hand = "";
                    int average = 0;
                    int index = avg.Length;
                    while (index >= 0)
                    {
                        if (int.TryParse(avg.Substring(0, index), out average))
                            break;
                        index -= 1;
                    }
                    hand = avg.Substring(index);

                    //output to the file
                    var bi = new BowlerInfo
                    {
                        LastName = lastName,
                        FirstName = firstName,
                        MI = mi,
                        Suffix = suffix,
                        Hand = hand,
                        Average = average.ToString(),
                        Season = season,
                        USBC_Id = parts[1],
                        Games = parts[3],
                        League = parts[4]
                    };
                    yield return bi;
                }
            }
        }

        private IEnumerable<IList<BowlerInfo>> LoadBowlers(FileInfo inputFile, string season)
        {
            var bowlerInfo = new List<BowlerInfo>(16);
            string lastId = String.Empty;
            foreach (var bi in LoadFile(inputFile, season))
            {
                if (lastId == String.Empty)
                {
                    lastId = bi.USBC_Id;
                    bowlerInfo.Add(bi);
                    continue;
                }

                if (String.IsNullOrEmpty(bi.LastName))
                    //add to current selection
                    bowlerInfo.Add(bi);
                else
                {
                    //new bowler
                    yield return bowlerInfo;

                    //setup for new entry
                    bowlerInfo.Clear();
                    lastId = bi.USBC_Id;
                    bowlerInfo.Add(bi);
                }
            }

            yield return bowlerInfo;
        }

        private PdfPCell CreateCell(string text, int alignment, BaseColor bgColor = null)
        {
            var p = new Phrase(text, PdfBaseFont());
            var cell = new PdfPCell(p);
            cell.HorizontalAlignment = alignment;
            cell.Padding = 0;
            cell.ExtraParagraphSpace = 2;
            cell.Border = 0;
            cell.BackgroundColor = (bgColor == null) ? BaseColor.WHITE : bgColor;
            return cell;
        }

        private iTextSharp.text.Font PdfBaseFont()
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, settings.AveragePage.FontSize, iTextSharp.text.Font.NORMAL);
            return font;
        }

        private void CreateBowlerPage(Document booklet, PdfWriter writer, IList<BowlerInfo> leftColumn, IList<BowlerInfo> rightColumn, FileInfo footerPage)
        {
            string[] headers = settings.AveragePage.Headers.Select(f => f.Text).ToArray();
            int[] cellAlignments = settings.AveragePage.Headers.Select(f =>
                                        {
                                            switch (f.Align)
                                            {
                                                case Alignment.LEFT:
                                                    return Element.ALIGN_LEFT;
                                                case Alignment.CENTER:
                                                    return Element.ALIGN_CENTER;
                                                default:
                                                    return Element.ALIGN_RIGHT;
                                            }
                                        }).ToArray();
            float[] columnWidths = settings.AveragePage.Headers.Select(f => f.Width).ToArray();

            var table = new PdfPTable(columnWidths.Length);
            table.SetWidths(columnWidths);
            table.TotalWidth = 100;
            table.WidthPercentage = 100;
            table.SpacingBefore = 0;
            table.SpacingAfter = 0;

            //add header
            booklet.NewPage();

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, settings.AveragePage.FontSize, iTextSharp.text.Font.BOLD);
            for (int i = 0; i < columnWidths.Length; i++)
            {
                var phrase = new Phrase(i <= settings.AveragePage.CenterColumnIndex ? headers[i] : (rightColumn.Any(f => f.Valid) ? headers[i] : String.Empty), font);
                var cell = new PdfPCell(phrase);
                cell.HorizontalAlignment = cellAlignments[i];
                cell.Border = 0;

                //center stripe
                if (i == settings.AveragePage.CenterColumnIndex)
                    cell.BackgroundColor = BaseColor.BLACK;

                if (i <= settings.AveragePage.CenterColumnIndex || rightColumn.Any(f => f.Valid))
                {
                    cell.BorderWidthBottom = 0.2F;
                    cell.PaddingBottom = 3F;
                    cell.BorderColorBottom = BaseColor.BLACK;
                }

                table.AddCell(cell);
            }
            table.CompleteRow();
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            //add rows
            for (int i = 0; i < leftColumn.Count; i++)
            {
                var lb = leftColumn[i];
                var rb = rightColumn[i];

                //Name
                table.AddCell(CreateCell(lb.Name, cellAlignments[0]));

                //USBC ID
                table.AddCell(CreateCell(lb.USBC_Id, cellAlignments[1]));

                //Average
                table.AddCell(CreateCell(lb.Average + " " + lb.Hand, cellAlignments[2]));

                //Games
                table.AddCell(CreateCell(lb.Games, cellAlignments[3]));

                //League
                table.AddCell(CreateCell(lb.League, cellAlignments[4]));

                //Spacer
                table.AddCell(CreateCell(String.Empty, cellAlignments[5]));
                table.AddCell(CreateCell(String.Empty, cellAlignments[6], BaseColor.BLACK));
                table.AddCell(CreateCell(String.Empty, cellAlignments[7]));

                //Name
                table.AddCell(CreateCell(rb.Name, cellAlignments[8]));

                //USBC ID
                table.AddCell(CreateCell(rb.USBC_Id, cellAlignments[9]));

                //Average
                table.AddCell(CreateCell(rb.Average + " " + rb.Hand, cellAlignments[10]));

                //Games
                table.AddCell(CreateCell(rb.Games, cellAlignments[11]));

                //League
                table.AddCell(CreateCell(rb.League, cellAlignments[12]));

                table.CompleteRow();
            }
            table.Complete = true;
            booklet.Add(table);

            //import footer
            if (footerPage.Exists)
            {
                var reader = new PdfReader(footerPage.FullName);
                var importedPage = writer.GetImportedPage(reader, 1);
                var pageImg = iTextSharp.text.Image.GetInstance(importedPage);
                pageImg.Bottom = 0;
                pageImg.PaddingTop = 4;
                pageImg.SetAbsolutePosition(0, booklet.GetBottom(0) - pageImg.GetBottom(0));
                booklet.Add(pageImg);
            }

            //increment page count
            booklet.PageCount = booklet.PageNumber + 1;
        }

        public void CreateBooklet(FileInfo cover, FileInfo back, FileInfo footer, FileInfo outputFile, FileInfo inputFile, string season)
        {
            float marginTop = 72 * settings.AveragePage.Margins.InTop;
            float marginRight = 72 * settings.AveragePage.Margins.InRight;
            float marginBottom = 72 * settings.AveragePage.Margins.InBottom;
            float marginLeft = 72 * settings.AveragePage.Margins.InLeft;
            var booklet = new Document(PageSize.LETTER, marginLeft, marginRight, marginTop, marginBottom);
            var writer = PdfWriter.GetInstance(booklet, new FileStream(outputFile.FullName, FileMode.Create));

            booklet.AddAuthor("RPGCor");
            booklet.AddLanguage("en-US");
            booklet.AddTitle("St. Paul USBC Season Averages");
            booklet.Open();

            //import header
            if (cover.Exists)
            {
                var bgReader = new PdfReader(cover.FullName);
                for (int p = 1; p <= bgReader.NumberOfPages; p++)
                {
                    booklet.NewPage();
                    var bg = writer.GetImportedPage(bgReader, p);
                    writer.DirectContentUnder.AddTemplate(bg, 0, 0);
                }
                booklet.PageCount = bgReader.NumberOfPages;

                //ensure book starts on an odd page
                if (booklet.PageNumber % 2 == 1)
                    AddBlankPage(booklet, writer);
            }

            //create pages
            var storedBowler = new List<BowlerInfo>(16);
            while (true)
            {
                //load bowlers
                var leftColumn = new List<BowlerInfo>(64);
                var rightColumn = new List<BowlerInfo>(64);

                //get next bowler
                leftColumn.AddRange(storedBowler);
                storedBowler.Clear();

                //parse into columns
                int rowsPerPage = settings.AveragePage.RowsPerPage;
                foreach (var bi in LoadBowlers(inputFile, season))
                {
                    int index = leftColumn.Count + rightColumn.Count + bi.Count;

                    if (index <= rowsPerPage)
                        //add to left hand column
                        leftColumn.AddRange(bi);
                    else if (leftColumn.Count < rowsPerPage)
                    {
                        //fill left column
                        while (leftColumn.Count < rowsPerPage)
                            leftColumn.Add(new BowlerInfo());

                        rightColumn.AddRange(bi);
                    }
                    else if (index < (rowsPerPage * 2))
                        rightColumn.AddRange(bi);
                    else if (index == (rowsPerPage * 2))
                    {
                        rightColumn.AddRange(bi);

                        //make page
                        CreateBowlerPage(booklet, writer, leftColumn, rightColumn, footer);

                        //clear for next
                        leftColumn.Clear();
                        rightColumn.Clear();
                    }
                    else
                    {
                        //fill right column
                        while (rightColumn.Count < rowsPerPage)
                            rightColumn.Add(new BowlerInfo());

                        //make page
                        CreateBowlerPage(booklet, writer, leftColumn, rightColumn, footer);

                        //clear for next
                        leftColumn.Clear();
                        leftColumn.AddRange(bi);
                        rightColumn.Clear();
                    }
                }

                //check for one more page
                if (leftColumn.Any())
                {
                    //update right column to match left column
                    while (leftColumn.Count != rightColumn.Count)
                        rightColumn.Add(new BowlerInfo());

                    //create final page
                    CreateBowlerPage(booklet, writer, leftColumn, rightColumn, footer);
                }
                break;
            }

            //import back
            if (back.Exists)
            {
                var backReader = new PdfReader(back.FullName);
                int backPages = backReader.NumberOfPages;

                //add blank pages to ensure that [booklet + back] is an even page count
                if ((booklet.PageNumber + backReader.NumberOfPages) % 2 == 1)
                    AddBlankPage(booklet, writer);

                //add in back
                for (int p = 1; p <= backReader.NumberOfPages; p++)
                {
                    booklet.NewPage();
                    var bg = writer.GetImportedPage(backReader, p);
                    writer.DirectContentUnder.AddTemplate(bg, 0, 0);
                }
            }
            else
            {
                //just ensure booklet has even number of pages
                if (booklet.PageNumber % 2 == 1)
                    AddBlankPage(booklet, writer);
            }

            booklet.Close();
        }

        private void AddBlankPage(Document booklet, PdfWriter writer)
        {
            booklet.NewPage();
            var bfi = new FileInfo(settings.Booklet.BlankFile);
            if (bfi.Exists)
            {
                var bgReader = new PdfReader(bfi.FullName);
                var bg = writer.GetImportedPage(bgReader, 1);
                writer.DirectContentUnder.AddTemplate(bg, 0, 0);
            }
            else
            {
                //generic blank page
                booklet.Add(new Paragraph(" ") { Alignment = Element.ALIGN_CENTER });
            }

            //increment page count
            booklet.PageCount = booklet.PageNumber + 1;
        }

        public void CreateUploadFile(FileInfo inputFile, FileInfo outputFile, string season)
        {
            //Name ,National ID,Avg,Games,Leagues
            using (var sw = new StreamWriter(outputFile.FullName))
            {
                sw.WriteLine(@"LastName,FirstName,MI,Suffix,USBC-ID,Average,Games,Hand [\*|L|R|S]*,League,Season");
                foreach (var bi in LoadFile(inputFile, season))
                {
                    string[] outputLineParts = { bi.LastName, bi.FirstName, bi.MI, bi.Suffix, bi.USBC_Id, bi.Average, bi.Games, bi.Hand, bi.League, bi.Season };
                    string outputLine = String.Join(",", outputLineParts);
                    sw.WriteLine(outputLine);
                }
            }
        }
    }
}
