
Public Class ISSBaseListViewParameters

#Region "Non Persistent Properties"
    Private _mIsObjectAllowedToBeViewedInDetailView As Boolean = True
    Public Property IsObjectAllowedToBeViewedInDetailView() As Boolean
        Get
            Return _mIsObjectAllowedToBeViewedInDetailView
        End Get
        Set(ByVal value As Boolean)
            If _mIsObjectAllowedToBeViewedInDetailView = value Then
                Return
            End If
            _mIsObjectAllowedToBeViewedInDetailView = value
        End Set
    End Property
    Private _mRequiresRowLabelClick As Boolean
    Property RequiresRowLabelClick As Boolean
        Get
            Return _mRequiresRowLabelClick
        End Get
        Set(ByVal Value As Boolean)
            _mRequiresRowLabelClick = Value
        End Set
    End Property
    
#End Region

End Class
