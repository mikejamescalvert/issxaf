Imports DevExpress.Xpo

Namespace Objects.SOP
    ''' <summary>
    ''' GP Table  SOP10205
    ''' </summary>
    <Persistent("SOP10205")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class SOPCustomerPricebookAssignment
        Inherits XPLiteObject

        Public Structure SOPCustomerPricebookAssignmentKey
            Private fPRCBKID As String
            <Size(15)>
            <Persistent("PRCBKID")>
            Public Property PRCBKID() As String
                Get
                    Return fPRCBKID
                End Get
                Set(ByVal value As String)
                    fPRCBKID = value
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

        Dim fOid As SOPCustomerPricebookAssignmentKey
        <Key()>
        <Persistent()>
        Public Property Oid() As SOPCustomerPricebookAssignmentKey
            Get
                Return fOid
            End Get
            Set(ByVal value As SOPCustomerPricebookAssignmentKey)
                SetPropertyValue(Of SOPCustomerPricebookAssignmentKey)("Oid", fOid, value)
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
