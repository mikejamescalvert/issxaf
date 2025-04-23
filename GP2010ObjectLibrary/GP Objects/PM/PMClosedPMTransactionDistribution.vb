Imports System
Imports DevExpress.Xpo
Namespace Objects.PM
    ''' <summary>
    ''' GP Table PM30600
    ''' </summary>
    <Persistent("PM30600")> _
    <OptimisticLocking(False)> _
    Public Class PMClosedPMTransactionDistribution
        Inherits XPLiteObject

        Public Structure ClosedPMTransactionDistributionKey
            Private fVCHRNMBR As String
            <Persistent("VCHRNMBR")> _
            <Size(21)> _
            Public Property VCHRNMBR() As String
                Get
                    Return fVCHRNMBR
                End Get
                Set(ByVal value As String)
                    fVCHRNMBR = value
                End Set
            End Property
            Private fDSTSQNUM As Integer
            <Persistent("DSTSQNUM")> _
            Public Property DSTSQNUM() As Integer
                Get
                    Return fDSTSQNUM
                End Get
                Set(ByVal value As Integer)
                    fDSTSQNUM = value
                End Set
            End Property
            Private fCNTRLTYP As Short
            <Persistent("CNTRLTYP")> _
            Public Property CNTRLTYP() As Short
                Get
                    Return fCNTRLTYP
                End Get
                Set(ByVal value As Short)
                    fCNTRLTYP = value
                End Set
            End Property
            Private fAPTVCHNM As String
            <Persistent("APTVCHNM")> _
            <Size(21)> _
            Public Property APTVCHNM() As String
                Get
                    Return fAPTVCHNM
                End Get
                Set(ByVal value As String)
                    fAPTVCHNM = value
                End Set
            End Property
            Private fSPCLDIST As Short
            <Persistent("SPCLDIST")> _
            Public Property SPCLDIST() As Short
                Get
                    Return fSPCLDIST
                End Get
                Set(ByVal value As Short)
                    fSPCLDIST = value
                End Set
            End Property
        End Structure

        Dim fOid As ClosedPMTransactionDistributionKey
        <Key()> _
        <Persistent()> _
        Public Property Oid() As ClosedPMTransactionDistributionKey
            Get
                Return fOid
            End Get
            Set(ByVal value As ClosedPMTransactionDistributionKey)
                SetPropertyValue(Of ClosedPMTransactionDistributionKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fDOCTYPE As Short
        Public Property DOCTYPE() As Short
            Get
                Return fDOCTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DOCTYPE", fDOCTYPE, value)
            End Set
        End Property
        Dim fCRDTAMNT As Decimal
        Public Property CRDTAMNT() As Decimal
            Get
                Return fCRDTAMNT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CRDTAMNT", fCRDTAMNT, value)
            End Set
        End Property
        Dim fDEBITAMT As Decimal
        Public Property DEBITAMT() As Decimal
            Get
                Return fDEBITAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DEBITAMT", fDEBITAMT, value)
            End Set
        End Property
        Dim fDSTINDX As Integer
        Public Property DSTINDX() As Integer
            Get
                Return fDSTINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DSTINDX", fDSTINDX, value)
            End Set
        End Property
        Dim fDISTTYPE As Short
        Public Property DISTTYPE() As Short
            Get
                Return fDISTTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DISTTYPE", fDISTTYPE, value)
            End Set
        End Property
        Dim fCHANGED As Byte
        Public Property CHANGED() As Byte
            Get
                Return fCHANGED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CHANGED", fCHANGED, value)
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
        Dim fPSTGSTUS As Short
        Public Property PSTGSTUS() As Short
            Get
                Return fPSTGSTUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PSTGSTUS", fPSTGSTUS, value)
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
        Dim fTRXSORCE As String
        <Size(13)> _
        Public Property TRXSORCE() As String
            Get
                Return fTRXSORCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXSORCE", fTRXSORCE, value)
            End Set
        End Property
        Dim fPSTGDATE As DateTime
        Public Property PSTGDATE() As DateTime
            Get
                Return fPSTGDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("PSTGDATE", fPSTGDATE, value)
            End Set
        End Property
        Dim fCURNCYID As String
        <Size(15)> _
        Public Property CURNCYID() As String
            Get
                Return fCURNCYID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CURNCYID", fCURNCYID, value)
            End Set
        End Property
        Dim fCURRNIDX As Short
        Public Property CURRNIDX() As Short
            Get
                Return fCURRNIDX
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CURRNIDX", fCURRNIDX, value)
            End Set
        End Property
        Dim fORCRDAMT As Decimal
        Public Property ORCRDAMT() As Decimal
            Get
                Return fORCRDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORCRDAMT", fORCRDAMT, value)
            End Set
        End Property
        Dim fORDBTAMT As Decimal
        Public Property ORDBTAMT() As Decimal
            Get
                Return fORDBTAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDBTAMT", fORDBTAMT, value)
            End Set
        End Property

        Dim fAPTODCTY As Short
        Public Property APTODCTY() As Short
            Get
                Return fAPTODCTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("APTODCTY", fAPTODCTY, value)
            End Set
        End Property

        Dim fDistRef As String
        <Size(31)> _
        Public Property DistRef() As String
            Get
                Return fDistRef
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DistRef", fDistRef, value)
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

        <PersistentAlias("[<GLAccountMaster>][ACTINDX = ^.DSTINDX].Single()")>
        Public ReadOnly Property GLAccountMaster() As GL.GLAccountMaster
            Get
                Return TryCast(EvaluateAlias("GLAccountMaster"), GL.GLAccountMaster)
            End Get
        End Property
        'Private _mGLAccountMaster As GL.GLAccountMaster
        'Public ReadOnly Property GLAccountMasterO() As GL.GLAccountMaster
        '    Get
        '        If _mGLAccountMaster Is Nothing Then
        '            _mGLAccountMaster = Session.FindObject(Of GL.GLAccountMaster)(New DevExpress.Data.Filtering.BinaryOperator("ACTINDX", Me.DSTINDX, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
        '        End If
        '        Return _mGLAccountMaster
        '    End Get
        'End Property

        Private _mDistributedTransactionAnalysisEntries As XPCollection(Of DTA.DTACodeAssignmentDetails)
        Public ReadOnly Property DistributedTransactionAnalysisEntries As XPCollection(Of DTA.DTACodeAssignmentDetails)
            Get
                RefreshDistributedTransactionAnalysisEntries()
                Return _mDistributedTransactionAnalysisEntries
            End Get
        End Property

        Public Sub RefreshDistributedTransactionAnalysisEntries()
            Dim ddfFilter As DevExpress.Data.Filtering.GroupOperator
            If _mDistributedTransactionAnalysisEntries Is Nothing Then
                ddfFilter = New DevExpress.Data.Filtering.GroupOperator
                ddfFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("DOCNUMBR", Me.Oid.VCHRNMBR, DevExpress.Data.Filtering.BinaryOperatorType.Like))
                ddfFilter.Operands.Add(New DevExpress.Data.Filtering.BinaryOperator("CompoundKey1.SEQNUMBR", Me.Oid.DSTSQNUM, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
                _mDistributedTransactionAnalysisEntries = New XPCollection(Of DTA.DTACodeAssignmentDetails)(Session, ddfFilter)

            End If
        End Sub


    End Class

End Namespace
