Imports AutoMapper
Public Class RPGMapperConfig

    Public Shared Sub MapSetup()

        Mapper.Initialize(Sub(cfg)
                              'Award
                              cfg.CreateMap(Of Models.Award.AwardModel, Data.Entity.Award)()
                              cfg.CreateMap(Of Data.Entity.Award, Models.Award.AwardModel)()
                              cfg.CreateMap(Of Data.Entity.Award, Models.Award.ManageModel)()

                              cfg.CreateMap(Of Models.Award.BowlerInfo, Data.Entity.Award)()
                              cfg.CreateMap(Of Data.Entity.Award, Models.Award.BowlerInfo)()
                              cfg.CreateMap(Of Models.Award.USBCAwards, Data.Entity.Award)()
                              cfg.CreateMap(Of Models.Award.LocalAwards, Data.Entity.Award)()
                              cfg.CreateMap(Of Models.Award.SecretaryInfo, Data.Entity.Award)()

                              'Account
                              cfg.CreateMap(Of Models.Account.UserCreateModel, Data.Entity.User)()
                              cfg.CreateMap(Of Data.Entity.User, Models.Account.UserCreateModel)()

                              'Board
                              cfg.CreateMap(Of Models.Board.BoardModel, Data.Entity.Board)()
                              cfg.CreateMap(Of Data.Entity.Board, Models.Board.BoardModel)()

                              cfg.CreateMap(Of Models.Board.BoardHistoryModel, Data.Entity.BoardHistory)()
                              cfg.CreateMap(Of Data.Entity.BoardHistory, Models.Board.BoardHistoryModel)()

                              cfg.CreateMap(Of Models.Board.BoardPositionModel, Data.Entity.BoardPosition)()
                              cfg.CreateMap(Of Data.Entity.BoardPosition, Models.Board.BoardPositionModel)()
                          End Sub)
    End Sub

End Class
