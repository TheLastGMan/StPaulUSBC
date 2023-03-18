Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class DBScript : Inherits BaseTest

    <TestMethod>
    Sub GenerateScript()
        Dim script As String = context.CreateDatabaseScript()

        'export script
        Using SW As New IO.StreamWriter("DBScript.sql", False)
            SW.Write(script)
        End Using

        Assert.IsTrue(script.Length > 0)
    End Sub

End Class
