Public Interface IEncryption

    Function Encrypt(ByRef str As String, ByRef salt As String) As String
    Function Decrypt(ByRef str As String, ByRef salt As String) As String
    ReadOnly Property Method As String

End Interface
