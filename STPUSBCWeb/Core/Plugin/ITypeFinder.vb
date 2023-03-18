Imports System.Reflection

Public Interface ITypeFinder

    Function FindClassesOfType(Of T)() As List(Of Type)
    Function FindClassesOfType(Of T)(ByRef Assembly As Assembly) As Type
    Function FindClassesOfType(ByRef Type As Type, ByRef assembiles As List(Of Assembly)) As List(Of Type)
    Function getAssemblies() As List(Of Assembly)

End Interface
