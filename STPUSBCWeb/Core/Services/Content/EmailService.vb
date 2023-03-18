Imports System.Net
Imports System.Net.Mail
Imports Data.Entity

Namespace Services.Content

    Public Class EmailService : Implements IEmailService

        ''' <summary>
        ''' Send and email using the specified profile
        ''' </summary>
        ''' <param name="profile">E-Mail profile</param>
        ''' <param name="sendTo">E-Mail to send message to</param>
        ''' <param name="subject">Subject of E-Mail</param>
        ''' <param name="htmlContent">Message Content</param>
        ''' <returns>T/F if send successfully</returns>
        Public Function SendEmail(ByVal profile As EmailProfile, ByVal sendTo As String, ByVal subject As String, ByVal htmlContent As String) As String Implements IEmailService.SendEmail
            Return SendEmail(profile, profile.DisplayName, sendTo, subject, Nothing, htmlContent)
        End Function

        Public Function SendEmail(profile As EmailProfile, fromName As String, sendTo As String, subject As String, replyTo As String, htmlContent As String) As String Implements IEmailService.SendEmail
            Try
                'create message
                Dim userEmail As New MailMessage()
                userEmail.To.Add(sendTo)
                userEmail.From = New MailAddress(profile.SendAs, fromName)
                userEmail.Subject = subject
                userEmail.IsBodyHtml = True
                userEmail.Body = htmlContent

                'add in reply-to if set
                If (Not String.IsNullOrEmpty(replyTo)) Then
                    userEmail.ReplyToList.Add(replyTo)
                End If

                'to authenticate we set the username and password properties on the SmtpClient
                Dim smtp As SmtpClient = New SmtpClient(profile.SmtpHost, profile.SmtpPort) With
                {
                    .UseDefaultCredentials = False,
                    .Credentials = New NetworkCredential(profile.UserName, profile.Password)
                }
                smtp.Send(userEmail)

                Return ""
            Catch ex As Exception
                Dim msg As String = ""
                Do
                    msg += ex.Message & " | "
                    ex = ex.InnerException
                Loop While (ex IsNot Nothing)
                Return msg
            End Try
        End Function
    End Class

End Namespace
