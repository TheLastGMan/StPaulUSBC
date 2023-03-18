Imports iTextSharp.text
Imports System.Web.HttpContext

Namespace Services.Content

    Public Class PDFCreater : Implements IPDFCreater

        Private _loc As Core.ILocalization

        Public Sub New(LOC As Core.ILocalization)
            _loc = LOC
        End Sub

        Public Function HallOfFameProfile(ByRef profile As Data.Entity.HallOfFame) As System.IO.MemoryStream Implements IPDFCreater.HallOfFameProfile
            Dim logo As String = Current.Server.MapPath("~/content/images/USBC_Logo.jpg")

            Dim out As New System.IO.MemoryStream
            Dim doc As New Document(PageSize.LETTER)
            doc.AddAuthor("RPGCor | Ryan Gau")
            doc.AddCreationDate()
            doc.AddTitle(String.Format("{0} {1}", profile.FirstName, profile.LastName))

            Dim writer = pdf.PdfWriter.GetInstance(doc, out)
            writer.CloseStream = False
            writer.SetFullCompression()
            doc.Open()

            'Fonts
            Dim headfontloc As String = Current.Server.MapPath("~/content/fonts/huxtable.ttf")
            Dim headfont = pdf.BaseFont.CreateFont(headfontloc, pdf.BaseFont.CP1252, True)
            Dim headerfont As Font = New Font(headfont, 24, Font.UNDERLINE, BaseColor.BLUE)
            Dim headerfontred As Font = New Font(headfont, 24, Font.BOLD, BaseColor.RED)

            'header table
            Dim htable As New pdf.PdfPTable(2)
            htable.WidthPercentage = 100
            'Logo
            Dim logoimg As Image = Image.GetInstance(logo)
            logoimg.Alignment = Image.ALIGN_CENTER
            Dim lcell As New pdf.PdfPCell(logoimg)
            lcell.HorizontalAlignment = pdf.PdfPCell.ALIGN_CENTER
            lcell.Border = 0
            htable.AddCell(lcell)
            'header text
            Dim line1 As New Anchor(_loc.Msg("Shared.Header.Line1"), headerfont) With {.Leading = 100}
            line1.Reference = "http://" & Current.Request.Url.Authority
            Dim line2 As New Paragraph(_loc.Msg("Shared.Header.Line2"), headerfontred)
            Dim rtable As New pdf.PdfPTable(1)
            rtable.WidthPercentage = 100
            rtable.AddCell(New pdf.PdfPCell(line1) With {.Padding = 5, .Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER})
            rtable.AddCell(New pdf.PdfPCell(line2) With {.Padding = 5, .Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER})
            Dim rcell As New pdf.PdfPCell(rtable) With {.Border = 0}
            htable.AddCell(rcell)
            doc.Add(htable)

            'name
            doc.Add(New Paragraph(String.Format("{0} {1}", profile.FirstName, profile.LastName), New Font(headfont, 18)))

            doc.Close()
            out.Position = 0

            Return out
        End Function

        Public Function AwardForm(ByRef award As Data.Entity.Award, ByVal reportUrl As String) As System.IO.MemoryStream Implements IPDFCreater.AwardForm
            Dim logo As String = Current.Server.MapPath("~/content/images/USBC_AssocLogo.png")

            Dim out As New System.IO.MemoryStream
            Dim doc As New Document(PageSize.LETTER)
            doc.AddAuthor("RPGCor | Ryan Gau")
            doc.AddCreationDate()
            doc.AddTitle(FormatTitle(award))

            Dim writer = pdf.PdfWriter.GetInstance(doc, out)
            writer.CloseStream = False
            writer.SetFullCompression()
            doc.Open()

            'Fonts
            Dim headfontloc As String = Current.Server.MapPath("~/content/fonts/huxtable.ttf")
            Dim headfont = pdf.BaseFont.CreateFont(headfontloc, pdf.BaseFont.CP1252, True)
            Dim headerfont As Font = New Font(headfont, 24, Font.UNDERLINE, BaseColor.BLUE)
            Dim headerfontred As Font = New Font(headfont, 24, Font.BOLD, BaseColor.RED)

            'header table
            Dim htable As New pdf.PdfPTable(2)
            htable.WidthPercentage = 100
            'Logo
            Dim logoimg As Image = Image.GetInstance(logo)
            logoimg.ScalePercent((80 / logoimg.Height) * 100)
            logoimg.Alignment = Element.ALIGN_CENTER
            Dim lcell As New pdf.PdfPCell(logoimg)
            lcell.HorizontalAlignment = Element.ALIGN_CENTER
            lcell.Border = 0
            htable.AddCell(lcell)
            'header text
            Dim line1 As New Anchor(_loc.Msg("Shared.Header.Line1"), headerfont) With {.Leading = 100}
            line1.Reference = "http://" & Current.Request.Url.Authority
            Dim line2 As New Paragraph(_loc.Msg("Shared.Header.Line2"), headerfontred)
            Dim rtable As New pdf.PdfPTable(1)
            rtable.WidthPercentage = 100
            rtable.AddCell(New pdf.PdfPCell(line1) With {.Padding = 5, .Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER})
            rtable.AddCell(New pdf.PdfPCell(line2) With {.Padding = 5, .Border = 0, .HorizontalAlignment = Element.ALIGN_CENTER})
            Dim rcell As New pdf.PdfPCell(rtable) With {.Border = 0}
            htable.AddCell(rcell)
            doc.Add(htable)

            'Page Title
            Dim titlex As New Paragraph(FormatTitle(award), New Font(headfont, 28, Font.BOLD))
            titlex.Alignment = Element.ALIGN_CENTER
            titlex.Leading = 32
            doc.Add(titlex)

            doc.Add(New Paragraph(" ", FontFactory.GetFont("Arial", 14)))

            'Award Table
            Dim table As New pdf.PdfPTable({0.4, 0.6})
            table.WidthPercentage = 95
            table.HorizontalAlignment = Element.ALIGN_CENTER

            'ID
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.ID")))
            Dim idanchor As New Anchor(award.Id.ToString, FontFactory.GetFont("Arial", 12, Font.UNDERLINE, BaseColor.BLUE))
            idanchor.Reference = reportUrl
            table.AddCell(New pdf.PdfPCell(idanchor) With {.Padding = 5, .PaddingBottom = 10})
            'Date Bowled
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.DateBowled")))
            table.AddCell(CellRight(award.DateBowled.ToString("MMM-dd-yyyy")))
            'Award Type
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.AwardType")))
            table.AddCell(CellRight(award.AwardType.Description))
            'Bowler Name
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.BowlerName")))
            table.AddCell(CellRight(award.BowlerName))
            'USBC ID
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.USBCID")))
            table.AddCell(CellRight(award.USBCID))
            'Center
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.Center")))
            table.AddCell(CellRight(award.Center))
            'League
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.League")))
            table.AddCell(CellRight(award.League))
            'Average
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.BowlerAverage")))
            table.AddCell(CellRight(award.BowlerAverage))
            'Games
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.BowlerGames")))
            table.AddCell(CellRight(award.BowlerGames))
            'Game 1
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.Game1")))
            table.AddCell(CellRight(award.Game1))
            'Game 2
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.Game2")))
            table.AddCell(CellRight(award.Game2))
            'Game 3
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.Game3")))
            table.AddCell(CellRight(award.Game3))
            'Series
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.Series")))
            table.AddCell(CellRight(award.Series))
            'USBC Awards
            If award.USBCAwardList.Count > 0 Then
                table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.USBCAward")))
                table.AddCell(CellRight(String.Join(vbCrLf, award.USBCAwardList.ToArray)))
            End If
            'Local Awards
            If award.LocalAwardList.Count > 0 Then
                table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.LocalAward")))
                table.AddCell(CellRight(String.Join(vbCrLf, award.LocalAwardList.ToArray)))
                'Local Award Choice (Adult only)
                If award.AwardTypeId = 1 Then
                    table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.LocalAwardChoice")))
                    table.AddCell(CellRight(award.AdultAwardChoice))
                End If
            End If
            'Secretary Info Row
            table.AddCell(HeaderRow("Secretary Info", New Font(headfont, 16, Font.BOLD)))
            'Secretary Name
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.SecretaryName")))
            table.AddCell(CellRight(award.SecretaryName))
            'Secretary Pin
            table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.SecretaryPin")))
            If Current.User.IsInRole("Award") Then
                table.AddCell(CellRight(award.SecretaryPin))
            Else
                table.AddCell(CellRight(""))
            End If
            'Secretary Phone
            If Not String.IsNullOrEmpty(award.SecretaryPhone) Then
                table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.SecretaryPhone")))
                table.AddCell(CellRight(IIf(Current.User.IsInRole("Award"), award.SecretaryPhone, "*****")))
            End If
            'Secretary Email
            If Not String.IsNullOrEmpty(award.SecretaryEmail) Then
                table.AddCell(CellLeft(_loc.Msg("Award.PrintAward.SecretaryEmail")))
                table.AddCell(CellRight(IIf(Current.User.IsInRole("Award"), award.SecretaryEmail, "*****")))
            End If

            doc.Add(table)
            doc.Close()

            out.Position = 0
            Return out
        End Function

        Private Function HeaderRow(ByRef content As String, ByRef tfont As Font) As pdf.PdfPCell
            Dim ncell As New pdf.PdfPCell(New Paragraph(content, tfont))
            ncell.Colspan = 2
            ncell.PaddingBottom = 10
            ncell.HorizontalAlignment = pdf.PdfPCell.ALIGN_CENTER
            ncell.VerticalAlignment = pdf.PdfPCell.ALIGN_MIDDLE
            Return ncell
        End Function

        Private Function CellLeft(ByRef content As String) As pdf.PdfPCell
            Dim cell As New pdf.PdfPCell(New Phrase(content & " :"))
            cell.HorizontalAlignment = pdf.PdfPCell.ALIGN_RIGHT
            cell.VerticalAlignment = pdf.PdfPCell.ALIGN_MIDDLE
            cell.Padding = 5
            Return cell
        End Function

        Private Function CellRight(ByRef content As String) As pdf.PdfPCell
            Dim cell As New pdf.PdfPCell(New Phrase(content))
            cell.HorizontalAlignment = pdf.PdfPCell.ALIGN_LEFT
            cell.VerticalAlignment = pdf.PdfPCell.ALIGN_MIDDLE
            cell.Padding = 5
            Return cell
        End Function

        Private Function FormatTitle(ByRef award As Data.Entity.Award)
            Dim title As String = _loc.Msg("Award.PrintAward.Title")
            title = title.Replace("{Center}", award.Center)
            title = title.Replace("{League}", award.League)
            title = title.Replace("{BowlerName}", award.BowlerName)
            title = title.Replace("{DateBowled}", award.DateBowled.ToString("MMM-dd-yyyy"))
            title = title.Replace("{SecretaryName}", award.SecretaryName)
            Return title
        End Function

    End Class

End Namespace
