Imports System
Imports DevExpress.Xpo
Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM00303
    ''' </summary>
    <Persistent("RM00303")>
    Public Class RMTerritory
        Inherits XPLiteObject
        Dim fSALSTERR As String
        <Key()>
        <Size(15)>
        Public Property SALSTERR() As String
            Get
                Return fSALSTERR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SALSTERR", fSALSTERR, value)
            End Set
        End Property
        Dim fSLTERDSC As String
        <Size(31)>
        Public Property SLTERDSC() As String
            Get
                Return fSLTERDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SLTERDSC", fSLTERDSC, value)
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
        Dim fSLPRSNID As String
        <Size(15)>
        Public Property SLPRSNID() As String
            Get
                Return fSLPRSNID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SLPRSNID", fSLPRSNID, value)
            End Set
        End Property
        Dim fSTMGRFNM As String
        <Size(15)>
        Public Property STMGRFNM() As String
            Get
                Return fSTMGRFNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STMGRFNM", fSTMGRFNM, value)
            End Set
        End Property
        Dim fSTMGRMNM As String
        <Size(15)>
        Public Property STMGRMNM() As String
            Get
                Return fSTMGRMNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STMGRMNM", fSTMGRMNM, value)
            End Set
        End Property
        Dim fSTMGRLNM As String
        <Size(21)>
        Public Property STMGRLNM() As String
            Get
                Return fSTMGRLNM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STMGRLNM", fSTMGRLNM, value)
            End Set
        End Property
        Dim fCOUNTRY As String
        <Size(61)>
        Public Property COUNTRY() As String
            Get
                Return fCOUNTRY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COUNTRY", fCOUNTRY, value)
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
        Dim fNCOMSLYR As Decimal
        Public Property NCOMSLYR() As Decimal
            Get
                Return fNCOMSLYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NCOMSLYR", fNCOMSLYR, value)
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
        Dim fCSTLSTYR As Decimal
        Public Property CSTLSTYR() As Decimal
            Get
                Return fCSTLSTYR
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CSTLSTYR", fCSTLSTYR, value)
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
        Dim fNCOMSLTD As Decimal
        Public Property NCOMSLTD() As Decimal
            Get
                Return fNCOMSLTD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NCOMSLTD", fNCOMSLTD, value)
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
