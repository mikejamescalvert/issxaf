Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV40700
    ''' </summary>
    <Persistent("IV40700")> _
        <OptimisticLocking(False)> _
        <DefaultProperty("LOCNCODE")> _
    Public Class IVSite
        Inherits XPLiteObject
        Dim fLOCNCODE As String
        <Key()> _
        <Size(11)> _
        Public Property LOCNCODE() As String
            Get
                Return fLOCNCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNCODE", fLOCNCODE, value)
            End Set
        End Property
        Dim fLOCNDSCR As String
        <Size(31)> _
        Public Property LOCNDSCR() As String
            Get
                Return fLOCNDSCR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNDSCR", fLOCNDSCR, value)
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
        Dim fFAXNUMBR As String
        <Size(21)> _
        Public Property FAXNUMBR() As String
            Get
                Return fFAXNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FAXNUMBR", fFAXNUMBR, value)
            End Set
        End Property
        Dim fLocation_Segment As String
        <Size(67)> _
        Public Property Location_Segment() As String
            Get
                Return fLocation_Segment
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Location_Segment", fLocation_Segment, value)
            End Set
        End Property
        Dim fSTAXSCHD As String
        <Size(15)> _
        Public Property STAXSCHD() As String
            Get
                Return fSTAXSCHD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STAXSCHD", fSTAXSCHD, value)
            End Set
        End Property
        Dim fPCTAXSCH As String
        <Size(15)> _
        Public Property PCTAXSCH() As String
            Get
                Return fPCTAXSCH
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PCTAXSCH", fPCTAXSCH, value)
            End Set
        End Property
        Dim fINCLDDINPLNNNG As Byte
        Public Property INCLDDINPLNNNG() As Byte
            Get
                Return fINCLDDINPLNNNG
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("INCLDDINPLNNNG", fINCLDDINPLNNNG, value)
            End Set
        End Property
        Dim fPORECEIPTBIN As String
        <Size(15)> _
        Public Property PORECEIPTBIN() As String
            Get
                Return fPORECEIPTBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PORECEIPTBIN", fPORECEIPTBIN, value)
            End Set
        End Property
        Dim fPORETRNBIN As String
        <Size(15)> _
        Public Property PORETRNBIN() As String
            Get
                Return fPORETRNBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PORETRNBIN", fPORETRNBIN, value)
            End Set
        End Property
        Dim fSOFULFILLMENTBIN As String
        <Size(15)> _
        Public Property SOFULFILLMENTBIN() As String
            Get
                Return fSOFULFILLMENTBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOFULFILLMENTBIN", fSOFULFILLMENTBIN, value)
            End Set
        End Property
        Dim fSORETURNBIN As String
        <Size(15)> _
        Public Property SORETURNBIN() As String
            Get
                Return fSORETURNBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SORETURNBIN", fSORETURNBIN, value)
            End Set
        End Property
        Dim fBOMRCPTBIN As String
        <Size(15)> _
        Public Property BOMRCPTBIN() As String
            Get
                Return fBOMRCPTBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BOMRCPTBIN", fBOMRCPTBIN, value)
            End Set
        End Property
        Dim fMATERIALISSUEBIN As String
        <Size(15)> _
        Public Property MATERIALISSUEBIN() As String
            Get
                Return fMATERIALISSUEBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MATERIALISSUEBIN", fMATERIALISSUEBIN, value)
            End Set
        End Property
        Dim fMORECEIPTBIN As String
        <Size(15)> _
        Public Property MORECEIPTBIN() As String
            Get
                Return fMORECEIPTBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MORECEIPTBIN", fMORECEIPTBIN, value)
            End Set
        End Property
        Dim fREPAIRISSUESBIN As String
        <Size(15)> _
        Public Property REPAIRISSUESBIN() As String
            Get
                Return fREPAIRISSUESBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("REPAIRISSUESBIN", fREPAIRISSUESBIN, value)
            End Set
        End Property
        Dim fWMSINT As Byte
        Public Property WMSINT() As Byte
            Get
                Return fWMSINT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("WMSINT", fWMSINT, value)
            End Set
        End Property
        Dim fPICKTICKETSITEOPT As Short
        Public Property PICKTICKETSITEOPT() As Short
            Get
                Return fPICKTICKETSITEOPT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PICKTICKETSITEOPT", fPICKTICKETSITEOPT, value)
            End Set
        End Property
        Dim fBINBREAK As Short
        Public Property BINBREAK() As Short
            Get
                Return fBINBREAK
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("BINBREAK", fBINBREAK, value)
            End Set
        End Property
        Dim fCCode As String
        <Size(7)> _
        Public Property CCode() As String
            Get
                Return fCCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CCode", fCCode, value)
            End Set
        End Property
        Dim fDECLID As String
        <Size(15)> _
        Public Property DECLID() As String
            Get
                Return fDECLID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DECLID", fDECLID, value)
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

#Region "NonPersistent"

        Private _mItemQuantities As xpcollection(Of IVItemQuantity)
        Public ReadOnly Property npItemQuantities As XPCollection(Of IVItemQuantity)
            Get
                _mItemQuantities = New XPCollection(Of IVItemQuantity)(Session, New BinaryOperator("Oid.LOCNCODE", Me.LOCNCODE))
                Return _mItemQuantities
            End Get
        End Property

        Private _mItemsAtSite As XPCollection(Of IVItem)
        Public ReadOnly Property npItemsAtSite As XPCollection(Of IVItem)
            Get
                Dim strCriteria As String
                If _mItemsAtSite Is Nothing Then
                    strCriteria = String.Format("[<IVItemQuantity>][^.ITEMNMBR = Oid.ITEMNMBR AND Oid.LOCNCODE = '{0}']", LOCNCODE)
                    _mItemsAtSite = New XPCollection(Of IVItem)(Session, CriteriaOperator.Parse(strCriteria))
                End If
                Return _mItemsAtSite
            End Get
        End Property



#End Region
    End Class

End Namespace
