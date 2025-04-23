Imports System
Imports DevExpress.Xpo
Namespace Objects.SOP
    ''' <summary>
    ''' GP Table SOP10202
    ''' </summary>
    <Persistent("SOP10202")>
    <OptimisticLocking(False)>
    Public Class SOPOrderLineNote
        Inherits XPLiteObject

        Public Structure SOPOrderLineNoteKey
            Private fSOPTYPE As Short
            <Persistent("SOPTYPE")>
            Public Property SOPTYPE() As Short
                Get
                    Return fSOPTYPE
                End Get
                Set(ByVal value As Short)
                    fSOPTYPE = value
                End Set
            End Property
            Private fSOPNUMBE As String
            <Size(21)>
            <Persistent("SOPNUMBE")>
            Public Property SOPNUMBE() As String
                Get
                    Return fSOPNUMBE
                End Get
                Set(ByVal value As String)
                    fSOPNUMBE = value
                End Set
            End Property
            Private fLNITMSEQ As Integer
            <Persistent("LNITMSEQ")>
            Public Property LNITMSEQ() As Integer
                Get
                    Return fLNITMSEQ
                End Get
                Set(ByVal value As Integer)
                    fLNITMSEQ = value
                End Set
            End Property
            Private fCMPNTSEQ As Integer
            <Persistent("CMPNTSEQ")>
            Public Property CMPNTSEQ() As Integer
                Get
                    Return fCMPNTSEQ
                End Get
                Set(ByVal value As Integer)
                    fCMPNTSEQ = value
                End Set
            End Property
        End Structure

        Private _mOid As SOPOrderLineNoteKey
        <Persistent()>
        <Key()>
        Public Property Oid As SOPOrderLineNoteKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As SOPOrderLineNoteKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property


        Dim fTRXSORCE As String
        <Size(13)>
        Public Property TRXSORCE() As String
            Get
                Return fTRXSORCE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TRXSORCE", fTRXSORCE, value)
            End Set
        End Property
        Dim fCOMMENT_1 As String
        <Size(51)>
        Public Property COMMENT_1() As String
            Get
                Return fCOMMENT_1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT_1", fCOMMENT_1, value)
            End Set
        End Property
        Dim fCOMMENT_2 As String
        <Size(51)>
        Public Property COMMENT_2() As String
            Get
                Return fCOMMENT_2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT_2", fCOMMENT_2, value)
            End Set
        End Property
        Dim fCOMMENT_3 As String
        <Size(51)>
        Public Property COMMENT_3() As String
            Get
                Return fCOMMENT_3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT_3", fCOMMENT_3, value)
            End Set
        End Property
        Dim fCOMMENT_4 As String
        <Size(51)>
        Public Property COMMENT_4() As String
            Get
                Return fCOMMENT_4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT_4", fCOMMENT_4, value)
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
        Dim fCMMTTEXT As String
        <Size(2147483647)>
        Public Property CMMTTEXT() As String
            Get
                Return fCMMTTEXT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CMMTTEXT", fCMMTTEXT, value)
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
