Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10002
    ''' </summary>
    <Persistent("IV10002")>
    Public Class IVInventoryAdjustmentDetailLotAssignment
        Inherits XPLiteObject

        Public Structure IVInventoryAdjustmentDetailLotAssignmentKey
            Private fIVDOCNBR As String
            <Size(17)> _
            <Persistent("IVDOCNBR")>
            Public Property IVDOCNBR() As String
                Get
                    Return fIVDOCNBR
                End Get
                Set(ByVal value As String)
                    fIVDOCNBR = value
                End Set
            End Property
            Private fIVDOCTYP As Short
            <Persistent("IVDOCTYP")>
            Public Property IVDOCTYP() As Short
                Get
                    Return fIVDOCTYP
                End Get
                Set(ByVal value As Short)
                    fIVDOCTYP = value
                End Set
            End Property
            Private fLNSEQNBR As Decimal
            <Persistent("LNSEQNBR")>
            Public Property LNSEQNBR() As Decimal
                Get
                    Return fLNSEQNBR
                End Get
                Set(ByVal value As Decimal)
                    fLNSEQNBR = value
                End Set
            End Property
            Private fSLTSQNUM As Integer
            <Persistent("SLTSQNUM")>
            Public Property SLTSQNUM() As Integer
                Get
                    Return fSLTSQNUM
                End Get
                Set(ByVal value As Integer)
                    fSLTSQNUM = value
                End Set
            End Property
        End Structure

        Dim fOid As IVInventoryAdjustmentDetailLotAssignmentKey
        <Key()>
        <Persistent()>
        Public Property Oid() As IVInventoryAdjustmentDetailLotAssignmentKey
            Get
                Return fOid
            End Get
            Set(ByVal value As IVInventoryAdjustmentDetailLotAssignmentKey)
                SetPropertyValue(Of IVInventoryAdjustmentDetailLotAssignmentKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fITEMNMBR As String
        <Size(31)> _
        Public Property ITEMNMBR() As String
            Get
                Return fITEMNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMNMBR", fITEMNMBR, value)
            End Set
        End Property
        Dim fSERLTNUM As String
        <Size(21)> _
        Public Property SERLTNUM() As String
            Get
                Return fSERLTNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SERLTNUM", fSERLTNUM, value)
            End Set
        End Property
        Dim fSERLTQTY As Decimal
        Public Property SERLTQTY() As Decimal
            Get
                Return fSERLTQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SERLTQTY", fSERLTQTY, value)
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
        Public Property DTSEQNUM() As Decimal
            Get
                Return fDTSEQNUM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DTSEQNUM", fDTSEQNUM, value)
            End Set
        End Property
        Dim fOVRSERLT As Short
        Public Property OVRSERLT() As Short
            Get
                Return fOVRSERLT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("OVRSERLT", fOVRSERLT, value)
            End Set
        End Property
        Dim fQTYSCRAPPED As Decimal
        Public Property QTYSCRAPPED() As Decimal
            Get
                Return fQTYSCRAPPED
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYSCRAPPED", fQTYSCRAPPED, value)
            End Set
        End Property
        Dim fFROMBIN As String
        <Size(15)> _
        Public Property FROMBIN() As String
            Get
                Return fFROMBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FROMBIN", fFROMBIN, value)
            End Set
        End Property
        Dim fTOBIN As String
        <Size(15)> _
        Public Property TOBIN() As String
            Get
                Return fTOBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TOBIN", fTOBIN, value)
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
