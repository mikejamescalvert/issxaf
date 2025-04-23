Imports System
Imports DevExpress.Xpo

Namespace Objects.CN
    ''' <summary>
    ''' GP Table CN00500 - Customer Collection Options
    ''' </summary>
    <Persistent("CN00500")> _
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()> _
    <OptimisticLocking(False)> _
    Public Class CNCustomerCollectionInfo
        Inherits XPLiteObject
        Dim fCUSTNMBR As String
        <Key()> _
        <Size(15)> _
        Public Property CUSTNMBR() As String
            Get
                Return fCUSTNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNMBR", fCUSTNMBR, value)
            End Set
        End Property
        Dim fCRDTMGR As String
        <Size(15)> _
        Public Property CRDTMGR() As String
            Get
                Return fCRDTMGR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CRDTMGR", fCRDTMGR, value)
            End Set
        End Property
        Dim fPreferredContactMethod As Short
        Public Property PreferredContactMethod() As Short
            Get
                Return fPreferredContactMethod
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PreferredContactMethod", fPreferredContactMethod, value)
            End Set
        End Property
        Dim fNOMAIL As Byte
        Public Property NOMAIL() As Byte
            Get
                Return fNOMAIL
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("NOMAIL", fNOMAIL, value)
            End Set
        End Property
        Dim fADRSCODE As String
        <Size(15)> _
        Public Property ADRSCODE() As String
            Get
                Return fADRSCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADRSCODE", fADRSCODE, value)
            End Set
        End Property
        Dim fTime_Zone As Short
        Public Property Time_Zone() As Short
            Get
                Return fTime_Zone
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("Time_Zone", fTime_Zone, value)
            End Set
        End Property
        Dim fCN_Credit_Control_Cycle As Short
        Public Property CN_Credit_Control_Cycle() As Short
            Get
                Return fCN_Credit_Control_Cycle
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CN_Credit_Control_Cycle", fCN_Credit_Control_Cycle, value)
            End Set
        End Property
        Dim fUSRTAB01 As String
        <Size(21)> _
        Public Property USRTAB01() As String
            Get
                Return fUSRTAB01
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USRTAB01", fUSRTAB01, value)
            End Set
        End Property
        Dim fUSRTAB09 As String
        <Size(21)> _
        Public Property USRTAB09() As String
            Get
                Return fUSRTAB09
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USRTAB09", fUSRTAB09, value)
            End Set
        End Property
        Dim fUSERDEF1 As String
        <Size(21)> _
        Public Property USERDEF1() As String
            Get
                Return fUSERDEF1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERDEF1", fUSERDEF1, value)
            End Set
        End Property
        Dim fUSERDEF2 As String
        <Size(21)> _
        Public Property USERDEF2() As String
            Get
                Return fUSERDEF2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERDEF2", fUSERDEF2, value)
            End Set
        End Property
        Dim fUSRDAT01 As DateTime
        Public Property USRDAT01() As DateTime
            Get
                Return fUSRDAT01
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("USRDAT01", fUSRDAT01, value)
            End Set
        End Property
        Dim fUser_Defined_CB1 As Byte
        Public Property User_Defined_CB1() As Byte
            Get
                Return fUser_Defined_CB1
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("User_Defined_CB1", fUser_Defined_CB1, value)
            End Set
        End Property
        Dim fUser_Defined_CB2 As Byte
        Public Property User_Defined_CB2() As Byte
            Get
                Return fUser_Defined_CB2
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("User_Defined_CB2", fUser_Defined_CB2, value)
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
            Me.CRDTMGR = ""
            Me.PreferredContactMethod = 0
            Me.NOMAIL = 0
            Me.ADRSCODE = ""
            Me.Time_Zone = 0
            Me.CN_Credit_Control_Cycle = 0
            Me.USRTAB01 = ""
            Me.USRTAB09 = ""
            Me.USERDEF1 = ""
            Me.USERDEF2 = ""
            Me.USRDAT01 = "1-1-1900"
            Me.User_Defined_CB1 = 0
            Me.User_Defined_CB2 = 0
        End Sub
    End Class

End Namespace
