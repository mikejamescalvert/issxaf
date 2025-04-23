Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.SOP
    ''' <summary>
    ''' GP Table SOP50200
    ''' </summary>

    <Persistent("SOP50200")>
    Public Class SOPPackList
        Inherits XPLiteObject

        Public Structure SOPPackListKey
            Private fDOCTYPE As Short
            <Persistent("DOCTYPE")>
            Public Property DOCTYPE() As Short
                Get
                    Return fDOCTYPE
                End Get
                Set(ByVal value As Short)
                    fDOCTYPE = value
                End Set
            End Property
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
            Private fLOCNCODE As String
            <Size(11)>
            <Persistent("LOCNCODE")>
            Public Property LOCNCODE() As String
                Get
                    Return fLOCNCODE
                End Get
                Set(ByVal value As String)
                    fLOCNCODE = value
                End Set
            End Property
            Private fUSERID As String
            <Size(15)>
            <Persistent("USERID")>
            Public Property USERID() As String
                Get
                    Return fUSERID
                End Get
                Set(ByVal value As String)
                    fUSERID = value
                End Set
            End Property
            Private fSEQNUMBR As Integer
            <Persistent("SEQNUMBR")>
            Public Property SEQNUMBR() As Integer
                Get
                    Return fSEQNUMBR
                End Get
                Set(ByVal value As Integer)
                    fSEQNUMBR = value
                End Set
            End Property
            Private fDOCPRINTSEQ As Integer
            <Persistent("DOCPRINTSEQ")>
            Public Property DOCPRINTSEQ() As Integer
                Get
                    Return fDOCPRINTSEQ
                End Get
                Set(ByVal value As Integer)
                    fDOCPRINTSEQ = value
                End Set
            End Property
            Private fEmail_Type As Short
            <Persistent("Email_Type")>
            Public Property Email_Type() As Short
                Get
                    Return fEmail_Type
                End Get
                Set(ByVal value As Short)
                    fEmail_Type = value
                End Set
            End Property
        End Structure

        Dim fOid As SOPPackListKey
        <Key()>
        <Persistent()>
        Public Property Oid() As SOPPackListKey
            Get
                Return fOid
            End Get
            Set(ByVal value As SOPPackListKey)
                SetPropertyValue(Of SOPPackListKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fCUSTNMBR As String
        <Size(15)>
        Public Property CUSTNMBR() As String
            Get
                Return fCUSTNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CUSTNMBR", fCUSTNMBR, value)
            End Set
        End Property

        Dim fShipToName As String
        <Size(65)>
        Public Property ShipToName() As String
            Get
                Return fShipToName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ShipToName", fShipToName, value)
            End Set
        End Property
        Dim fCNTCPRSN As String
        <Size(61)>
        Public Property CNTCPRSN() As String
            Get
                Return fCNTCPRSN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CNTCPRSN", fCNTCPRSN, value)
            End Set
        End Property
        Dim fADDRESS1 As String
        <Size(61)>
        Public Property ADDRESS1() As String
            Get
                Return fADDRESS1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS1", fADDRESS1, value)
            End Set
        End Property
        Dim fADDRESS2 As String
        <Size(61)>
        Public Property ADDRESS2() As String
            Get
                Return fADDRESS2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS2", fADDRESS2, value)
            End Set
        End Property
        Dim fADDRESS3 As String
        <Size(61)>
        Public Property ADDRESS3() As String
            Get
                Return fADDRESS3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS3", fADDRESS3, value)
            End Set
        End Property
        Dim fCITY As String
        <Size(35)>
        Public Property CITY() As String
            Get
                Return fCITY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CITY", fCITY, value)
            End Set
        End Property
        Dim fSTATE As String
        <Size(29)>
        Public Property STATE() As String
            Get
                Return fSTATE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STATE", fSTATE, value)
            End Set
        End Property
        Dim fZIPCODE As String
        <Size(11)>
        Public Property ZIPCODE() As String
            Get
                Return fZIPCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ZIPCODE", fZIPCODE, value)
            End Set
        End Property
        Dim fCOUNTRY As String
        <Size(61)>
        Public Property COUNTRY() As String
            Get
                Return fCOUNTRY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COUNTRY", fCOUNTRY, value)
            End Set
        End Property
        Dim fSHIPMTHD As String
        <Size(15)>
        Public Property SHIPMTHD() As String
            Get
                Return fSHIPMTHD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SHIPMTHD", fSHIPMTHD, value)
            End Set
        End Property
        Dim fReprint As Byte
        Public Property Reprint() As Byte
            Get
                Return fReprint
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Reprint", fReprint, value)
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
