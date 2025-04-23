Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.SOP

    ''' <summary>
    ''' GP Table SOP40101
    ''' </summary>
    <Persistent("SOP40101")>
    Public Class SOPWorkflow
        Inherits XPLiteObject
        Dim fSOPSTATUS As Short
        <Key()>
        Public Property SOPSTATUS() As Short
            Get
                Return fSOPSTATUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SOPSTATUS", fSOPSTATUS, value)
            End Set
        End Property
        Dim fSOPSTSDESCR As String
        <Size(51)>
        Public Property SOPSTSDESCR() As String
            Get
                Return fSOPSTSDESCR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SOPSTSDESCR", fSOPSTSDESCR, value)
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
