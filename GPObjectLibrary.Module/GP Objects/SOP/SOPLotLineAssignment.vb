Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Namespace Objects.SOP
    ''' <summary>
    ''' GP Table SOP10201
    ''' </summary>
    <Persistent("SOP10201")>
    Partial Public Class SOPLotLineAssignment
        Inherits XPLiteObject
        Public Structure SOPLotLineAssignmentKey
            Private fSOPTYPE As Short
            <Persistent("SOPTYPE")>
            Public Property SOPTYPE() As Short
                Get
                    Return fSOPTYPE
                End Get
                Set(ByVal value As Short)
                    fSOPTYPE = value
                End Set
            End Property
            Private fSOPNUMBE As String
            <Size(21)>
            <Persistent("SOPNUMBE")>
            Public Property SOPNUMBE() As String
                Get
                    Return fSOPNUMBE
                End Get
                Set(ByVal value As String)
                    fSOPNUMBE = value
                End Set
            End Property
            Private fLNITMSEQ As Integer
            <Persistent("LNITMSEQ")>
            Public Property LNITMSEQ() As Integer
                Get
                    Return fLNITMSEQ
                End Get
                Set(ByVal value As Integer)
                    fLNITMSEQ = value
                End Set
            End Property
            Private fCMPNTSEQ As Integer
            <Persistent("CMPNTSEQ")>
            Public Property CMPNTSEQ() As Integer
                Get
                    Return fCMPNTSEQ
                End Get
                Set(ByVal value As Integer)
                    fCMPNTSEQ = value
                End Set
            End Property
            Private fQTYTYPE As Short
            <Persistent("QTYTYPE")>
            Public Property QTYTYPE() As Short
                Get
                    Return fQTYTYPE
                End Get
                Set(ByVal value As Short)
                    fQTYTYPE = value
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
#Region "Properties"
        Private _mOid As SOPLotLineAssignmentKey
        <Key()>
        <Persistent()>
        Public Property Oid() As SOPLotLineAssignmentKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As SOPLotLineAssignmentKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property
        Dim fSERLTNUM As String
        <Size(21)>
        Public Property SERLTNUM() As String
            Get
                Return fSERLTNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)(NameOf(SERLTNUM), fSERLTNUM, value)
            End Set
        End Property
        Dim fSERLTQTY As Decimal
        Public Property SERLTQTY() As Decimal
            Get
                Return fSERLTQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)(NameOf(SERLTQTY), fSERLTQTY, value)
            End Set
        End Property
        Dim fDATERECD As DateTime
        Public Property DATERECD() As DateTime
            Get
                Return fDATERECD
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)(NameOf(DATERECD), fDATERECD, value)
            End Set
        End Property
        Dim fDTSEQNUM As Decimal
        Public Property DTSEQNUM() As Decimal
            Get
                Return fDTSEQNUM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)(NameOf(DTSEQNUM), fDTSEQNUM, value)
            End Set
        End Property
        Dim fUNITCOST As Decimal
        Public Property UNITCOST() As Decimal
            Get
                Return fUNITCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)(NameOf(UNITCOST), fUNITCOST, value)
            End Set
        End Property
        Dim fITEMNMBR As String
        <Size(31)>
        Public Property ITEMNMBR() As String
            Get
                Return fITEMNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)(NameOf(ITEMNMBR), fITEMNMBR, value)
            End Set
        End Property
        Dim fTRXSORCE As String
        <Size(13)>
        Public Property TRXSORCE() As String
            Get
                Return fTRXSORCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)(NameOf(TRXSORCE), fTRXSORCE, value)
            End Set
        End Property
        Dim fPOSTED As Byte
        Public Property POSTED() As Byte
            Get
                Return fPOSTED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)(NameOf(POSTED), fPOSTED, value)
            End Set
        End Property
        Dim fOVRSERLT As Short
        Public Property OVRSERLT() As Short
            Get
                Return fOVRSERLT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)(NameOf(OVRSERLT), fOVRSERLT, value)
            End Set
        End Property
        Dim fBIN As String
        <Size(15)>
        Public Property BIN() As String
            Get
                Return fBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)(NameOf(BIN), fBIN, value)
            End Set
        End Property
        Dim fMFGDATE As DateTime
        Public Property MFGDATE() As DateTime
            Get
                Return fMFGDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)(NameOf(MFGDATE), fMFGDATE, value)
            End Set
        End Property
        Dim fEXPNDATE As DateTime
        Public Property EXPNDATE() As DateTime
            Get
                Return fEXPNDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)(NameOf(EXPNDATE), fEXPNDATE, value)
            End Set
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
#End Region
    End Class
End Namespace
