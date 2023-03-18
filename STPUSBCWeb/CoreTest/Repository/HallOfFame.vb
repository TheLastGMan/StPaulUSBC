Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class HallOfFame : Inherits BaseTest

    <TestMethod()>
    Sub HallOfFame_Create()
        'Arrange
        Dim IHof As New Core.Repository.HallOfFame(context)
        Dim hof = TestHallOfFame()

        'Act
        Dim res As Boolean = IHof.Create(hof)

        'Assert
        Assert.IsTrue(res, "Could Not Create Hall Of Fame User")
    End Sub

    <TestMethod()>
    Sub HallOfFame_Update()
        'Arrange
        Dim IHof As New Core.Repository.HallOfFame(context)
        Dim hof = TestHallOfFame()

        'Act
        IHof.Create(hof)
        hof.LastName = "Demo"
        IHof.Update(hof)
        Dim res = IHof.ById(hof.Id)

        'Assert
        Assert.AreEqual("Demo", res.LastName, "Error Updating Hall Of Fame Person")
    End Sub

    <TestMethod()>
    Sub HallOfFame_Delete()
        'Arrange
        Dim IHof As New Core.Repository.HallOfFame(context)
        Dim hof = TestHallOfFame()

        'Act
        IHof.Create(hof)
        IHof.DeleteById(hof.Id)
        Dim ret = IHof.ById(hof.Id)

        'Assert
        Assert.IsFalse(ret.Display, "Could Not Delete Hall Of Fame Person")
    End Sub

    Private Function TestHallOfFame() As Data.Entity.HallOfFame
        Return New Data.Entity.HallOfFame With {
            .FirstName = "Ryan",
            .LastName = "Gau",
            .Achieved = New Date(2012, 1, 1),
            .USBC_ID = "314159-2653589",
            .WriteUp = "Test"}
    End Function

    Private Function TestRecognition() As Data.Entity.HallOfFame_RecognitionType
        Return New Data.Entity.HallOfFame_RecognitionType With {
            .Id = 1,
            .Description = "Test Honors",
            .Display = True}
    End Function

End Class
