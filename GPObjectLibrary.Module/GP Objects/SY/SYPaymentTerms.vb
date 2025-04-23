Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.SY
    ''' <summary>
    ''' GP Table SY03300
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.DefaultProperty("PYMTRMID")>
    <OptimisticLocking(False)>
    <Persistent("SY03300")>
    Public Class SYPaymentTerms
        Inherits XPLiteObject
        Public Enum DueTypes
            NetDays = 1
            [Date] = 2
            EOM = 3
            None = 4
            NextMonth = 5
            Months = 6
            MonthDay = 7
            Annual = 8

        End Enum


        Dim fPYMTRMID As String
        <Key()> _
        <Size(21)> _
        Public Property PYMTRMID() As String
            Get
                Return fPYMTRMID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PYMTRMID", fPYMTRMID, value)
            End Set
        End Property
        Dim fDUETYPE As DueTypes
        Public Property DUETYPE() As DueTypes
            Get
                Return fDUETYPE
            End Get
            Set(ByVal value As DueTypes)
                SetPropertyValue(Of Short)("DUETYPE", fDUETYPE, value)
            End Set
        End Property
        Dim fDUEDTDS As Short
        Public Property DUEDTDS() As Short
            Get
                Return fDUEDTDS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DUEDTDS", fDUEDTDS, value)
            End Set
        End Property
        Dim fDISCTYPE As Short
        Public Property DISCTYPE() As Short
            Get
                Return fDISCTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DISCTYPE", fDISCTYPE, value)
            End Set
        End Property
        Dim fDISCDTDS As Short
        Public Property DISCDTDS() As Short
            Get
                Return fDISCDTDS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DISCDTDS", fDISCDTDS, value)
            End Set
        End Property
        Dim fDSCLCTYP As Short
        Public Property DSCLCTYP() As Short
            Get
                Return fDSCLCTYP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DSCLCTYP", fDSCLCTYP, value)
            End Set
        End Property
        Dim fDSCDLRAM As Decimal
        Public Property DSCDLRAM() As Decimal
            Get
                Return fDSCDLRAM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("DSCDLRAM", fDSCDLRAM, value)
            End Set
        End Property
        Dim fDSCPCTAM As Short
        Public Property DSCPCTAM() As Short
            Get
                Return fDSCPCTAM
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DSCPCTAM", fDSCPCTAM, value)
            End Set
        End Property
        Dim fSALPURCH As Byte
        Public Property SALPURCH() As Byte
            Get
                Return fSALPURCH
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("SALPURCH", fSALPURCH, value)
            End Set
        End Property
        Dim fDISCNTCB As Byte
        Public Property DISCNTCB() As Byte
            Get
                Return fDISCNTCB
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DISCNTCB", fDISCNTCB, value)
            End Set
        End Property
        Dim fFREIGHT As Byte
        Public Property FREIGHT() As Byte
            Get
                Return fFREIGHT
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("FREIGHT", fFREIGHT, value)
            End Set
        End Property
        Dim fMISC As Byte
        Public Property MISC() As Byte
            Get
                Return fMISC
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("MISC", fMISC, value)
            End Set
        End Property
        Dim fTAX As Byte
        Public Property TAX() As Byte
            Get
                Return fTAX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TAX", fTAX, value)
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
        Dim fCBUVATMD As Byte
        Public Property CBUVATMD() As Byte
            Get
                Return fCBUVATMD
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CBUVATMD", fCBUVATMD, value)
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
        Dim fUSEGRPER As Byte
        Public Property USEGRPER() As Byte
            Get
                Return fUSEGRPER
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("USEGRPER", fUSEGRPER, value)
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
