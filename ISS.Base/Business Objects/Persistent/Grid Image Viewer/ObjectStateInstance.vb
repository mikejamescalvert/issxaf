Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Public Class ObjectStateInstance
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Public Enum StateInstanceImages
        None = 0
        Warning = 1
        [Error] = 2
        Success = 3
    End Enum

    Private _mCurrentState As StateInstanceImages
    Public Property CurrentState() As StateInstanceImages
        Get
            Return _mCurrentState
        End Get
        Set(ByVal Value As StateInstanceImages)
            _mCurrentState = Value
        End Set
    End Property

    Public ReadOnly Property StateImage() As Drawing.Image
        Get
            Select Case CurrentState
                Case StateInstanceImages.None
                    Return Nothing
                Case StateInstanceImages.Error
                    Return My.Resources.agt_stop
                Case StateInstanceImages.Warning
                    Return My.Resources.agt_update_critical
                Case StateInstanceImages.Success
                    Return My.Resources.agt_action_success
            End Select
            Return Nothing
        End Get
    End Property

    Private _mToolTip As String
    Public Property ToolTip() As String
        Get
            Return _mToolTip
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ToolTip", _mToolTip, Value)
        End Set
    End Property

    Private _mActionData As String
    Public Property ActionData() As String
        Get
            Return _mActionData
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ActionData", _mActionData, Value)
        End Set
    End Property

    Private _mObjectState As ObjectState
    <Association("ObjectState-ObjectStateInstances")> _
    Public Property ObjectState() As ObjectState
        Get
            Return _mObjectState
        End Get
        Set(ByVal Value As ObjectState)
            SetPropertyValue("ObjectState", _mObjectState, Value)
        End Set
    End Property



End Class
