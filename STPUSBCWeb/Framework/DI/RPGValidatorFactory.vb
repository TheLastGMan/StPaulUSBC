Imports FluentValidation
Imports FluentValidation.Attributes
Namespace DI

    Public Class RPGValidatorFactory : Inherits AttributedValidatorFactory

        Public Overrides Function GetValidator(type As Type) As IValidator
            If type IsNot Nothing Then
                Dim attributex = DirectCast(Attribute.GetCustomAttribute(type, GetType(ValidatorAttribute)), ValidatorAttribute)
                If (attributex IsNot Nothing) AndAlso (attributex.ValidatorType IsNot Nothing) Then
                    Dim instance = New Core.DI.IoC().Get(attributex.ValidatorType)
                    Return DirectCast(instance, IValidator)
                End If
            End If
            Return Nothing
        End Function

    End Class

End Namespace