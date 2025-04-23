Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.TX
    ''' <summary>
    ''' GP Table TX00201
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <OptimisticLocking(False)> _
    <System.ComponentModel.DefaultProperty("TAXDTLID")> _
    <Persistent("TX00201")> _
        Public Class TXTaxDetail
        Inherits XPBaseObject

        Public Enum TaxDetailTypes
            Purchase = 2
            Sale = 1

        End Enum
        Public Enum TaxDetailFormulaTypes
            TaxIncludedInPrice = 1
            FlatAmountPerUnit = 2
            PercentOfSaleOrPurchase = 3
            PercentOfCost = 4
            PercentOfAnotherTaxDetail = 5
            PercentOfSaleOrPurchasePlusTaxableTaxes = 6
        End Enum


        Dim fTAXDTLID As String
        <Key()> _
        <Size(15)> _
        Public Property TAXDTLID() As String
            Get
                Return fTAXDTLID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXDTLID", fTAXDTLID, value)
            End Set
        End Property
        Dim fTXDTLDSC As String
        <Size(31)> _
        Public Property TXDTLDSC() As String
            Get
                Return fTXDTLDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXDTLDSC", fTXDTLDSC, value)
            End Set
        End Property
        Dim fTXDTLTYP As TaxDetailTypes
        Public Property TXDTLTYP() As TaxDetailTypes
            Get
                Return fTXDTLTYP
            End Get
            Set(ByVal value As TaxDetailTypes)
                SetPropertyValue(Of Short)("TXDTLTYP", fTXDTLTYP, value)
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
        Dim fTXIDNMBR As String
        <Size(11)> _
        Public Property TXIDNMBR() As String
            Get
                Return fTXIDNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXIDNMBR", fTXIDNMBR, value)
            End Set
        End Property
        Dim fTXDTLBSE As TaxDetailFormulaTypes
        Public Property TXDTLBSE() As TaxDetailFormulaTypes
            Get
                Return fTXDTLBSE
            End Get
            Set(ByVal value As TaxDetailFormulaTypes)
                SetPropertyValue(Of TaxDetailFormulaTypes)("TXDTLBSE", fTXDTLBSE, value)
            End Set
        End Property
        Dim fTXDTLPCT As Decimal
        Public Property TXDTLPCT() As Decimal
            Get
                Return fTXDTLPCT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TXDTLPCT", fTXDTLPCT, value)
            End Set
        End Property
        Dim fTXDTLAMT As Decimal
        Public Property TXDTLAMT() As Decimal
            Get
                Return fTXDTLAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TXDTLAMT", fTXDTLAMT, value)
            End Set
        End Property
        Dim fTDTLRNDG As Short
        Public Property TDTLRNDG() As Short
            Get
                Return fTDTLRNDG
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TDTLRNDG", fTDTLRNDG, value)
            End Set
        End Property
        Dim fTXDBODTL As String
        <Size(15)> _
        Public Property TXDBODTL() As String
            Get
                Return fTXDBODTL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXDBODTL", fTXDBODTL, value)
            End Set
        End Property
        Dim fTDTABMIN As Decimal
        Public Property TDTABMIN() As Decimal
            Get
                Return fTDTABMIN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TDTABMIN", fTDTABMIN, value)
            End Set
        End Property
        Dim fTDTABMAX As Decimal
        Public Property TDTABMAX() As Decimal
            Get
                Return fTDTABMAX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TDTABMAX", fTDTABMAX, value)
            End Set
        End Property
        Dim fTDTAXMIN As Decimal
        Public Property TDTAXMIN() As Decimal
            Get
                Return fTDTAXMIN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TDTAXMIN", fTDTAXMIN, value)
            End Set
        End Property
        Dim fTDTAXMAX As Decimal
        Public Property TDTAXMAX() As Decimal
            Get
                Return fTDTAXMAX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TDTAXMAX", fTDTAXMAX, value)
            End Set
        End Property
        Dim fTDRNGTYP As Short
        Public Property TDRNGTYP() As Short
            Get
                Return fTDRNGTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TDRNGTYP", fTDRNGTYP, value)
            End Set
        End Property
        Dim fTXDTQUAL As Short
        Public Property TXDTQUAL() As Short
            Get
                Return fTXDTQUAL
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TXDTQUAL", fTXDTQUAL, value)
            End Set
        End Property
        Dim fTDTAXTAX As Byte
        Public Property TDTAXTAX() As Byte
            Get
                Return fTDTAXTAX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TDTAXTAX", fTDTAXTAX, value)
            End Set
        End Property
        Dim fTXDTLPDC As Byte
        Public Property TXDTLPDC() As Byte
            Get
                Return fTXDTLPDC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TXDTLPDC", fTXDTLPDC, value)
            End Set
        End Property
        Dim fTXDTLPCH As Char
        Public Property TXDTLPCH() As Char
            Get
                Return fTXDTLPCH
            End Get
            Set(ByVal value As Char)
                SetPropertyValue(Of Char)("TXDTLPCH", fTXDTLPCH, value)
            End Set
        End Property
        Dim fTXDXDISC As Byte
        Public Property TXDXDISC() As Byte
            Get
                Return fTXDXDISC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TXDXDISC", fTXDXDISC, value)
            End Set
        End Property
        Dim fCMNYTXID As String
        <Size(15)> _
        Public Property CMNYTXID() As String
            Get
                Return fCMNYTXID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CMNYTXID", fCMNYTXID, value)
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
        Dim fNAME As String
        <Size(31)> _
        Public Property NAME() As String
            Get
                Return fNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("NAME", fNAME, value)
            End Set
        End Property
        Dim fCNTCPRSN As String
        <Size(61)> _
        Public Property CNTCPRSN() As String
            Get
                Return fCNTCPRSN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CNTCPRSN", fCNTCPRSN, value)
            End Set
        End Property
        Dim fADDRESS1 As String
        <Size(61)> _
        Public Property ADDRESS1() As String
            Get
                Return fADDRESS1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS1", fADDRESS1, value)
            End Set
        End Property
        Dim fADDRESS2 As String
        <Size(61)> _
        Public Property ADDRESS2() As String
            Get
                Return fADDRESS2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS2", fADDRESS2, value)
            End Set
        End Property
        Dim fADDRESS3 As String
        <Size(61)> _
        Public Property ADDRESS3() As String
            Get
                Return fADDRESS3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS3", fADDRESS3, value)
            End Set
        End Property
        Dim fCITY As String
        <Size(35)> _
        Public Property CITY() As String
            Get
                Return fCITY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CITY", fCITY, value)
            End Set
        End Property
        Dim fSTATE As String
        <Size(29)> _
        Public Property STATE() As String
            Get
                Return fSTATE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STATE", fSTATE, value)
            End Set
        End Property
        Dim fZIPCODE As String
        <Size(11)> _
        Public Property ZIPCODE() As String
            Get
                Return fZIPCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ZIPCODE", fZIPCODE, value)
            End Set
        End Property
        Dim fCOUNTRY As String
        <Size(61)> _
        Public Property COUNTRY() As String
            Get
                Return fCOUNTRY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COUNTRY", fCOUNTRY, value)
            End Set
        End Property
        Dim fPHONE1 As String
        <Size(21)> _
        Public Property PHONE1() As String
            Get
                Return fPHONE1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE1", fPHONE1, value)
            End Set
        End Property
        Dim fPHONE2 As String
        <Size(21)> _
        Public Property PHONE2() As String
            Get
                Return fPHONE2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE2", fPHONE2, value)
            End Set
        End Property
        Dim fPHONE3 As String
        <Size(21)> _
        Public Property PHONE3() As String
            Get
                Return fPHONE3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE3", fPHONE3, value)
            End Set
        End Property
        Dim fFAX As String
        <Size(21)> _
        Public Property FAX() As String
            Get
                Return fFAX
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FAX", fFAX, value)
            End Set
        End Property
        Dim fTXUSRDF1 As String
        <Size(21)> _
        Public Property TXUSRDF1() As String
            Get
                Return fTXUSRDF1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXUSRDF1", fTXUSRDF1, value)
            End Set
        End Property
        Dim fTXUSRDF2 As String
        <Size(21)> _
        Public Property TXUSRDF2() As String
            Get
                Return fTXUSRDF2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXUSRDF2", fTXUSRDF2, value)
            End Set
        End Property
        Dim fVATREGTX As Byte
        Public Property VATREGTX() As Byte
            Get
                Return fVATREGTX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("VATREGTX", fVATREGTX, value)
            End Set
        End Property
        Dim fTaxInvReqd As Byte
        Public Property TaxInvReqd() As Byte
            Get
                Return fTaxInvReqd
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TaxInvReqd", fTaxInvReqd, value)
            End Set
        End Property
        Dim fTaxPostToAcct As Short
        Public Property TaxPostToAcct() As Short
            Get
                Return fTaxPostToAcct
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TaxPostToAcct", fTaxPostToAcct, value)
            End Set
        End Property
        Dim fIGNRGRSSAMNT As Byte
        Public Property IGNRGRSSAMNT() As Byte
            Get
                Return fIGNRGRSSAMNT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("IGNRGRSSAMNT", fIGNRGRSSAMNT, value)
            End Set
        End Property
        Dim fTDTABPCT As Decimal
        Public Property TDTABPCT() As Decimal
            Get
                Return fTDTABPCT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TDTABPCT", fTDTABPCT, value)
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
