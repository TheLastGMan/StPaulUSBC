Imports System.Drawing
Imports System.Drawing.Imaging

Public Class HallOfFameService : Implements IHallOfFameService

    Private _repos As IHallOfFame
    Private Shared Property LockMe As New Object

    Public Sub New(Repository As IHallOfFame)
        _repos = Repository
    End Sub

    Public Function BriefList(ByRef sortmethod As Services.HallOfFame.SortMethod) As List(Of HOF_BriefModel) Implements IHallOfFameService.BriefList
        Dim lst As IQueryable(Of Data.Entity.HallOfFame) = _repos.Entities

        Select Case sortmethod
            Case Services.HallOfFame.SortMethod.NameDESC
                lst = lst.OrderByDescending(Function(f) f.LastName).ThenBy(Function(f) f.FirstName)
            Case Services.HallOfFame.SortMethod.AchievedASC
                lst = lst.OrderBy(Function(f) f.Achieved)
            Case Services.HallOfFame.SortMethod.AchievedDESC
                lst = lst.OrderByDescending(Function(f) f.Achieved)
            Case Services.HallOfFame.SortMethod.RecognitionASC
                lst = lst.OrderBy(Function(f) f.HallOfFame_RecognitionType.Description)
            Case Services.HallOfFame.SortMethod.RecognitionDESC
                lst = lst.OrderByDescending(Function(f) f.HallOfFame_RecognitionType.Description)
            Case Else
                'name ASC
                lst = lst.OrderBy(Function(f) f.LastName).ThenBy(Function(f) f.FirstName)
        End Select

        Return lst.Select(Function(f) New HOF_BriefModel With {
                                        .id = f.Id,
                                        .First_Name = f.FirstName,
                                        .Last_Name = f.LastName,
                                        .Awareded = f.Achieved,
                                        .Deceased = f.Deceased,
                                        .RecognitionName = f.HallOfFame_RecognitionType.Description,
                                        .USBC_ID = f.USBC_ID}).ToList
    End Function

    Public Function ProfilePicture(ByRef id As Integer) As HOF_ProfilePicture Implements IHallOfFameService.ProfilePicture
        Dim file As String = String.Format("{0}.jpg", id)
        Dim folder As String = System.Web.HttpContext.Current.Server.MapPath("~" & ImageUploadPath)
        Dim searchpath As String = IO.Path.Combine(folder, file)
        If IO.File.Exists(searchpath) Then
            Return New HOF_ProfilePicture With {.URL = IO.Path.Combine(ImageUploadPath, file)}
        Else
            'does not exist
            Return New HOF_ProfilePicture With {.URL = "/content/images/no-profile.png"}
        End If
    End Function

    Public Function SaveProfilePicture(ByRef id As Integer, ByRef image() As Byte, ByRef mime As String) As Boolean Implements IHallOfFameService.SaveProfilePicture
        Dim u = _repos.ById(id)

        Dim localpath As String = System.Web.HttpContext.Current.Server.MapPath("~" & ImageUploadPath)
        Dim file_org As String = String.Format("{0}_full.{1}", id, mime)
        Dim file As String = String.Format("{0}.jpg", id)
        Dim fullpath As String = IO.Path.Combine(localpath, file_org)

        IO.Directory.CreateDirectory(localpath)
        SyncLock LockMe
            Using SW As New IO.StreamWriter(fullpath, False)
                SW.BaseStream.Write(image, 0, image.Length)
            End Using
        End SyncLock


        Dim b = New Bitmap(fullpath)
        fullpath = IO.Path.Combine(localpath, file)

        Dim newsize = CalcDimensions(b.Size, 360)
        Dim bitmap = New Bitmap(newsize.Width, newsize.Height)

        Dim g = Graphics.FromImage(bitmap)
        With g
            .SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            .CompositingQuality = Drawing2D.CompositingQuality.HighQuality
            .PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
            .DrawImage(b, 0, 0, newsize.Width, newsize.Height)

            Dim ep = New EncoderParameters()
            ep.Param(0) = New EncoderParameter(Imaging.Encoder.Quality, 80)
            Dim iciary = ImageCodecInfo.GetImageEncoders
            Dim ici = iciary.Where(Function(f) f.MimeType.Equals("image/jpeg", StringComparison.OrdinalIgnoreCase)).FirstOrDefault

            bitmap.Save(fullpath, ici, ep)
            bitmap.Dispose()
            b.Dispose()
        End With

        Return _repos.Update(u)
    End Function

    Private Function CalcDimensions(ByRef source As Size, ByRef targetheight As Integer) As Size
        Dim newsize As New Size
        'format to a height of the target height
        newsize.Width = source.Width * (targetheight / source.Height)
        newsize.Height = targetheight
        Return newsize
    End Function

    Private ReadOnly Property ImageUploadPath As String
        Get
            Return "/uploads/images/halloffame/"
        End Get
    End Property

End Class
