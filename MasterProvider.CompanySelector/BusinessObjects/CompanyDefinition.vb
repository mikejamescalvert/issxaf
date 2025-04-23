Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Xpo
Imports MasterProvider.Module
Imports Microsoft.VisualBasic

<AllowDataModificationsInMasterProvider>
<AllowDatabaseUpdateInMasterProvider>
Public Class CompanyDefinition ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject
    Implements ICompanyDefinition
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _mName As String
    Public Property Name As String Implements ICompanyDefinition.Name
        Get
            Return _mName
        End Get
        Set(value As String)
            SetPropertyValue("Name", _mName, value)
        End Set
    End Property

    Private _mCompanyId As String
    Public Property CompanyId As String Implements ICompanyDefinition.CompanyId
        Get
            Return _mCompanyId
        End Get
        Set(value As String)
            SetPropertyValue("CompanyId", _mCompanyId, value)
        End Set
    End Property

    Private _mERPType As ERPTypes
    Public Property ERPType As ERPTypes Implements ICompanyDefinition.ERPType
        Get
            Return _mERPType
        End Get
        Set(value As ERPTypes)
            SetPropertyValue("ERPType", _mERPType, value)
        End Set
    End Property

    Private _mERPCompanyId As String
    Public Property ERPCompanyId As String Implements ICompanyDefinition.ERPCompanyId
        Get
            Return _mERPCompanyId
        End Get
        Set(value As String)
            SetPropertyValue("ERPCompanyId", _mERPCompanyId, value)
        End Set
    End Property
End Class
