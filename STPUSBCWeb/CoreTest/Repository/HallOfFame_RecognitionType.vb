Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class HallOfFame_RecognitionType : Inherits BaseTest

    <TestMethod()>
    Sub HallOfFame_Recognition_Create()
        'Arrange
        Dim IHofR As New Core.Repository.HallOfFame_RecognitionType(context)

        'Act
        Dim res As Boolean = IHofR.Create(TestHOF_Recognition)

        'Assert
        Assert.IsTrue(res, "HOF_Recognition Error Creating User")
    End Sub

    <TestMethod()>
    Sub HallOfFame_Recognition_Update()
        'Arrange
        Dim IHofR As New Core.Repository.HallOfFame_RecognitionType(context)
        Dim tr = TestHOF_Recognition()

        'Act
        IHofR.Create(tr)
        tr.Description = "Demo"
        IHofR.Update(tr)
        Dim ret = IHofR.ById(tr.Id)

        'Assert
        Assert.AreEqual("Demo", ret.Description, "HOF_Recognition Couldn't Update")
    End Sub

    <TestMethod()>
    Sub HallOfFame_Recognition_Delete()
        'Arrange
        Dim IHofR As New Core.Repository.HallOfFame_RecognitionType(context)
        Dim tr = TestHOF_Recognition()

        'Act
        IHofR.Create(tr)
        IHofR.Delete(tr)
        Dim ret = IHofR.ById(tr.Id)

        'Assert
        Assert.IsFalse(ret.Display, "HOF_Recognition Error Deleting")
    End Sub

    Private Function TestHOF_Recognition() As Data.Entity.HallOfFame_RecognitionType
        Return New Data.Entity.HallOfFame_RecognitionType With {
            .Description = "Test Type"
        }
    End Function

End Class
