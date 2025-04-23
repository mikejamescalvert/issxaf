Imports System.Configuration
Imports DevExpress.Xpo

Public Class CompanySelectorInformation
    Inherits ConfigurationElement

    Private _mERPConnectionStringName As String
    <ConfigurationProperty("eRPConnectionStringName", DefaultValue:="", IsKey:=True, IsRequired:=True)>
    Public Property ERPConnectionStringName As String
        Get
            Return MyBase.Item("eRPConnectionStringName")
        End Get
        Set(ByVal Value As String)
            MyBase.Item("eRPConnectionStringName") = Value
        End Set
    End Property

    Private _mCompanyConnectionStringName As String
    <ConfigurationProperty("companyConnectionStringName", DefaultValue:="", IsKey:=False, IsRequired:=True)>
    Public Property CompanyConnectionStringName As String
        Get
            Return MyBase.Item("companyConnectionStringName")
        End Get
        Set(ByVal Value As String)
            MyBase.Item("companyConnectionStringName") = Value
        End Set
    End Property

    Private _mIgnoreSchemaContraints As String
    <ConfigurationProperty("ignoreSchemaConstraints", DefaultValue:="False", IsKey:=False, IsRequired:=False)>
    Public Property IgnoreSchemaConstraints As String
        Get
            Return MyBase.Item("ignoreSchemaConstraints")
        End Get
        Set(ByVal Value As String)
            MyBase.Item("ignoreSchemaConstraints") = Value
        End Set
    End Property

    Private _mDisplayName As String
    <ConfigurationProperty("displayName", DefaultValue:="", IsKey:=False, IsRequired:=False)>
    Public Property DisplayName As String
        Get
            Return MyBase.Item("displayName")
        End Get
        Set(ByVal Value As String)
            MyBase.Item("displayName") = Value
        End Set
    End Property

    Public Function GetDisplayName() As String
        If DisplayName = String.Empty Then
            Return ERPConnectionStringName
        End If
        Return DisplayName
    End Function

End Class
