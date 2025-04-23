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
Imports Microsoft.VisualBasic


'<DefaultClassOptions()> _
Public Class ViewCustomizationRuleField ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub
    Private _mViewCustomizationRule As ViewCustomizationRule
    <Association("ViewCustomizationRule-ViewCustomizationRuleFields")>
    Property ViewCustomizationRule() As ViewCustomizationRule
        Get
            Return _mViewCustomizationRule
        End Get
        Set(ByVal Value As ViewCustomizationRule)
            SetPropertyValue(NameOf(ViewCustomizationRule), _mViewCustomizationRule, Value)
        End Set
    End Property
    
    Private _mFieldName As String
    <Size(255)>
    Property FieldName As String
        Get
            Return _mFieldName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(FieldName), _mFieldName, Value)
        End Set
    End Property
    


End Class
