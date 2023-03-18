Public Interface IHallOfFameService

    Function BriefList(ByRef sortmethod As Services.HallOfFame.SortMethod) As List(Of HOF_BriefModel)
    Function ProfilePicture(ByRef id As Integer) As HOF_ProfilePicture
    Function SaveProfilePicture(ByRef id As Integer, ByRef image() As Byte, ByRef mime As String) As Boolean

End Interface
