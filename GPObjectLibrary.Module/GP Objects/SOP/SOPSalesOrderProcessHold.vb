Imports System
Imports DevExpress.Xpo
Namespace Objects.SOP
    ''' <summary>
    ''' GP Table SOP10104
    ''' </summary>
    <Persistent("SOP10104")>
    Public Class SOPSalesOrderProcessHold
        Inherits XPLiteObject

        Public Structure SalesOrderProcessHoldKey
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
            Private fPRCHLDID As String
            <Size(15)>
            <Persistent("PRCHLDID")>
            Public Property PRCHLDID() As String
                Get
                    Return fPRCHLDID
                End Get
                Set(ByVal value As String)
                    fPRCHLDID = value
                End Set
            End Property

        End Structure

        Dim fOid As SalesOrderProcessHoldKey
        <Key()>
        <Persistent()>
        Public Property Oid() As SalesOrderProcessHoldKey
            Get
                Return fOid
            End Get
            Set(ByVal value As SalesOrderProcessHoldKey)
                SetPropertyValue(Of SalesOrderProcessHoldKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fDELETE1 As Byte
        Public Property DELETE1() As Byte
            Get
                Return fDELETE1
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("DELETE1", fDELETE1, value)
            End Set
        End Property
        Dim fUSERID As String
        <Size(15)>
        Public Property USERID() As String
            Get
                Return fUSERID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERID", fUSERID, value)
            End Set
        End Property
        Dim fHOLDDATE As DateTime
        Public Property HOLDDATE() As DateTime
            Get
                Return fHOLDDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("HOLDDATE", fHOLDDATE, value)
            End Set
        End Property
        Dim fTIME1 As DateTime
        Public Property TIME1() As DateTime
            Get
                Return fTIME1
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("TIME1", fTIME1, value)
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

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
