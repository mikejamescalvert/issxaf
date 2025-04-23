Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Xpo
Imports Microsoft.VisualBasic

<DefaultClassOptions()>
Public Class BusinessObjectCustomization ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
    End Sub

    <RuleRequiredField("BusinessObjectCustomization.ObjectTypeRequired", DefaultContexts.Save, "Object Type Is Required")>
    <RuleUniqueValue("BusinessObjectCustomization.ObjectTypeUnique", DefaultContexts.Save, "Object Type Already Defined")>
    <ImmediatePostData()>
    <ValueConverter(GetType(TypeToStringConverter))>
    <TypeConverter(GetType(LocalizedClassInfoTypeConverter))>
    <Size(SizeAttribute.Unlimited)>
    Public Property ObjectType() As Type
        Get
            Return GetPropertyValue(Of Type)(NameOf(ObjectType))
        End Get
        Set(ByVal value As Type)
            SetPropertyValue(Of Type)(NameOf(ObjectType), value)
        End Set
    End Property

    <Association("BusinessObjectCustomization-ViewCustomizationRules")>
    <DevExpress.Xpo.Aggregated()>
    Public ReadOnly Property ViewCustomizationRules() As XPCollection(Of ViewCustomizationRule)
        Get
            Return GetCollection(Of ViewCustomizationRule)(NameOf(ViewCustomizationRules))
        End Get
    End Property

    Private Sub ClearObjectDefinition()
        'todo: handle any potential issues from the type changing (filters etc. not working?)

    End Sub

    Private Sub BusinessObjectCustomization_Changed(sender As Object, e As ObjectChangeEventArgs) Handles Me.Changed
        If e.PropertyName = "ObjectType" Then
            ClearObjectDefinition()
        End If
    End Sub
End Class
