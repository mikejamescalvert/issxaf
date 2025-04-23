Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Public Class ISSBaseCustomCaption
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        ' This constructor is used when an object is loaded from a persistent storage.
        ' Do not place any code here or place it only when the IsLoading property is false:
        ' if (!IsLoading){
        '   It is now OK to place your initialization code here.
        ' }
        ' or as an alternative, move your initialization code into the AfterConstruction method.
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place here your initialization code.
    End Sub


    Private _mObjectCustomization As ISSBaseBusinessRules
    <Association("ObjectCustomization-CustomCaptions")> _
    <Browsable(False)> _
    <Xml.Serialization.XmlIgnore()> _
    Public Property ObjectCustomization As ISSBaseBusinessRules
        Get
            Return _mObjectCustomization
        End Get
        Set(ByVal Value As ISSBaseBusinessRules)
            SetPropertyValue("ObjectCustomization", _mObjectCustomization, Value)
        End Set
    End Property

    Private _mPropertyName As String
    <[ReadOnly](True)> _
    <Browsable(False)> _
    Public Property PropertyName As String
        Get
            Return _mPropertyName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("PropertyName", _mPropertyName, Value)
        End Set
    End Property


    <RuleRequiredField("CustomCaption.PropertyRequired", DefaultContexts.Save, "Property Is Required")> _
    <Index(1)> _
    Public Property PropertyValue() As System.Reflection.PropertyInfo
        Get
            If Me.PropertyName Is Nothing Then
                Return Nothing
            Else
                If ObjectCustomization IsNot Nothing AndAlso ObjectCustomization.ObjectType IsNot Nothing Then
                    Return ObjectCustomization.ObjectType.GetProperty(Me.PropertyName)
                Else
                    Return Nothing
                End If
            End If
        End Get
        Set(ByVal value As System.Reflection.PropertyInfo)
            Me.PropertyName = value.Name
        End Set
    End Property

    Private _mNewCaption As String
    <Size(255)>
    Public Property NewCaption As String
        Get
            Return _mNewCaption
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("NewCaption", _mNewCaption, Value)
        End Set
    End Property


End Class
