Imports System.Configuration

<ConfigurationCollection(GetType(CompanySelectorInformation))>
Public Class CompanySelectorInformationCollection
    Inherits ConfigurationElementCollection

    Protected Overloads Overrides Function CreateNewElement() As System.Configuration.ConfigurationElement
        Return New CompanySelectorInformation
    End Function

    Protected Overrides Function GetElementKey(ByVal element As System.Configuration.ConfigurationElement) As Object
        Return CType(element, CompanySelectorInformation).ERPConnectionStringName
    End Function


End Class
