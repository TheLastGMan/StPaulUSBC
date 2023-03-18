Imports System.Web.Mvc
Imports System.Web.Mvc.Html
Imports System.Web.Routing
Imports System.Web.WebPages
Imports System.Text
Imports System.Runtime.CompilerServices
Imports AutoMapper

Public Module RPGMapper

#Region "Award"

    <Extension>
    Public Function ToModel(entity As Data.Entity.Award) As Models.Award.AwardModel
        Return Mapper.Map(Of Data.Entity.Award, Models.Award.AwardModel)(entity)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Award.AwardModel) As Data.Entity.Award
        Return Mapper.Map(Of Models.Award.AwardModel, Data.Entity.Award)(model)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Award.AwardModel, entity As Data.Entity.Award) As Data.Entity.Award
        Return Mapper.Map(model, entity)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Award.BowlerInfo, entity As Data.Entity.Award) As Data.Entity.Award
            Return Mapper.Map(model, entity)
    End Function

    <Extension>
    Public Function ToBowlerInfo(model As Data.Entity.Award) As Models.Award.BowlerInfo
        Return Mapper.Map(Of Data.Entity.Award, Models.Award.BowlerInfo)(model)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Award.SecretaryInfo, entity As Data.Entity.Award) As Data.Entity.Award
        Return Mapper.Map(model, entity)
    End Function

    'Admin View
    <Extension>
    Public Function ToManageModel(entity As Data.Entity.Award) As Models.Award.ManageModel
        Return Mapper.Map(Of Data.Entity.Award, Models.Award.ManageModel)(entity)
    End Function

#End Region

#Region "Account"

    <Extension>
    Public Function ToModel(entity As Data.Entity.User) As Models.Account.UserCreateModel
        Return Mapper.Map(Of Data.Entity.User, Models.Account.UserCreateModel)(entity)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Account.UserCreateModel) As Data.Entity.User
        Return Mapper.Map(Of Models.Account.UserCreateModel, Data.Entity.User)(model)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Account.UserCreateModel, entity As Data.Entity.User) As Data.Entity.User
        Return Mapper.Map(model, entity)
    End Function

#End Region

#Region "Board"

    <Extension>
    Public Function ToModel(entity As Data.Entity.Board) As Models.Board.BoardModel
        Return Mapper.Map(Of Data.Entity.Board, Models.Board.BoardModel)(entity)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Board.BoardModel) As Data.Entity.Board
        Return Mapper.Map(Of Models.Board.BoardModel, Data.Entity.Board)(model)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Board.BoardModel, entity As Data.Entity.Board) As Data.Entity.Board
        Return Mapper.Map(model, entity)
    End Function

#End Region

#Region "BoardPosition"

    <Extension>
    Public Function ToModel(entity As Data.Entity.BoardPosition) As Models.Board.BoardPositionModel
        Return Mapper.Map(Of Data.Entity.BoardPosition, Models.Board.BoardPositionModel)(entity)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Board.BoardPositionModel) As Data.Entity.BoardPosition
        Return Mapper.Map(Of Models.Board.BoardPositionModel, Data.Entity.BoardPosition)(model)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Board.BoardPositionModel, entity As Data.Entity.BoardPosition) As Data.Entity.BoardPosition
        Return Mapper.Map(model, entity)
    End Function

#End Region

#Region "BoardHistory"

    <Extension>
    Public Function ToModel(entity As Data.Entity.BoardHistory) As Models.Board.BoardHistoryModel
        Return Mapper.Map(Of Data.Entity.BoardHistory, Models.Board.BoardHistoryModel)(entity)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Board.BoardHistoryModel) As Data.Entity.BoardHistory
        Return Mapper.Map(Of Models.Board.BoardHistoryModel, Data.Entity.BoardHistory)(model)
    End Function

    <Extension>
    Public Function ToEntity(model As Models.Board.BoardHistoryModel, entity As Data.Entity.BoardHistory) As Data.Entity.BoardHistory
        Return Mapper.Map(model, entity)
    End Function

#End Region

End Module
