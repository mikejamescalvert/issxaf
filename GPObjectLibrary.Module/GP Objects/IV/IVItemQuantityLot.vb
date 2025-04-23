Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV00300
    ''' </summary>
    <Persistent("IV00300")>
    <OptimisticLocking(False)>
    Public Class IVItemQuantityLot
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
        Dim fLOCNCODE As String
        <Size(11)>
        Public Property LOCNCODE() As String
            Get
                Return fLOCNCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNCODE", fLOCNCODE, value)
            End Set
        End Property
        Dim fDATERECD As DateTime
        Public Property DATERECD() As DateTime
            Get
                Return fDATERECD
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DATERECD", fDATERECD, value)
            End Set
        End Property
        Dim fDTSEQNUM As Decimal
        <Custom("DisplayFormat", "{0:N}")>
        Public Property DTSEQNUM() As Decimal
            Get
                Return fDTSEQNUM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DTSEQNUM", fDTSEQNUM, value)
            End Set
        End Property
        Dim fLOTNUMBR As String
        <Size(21)>
        Public Property LOTNUMBR() As String
            Get
                Return fLOTNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOTNUMBR", fLOTNUMBR, value)
            End Set
        End Property

        <PersistentAlias("QTYRECVD - QTYSOLD")>
        Public ReadOnly Property QuantityInStock As Decimal
            Get
                Return EvaluateAlias("QuantityInStock")
            End Get
        End Property

        Dim fQTYRECVD As Decimal
        <Custom("DisplayFormat", "{0:N}")>
        Public Property QTYRECVD() As Decimal
            Get
                Return fQTYRECVD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYRECVD", fQTYRECVD, value)
            End Set
        End Property
        Dim fQTYSOLD As Decimal
        <Custom("DisplayFormat", "{0:N}")>
        Public Property QTYSOLD() As Decimal
            Get
                Return fQTYSOLD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYSOLD", fQTYSOLD, value)
            End Set
        End Property
        Dim fATYALLOC As Decimal
        <Custom("DisplayFormat", "{0:N}")>
        Public Property ATYALLOC() As Decimal
            Get
                Return fATYALLOC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ATYALLOC", fATYALLOC, value)
            End Set
        End Property
        Dim fUNITCOST As Decimal
        Public Property UNITCOST() As Decimal
            Get
                Return fUNITCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("UNITCOST", fUNITCOST, value)
            End Set
        End Property
        Dim fRCTSEQNM As Integer
        Public Property RCTSEQNM() As Integer
            Get
                Return fRCTSEQNM
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("RCTSEQNM", fRCTSEQNM, value)
            End Set
        End Property
        Dim fVNDRNMBR As String
        <Size(25)>
        Public Property VNDRNMBR() As String
            Get
                Return fVNDRNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDRNMBR", fVNDRNMBR, value)
            End Set
        End Property
        Dim fLTNUMSLD As Byte
        Public Property LTNUMSLD() As Byte
            Get
                Return fLTNUMSLD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("LTNUMSLD", fLTNUMSLD, value)
            End Set
        End Property
        Dim fQTYTYPE As Short
        Public Property QTYTYPE() As Short
            Get
                Return fQTYTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("QTYTYPE", fQTYTYPE, value)
            End Set
        End Property
        Dim fBIN As String
        <Size(15)>
        Public Property BIN() As String
            Get
                Return fBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BIN", fBIN, value)
            End Set
        End Property
        Dim fMFGDATE As DateTime
        Public Property MFGDATE() As DateTime
            Get
                Return fMFGDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MFGDATE", fMFGDATE, value)
            End Set
        End Property
        Dim fEXPNDATE As DateTime
        Public Property EXPNDATE() As DateTime
            Get
                Return fEXPNDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EXPNDATE", fEXPNDATE, value)
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
