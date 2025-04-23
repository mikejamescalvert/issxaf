Imports System
Imports DevExpress.Xpo
Namespace Objects.SY
    ''' <summary>
    ''' GP Table SY01200
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("SY01200")> _
    Public Class SYInternetAddressDetail
        Inherits XPLiteObject

        Public Structure InternetAddressDetailKey
            Private fMaster_Type As String
            <Size(3)> _
            <Persistent("Master_Type")> _
            Public Property Master_Type() As String
                Get
                    Return fMaster_Type
                End Get
                Set(ByVal value As String)
                    fMaster_Type = value
                End Set
            End Property
            Private fMaster_ID As String
            <Size(31)> _
            <Persistent("Master_ID")> _
            Public Property Master_ID() As String
                Get
                    Return fMaster_ID
                End Get
                Set(ByVal value As String)
                    fMaster_ID = value
                End Set
            End Property
            Private fADRSCODE As String
            <Size(15)> _
            <Persistent("ADRSCODE")> _
            Public Property ADRSCODE() As String
                Get
                    Return fADRSCODE
                End Get
                Set(ByVal value As String)
                    fADRSCODE = value
                End Set
            End Property
        End Structure

        Dim fOid As InternetAddressDetailKey
        <Key()> _
        <Persistent()> _
        Public Property Oid() As InternetAddressDetailKey
            Get
                Return fOid
            End Get
            Set(ByVal value As InternetAddressDetailKey)
                SetPropertyValue(Of InternetAddressDetailKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fINET1 As String
        ''' <summary>
        ''' Email Address
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Size(201)> _
Public Property INET1() As String
            Get
                Return fINET1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INET1", fINET1, value)
            End Set
        End Property
        Dim fINET2 As String
        <Size(201)> _
        Public Property INET2() As String
            Get
                Return fINET2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INET2", fINET2, value)
            End Set
        End Property
        Dim fINET3 As String
        <Size(201)> _
        Public Property INET3() As String
            Get
                Return fINET3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INET3", fINET3, value)
            End Set
        End Property
        Dim fINET4 As String
        <Size(201)> _
        Public Property INET4() As String
            Get
                Return fINET4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INET4", fINET4, value)
            End Set
        End Property
        Dim fINET5 As String
        <Size(201)> _
        Public Property INET5() As String
            Get
                Return fINET5
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INET5", fINET5, value)
            End Set
        End Property
        Dim fINET6 As String
        <Size(201)> _
        Public Property INET6() As String
            Get
                Return fINET6
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INET6", fINET6, value)
            End Set
        End Property
        Dim fINET7 As String
        <Size(201)> _
        Public Property INET7() As String
            Get
                Return fINET7
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INET7", fINET7, value)
            End Set
        End Property
        Dim fINET8 As String
        <Size(201)> _
        Public Property INET8() As String
            Get
                Return fINET8
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INET8", fINET8, value)
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
        Dim fINETINFO As String
        <Size(2147483647)>
        Public Property INETINFO() As String
            Get
                Return fINETINFO
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INETINFO", fINETINFO, value)
            End Set
        End Property

        Private _mEmailToAddress As String
        <Size(201)>
        Property EmailToAddress As String
            Get
                Return _mEmailToAddress
            End Get
            Set(ByVal Value As String)
                SetPropertyValue(NameOf(EmailToAddress), _mEmailToAddress, Value)
            End Set
        End Property

        Private _mEmailCcAddress As String
        <Size(201)>
        Property EmailCcAddress As String
            Get
                Return _mEmailCcAddress
            End Get
            Set(ByVal Value As String)
                SetPropertyValue(NameOf(EmailCcAddress), _mEmailCcAddress, Value)
            End Set
        End Property

        Private _mEmailBccAddress As String
        <Size(201)>
        Property EmailBccAddress As String
            Get
                Return _mEmailBccAddress
            End Get
            Set(ByVal Value As String)
                SetPropertyValue(NameOf(EmailBccAddress), _mEmailBccAddress, Value)
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
