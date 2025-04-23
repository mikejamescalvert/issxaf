Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation


Namespace Objects.SY
    ''' <summary>
    ''' GP Table SY03000
    ''' </summary>
    <Persistent("SY03000")> _
    <DefaultProperty("SHMTHDSC")> _
    <OptimisticLocking(False)> _
    Public Class SYShippingMethod
        Inherits XPLiteObject
        Dim fSHIPMTHD As String
        <Key()> _
        <Size(15)> _
        Public Property SHIPMTHD() As String
            Get
                Return fSHIPMTHD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SHIPMTHD", fSHIPMTHD, value)
            End Set
        End Property
        Dim fSHMTHDSC As String
        <Size(31)> _
        Public Property SHMTHDSC() As String
            Get
                Return fSHMTHDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SHMTHDSC", fSHMTHDSC, value)
            End Set
        End Property
        Dim fPHONNAME As String
        <Size(21)> _
        Public Property PHONNAME() As String
            Get
                Return fPHONNAME
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONNAME", fPHONNAME, value)
            End Set
        End Property
        Dim fCONTACT As String
        <Size(61)> _
        Public Property CONTACT() As String
            Get
                Return fCONTACT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CONTACT", fCONTACT, value)
            End Set
        End Property
        Dim fCARRACCT As String
        <Size(15)> _
        Public Property CARRACCT() As String
            Get
                Return fCARRACCT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CARRACCT", fCARRACCT, value)
            End Set
        End Property
        Dim fCARRIER As String
        <Size(31)> _
        Public Property CARRIER() As String
            Get
                Return fCARRIER
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CARRIER", fCARRIER, value)
            End Set
        End Property
        Dim fSHIPTYPE As Short
        Public Property SHIPTYPE() As Short
            Get
                Return fSHIPTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SHIPTYPE", fSHIPTYPE, value)
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
        Dim fLSTUSRED As String
        <Size(15)> _
        Public Property LSTUSRED() As String
            Get
                Return fLSTUSRED
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LSTUSRED", fLSTUSRED, value)
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
        Dim fMODIFDT As DateTime
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
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