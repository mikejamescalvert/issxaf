Imports DevExpress.Xpo

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10200
    ''' </summary>
    <Persistent("IV10200")>
    Public Class IVReceiptHeader
        Inherits XPLiteObject

        Public Structure IVReceiptHeaderKey
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

        Dim fOid As IVReceiptHeaderKey
        <Key()>
        <Persistent()>
        Public Property Oid() As IVReceiptHeaderKey
            Get
                Return fOid
            End Get
            Set(ByVal value As IVReceiptHeaderKey)
                SetPropertyValue(Of IVReceiptHeaderKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fRCPTSOLD As Byte
        Public Property RCPTSOLD() As Byte
            Get
                Return fRCPTSOLD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("RCPTSOLD", fRCPTSOLD, value)
            End Set
        End Property
        Dim fQTYRECVD As Decimal
        Public Property QTYRECVD() As Decimal
            Get
                Return fQTYRECVD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYRECVD", fQTYRECVD, value)
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
        Dim fQTYCOMTD As Decimal
        Public Property QTYCOMTD() As Decimal
            Get
                Return fQTYCOMTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYCOMTD", fQTYCOMTD, value)
            End Set
        End Property
        Dim fQTYRESERVED As Decimal
        Public Property QTYRESERVED() As Decimal
            Get
                Return fQTYRESERVED
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYRESERVED", fQTYRESERVED, value)
            End Set
        End Property
        Dim fFLRPLNDT As DateTime
        Public Property FLRPLNDT() As DateTime
            Get
                Return fFLRPLNDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("FLRPLNDT", fFLRPLNDT, value)
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
        Dim fRCPTNMBR As String
        <Size(21)>
        Public Property RCPTNMBR() As String
            Get
                Return fRCPTNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RCPTNMBR", fRCPTNMBR, value)
            End Set
        End Property
        Dim fVENDORID As String
        <Size(15)>
        Public Property VENDORID() As String
            Get
                Return fVENDORID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VENDORID", fVENDORID, value)
            End Set
        End Property
        Dim fPORDNMBR As String
        <Size(21)>
        Public Property PORDNMBR() As String
            Get
                Return fPORDNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PORDNMBR", fPORDNMBR, value)
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

        Dim fLanded_Cost As Byte
        Public Property Landed_Cost() As Byte
            Get
                Return fLanded_Cost
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Landed_Cost", fLanded_Cost, value)
            End Set
        End Property
        Dim fNEGQTYSOPINV As Byte
        Public Property NEGQTYSOPINV() As Byte
            Get
                Return fNEGQTYSOPINV
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("NEGQTYSOPINV", fNEGQTYSOPINV, value)
            End Set
        End Property
        Dim fVCTNMTHD As Short
        Public Property VCTNMTHD() As Short
            Get
                Return fVCTNMTHD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("VCTNMTHD", fVCTNMTHD, value)
            End Set
        End Property
        Dim fADJUNITCOST As Decimal
        Public Property ADJUNITCOST() As Decimal
            Get
                Return fADJUNITCOST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ADJUNITCOST", fADJUNITCOST, value)
            End Set
        End Property
        Dim fQTYONHND As Decimal
        Public Property QTYONHND() As Decimal
            Get
                Return fQTYONHND
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYONHND", fQTYONHND, value)
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
