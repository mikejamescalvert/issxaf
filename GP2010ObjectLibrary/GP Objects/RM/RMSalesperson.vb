Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation


Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM00301
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("RM00301")> _
    <DefaultProperty("npSummaryInfo")> _
    <OptimisticLocking(False)> _
    Public Class RMSalesperson
        Inherits XPLiteObject



#Region "Behaviors"

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub



#End Region


#Region "Non-Persistent Properties"
        <PersistentAlias("concat(SLPRSNID,' - ',SLPRSNFN,' ',SPRSNSLN)")>
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Summary Info")>
        Public ReadOnly Property npSummaryInfo As String
            Get
                Return EvaluateAlias("npSummaryInfo")
            End Get
        End Property

        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Full Name")>
        <PersistentAlias("concat(SLPRSNFN,' ',SPRSNSLN)")>
        Public ReadOnly Property npFullName As String
            Get
                Return EvaluateAlias("npFullName")
            End Get
        End Property
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Email Address")>
        Public ReadOnly Property npEmailAddress As String
            Get
                Return INetInfo.INET1
            End Get
        End Property

        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <PersistentAlias("[<SYInternetAddressDetail>][Oid.Master_ID = ^.SLPRSNID AND Oid.Master_Type = 'SLP'].Single()")>
        Public ReadOnly Property INetInfo As SY.SYInternetAddressDetail
            Get
                Return TryCast(EvaluateAlias("INetInfo"), SY.SYInternetAddressDetail)
            End Get
        End Property

        'Private _mINetInfo As sy.SYInternetAddressDetail
        '<VisibleInDetailView(False)>
        '<VisibleInListView(False)>
        'Public ReadOnly Property INetInfoO As SY.SYInternetAddressDetail
        '    Get
        '        If _mINetInfo Is Nothing Then
        '            _mINetInfo = SY.Helpers.SYHelper.GetInternetDetailsForSalesPerson(Me.SLPRSNID, "SLP", Me.Session)
        '        End If
        '        Return _mINetInfo
        '    End Get
        'End Property

        

#End Region

#Region "Properties"



        Private fSLPRSNID As String
        <Size(15)> _
        <Key()> _
        Public Property SLPRSNID() As String
            Get
                Return fSLPRSNID
            End Get
            Set(ByVal value As String)
                fSLPRSNID = value
            End Set
        End Property

        Dim fEMPLOYID As String
        <Size(15)> _
        Public Property EMPLOYID() As String
            Get
                Return fEMPLOYID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EMPLOYID", fEMPLOYID, value)
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
        Dim fSLPRSNFN As String
        <Size(15)> _
        Public Property SLPRSNFN() As String
            Get
                Return fSLPRSNFN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SLPRSNFN", fSLPRSNFN, value)
            End Set
        End Property
        Dim fSPRSNSMN As String
        <Size(15)> _
        Public Property SPRSNSMN() As String
            Get
                Return fSPRSNSMN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SPRSNSMN", fSPRSNSMN, value)
            End Set
        End Property
        Dim fSPRSNSLN As String
        <Size(21)> _
        Public Property SPRSNSLN() As String
            Get
                Return fSPRSNSLN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SPRSNSLN", fSPRSNSLN, value)
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
        Dim fZIP As String
        <Size(11)> _
        Public Property ZIP() As String
            Get
                Return fZIP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ZIP", fZIP, value)
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
        Dim fINACTIVE As Byte
        Public Property INACTIVE() As Byte
            Get
                Return fINACTIVE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INACTIVE", fINACTIVE, value)
            End Set
        End Property
        Dim fSALSTERR As String
        <Size(15)> _
        Public Property SALSTERR() As String
            Get
                Return fSALSTERR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SALSTERR", fSALSTERR, value)
            End Set
        End Property
        Dim fCOMMCODE As String
        <Size(15)> _
        Public Property COMMCODE() As String
            Get
                Return fCOMMCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMCODE", fCOMMCODE, value)
            End Set
        End Property
        Dim fCOMPRCNT As Short
        Public Property COMPRCNT() As Short
            Get
                Return fCOMPRCNT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("COMPRCNT", fCOMPRCNT, value)
            End Set
        End Property
        Dim fSTDCPRCT As Short
        Public Property STDCPRCT() As Short
            Get
                Return fSTDCPRCT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("STDCPRCT", fSTDCPRCT, value)
            End Set
        End Property
        Dim fCOMAPPTO As Short
        Public Property COMAPPTO() As Short
            Get
                Return fCOMAPPTO
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("COMAPPTO", fCOMAPPTO, value)
            End Set
        End Property
        Dim fCOSTTODT As Decimal
        Public Property COSTTODT() As Decimal
            Get
                Return fCOSTTODT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("COSTTODT", fCOSTTODT, value)
            End Set
        End Property
        Dim fCSTLSTYR As Decimal
        Public Property CSTLSTYR() As Decimal
            Get
                Return fCSTLSTYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CSTLSTYR", fCSTLSTYR, value)
            End Set
        End Property
        Dim fTTLCOMTD As Decimal
        Public Property TTLCOMTD() As Decimal
            Get
                Return fTTLCOMTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TTLCOMTD", fTTLCOMTD, value)
            End Set
        End Property
        Dim fTTLCOMLY As Decimal
        Public Property TTLCOMLY() As Decimal
            Get
                Return fTTLCOMLY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("TTLCOMLY", fTTLCOMLY, value)
            End Set
        End Property
        Dim fCOMSLTDT As Decimal
        Public Property COMSLTDT() As Decimal
            Get
                Return fCOMSLTDT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("COMSLTDT", fCOMSLTDT, value)
            End Set
        End Property
        Dim fCOMSLLYR As Decimal
        Public Property COMSLLYR() As Decimal
            Get
                Return fCOMSLLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("COMSLLYR", fCOMSLLYR, value)
            End Set
        End Property
        Dim fNCOMSLTD As Decimal
        Public Property NCOMSLTD() As Decimal
            Get
                Return fNCOMSLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NCOMSLTD", fNCOMSLTD, value)
            End Set
        End Property
        Dim fNCOMSLYR As Decimal
        Public Property NCOMSLYR() As Decimal
            Get
                Return fNCOMSLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NCOMSLYR", fNCOMSLYR, value)
            End Set
        End Property
        Dim fKPCALHST As Byte
        Public Property KPCALHST() As Byte
            Get
                Return fKPCALHST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPCALHST", fKPCALHST, value)
            End Set
        End Property
        Dim fKPERHIST As Byte
        Public Property KPERHIST() As Byte
            Get
                Return fKPERHIST
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("KPERHIST", fKPERHIST, value)
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
        Dim fMODIFDT As DateTime
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
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
        Dim fCOMMDEST As Short
        Public Property COMMDEST() As Short
            Get
                Return fCOMMDEST
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("COMMDEST", fCOMMDEST, value)
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


        Private _mCustomers As XPCollection(Of RM.RMCustomer)
        <VisibleInDetailView(False)>
        <VisibleInListView(False)>
        <System.ComponentModel.DisplayName("Customers")>
        Public ReadOnly Property npCustomers As XPCollection(Of RM.RMCustomer)
            Get
                If _mCustomers Is Nothing Then
                    _mCustomers = New XPCollection(Of RM.RMCustomer)(Session, New BinaryOperator("SLPRSNID", Me.SLPRSNID))
                End If
                Return _mCustomers
            End Get
        End Property

#End Region
    End Class

End Namespace
