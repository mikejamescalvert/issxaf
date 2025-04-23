Imports System.Configuration

Public Class MasterProviderSettings
    Inherits ConfigurationSection

    Public Shared Function GetInstance() As MasterProviderSettings
        Return ConfigurationManager.GetSection("masterProviderSettings")
    End Function

    <ConfigurationProperty("assemblies")> _
    Public ReadOnly Property Assemblies As AssemblyInformationCollection
        Get
            Return CType(MyBase.Item("assemblies"), AssemblyInformationCollection)
        End Get
    End Property


End Class
