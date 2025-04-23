Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10201
    ''' </summary>
    <Persistent("IV10201")>
    Public Class IVReceiptHeaderHistory
        Inherits XPLiteObject

        Public Structure IVReceiptHeaderHistoryKey
            Private fITEMNMBR As String
            <Size(31)>
            <Persistent("ITEMNMBR")>
            Public Property ITEMNMBR() As String
                Get
                    Return fITEMNMBR
                End Get
                Set(ByVal value As String)
                    fITEMNMBR = value
                End Set
            End Property
            Private fTRXLOCTN As String
            <Size(11)>
            <Persistent("TRXLOCTN")>
            Public Property TRXLOCTN() As String
                Get
                    Return fTRXLOCTN
                End Get
                Set(ByVal value As String)
                    fTRXLOCTN = value
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
            Private fDOCDATE As DateTime
            <Persistent("DOCDATE")>
            Public Property DOCDATE() As DateTime
                Get
                    Return fDOCDATE
                End Get
                Set(ByVal value As DateTime)
                    fDOCDATE = value
                End Set
            End Property
            Private fRCTSEQNM As Integer
            <Persistent("RCTSEQNM")>
            Public Property RCTSEQNM() As Integer
                Get
                    Return fRCTSEQNM
                End Get
                Set(ByVal value As Integer)
                    fRCTSEQNM = value
                End Set
            End Property
            Private fSRCRCTSEQNM As Integer
            <Persistent("SRCRCTSEQNM")>
            Public Property SRCRCTSEQNM() As Integer
                Get
                    Return fSRCRCTSEQNM
                End Get
                Set(ByVal value As Integer)
                    fSRCRCTSEQNM = value
                End Set
            End Property
        End Structure

        Dim fOid As IVReceiptHeaderHistoryKey
        <Key()>
        <Persistent()>
        Public Property Oid() As IVReceiptHeaderHistoryKey
            Get
                Return fOid
            End Get
            Set(ByVal value As IVReceiptHeaderHistoryKey)
                SetPropertyValue(Of IVReceiptHeaderHistoryKey)("Oid", fOid, value)
            End Set
        End Property
        
        Dim fORIGINDOCTYPE As Short
        Public Property ORIGINDOCTYPE() As Short
            Get
                Return fORIGINDOCTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ORIGINDOCTYPE", fORIGINDOCTYPE, value)
            End Set
        End Property
        Dim fORIGINDOCID As String
        <Size(31)> _
        Public Property ORIGINDOCID() As String
            Get
                Return fORIGINDOCID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ORIGINDOCID", fORIGINDOCID, value)
            End Set
        End Property
        Dim fLNSEQNBR As Decimal
        Public Property LNSEQNBR() As Decimal
            Get
                Return fLNSEQNBR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LNSEQNBR", fLNSEQNBR, value)
            End Set
        End Property
        Dim fCMPNTSEQ As Integer
        Public Property CMPNTSEQ() As Integer
            Get
                Return fCMPNTSEQ
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CMPNTSEQ", fCMPNTSEQ, value)
            End Set
        End Property
        Dim fQTYSOLD As Decimal
        Public Property QTYSOLD() As Decimal
            Get
                Return fQTYSOLD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYSOLD", fQTYSOLD, value)
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
        Dim fIVIVINDX As Integer
        Public Property IVIVINDX() As Integer
            Get
                Return fIVIVINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVIVINDX", fIVIVINDX, value)
            End Set
        End Property
        Dim fIVIVOFIX As Integer
        Public Property IVIVOFIX() As Integer
            Get
                Return fIVIVOFIX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVIVOFIX", fIVIVOFIX, value)
            End Set
        End Property

        Dim fTRXREFERENCE As Short
        Public Property TRXREFERENCE() As Short
            Get
                Return fTRXREFERENCE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TRXREFERENCE", fTRXREFERENCE, value)
            End Set
        End Property
        Dim fPCHSRCTY As Short
        Public Property PCHSRCTY() As Short
            Get
                Return fPCHSRCTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PCHSRCTY", fPCHSRCTY, value)
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
