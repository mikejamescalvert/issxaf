Imports System
Imports DevExpress.Xpo
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV00105
    ''' </summary>
    <Persistent("IV00105")>
    <OptimisticLocking(False)>
    Public Class IVItemCurrency
        Inherits XPLiteObject

        Public Structure IVItemCurrencyKey
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
            Private fCURNCYID As String
            <Size(15)>
            <Persistent("CURNCYID")>
            Public Property CURNCYID() As String
                Get
                    Return fCURNCYID
                End Get
                Set(ByVal value As String)
                    fCURNCYID = value
                End Set
            End Property

        End Structure

        Private _mOid As IVItemCurrencyKey
        <Persistent()>
        <Key()>
        Public Property Oid() As IVItemCurrencyKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As IVItemCurrencyKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property

        Dim fDECPLCUR As Integer
        Public Property DECPLCUR() As Integer
            Get
                Return fDECPLCUR
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DECPLCUR", fDECPLCUR, value)
            End Set
        End Property

        Dim fCURRNIDX As Integer
        Public Property CURRNIDX() As Integer
            Get
                Return fCURRNIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("CURRNIDX", fCURRNIDX, value)
            End Set
        End Property

        Dim fLISTPRCE As Decimal
        Public Property LISTPRCE() As Decimal
            Get
                Return fLISTPRCE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LISTPRCE", fLISTPRCE, value)
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