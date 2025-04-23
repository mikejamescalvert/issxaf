Namespace IV
    Public Class IVItemSite
        Private _mSiteId As String
        Public Property SiteId As String
            Get
                Return _mSiteId
            End Get
            Set(ByVal Value As String)
                _mSiteId = Value
            End Set
        End Property
        Private _mItemKey As String
        Public Property ItemKey As String
            Get
                Return _mItemKey
            End Get
            Set(ByVal Value As String)
                _mItemKey = Value
            End Set
        End Property
        



    End Class
End Namespace

