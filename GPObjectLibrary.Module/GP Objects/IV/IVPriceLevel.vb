Imports System
Imports DevExpress.Xpo
Imports System.ComponentModel

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV40800
    ''' </summary>
    <Persistent("IV40800")>
    <DefaultProperty("PRCLEVEL")>
    Public Class IVPriceLevel
        Inherits XPLiteObject
        Dim fPRCLEVEL As String
        <Key()>
        <Size(11)>
        Public Property PRCLEVEL() As String
            Get
                Return fPRCLEVEL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCLEVEL", fPRCLEVEL, value)
            End Set
        End Property
        Dim fDSCRIPTN As String
        <Size(31)>
        Public Property DSCRIPTN() As String
            Get
                Return fDSCRIPTN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DSCRIPTN", fDSCRIPTN, value)
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
        Dim fCREATDDT As DateTime
        Public Property CREATDDT() As DateTime
            Get
                Return fCREATDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CREATDDT", fCREATDDT, value)
            End Set
        End Property
        Dim fMODIFDT As DateTime
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
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
