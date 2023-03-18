Imports Ninject
Imports Data
Imports System.Web.Mvc
Imports Core.Services.UrlSrv
Imports Core.Services.Content

Namespace DI

    Public Class IoC

        Private Shared Kernel As IKernel

        Public Sub New()
            If Kernel Is Nothing Then
                Throw New Exception("IoC Kernel Not SetUp")
            End If
        End Sub

        Public Sub New(ByRef connectionString As String)
            Kernel = New StandardKernel()
            AddBindings(connectionString)
        End Sub

        Private Sub AddBindings(ByRef connectionString As String)
            With Kernel
                'data
                .Bind(Of IDBContext).To(Of Context).WithConstructorArgument("nameOrConnectionString", connectionString)

                'tables
                .Bind(Of ISetting).To(Of Repository.Setting)()
                .Bind(Of ILocalization).To(Of Repository.Localization)()
                .Bind(Of IHallOfFame_RecognitionType).To(Of Repository.HallOfFame_RecognitionType)()
                .Bind(Of IHallOfFame).To(Of Repository.HallOfFame)()
                .Bind(Of ITournament).To(Of Repository.Tournament)()
                .Bind(Of ITournament_Classification).To(Of Repository.Tournament_Classification)()
                .Bind(Of IHonor).To(Of Repository.Honor)()
                .Bind(Of IHonorType).To(Of Repository.HonorType)()
                .Bind(Of IHonorCategory).To(Of Repository.HonorCategory)()
                .Bind(Of IBoard).To(Of Repository.Board)()
                .Bind(Of IBoardPosition).To(Of Repository.BoardPosition)()
                .Bind(Of IBoardHistory).To(Of Repository.BoardHistory)()
                .Bind(Of ILink).To(Of Repository.Link)()
                .Bind(Of ITopic).To(Of Repository.Topic)()
                .Bind(Of IUser).To(Of Repository.User)()
                .Bind(Of IAward).To(Of Repository.Award)()
                .Bind(Of IAwardName).To(Of Repository.AwardName)()
                .Bind(Of IAwardDivision).To(Of Repository.AwardDivision)()
                .Bind(Of IAwardType).To(Of Repository.AwardType)()
                .Bind(Of IHomeLink).To(Of Repository.HomeLink)()
                .Bind(Of IUserRole).To(Of Repository.UserRole)()
                .Bind(Of IRole).To(Of Repository.Role)()
                .Bind(Of ISeasonAverage).To(Of Repository.SeasonAverage)()
                .Bind(Of ISeasonAverageBowler).To(Of Repository.SeasonAverageBowler)()
                .Bind(Of IEmailProfile).To(Of Repository.EmailProfile)()

                'Services
                .Bind(Of ITypeFinder).To(Of Plugin.TypeFinder)()
                .Bind(Of IEncryption).To(Of Security.Encryption)()
                .Bind(Of IUrlService).To(Of Services.UrlSrv.UrlServices)()
                .Bind(Of IRSSGen).To(Of Services.Content.RSSGen)()
                .Bind(Of ISearcher).To(Of Services.Content.Searcher)()
                .Bind(Of IPDFCreater).To(Of Services.Content.PDFCreater)()
                .Bind(Of ISeasonAverageService).To(Of Services.Bowling.SeasonAverageService)()
                .Bind(Of IHallOfFameService).To(Of HallOfFameService)()
                .Bind(Of IAccountService).To(Of AccountService)()
                .Bind(Of ISitemapService).To(Of SiteMap.SitemapService)()
                .Bind(Of IEmailService).To(Of EmailService)()

            End With
        End Sub

        Public Function [Get](ByRef T As Type) As Object
            Return Kernel.Get(T)
        End Function

        Public Function TryGet(ByRef type As Type) As Object
            Return Kernel.TryGet(type)
        End Function

        Public Function GetAll(ByRef type As Type) As IEnumerable(Of Object)
            Return Kernel.GetAll(type)
        End Function

    End Class

End Namespace
