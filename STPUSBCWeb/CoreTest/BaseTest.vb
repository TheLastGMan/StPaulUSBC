Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class BaseTest

    Protected context As Data.Context

    <TestInitialize>
    Public Sub SetUp()
        context = New Data.Context(GetTestConStr())
        'context.Database.Delete()
        'context.Database.Create()
    End Sub

    Private ReadOnly Property GetTestConStr As String
        Get
            Return "Data Source=.\SQLEXPRESS;Initial Catalog=STPUSBC_UnitTest;Persist Security Info=True;Integrated Security=SSPI;"
        End Get
    End Property

End Class