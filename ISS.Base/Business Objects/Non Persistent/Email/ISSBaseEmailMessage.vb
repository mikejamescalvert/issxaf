Public Class ISSBaseEmailMessage

#Region "Non Persistent Properties"
    Private _mBCCAddresses As New System.Collections.ObjectModel.Collection(Of String)
    Private _mCCAddresses As New System.Collections.ObjectModel.Collection(Of String)
    Private _mMessage As String
    Private _mSubject As String
    Private _mToAddresses As New System.Collections.ObjectModel.Collection(Of String)

    Public Property BCCAddresses() As System.Collections.ObjectModel.Collection(Of String)
        Get
            Return _mBCCAddresses
        End Get
        Set(ByVal value As System.Collections.ObjectModel.Collection(Of String))
            If _mBCCAddresses Is value Then
                Return
            End If
            _mBCCAddresses = value
        End Set
    End Property
    Public Property CCAddresses() As System.Collections.ObjectModel.Collection(Of String)
        Get
            Return _mCCAddresses
        End Get
        Set(ByVal value As System.Collections.ObjectModel.Collection(Of String))
            If _mCCAddresses Is value Then
                Return
            End If
            _mCCAddresses = value
        End Set
    End Property
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
    Public Property Subject() As String
        Get
            Return _mSubject
        End Get
        Set(ByVal value As String)
            If _mSubject = value Then
                Return
            End If
            _mSubject = value
        End Set
    End Property
    Public Property ToAddresses() As System.Collections.ObjectModel.Collection(Of String)
        Get
            Return _mToAddresses
        End Get
        Set(ByVal value As System.Collections.ObjectModel.Collection(Of String))
            If _mToAddresses Is value Then
                Return
            End If
            _mToAddresses = value
        End Set
    End Property
#End Region

End Class
