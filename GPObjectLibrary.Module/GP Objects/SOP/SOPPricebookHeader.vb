Imports System
Imports DevExpress.Xpo
Imports System.ComponentModel

Namespace Objects.SOP
    ''' <summary>
    ''' GP Table SOP10109
    ''' </summary>
    <Persistent("SOP10109")>
    <DefaultProperty("PRCBKID")>
    Public Class SOPPricebookHeader
        Inherits XPLiteObject
        Dim fPRCBKID As String
        <Key()>
        <Size(15)>
        Public Property PRCBKID() As String
            Get
                Return fPRCBKID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCBKID", fPRCBKID, value)
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
        Dim fISBASE As Byte
        Public Property ISBASE() As Byte
            Get
                Return fISBASE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ISBASE", fISBASE, value)
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
