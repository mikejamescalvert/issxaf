Imports System
Imports DevExpress.Xpo
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV00108
    ''' </summary>
    <Persistent("IV00108")>
    <OptimisticLocking(False)>
    Public Class IVItemPriceList

        Inherits XPLiteObject
        Dim fITEMNMBR As String
        <Size(31)>
        Public Property ITEMNMBR() As String
            Get
                Return fITEMNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMNMBR", fITEMNMBR, value)
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
        Dim fPRCLEVEL As String
        <Size(11)>
        Public Property PRCLEVEL() As String
            Get
                Return fPRCLEVEL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCLEVEL", fPRCLEVEL, value)
            End Set
        End Property
        Dim fUOFM As String
        <Size(9)>
        Public Property UOFM() As String
            Get
                Return fUOFM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOFM", fUOFM, value)
            End Set
        End Property
        Dim fTOQTY As Decimal
        Public Property TOQTY() As Decimal
            Get
                Return fTOQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TOQTY", fTOQTY, value)
            End Set
        End Property
        Dim fFROMQTY As Decimal
        Public Property FROMQTY() As Decimal
            Get
                Return fFROMQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("FROMQTY", fFROMQTY, value)
            End Set
        End Property
        Dim fUOMPRICE As Decimal
        Public Property UOMPRICE() As Decimal
            Get
                Return fUOMPRICE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UOMPRICE", fUOMPRICE, value)
            End Set
        End Property
        Dim fQTYBSUOM As Decimal
        Public Property QTYBSUOM() As Decimal
            Get
                Return fQTYBSUOM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYBSUOM", fQTYBSUOM, value)
            End Set
        End Property
        Dim fDEX_ROW_ID As Integer
        <Key(True)>
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