Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.POP
    ''' <summary>
    ''' GP Table POP10390
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("POP10390")> _
    <System.ComponentModel.DefaultProperty("POPRCTNM")> _
    <OptimisticLocking(False)> _
    Public Class POPReceiptDistribution
        Inherits XPLiteObject

        Public Structure POPReceiptDistributionKey
            Private fPOPRCTNM As String
            <Size(17)> _
            <Persistent("POPRCTNM")>
            Public Property POPRCTNM() As String
                Get
                    Return fPOPRCTNM
                End Get
                Set(ByVal value As String)
                    fPOPRCTNM = value
                End Set
            End Property
            Private fSEQNUMBR As Integer
            <Persistent("SEQNUMBR")>
            Public Property SEQNUMBR() As Integer
                Get
                    Return fSEQNUMBR
                End Get
                Set(ByVal value As Integer)
                    fSEQNUMBR = value
                End Set
            End Property
            Private fACTINDX As Integer
            <Persistent("ACTINDX")>
            Public Property ACTINDX() As Integer
                Get
                    Return fACTINDX
                End Get
                Set(ByVal value As Integer)
                    fACTINDX = value
                End Set
            End Property
            Private fDISTTYPE As Short
            <Persistent("DISTTYPE")>
            Public Property DISTTYPE() As Short
                Get
                    Return fDISTTYPE
                End Get
                Set(ByVal value As Short)
                    fDISTTYPE = value
                End Set
            End Property
            Private fXCHGRATE As Decimal
            <Persistent("XCHGRATE")>
            Public Property XCHGRATE() As Decimal
                Get
                    Return fXCHGRATE
                End Get
                Set(ByVal value As Decimal)
                    fXCHGRATE = value
                End Set
            End Property
            Private fVENDORID As String
            <Persistent("VENDORID")>
            <Size(15)> _
            Public Property VENDORID() As String
                Get
                    Return fVENDORID
                End Get
                Set(ByVal value As String)
                    fVENDORID = value
                End Set
            End Property
            Private fCURNCYID As String
            <Persistent("CURNCYID")>
            <Size(15)> _
            Public Property CURNCYID() As String
                Get
                    Return fCURNCYID
                End Get
                Set(ByVal value As String)
                    fCURNCYID = value
                End Set
            End Property
        End Structure

        Private _mOid As POPReceiptDistributionKey
        <Key()>
        <Persistent()>
        Public Property Oid As POPReceiptDistributionKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As POPReceiptDistributionKey)
                SetPropertyValue("Oid", _mOid, Value)
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
        Dim fORCRDAMT As Decimal
        Public Property ORCRDAMT() As Decimal
            Get
                Return fORCRDAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORCRDAMT", fORCRDAMT, value)
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
        Dim fORDBTAMT As Decimal
        Public Property ORDBTAMT() As Decimal
            Get
                Return fORDBTAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDBTAMT", fORDBTAMT, value)
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
        Dim fCURRNIDX As Short
        Public Property CURRNIDX() As Short
            Get
                Return fCURRNIDX
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CURRNIDX", fCURRNIDX, value)
            End Set
        End Property



        Dim fRATETPID As String
        <Size(15)> _
        Public Property RATETPID() As String
            Get
                Return fRATETPID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("RATETPID", fRATETPID, value)
            End Set
        End Property
        Dim fEXGTBLID As String
        <Size(15)> _
        Public Property EXGTBLID() As String
            Get
                Return fEXGTBLID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("EXGTBLID", fEXGTBLID, value)
            End Set
        End Property
        Dim fEXCHDATE As DateTime
        Public Property EXCHDATE() As DateTime
            Get
                Return fEXCHDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EXCHDATE", fEXCHDATE, value)
            End Set
        End Property
        Dim fTIME1 As DateTime
        Public Property TIME1() As DateTime
            Get
                Return fTIME1
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("TIME1", fTIME1, value)
            End Set
        End Property
        Dim fRATECALC As Short
        Public Property RATECALC() As Short
            Get
                Return fRATECALC
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RATECALC", fRATECALC, value)
            End Set
        End Property
        Dim fDENXRATE As Decimal
        Public Property DENXRATE() As Decimal
            Get
                Return fDENXRATE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DENXRATE", fDENXRATE, value)
            End Set
        End Property
        Dim fMCTRXSTT As Short
        Public Property MCTRXSTT() As Short
            Get
                Return fMCTRXSTT
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("MCTRXSTT", fMCTRXSTT, value)
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
