Imports DevExpress.Xpo

Namespace Objects.SOP
    ''' <summary>
    ''' GP Table SOP10110
    ''' </summary>
    <Persistent("SOP10110")>
    Public Class SOPPricesheetHeader
        Inherits XPLiteObject
        Dim fPRCSHID As String
        <Key()>
        <Size(15)>
        Public Property PRCSHID() As String
            Get
                Return fPRCSHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCSHID", fPRCSHID, value)
            End Set
        End Property
        Dim fDESCEXPR As String
        <Size(51)>
        Public Property DESCEXPR() As String
            Get
                Return fDESCEXPR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DESCEXPR", fDESCEXPR, value)
            End Set
        End Property
        Dim fNTPRONLY As Byte
        Public Property NTPRONLY() As Byte
            Get
                Return fNTPRONLY
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("NTPRONLY", fNTPRONLY, value)
            End Set
        End Property
        Dim fACTIVE As Byte
        Public Property ACTIVE() As Byte
            Get
                Return fACTIVE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ACTIVE", fACTIVE, value)
            End Set
        End Property
        Dim fSTRTDATE As DateTime
        Public Property STRTDATE() As DateTime
            Get
                Return fSTRTDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("STRTDATE", fSTRTDATE, value)
            End Set
        End Property
        Dim fENDDATE As DateTime
        Public Property ENDDATE() As DateTime
            Get
                Return fENDDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("ENDDATE", fENDDATE, value)
            End Set
        End Property
        Dim fNOTEINDX As Decimal
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
            End Set
        End Property
        Dim fPROMO As Byte
        Public Property PROMO() As Byte
            Get
                Return fPROMO
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("PROMO", fPROMO, value)
            End Set
        End Property
        Dim fCURNCYID As String
        <Size(15)>
        Public Property CURNCYID() As String
            Get
                Return fCURNCYID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CURNCYID", fCURNCYID, value)
            End Set
        End Property
        Dim fDEX_ROW_ID As Integer
        Public Property DEX_ROW_ID() As Integer
            Get
                Return fDEX_ROW_ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DEX_ROW_ID", fDEX_ROW_ID, value)
            End Set
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
