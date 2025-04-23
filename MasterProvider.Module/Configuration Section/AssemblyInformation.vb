Imports System.Configuration
Imports DevExpress.Xpo

Public Class AssemblyInformation
    Inherits ConfigurationElement

    Private _mAssemblyName As String
    <ConfigurationProperty("assemblyName", DefaultValue:="", IsKey:=True, IsRequired:=True)> _
    Public Property AssemblyName As String
        Get
            Return MyBase.Item("assemblyName")
        End Get
        Set(ByVal Value As String)
            MyBase.Item("assemblyName") = Value
        End Set
    End Property

    Private _mConnectionStringName As String
    <ConfigurationProperty("connectionStringName", DefaultValue:="", IsKey:=False, IsRequired:=True)> _
    Public Property ConnectionStringName As String
        Get
            Return MyBase.Item("connectionStringName")
        End Get
        Set(ByVal Value As String)
            MyBase.Item("connectionStringName") = Value
        End Set
    End Property

    Private _mIgnoreSchemaContraints As String
    <ConfigurationProperty("ignoreSchemaConstraints", DefaultValue:="False", IsKey:=False, IsRequired:=False)> _
    Public Property IgnoreSchemaContraints As String
        Get
            Return MyBase.Item("ignoreSchemaConstraints")
        End Get
        Set(ByVal Value As String)
            MyBase.Item("ignoreSchemaConstraints") = Value
        End Set
    End Property

    Private _mDisplayName As String
    <ConfigurationProperty("displayName", DefaultValue:="", IsKey:=False, IsRequired:=False)> _
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
            Return ConnectionStringName
        End If
        Return DisplayName
    End Function

End Class
