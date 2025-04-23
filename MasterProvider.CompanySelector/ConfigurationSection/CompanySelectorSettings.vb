Imports System.Configuration

Public Class CompanySelectorSettings
    Inherits ConfigurationSection

    Public Shared Function GetInstance() As CompanySelectorSettings
        Return ConfigurationManager.GetSection("companySelectorSettings")
    End Function

    <ConfigurationProperty("companySelectorInformation")>
    Public ReadOnly Property CompanySelectorInformation As CompanySelectorInformationCollection
        Get
            Return CType(MyBase.Item("companySelectorInformation"), CompanySelectorInformationCollection)
        End Get
    End Property


End Class
