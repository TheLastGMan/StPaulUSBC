Imports Data
Public Interface IHallOfFame : Inherits ICrudInterface(Of Entity.HallOfFame)

    Function GetBy_USBCId(ByRef usbc As String) As Entity.HallOfFame
    Function Search_LastName_BeginsWith(ByRef lname As String) As List(Of Entity.HallOfFame)
    Function Achieved_Range(ByRef start_date As Date, ByRef end_date As Date) As List(Of Entity.HallOfFame)
    Function ById(ByRef id As Integer) As Entity.HallOfFame
    Function ByGuid(ByRef guid As String) As Entity.HallOfFame
    Function DeleteById(ByRef id As Integer) As Boolean
    Function GetAll(Optional ByVal IsOnlyVisible As Boolean = True) As List(Of Entity.HallOfFame)
    Function ActivateChange(ByRef id As Integer, ByRef status As Boolean) As Boolean

End Interface
