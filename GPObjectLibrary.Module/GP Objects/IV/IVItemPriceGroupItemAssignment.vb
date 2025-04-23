Imports System
Imports DevExpress.Xpo
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10400
    ''' </summary>
    <Persistent("IV10400")>
    Public Class IVItemPriceGroupItemAssignment
        Inherits XPLiteObject

        Public Structure IVItemPriceGroupItemAssignmentKey
            Private fPRCGRPID As String
            <Size(31)>
            <Persistent("PRCGRPID")>
            Public Property PRCGRPID() As String
                Get
                    Return fPRCGRPID
                End Get
                Set(ByVal value As String)
                    fPRCGRPID = value
                End Set
            End Property
            Private fITEMNMBR As String
            <Size(31)>
            <Persistent("ITEMNMBR")>
            Public Property ITEMNMBR() As String
                Get
                    Return fITEMNMBR
                End Get
                Set(ByVal value As String)
                    fITEMNMBR = value
                End Set
            End Property
        End Structure

        Dim fOid As IVItemPriceGroupItemAssignmentKey
        <Key()>
        <Persistent()>
        Public Property Oid() As IVItemPriceGroupItemAssignmentKey
            Get
                Return fOid
            End Get
            Set(ByVal value As IVItemPriceGroupItemAssignmentKey)
                SetPropertyValue(Of IVItemPriceGroupItemAssignmentKey)("Oid", fOid, value)
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
