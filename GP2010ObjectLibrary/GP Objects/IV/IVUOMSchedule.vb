Imports System
Imports DevExpress.Xpo
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV40201
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.DefaultProperty("UOMSCHDL")>
    <Persistent("IV40201")> _
    <OptimisticLocking(False)> _
    Public Class IVUOMSchedule

        Inherits XPLiteObject
        Dim fUOMSCHDL As String
        <Key()> _
        <Size(11)> _
        Public Property UOMSCHDL() As String
            Get
                Return fUOMSCHDL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UOMSCHDL", fUOMSCHDL, value)
            End Set
        End Property
        Dim fUMSCHDSC As String
        <Size(31)> _
        Public Property UMSCHDSC() As String
            Get
                Return fUMSCHDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UMSCHDSC", fUMSCHDSC, value)
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
        Dim fBASEUOFM As String
        <Size(9)> _
        Public Property BASEUOFM() As String
            Get
                Return fBASEUOFM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BASEUOFM", fBASEUOFM, value)
            End Set
        End Property
        Dim fUMDPQTYS As Short
        Public Property UMDPQTYS() As Short
            Get
                Return fUMDPQTYS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("UMDPQTYS", fUMDPQTYS, value)
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