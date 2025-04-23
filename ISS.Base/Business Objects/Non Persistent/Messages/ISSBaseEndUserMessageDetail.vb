Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.BaseImpl

<NonPersistent()> _
<System.ComponentModel.DisplayName("UserMessageDetail")> _
Public Class ISSBaseEndUserMessageDetail
    Inherits BaseObject

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private _mMessage As String
    <Size(SizeAttribute.Unlimited)> _
    Public Property Message() As String
        Get
            Return _mMessage
        End Get
        Set(ByVal value As String)
            If _mMessage = value Then
                Return
            End If
            _mMessage = value
        End Set
    End Property

End Class
