Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Security
Imports DevExpress.ExpressApp.Utils
Imports MasterProvider.Module
Imports DevExpress.ExpressApp.Xpo

<AllowDataModificationsInMasterProvider>
<AllowDatabaseUpdateInMasterProvider>
<DomainComponent>
<ComponentModel.DisplayName("Logon")>
Public Class companySelectorLogonParameters
    Inherits AuthenticationStandardLogonParameters
    Implements ICustomObjectSerialize

    Private _mCompany As CompanyDefinition
    <DataSourceProperty("Companies")>
    Property Company As CompanyDefinition
        Get
            Return _mCompany
        End Get
        Set(value As CompanyDefinition)
            _mCompany = value
        End Set
    End Property

    Private _mCompanies As IEnumerable(Of CompanyDefinition)
    <VisibleInListView(False)>
    <VisibleInDetailView(False)>
    <VisibleInLookupListView(False)>
    ReadOnly Property Companies As IEnumerable(Of CompanyDefinition)
        Get
            Return _mCompanies
        End Get
    End Property

    Public Sub RefreshPersistentObjects(objectSpace As IObjectSpace)
        Dim obs As Xpo.XPObjectSpace = TryCast(objectSpace, Xpo.XPObjectSpace)
        If obs IsNot Nothing Then
            _mCompanies = New XPCollection(Of CompanyDefinition)(CType(objectSpace, XPObjectSpace).Session)
        End If


    End Sub

End Class
