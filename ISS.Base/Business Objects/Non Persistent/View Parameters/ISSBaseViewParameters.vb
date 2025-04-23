Public Class ISSBaseViewParameters

#Region "Non Persistent Properties"
    Private _mIsDeleteVisible As Boolean = True
    Private _mIsNewVisible As Boolean = True
    Private _mISSBaseDetailViewParameters As New ISSBaseDetailViewParameters
    Private _mISSBaseListViewParameters As New ISSBaseListViewParameters
    Public Property IsDeleteVisible() As Boolean
        Get
            Return _mIsDeleteVisible
        End Get
        Set(ByVal value As Boolean)
            If _mIsDeleteVisible = value Then
                Return
            End If
            _mIsDeleteVisible = value
        End Set
    End Property
    Public Property IsNewVisible() As Boolean
        Get
            Return _mIsNewVisible
        End Get
        Set(ByVal value As Boolean)
            If _mIsNewVisible = value Then
                Return
            End If
            _mIsNewVisible = value
        End Set
    End Property
    Public Property ISSBaseDetailViewParameters() As ISSBaseDetailViewParameters
        Get
            Return _mISSBaseDetailViewParameters
        End Get
        Set(ByVal value As ISSBaseDetailViewParameters)
            If _mISSBaseDetailViewParameters Is value Then
                Return
            End If
            _mISSBaseDetailViewParameters = value
        End Set
    End Property
    Public Property ISSBaseListViewParameters() As ISSBaseListViewParameters
        Get
            Return _mISSBaseListViewParameters
        End Get
        Set(ByVal value As ISSBaseListViewParameters)
            If _mISSBaseListViewParameters Is value Then
                Return
            End If
            _mISSBaseListViewParameters = value
        End Set
    End Property
#End Region

End Class
