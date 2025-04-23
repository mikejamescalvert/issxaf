Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV00200
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    <Persistent("IV00200")> _
<OptimisticLocking(False)> _
    Public Class IVItemSerialNumber
        Inherits XPLiteObject

        Public Structure ItemSerialNumberKey
            Private fITEMNMBR As String
            <Size(31)> _
            <Persistent("ITEMNMBR")>
            Public Property ITEMNMBR() As String
                Get
                    Return fITEMNMBR
                End Get
                Set(ByVal value As String)
                    fITEMNMBR = value
                End Set
            End Property
            Private fLOCNCODE As String
            <Size(11)> _
            <Persistent("LOCNCODE")>
            Public Property LOCNCODE() As String
                Get
                    Return fLOCNCODE
                End Get
                Set(ByVal value As String)
                    fLOCNCODE = value
                End Set
            End Property
            Private fDATERECD As DateTime
            <Persistent("DATERECD")>
            Public Property DATERECD() As DateTime
                Get
                    Return fDATERECD
                End Get
                Set(ByVal value As DateTime)
                    fDATERECD = value
                End Set
            End Property
            Private fDTSEQNUM As Decimal
            <Persistent("DTSEQNUM")>
            Public Property DTSEQNUM() As Decimal
                Get
                    Return fDTSEQNUM
                End Get
                Set(ByVal value As Decimal)
                    fDTSEQNUM = value
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
        End Structure

        Dim fOid As ItemSerialNumberKey
        <Key()> _
        <Persistent()> _
        Public Property Oid() As ItemSerialNumberKey
            Get
                Return fOid
            End Get
            Set(ByVal value As ItemSerialNumberKey)
                SetPropertyValue(Of ItemSerialNumberKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fSERLNMBR As String
        <Size(21)> _
        Public Property SERLNMBR() As String
            Get
                Return fSERLNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SERLNMBR", fSERLNMBR, value)
            End Set
        End Property
        Dim fFGDITMNM As String
        <Size(31)> _
        Public Property FGDITMNM() As String
            Get
                Return fFGDITMNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FGDITMNM", fFGDITMNM, value)
            End Set
        End Property
        Dim fFGSERNBR As String
        <Size(21)> _
        Public Property FGSERNBR() As String
            Get
                Return fFGSERNBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FGSERNBR", fFGSERNBR, value)
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
        <Size(25)> _
        Public Property VNDRNMBR() As String
            Get
                Return fVNDRNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDRNMBR", fVNDRNMBR, value)
            End Set
        End Property
        Dim fCMPFINGD As Byte
        Public Property CMPFINGD() As Byte
            Get
                Return fCMPFINGD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CMPFINGD", fCMPFINGD, value)
            End Set
        End Property
        Dim fSERLNSLD As Byte
        Public Property SERLNSLD() As Byte
            Get
                Return fSERLNSLD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SERLNSLD", fSERLNSLD, value)
            End Set
        End Property

        Dim fBIN As String
        <Size(15)> _
        Public Property BIN() As String
            Get
                Return fBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BIN", fBIN, value)
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
