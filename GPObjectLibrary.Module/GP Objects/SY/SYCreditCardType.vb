Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation


Namespace Objects.SY

    ''' <summary>
    ''' GP Table SY03100
    ''' </summary>
    <Persistent("SY03100")> _
    <OptimisticLocking(False)> _
    <DefaultProperty("CARDNAME")> _
    Public Class SYCreditCardType
        Inherits XPLiteObject
        Dim fPYBLGRBX As Short
        Public Property PYBLGRBX() As Short
            Get
                Return fPYBLGRBX
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PYBLGRBX", fPYBLGRBX, value)
            End Set
        End Property
        Dim fRCVBGRBX As Short
        Public Property RCVBGRBX() As Short
            Get
                Return fRCVBGRBX
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RCVBGRBX", fRCVBGRBX, value)
            End Set
        End Property
        Dim fCARDNAME As String
        <Key()> _
        <Size(15)> _
        Public Property CARDNAME() As String
            Get
                Return fCARDNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CARDNAME", fCARDNAME, value)
            End Set
        End Property
        Dim fCBPAYBLE As Byte
        Public Property CBPAYBLE() As Byte
            Get
                Return fCBPAYBLE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CBPAYBLE", fCBPAYBLE, value)
            End Set
        End Property
        Dim fCBRCVBLE As Byte
        Public Property CBRCVBLE() As Byte
            Get
                Return fCBRCVBLE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CBRCVBLE", fCBRCVBLE, value)
            End Set
        End Property
        Dim fCKBKNUM1 As String
        <Size(15)> _
        Public Property CKBKNUM1() As String
            Get
                Return fCKBKNUM1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CKBKNUM1", fCKBKNUM1, value)
            End Set
        End Property
        Dim fCKBKNUM2 As String
        <Size(15)> _
        Public Property CKBKNUM2() As String
            Get
                Return fCKBKNUM2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CKBKNUM2", fCKBKNUM2, value)
            End Set
        End Property
        Dim fACTINDX As Integer
        Public Property ACTINDX() As Integer
            Get
                Return fACTINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ACTINDX", fACTINDX, value)
            End Set
        End Property
        Dim fVENDORID As String
        <Size(15)> _
        Public Property VENDORID() As String
            Get
                Return fVENDORID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDORID", fVENDORID, value)
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
        Dim fLSTUSRED As String
        <Size(15)> _
        Public Property LSTUSRED() As String
            Get
                Return fLSTUSRED
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LSTUSRED", fLSTUSRED, value)
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