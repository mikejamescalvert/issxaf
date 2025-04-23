Imports System
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10300
    ''' </summary>
    <Persistent("IV10300")>
    <OptimisticLocking(False)>
    <System.ComponentModel.DefaultProperty("STCKCNTID")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class IVItemStockCount
        Inherits XPLiteObject
        Dim fSTCKCNTID As String
        <Key()>
        <Size(15)>
        <DisplayName("Stock Count Id")>
        Public Property STCKCNTID() As String
            Get
                Return fSTCKCNTID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STCKCNTID", fSTCKCNTID, value)
            End Set
        End Property
        Dim fSTCKCNTDSCRPTN As String
        <Size(31)>
        <DisplayName("Description")>
        Public Property STCKCNTDSCRPTN() As String
            Get
                Return fSTCKCNTDSCRPTN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STCKCNTDSCRPTN", fSTCKCNTDSCRPTN, value)
            End Set
        End Property
        Dim fSTCKCNTSTTS As Short
        <VisibleInListView(False)>
        Public Property STCKCNTSTTS() As Short

            Get
                Return fSTCKCNTSTTS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("STCKCNTSTTS", fSTCKCNTSTTS, value)
            End Set
        End Property
        Dim fDOCDATE As DateTime
        <VisibleInListView(False)>
        Public Property DOCDATE() As DateTime
            Get
                Return fDOCDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DOCDATE", fDOCDATE, value)
            End Set
        End Property
        Dim fGLPOSTDT As DateTime
        <VisibleInListView(False)>
        Public Property GLPOSTDT() As DateTime
            Get
                Return fGLPOSTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("GLPOSTDT", fGLPOSTDT, value)
            End Set
        End Property
        Dim fNOTEINDX As Decimal
        <VisibleInListView(False)>
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
            End Set
        End Property
        Dim fCNTSTRTDT As DateTime
        <VisibleInListView(False)>
        Public Property CNTSTRTDT() As DateTime
            Get
                Return fCNTSTRTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CNTSTRTDT", fCNTSTRTDT, value)
            End Set
        End Property
        Dim fCNTSTRTTM As DateTime
        <VisibleInListView(False)>
        Public Property CNTSTRTTM() As DateTime
            Get
                Return fCNTSTRTTM
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CNTSTRTTM", fCNTSTRTTM, value)
            End Set
        End Property
        Dim fATPSTVRNC As Byte
        <VisibleInListView(False)>
        Public Property ATPSTVRNC() As Byte
            Get
                Return fATPSTVRNC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ATPSTVRNC", fATPSTVRNC, value)
            End Set
        End Property
        Dim fRSSTCKCNT As Byte
        <VisibleInListView(False)>
        Public Property RSSTCKCNT() As Byte
            Get
                Return fRSSTCKCNT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("RSSTCKCNT", fRSSTCKCNT, value)
            End Set
        End Property
        Dim fDFLTCNTDT As DateTime
        <VisibleInListView(False)>
        Public Property DFLTCNTDT() As DateTime
            Get
                Return fDFLTCNTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DFLTCNTDT", fDFLTCNTDT, value)
            End Set
        End Property
        Dim fDFLTCNTTM As DateTime
        <VisibleInListView(False)>
        Public Property DFLTCNTTM() As DateTime
            Get
                Return fDFLTCNTTM
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("DFLTCNTTM", fDFLTCNTTM, value)
            End Set
        End Property
        Dim fLSTCNTDT As DateTime
        <VisibleInListView(False)>
        Public Property LSTCNTDT() As DateTime
            Get
                Return fLSTCNTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTCNTDT", fLSTCNTDT, value)
            End Set
        End Property
        Dim fENABLEMULTIBIN As Byte
        <VisibleInListView(False)>
        Public Property ENABLEMULTIBIN() As Byte
            Get
                Return fENABLEMULTIBIN
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ENABLEMULTIBIN", fENABLEMULTIBIN, value)
            End Set
        End Property
        Dim fLOCNCODE As String
        <Size(11)>
        <VisibleInListView(False)>
        Public Property LOCNCODE() As String
            Get
                Return fLOCNCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNCODE", fLOCNCODE, value)
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
