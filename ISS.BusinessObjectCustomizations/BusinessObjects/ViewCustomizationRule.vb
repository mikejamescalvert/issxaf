Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Xpo
Imports Microsoft.VisualBasic

'<DefaultClassOptions()>
Public Class ViewCustomizationRule ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub

    Private _mBusinessObjectCustomization As BusinessObjectCustomization
    <Association("BusinessObjectCustomization-ViewCustomizationRules")>
    Property BusinessObjectCustomization() As BusinessObjectCustomization
        Get
            Return _mBusinessObjectCustomization
        End Get
        Set(ByVal Value As BusinessObjectCustomization)
            SetPropertyValue(NameOf(BusinessObjectCustomization), _mBusinessObjectCustomization, Value)
        End Set
    End Property

    Private _mCustomizationRuleName As String
    <Size(255)>
    <RuleRequiredField>
    <RuleUniqueValue>
    Property CustomizationRuleName As String
        Get
            Return _mCustomizationRuleName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(CustomizationRuleName), _mCustomizationRuleName, Value)
        End Set
    End Property

    Private _mViewId As String
    <Size(255)>
    <ISS.Base.Attributes.Editors.PropertyEditors.ViewIdEditor("ViewCustomizationRule.ObjectType")>
    <ToolTip("Leave blank to apply to all views")>
    Property ViewId As String
        Get
            Return _mViewId
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(ViewId), _mViewId, Value)
        End Set
    End Property

    Private _mCurrentObjectFilter As String
    <Size(-1)>
    <CriteriaOptions("BusinessObjectCustomization.ObjectType")>
    Property CurrentObjectFilter As String
        Get
            Return _mCurrentObjectFilter
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(CurrentObjectFilter), _mCurrentObjectFilter, Value)
        End Set
    End Property


    Private _mCurrentUserFilter As String
    <Size(-1)>
    <CriteriaOptions("CurrentUserType")>
    Property CurrentUserFilter As String
        Get
            Return _mCurrentUserFilter
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(CurrentUserFilter), _mCurrentUserFilter, Value)
        End Set
    End Property

    <Browsable(False)>
    Public ReadOnly Property CurrentUserType As Type
        Get
            Return DevExpress.ExpressApp.SecuritySystem.UserType
        End Get
    End Property

    <Association("ViewCustomizationRule-ViewCustomizationRuleActions")>
    <DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property ViewCustomizationRuleActions() As XPCollection(Of ViewCustomizationRuleAction)
        Get
            Return GetCollection(Of ViewCustomizationRuleAction)(NameOf(ViewCustomizationRuleActions))
        End Get
    End Property

    <Association("ViewCustomizationRule-ViewCustomizationRuleFields")>
    <DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property ViewCustomizationRuleFields() As XPCollection(Of ViewCustomizationRuleField)
        Get
            Return GetCollection(Of ViewCustomizationRuleField)(NameOf(ViewCustomizationRuleFields))
        End Get
    End Property

End Class
