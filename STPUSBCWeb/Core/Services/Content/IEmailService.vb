Public Interface IEmailService

    Function SendEmail(ByVal profile As Data.Entity.EmailProfile, ByVal sendTo As String, ByVal subject As String, ByVal htmlContent As String) As String
    Function SendEmail(profile As Data.Entity.EmailProfile, fromName As String, sendTo As String, subject As String, replyTo As String, htmlContent As String) As String

End Interface
