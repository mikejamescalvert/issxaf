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

Public Class NotificationPropertyChangedQueueItem

    Private _newValue As Object
    Property NewValue As Object
        Get
            Return _newValue
        End Get
        Set(ByVal Value As Object)
            _newValue = Value
        End Set
    End Property

    Private _oldValue As Object
    Property OldValue As Object
        Get
            Return _oldValue
        End Get
        Set(ByVal Value As Object)
            _oldValue = Value
        End Set
    End Property

    Private _propertyName As String
    Property PropertyName As String
        Get
            Return _propertyName
        End Get
        Set(ByVal Value As String)
            _propertyName = Value
        End Set
    End Property

    Private _sourceRule As NotificationRule
    Property SourceRule As NotificationRule
        Get
            Return _sourceRule
        End Get
        Set(ByVal Value As NotificationRule)
            _sourceRule = Value
        End Set
    End Property

    Private _mTargetObject As Object
    Public Property TargetObject As Object
        Get
            Return _mTargetObject
        End Get
        Set(value As Object)
            _mTargetObject = value
        End Set
    End Property
End Class
