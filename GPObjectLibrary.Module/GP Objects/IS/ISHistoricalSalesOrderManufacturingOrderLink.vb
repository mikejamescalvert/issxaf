Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base
Imports System.ComponentModel
Namespace Objects.IS

    Public Structure HistoricalSalesOrderManufacturingOrderLinkKey
        Private _mSOPNUMBE As String
        <Persistent("SOPNUMBE")> _
        Public Property SOPNUMBE() As String
            Get
                Return _mSOPNUMBE
            End Get
            Set(ByVal value As String)
                If _mSOPNUMBE = value Then
                    Return
                End If
                _mSOPNUMBE = value
            End Set
        End Property
        Private _mSOPTYPE As Short
        <Persistent("SOPTYPE")> _
        Public Property SOPTYPE() As Short
            Get
                Return _mSOPTYPE
            End Get
            Set(ByVal value As Short)
                If _mSOPTYPE = value Then
                    Return
                End If
                _mSOPTYPE = value
            End Set
        End Property
        Private _mLNITMSEQ As Integer
        <Persistent("LNITMSEQ")> _
        Public Property LNITMSEQ() As Integer
            Get
                Return _mLNITMSEQ
            End Get
            Set(ByVal value As Integer)
                If _mLNITMSEQ = value Then
                    Return
                End If
                _mLNITMSEQ = value
            End Set
        End Property
        Private _mCMPNTSEQ As Integer
        <Persistent("CMPNTSEQ")> _
        Public Property CMPNTSEQ() As Integer
            Get
                Return _mCMPNTSEQ
            End Get
            Set(ByVal value As Integer)
                If _mCMPNTSEQ = value Then
                    Return
                End If
                _mCMPNTSEQ = value
            End Set
        End Property
    End Structure
    ''' <summary>
    ''' GP Table IS030001
    ''' </summary>
    <Persistent("IS030001")> _
    <DefaultProperty("SummaryInfo")> _
    <OptimisticLocking(False)> _
    Public Class ISHistoricalSalesOrderManufacturingOrderLink
        Inherits XPLiteObject
        Dim fOid As HistoricalSalesOrderManufacturingOrderLinkKey
        <Key()> _
        <Persistent()> _
        Public Property Oid() As HistoricalSalesOrderManufacturingOrderLinkKey
            Get
                Return fOid
            End Get
            Set(ByVal value As HistoricalSalesOrderManufacturingOrderLinkKey)
                SetPropertyValue(Of HistoricalSalesOrderManufacturingOrderLinkKey)("Oid", fOid, value)
            End Set
        End Property
        'Dim fSOPNUMBE As String
        '<Size(21)> _
        'Public Property SOPNUMBE() As String
        '	Get
        '		Return fSOPNUMBE
        '	End Get
        '	Set(ByVal value As String)
        '		SetPropertyValue(Of String)("SOPNUMBE", fSOPNUMBE, value)
        '	End Set
        'End Property
        'Dim fSOPTYPE As Short
        'Public Property SOPTYPE() As Short
        '	Get
        '		Return fSOPTYPE
        '	End Get
        '	Set(ByVal value As Short)
        '		SetPropertyValue(Of Short)("SOPTYPE", fSOPTYPE, value)
        '	End Set
        'End Property
        'Dim fLNITMSEQ As Integer
        'Public Property LNITMSEQ() As Integer
        '	Get
        '		Return fLNITMSEQ
        '	End Get
        '	Set(ByVal value As Integer)
        '		SetPropertyValue(Of Integer)("LNITMSEQ", fLNITMSEQ, value)
        '	End Set
        'End Property
        'Dim fCMPNTSEQ As Integer
        'Public Property CMPNTSEQ() As Integer
        '	Get
        '		Return fCMPNTSEQ
        '	End Get
        '	Set(ByVal value As Integer)
        '		SetPropertyValue(Of Integer)("CMPNTSEQ", fCMPNTSEQ, value)
        '	End Set
        'End Property
        Dim fMANUFACTUREORDER_I As String
        <Size(31)> _
        Public Property MANUFACTUREORDER_I() As String
            Get
                Return fMANUFACTUREORDER_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MANUFACTUREORDER_I", fMANUFACTUREORDER_I, value)
            End Set
        End Property
        Dim fSOITEMDUEDATE_I As DateTime
        Public Property SOITEMDUEDATE_I() As DateTime
            Get
                Return fSOITEMDUEDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("SOITEMDUEDATE_I", fSOITEMDUEDATE_I, value)
            End Set
        End Property
        Dim fSOITEMPROMISEDATE_I As DateTime
        Public Property SOITEMPROMISEDATE_I() As DateTime
            Get
                Return fSOITEMPROMISEDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("SOITEMPROMISEDATE_I", fSOITEMPROMISEDATE_I, value)
            End Set
        End Property
        Dim fCUSTOMERPARTNUMBER_I As String
        <Size(31)> _
        Public Property CUSTOMERPARTNUMBER_I() As String
            Get
                Return fCUSTOMERPARTNUMBER_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTOMERPARTNUMBER_I", fCUSTOMERPARTNUMBER_I, value)
            End Set
        End Property
        Dim fSOCHANGEDATE_I As DateTime
        Public Property SOCHANGEDATE_I() As DateTime
            Get
                Return fSOCHANGEDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("SOCHANGEDATE_I", fSOCHANGEDATE_I, value)
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
        Dim fREVISIONLEVEL_I As String
        <Size(51)> _
        Public Property REVISIONLEVEL_I() As String
            Get
                Return fREVISIONLEVEL_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("REVISIONLEVEL_I", fREVISIONLEVEL_I, value)
            End Set
        End Property
        Dim fMFGNOTEINDEX_I As Decimal
        Public Property MFGNOTEINDEX_I() As Decimal
            Get
                Return fMFGNOTEINDEX_I
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MFGNOTEINDEX_I", fMFGNOTEINDEX_I, value)
            End Set
        End Property
        Dim fMRKDNAMT As Decimal
        Public Property MRKDNAMT() As Decimal
            Get
                Return fMRKDNAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MRKDNAMT", fMRKDNAMT, value)
            End Set
        End Property
        Dim fMarkdown_Amount_Addition As Decimal
        Public Property Markdown_Amount_Addition() As Decimal
            Get
                Return fMarkdown_Amount_Addition
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Markdown_Amount_Addition", fMarkdown_Amount_Addition, value)
            End Set
        End Property
        Dim fCHANGEDATE_I As DateTime
        Public Property CHANGEDATE_I() As DateTime
            Get
                Return fCHANGEDATE_I
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CHANGEDATE_I", fCHANGEDATE_I, value)
            End Set
        End Property
        Dim fUSERID As String
        <Size(15)> _
        Public Property USERID() As String
            Get
                Return fUSERID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERID", fUSERID, value)
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
        <PersistentAlias("concat('Order Number: ',Oid.SOPNUMBE,' Manufacturing Order: ',MANUFACTUREORDER_I)")>
        Public ReadOnly Property SummaryInfo() As String
            Get
                Return EvaluateAlias("SummaryInfo") ' String.Format("Order Number:{0} Manufacturing Order: {1}", Me.Oid.SOPNUMBE.Trim, Me.MANUFACTUREORDER_I.Trim)
            End Get
        End Property

    End Class

End Namespace
