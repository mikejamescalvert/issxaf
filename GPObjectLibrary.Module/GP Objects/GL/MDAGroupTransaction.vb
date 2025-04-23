Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.GL
    ''' <summary>
    ''' GP Table DTA10100
    ''' </summary>
    <Persistent("DTA10100")>
    Public Class MDAGroupTransaction
        Inherits XPLiteObject
        Dim fDTASERIES As Globals.MDASeriesType
        Public Property DTASERIES() As Globals.MDASeriesType
            Get
                Return fDTASERIES
            End Get
            Set(ByVal value As Globals.MDASeriesType)
                SetPropertyValue(Of Globals.MDASeriesType)("DTASERIES", fDTASERIES, value)
            End Set
        End Property
        Dim fDTAREF As String
        <Size(25)>
        Public Property DTAREF() As String
            Get
                Return fDTAREF
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DTAREF", fDTAREF, value)
            End Set
        End Property
        Dim fACTINDX As Integer
        Public Property ACTINDX() As Integer
            Get
                Return fACTINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ACTINDX", fACTINDX, value)
            End Set
        End Property
        Dim fSEQNUMBR As Integer
        Public Property SEQNUMBR() As Integer
            Get
                Return fSEQNUMBR
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SEQNUMBR", fSEQNUMBR, value)
            End Set
        End Property
        Dim fGROUPID As String
        <Size(15)>
        Public Property GROUPID() As String
            Get
                Return fGROUPID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GROUPID", fGROUPID, value)
            End Set
        End Property
        Dim fDTA_GL_Reference As String
        <Size(25)>
        Public Property DTA_GL_Reference() As String
            Get
                Return fDTA_GL_Reference
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DTA_GL_Reference", fDTA_GL_Reference, value)
            End Set
        End Property
        Dim fDOCNUMBR As String
        <Size(21)>
        Public Property DOCNUMBR() As String
            Get
                Return fDOCNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DOCNUMBR", fDOCNUMBR, value)
            End Set
        End Property
        Dim fRMDTYPAL As Short
        Public Property RMDTYPAL() As Short
            Get
                Return fRMDTYPAL
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("RMDTYPAL", fRMDTYPAL, value)
            End Set
        End Property
        Dim fGROUPAMT As Decimal
        Public Property GROUPAMT() As Decimal
            Get
                Return fGROUPAMT
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("GROUPAMT", fGROUPAMT, value)
            End Set
        End Property
        Dim fJRNENTRY As Integer
        Public Property JRNENTRY() As Integer
            Get
                Return fJRNENTRY
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("JRNENTRY", fJRNENTRY, value)
            End Set
        End Property
        Dim fTRXDATE As DateTime
        Public Property TRXDATE() As DateTime
            Get
                Return fTRXDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("TRXDATE", fTRXDATE, value)
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
        Dim fDEX_ROW_ID As Integer
        <Browsable(False)>
        <Key(True)>
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