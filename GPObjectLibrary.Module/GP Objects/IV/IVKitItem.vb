Imports System
Imports DevExpress.Xpo
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV00104
    ''' </summary>
    <Persistent("IV00104")>
    Public Class IVKitItem
        Inherits XPLiteObject

        Public Structure KitItemKey
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
            Private fCMPTITNM As String
            <Size(31)>
            <Persistent("CMPTITNM")>
            Public Property CMPTITNM() As String
                Get
                    Return fCMPTITNM
                End Get
                Set(ByVal value As String)
                    fCMPTITNM = value
                End Set
            End Property
            Private fCMPITUOM As String
            <Size(9)>
            <Persistent("CMPITUOM")>
            Public Property CMPITUOM() As String
                Get
                    Return fCMPITUOM
                End Get
                Set(ByVal value As String)
                    fCMPITUOM = value
                End Set
            End Property
        End Structure

        Dim fOid As KitItemKey
        <Key()>
        <Persistent()>
        Public Property Oid() As KitItemKey
            Get
                Return fOid
            End Get
            Set(ByVal value As KitItemKey)
                SetPropertyValue(Of KitItemKey)("Oid", fOid, value)
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

        Dim fCMPITQTY As Decimal
        Public Property CMPITQTY() As Decimal
            Get
                Return fCMPITQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CMPITQTY", fCMPITQTY, value)
            End Set
        End Property
        Dim fCMPSERNM As Byte
        Public Property CMPSERNM() As Byte
            Get
                Return fCMPSERNM
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("CMPSERNM", fCMPSERNM, value)
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
