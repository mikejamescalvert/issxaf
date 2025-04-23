Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.BaseImpl


<NonPersistent()> _
<System.ComponentModel.DisplayName("UserMessage")> _
Public Class ISSBaseEndUserMessage
    Inherits BaseObject

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private _mMessage As String
    <Size(SizeAttribute.Unlimited)> _
    Public ReadOnly Property Message() As String
        Get
            Return _mMessage
        End Get
    End Property

    Private _mEndUserMessageDetail As New List(Of ISSBaseEndUserMessageDetail)
    <Attributes.View.ShowActionBar(False)> _
    Public ReadOnly Property EndUserMessageDetails() As List(Of ISSBaseEndUserMessageDetail)
        Get
            Return _mEndUserMessageDetail
        End Get
    End Property

    Private _mAccepted As Boolean
    <Browsable(False)> _
    Public Property Accepted() As Boolean
        Get
            Return _mAccepted
        End Get
        Set(ByVal value As Boolean)
            If _mAccepted = value Then
                Return
            End If
            _mAccepted = value
        End Set
    End Property

    Private Sub MarkAccepted()
        _mAccepted = True
    End Sub

    Public Enum MessageReturnValues
        InformativeOk
        No
        Yes
    End Enum

    Public Enum MessageTypes
        Confirmation
        Informative
    End Enum

    Public Sub Setup(ByVal HeaderMessage As String, ByVal MessageCollection As List(Of String))
        _mMessage = HeaderMessage
        Dim emdMessageDetail As ISSBaseEndUserMessageDetail
        For Each oString As String In MessageCollection
            emdMessageDetail = New ISSBaseEndUserMessageDetail(Session)
            emdMessageDetail.Message = oString
            EndUserMessageDetails.Add(emdMessageDetail)
        Next
    End Sub

    Public Sub AddMessageToCollection(ByVal Message As String)
        Dim emdMessageDetail As New ISSBaseEndUserMessageDetail(Session) With {.Message = Message}
        EndUserMessageDetails.Add(emdMessageDetail)
    End Sub

    'Private WithEvents _mPopupAction As DevExpress.ExpressApp.Actions.PopupWindowShowAction

    'Private Sub PopupAction_CustomizePopupWindowParams(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventArgs)
    '    'ObjectSpace objectSpace = Application.CreateObjectSpace();


    '    'e.View = Application.CreateListView(Application.FindListViewId(typeof(Note)),
    '    '   new CollectionSource(objectSpace, typeof(Note)), true);
    'End Sub

End Class
