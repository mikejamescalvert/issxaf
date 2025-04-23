Imports DevExpress.Xpo

Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM00500
    ''' </summary>
    <Persistent("RM00500")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class RMPricebookPricesheetLink
        Inherits XPLiteObject

        Public Structure RMPricebookPricesheetLinkKey
            Private fPRCSHID As String
            <Size(15)>
            <Persistent("PRCSHID")>
            Public Property PRCSHID() As String
                Get
                    Return fPRCSHID
                End Get
                Set(ByVal value As String)
                    fPRCSHID = value
                End Set
            End Property
            Private fPRODTCOD As Char
            <Persistent("PRODTCOD")>
            Public Property PRODTCOD() As Char
                Get
                    Return fPRODTCOD
                End Get
                Set(ByVal value As Char)
                    fPRODTCOD = value
                End Set
            End Property
            Private fLINKCODE As String
            <Size(15)>
            <Persistent("LINKCODE")>
            Public Property LINKCODE() As String
                Get
                    Return fLINKCODE
                End Get
                Set(ByVal value As String)
                    fLINKCODE = value
                End Set
            End Property
        End Structure


        Dim fOid As RMPricebookPricesheetLinkKey
        <Key()>
        <Persistent()>
        Public Property Oid() As RMPricebookPricesheetLinkKey
            Get
                Return fOid
            End Get
            Set(ByVal value As RMPricebookPricesheetLinkKey)
                SetPropertyValue(Of RMPricebookPricesheetLinkKey)("Oid", fOid, value)
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
        Dim fPSSEQNUM As Integer
        Public Property PSSEQNUM() As Integer
            Get
                Return fPSSEQNUM
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("PSSEQNUM", fPSSEQNUM, value)
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
