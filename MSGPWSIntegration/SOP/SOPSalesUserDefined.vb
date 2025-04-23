Namespace SOP
    Public Class SOPSalesUserDefined
        Private _mDate01 As Date
        Private _mDate02 As Date
        Private _mList01 As String = String.Empty
        Private _mList02 As String = String.Empty
        Private _mList03 As String = String.Empty
        Private _mText01 As String = String.Empty
        Private _mText02 As String = String.Empty
        Private _mText03 As String = String.Empty
        Private _mText04 As String = String.Empty
        Private _mText05 As String = String.Empty

        Public Property Date01() As Date
            Get
                Return _mDate01
            End Get
            Set(ByVal value As Date)
                _mDate01 = value
            End Set
        End Property
        Public Property Date02() As Date
            Get
                Return _mDate02
            End Get
            Set(ByVal value As Date)
                _mDate02 = value
            End Set
        End Property
        Public Property List01() As String
            Get
                Return _mList01
            End Get
            Set(ByVal value As String)
                _mList01 = value
            End Set
        End Property
        Public Property List02() As String
            Get
                Return _mList02
            End Get
            Set(ByVal value As String)
                _mList02 = value
            End Set
        End Property
        Public Property List03() As String
            Get
                Return _mList03
            End Get
            Set(ByVal value As String)
                _mList03 = value
            End Set
        End Property
        Public Property Text01() As String
            Get
                Return _mText01
            End Get
            Set(ByVal value As String)
                _mText01 = value
            End Set
        End Property
        Public Property Text02() As String
            Get
                Return _mText02
            End Get
            Set(ByVal value As String)
                _mText02 = value
            End Set
        End Property
        Public Property Text03() As String
            Get
                Return _mText03
            End Get
            Set(ByVal value As String)
                _mText03 = value
            End Set
        End Property
        Public Property Text04() As String
            Get
                Return _mText04
            End Get
            Set(ByVal value As String)
                _mText04 = value
            End Set
        End Property
        Public Property Text05() As String
            Get
                Return _mText05
            End Get
            Set(ByVal value As String)
                _mText05 = value
            End Set
        End Property
    End Class

End Namespace
