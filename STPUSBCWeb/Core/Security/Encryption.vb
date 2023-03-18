Imports System.Text.Encoding
Imports System.Security
Imports System.Security.Cryptography

Namespace Security

    Public Class Encryption : Implements IEncryption

        Public ReadOnly Property Method As String Implements IEncryption.Method
            Get
                Return "SHA512-Rijndael"
            End Get
        End Property

        Private Function CreateKey(ByRef pass As String) As Byte()
            'Convert strPassword to an array and store in chrData.
            Dim chrData() As Char = pass.ToCharArray
            'Use intLength to get strPassword size.
            Dim intLength As Integer = chrData.GetUpperBound(0)
            'Declare bytDataToHash and make it the same size as chrData.
            Dim bytDataToHash(intLength) As Byte

            'Use For Next to convert and store chrData into bytDataToHash.
            For i As Integer = 0 To chrData.GetUpperBound(0)
                bytDataToHash(i) = CByte(Asc(chrData(i)))
            Next

            'Declare what hash to use.
            Dim SHA512 As New System.Security.Cryptography.SHA512Managed
            'Declare bytResult, Hash bytDataToHash and store it in bytResult.
            Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
            'Declare bytKey(31).  It will hold 256 bits.
            Dim bytKey(31) As Byte

            'Use For Next to put a specific size (256 bits) of 
            'bytResult into bytKey. The 0 To 31 will put the first 256 bits
            'of 512 bits into bytKey.
            For i As Integer = 0 To 31
                bytKey(i) = bytResult(i)
            Next

            Return bytKey 'Return the key.
        End Function

        Private Function CreateIV(ByRef pass As String) As Byte()
            'Convert strPassword to an array and store in chrData.
            Dim chrData() As Char = pass.ToCharArray
            'Use intLength to get strPassword size.
            Dim intLength As Integer = chrData.GetUpperBound(0)
            'Declare bytDataToHash and make it the same size as chrData.
            Dim bytDataToHash(intLength) As Byte

            'Use For Next to convert and store chrData into bytDataToHash.
            For i As Integer = 0 To chrData.GetUpperBound(0)
                bytDataToHash(i) = CByte(Asc(chrData(i)))
            Next

            'Declare what hash to use.
            Dim SHA512 As New System.Security.Cryptography.SHA512Managed
            'Declare bytResult, Hash bytDataToHash and store it in bytResult.
            Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
            'Declare bytIV(15).  It will hold 128 bits.
            Dim bytIV(15) As Byte

            'Use For Next to put a specific size (128 bits) of bytResult into bytIV.
            'The 0 To 30 for bytKey used the first 256 bits of the hashed password.
            'The 32 To 47 will put the next 128 bits into bytIV.
            For i As Integer = 32 To 47
                bytIV(i - 32) = bytResult(i)
            Next

            Return bytIV 'Return the IV.
        End Function

        'Inserts salt in middle of password
        Public Function Encrypt(ByRef str As String, ByRef salt As String) As String Implements IEncryption.Encrypt
            Dim start As Integer = Math.Floor(str.Length / 2)
            Dim parts() As String = {str.Substring(0, start), str.Substring(start)}
            Dim fullpwd As String = String.Format("{0}{1}{2}", parts(0), salt, parts(1))

            Return EncryptDecrypt(CryptoDirection.Encrypt, salt, fullpwd)
        End Function

        Public Function Decrypt(ByRef str As String, ByRef salt As String) As String Implements IEncryption.Decrypt
            Dim fullpwd As String = EncryptDecrypt(CryptoDirection.Decrypt, salt, str)

            Dim start As Integer = Math.Floor((fullpwd.Length - salt.Length) / 2)
            Dim parts() As String = {fullpwd.Substring(0, start), fullpwd.Substring(start + salt.Length)}

            Return String.Join("", parts)
        End Function

        Private Function EncryptDecrypt(ByRef action As CryptoDirection, ByRef salt As String, ByRef input As String) As String
            Dim key As Byte() = CreateKey(salt)
            Dim iv As Byte() = CreateIV(salt)

            Dim csCryptoStream As CryptoStream
            Dim csStream As New IO.MemoryStream
            Dim buffer As Byte()
            Select Case action
                Case CryptoDirection.Encrypt
                    csCryptoStream = New CryptoStream(csStream, New RijndaelManaged().CreateEncryptor(key, iv), CryptoStreamMode.Write)
                    buffer = ASCII.GetBytes(input)
                Case Else
                    csCryptoStream = New CryptoStream(csStream, New RijndaelManaged().CreateDecryptor(key, iv), CryptoStreamMode.Write)
                    buffer = System.Convert.FromBase64String(input)
            End Select
            csCryptoStream.Write(buffer, 0, buffer.Length)
            csCryptoStream.FlushFinalBlock()

            Dim res As Byte() = csStream.ToArray
            Dim out As String
            Select Case action
                Case CryptoDirection.Encrypt
                    out = System.Convert.ToBase64String(res)
                Case Else
                    out = ASCII.GetString(res)
            End Select

            csCryptoStream.Close()
            csStream.Close()
            Return out
        End Function

        Private Enum CryptoDirection As Byte
            Encrypt = 1
            Decrypt = 2
        End Enum

    End Class

End Namespace
