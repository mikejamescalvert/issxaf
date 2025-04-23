Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<NonPersistent()> _
 Public Class ISSExceptionMessage
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Private _mTitle As String
    Public Property Title() As String
        Get
            Return _mTitle
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Title", _mTitle, Value)
        End Set
    End Property

    Private _mException As Exception
    <Browsable(False)> _
    Public Property Exception() As Exception
        Get
            Return _mException
        End Get
        Set(ByVal Value As Exception)
            SetPropertyValue("Exception", _mException, Value)
        End Set
    End Property

    Public ReadOnly Property ExceptionMessage() As String
        Get
            If Exception Is Nothing Then
                Return Nothing
            End If
            If TypeOf Exception Is UserFriendlyException Then
                Return CType(Exception, UserFriendlyException).Message
            End If
            Return Exception.Message
        End Get
    End Property

    <Browsable(False)> _
    Public ReadOnly Property FullExceptionMessage() As String
        Get
            Dim strMessage As String = String.Empty
            Dim expException As Exception = Exception
            While expException IsNot Nothing
                strMessage += expException.Message + Environment.NewLine
                expException = expException.InnerException
            End While
            Return strMessage
        End Get
    End Property

End Class
