Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class Localization : Inherits BaseTest

    <TestMethod()>
    Public Sub Localization_Create()
        'Arrange
        Dim loc = TestLocalization()
        Dim ILoc = New Core.Repository.Localization(context)

        'Act
        Dim res As Boolean = ILoc.Create(loc)

        'Assert
        Assert.IsTrue(res, "Did Not Insert Localization")
    End Sub

    <TestMethod()>
    Public Sub Localization_Update()
        'Arrange
        Dim loc = TestLocalization()
        Dim ILoc = New Core.Repository.Localization(context)

        'Act
        Localization_Create()
        ILoc.Set(loc.Key, "MyValue2")
        Dim res As String = ILoc.ReadByKey(loc.Key).Value

        'Assert
        Assert.AreEqual("MyValue2", res, "Could Not Find Setting")
    End Sub

    <TestMethod()>
    Public Sub Localization_Delete()
        Dim loc = TestLocalization()
        Dim ILoc = New Core.Repository.Localization(context)

        'Act
        Localization_Create()
        ILoc.DeleteByKey(loc.Key)
        Dim res = ILoc.ReadByKey(loc.Key)

        'Assert
        Assert.IsNull(res, "Setting Still Found After Deletion")
    End Sub

    Private Function TestLocalization() As Data.Entity.Localization
        Dim out As New Data.Entity.Localization With {
            .Key = "MyLoc",
            .Value = "MyValue"
        }
        Return out
    End Function

End Class