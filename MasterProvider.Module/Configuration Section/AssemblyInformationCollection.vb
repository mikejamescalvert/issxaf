Imports System.Configuration

<ConfigurationCollection(GetType(AssemblyInformation))> _
Public Class AssemblyInformationCollection
    Inherits ConfigurationElementCollection

    Protected Overloads Overrides Function CreateNewElement() As System.Configuration.ConfigurationElement
        Return New AssemblyInformation
    End Function

    Protected Overrides Function GetElementKey(ByVal element As System.Configuration.ConfigurationElement) As Object
        Return CType(element, AssemblyInformation).AssemblyName
    End Function


End Class
