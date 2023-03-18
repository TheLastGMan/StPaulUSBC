Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class Encryption

    <TestMethod>
    Sub EncryptDecrypt_OddLength()
        Dim SM As New Core.Security.Encryption()
        Dim un As String = "admin"
        Dim pwd As String = "admin"

        Dim enc As String = SM.Encrypt(pwd, un)
        Dim res As String = SM.Decrypt(enc, un)

        Assert.AreEqual(pwd, res)
    End Sub

    <TestMethod>
    Sub EncryptDecrypt_EvenLength()
        Dim SM As New Core.Security.Encryption
        Dim un As String = "testuser"
        Dim pwd As String = "123  678"

        Dim enc As String = SM.Encrypt(pwd, un)
        Dim res As String = SM.Decrypt(enc, un)

        Assert.AreEqual(pwd, res)
    End Sub

End Class
