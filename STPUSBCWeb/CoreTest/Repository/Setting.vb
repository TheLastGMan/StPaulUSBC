Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Moq

<TestClass()>
Public Class Setting : Inherits BaseTest

    <TestMethod()>
    Public Sub Setting_Insert()
        'Arrange
        Dim setting = TestSetting()
        Dim ISet = New Core.Repository.Setting(context)

        'Act
        Dim res As Boolean = ISet.Create(setting)

        'Assert
        Assert.IsTrue(res, "Did Not Insert Setting")
    End Sub

    <TestMethod()>
    Public Sub Setting_Update()
        'Arrange
        Dim setting = TestSetting()
        Dim ISet = New Core.Repository.Setting(context)

        'Act
        Setting_Insert()
        ISet.Set(setting.Key, "MyValue2")
        Dim res As String = ISet.ReadByKey(setting.Key)

        'Assert
        Assert.AreEqual("MyValue2", res, "Could Not Find Setting")
    End Sub

    <TestMethod()>
    Public Sub Setting_Delete()
        Dim setting = TestSetting()
        Dim ISet = New Core.Repository.Setting(context)

        'Act
        Setting_Insert()
        ISet.DeleteByKey(setting.Key)
        Dim res As Boolean = String.IsNullOrEmpty(ISet.ReadByKey(setting.Key))

        'Assert
        Assert.IsTrue(res, "Setting Still Found After Deletion")
    End Sub

    Private Function TestSetting() As Data.Entity.Setting
        Dim res As New Data.Entity.Setting
        With res
            .Key = "MyKey"
            .Value = "MyValue"
        End With
        Return res
    End Function

End Class