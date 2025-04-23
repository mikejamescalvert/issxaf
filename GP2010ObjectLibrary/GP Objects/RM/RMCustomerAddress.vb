Imports System
Imports DevExpress.Xpo

Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM00102
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <System.ComponentModel.DefaultProperty("Oid.ADRSCODE")>
    <Persistent("RM00102")> _
    Public Class RMCustomerAddress
        Inherits XPLiteObject

        Public Structure CustomerAddressKey
            Private fCUSTNMBR As String
            <Size(15)> _
            <Persistent("CUSTNMBR")> _
            Public Property CUSTNMBR() As String
                Get
                    Return fCUSTNMBR
                End Get
                Set(ByVal value As String)
                    fCUSTNMBR = value
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


#Region "Behaviors"

        Public Function GetEmailAddress() As String
            Dim gpINet As SY.SYInternetAddressDetail
            gpINet = SY.Helpers.SYHelper.GetInternetDetailsForCustomerAddress(Me.Oid.CUSTNMBR, Me.Oid.ADRSCODE, Me.Session)
            If gpINet IsNot Nothing Then
                Return gpINet.INET1
            Else
                Return Nothing
            End If
        End Function

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
#End Region


#Region "Non Persistent Properties"
		<System.ComponentModel.DisplayName("Email Address")>
<PersistentAlias("INetInfo.INET1")>
Public ReadOnly Property EmailAddress As String
			Get
				Return EvaluateAlias("EmailAddress")
			End Get
		End Property

		<PersistentAlias("[<SYInternetAddressDetail>][Oid.Master_Type = 'CUS' AND Oid.Master_ID = ^.Oid.CUSTNMBR AND Oid.ADRSCODE = ^.Oid.ADRSCODE].Single()")>
		Public ReadOnly Property INetInfo As SY.SYInternetAddressDetail
			Get
				Return TryCast(EvaluateAlias("INetInfo"), SY.SYInternetAddressDetail)
			End Get
		End Property
        'Private _mINetInfo As sy.SYInternetAddressDetail
        'Public ReadOnly Property INetInfoO As SY.SYInternetAddressDetail
        '    Get
        '        If _mINetInfo Is Nothing Then
        '            _mINetInfo = SY.Helpers.SYHelper.GetInternetDetailsForCustomerAddress(Me.Oid.CUSTNMBR, Me.Oid.ADRSCODE, Me.Session)
        '        End If
        '        Return _mINetInfo
        '    End Get
        'End Property
        

        Public ReadOnly Property FormattedAddressMultiLine As String
            Get
                Dim str As New System.Text.StringBuilder
                If Not String.IsNullOrEmpty(RTrim(ADDRESS1)) Then
                    str.AppendLine(ADDRESS1.Trim)
                End If
                If Not String.IsNullOrEmpty(RTrim(ADDRESS2)) Then
                    str.AppendLine(ADDRESS2.Trim)
                End If
                If Not String.IsNullOrEmpty(RTrim(ADDRESS3)) Then
                    str.AppendLine(ADDRESS3.Trim)
                End If

                If Not String.IsNullOrEmpty(RTrim(CITY)) Then
                    str.Append(CITY.Trim & ", ")
                End If
                If Not String.IsNullOrEmpty(RTrim(STATE)) Then
                    str.Append(STATE.Trim & " ")
                End If
                If Not String.IsNullOrEmpty(RTrim(ZIP)) Then
                    str.AppendLine(RTrim(ZIP))

                End If
                Return str.ToString
            End Get
        End Property
        Public ReadOnly Property FormattedAddressSingleLine As String
            Get
                Dim str As New System.Text.StringBuilder
                If Not String.IsNullOrEmpty(ADDRESS1.Trim) Then
                    str.Append(ADDRESS1.Trim & " ")
                End If
                If Not String.IsNullOrEmpty(ADDRESS2) Then
                    str.Append(ADDRESS2.Trim & " ")
                End If
                If Not String.IsNullOrEmpty(ADDRESS3) Then
                    str.Append(ADDRESS3.Trim & " ")
                End If

                If Not String.IsNullOrEmpty(CITY) Then
                    str.Append(CITY.Trim & ", ")
                End If
                If Not String.IsNullOrEmpty(STATE) Then
                    str.Append(STATE.Trim & " ")
                End If
                If Not String.IsNullOrEmpty(ZIP) Then
                    str.Append(ZIP)

                End If
                Return str.ToString.Trim
            End Get
        End Property

#End Region


#Region "Properties"
        Dim fOid As CustomerAddressKey
        <Key()> _
        <Persistent()> _
        Public Property Oid() As CustomerAddressKey
            Get
                Return fOid
            End Get
            Set(ByVal value As CustomerAddressKey)
                SetPropertyValue(Of CustomerAddressKey)("Oid", fOid, value)
            End Set
        End Property

        Dim fSLPRSNID As String
        <Size(15)> _
        Public Property SLPRSNID() As String
            Get
                Return fSLPRSNID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SLPRSNID", fSLPRSNID, value)
            End Set
        End Property
        Dim fUPSZONE As String
        <Size(3)> _
        Public Property UPSZONE() As String
            Get
                Return fUPSZONE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UPSZONE", fUPSZONE, value)
            End Set
        End Property
        Dim fSHIPMTHD As String
        <Size(15)> _
        Public Property SHIPMTHD() As String
            Get
                Return fSHIPMTHD
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SHIPMTHD", fSHIPMTHD, value)
            End Set
        End Property
        Dim fTAXSCHID As String
        <Size(15)> _
        Public Property TAXSCHID() As String
            Get
                Return fTAXSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXSCHID", fTAXSCHID, value)
            End Set
        End Property
        Dim fCNTCPRSN As String
        <Size(61)> _
        Public Property CNTCPRSN() As String
            Get
                Return fCNTCPRSN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CNTCPRSN", fCNTCPRSN, value)
            End Set
        End Property
        Dim fADDRESS1 As String
        <Size(61)> _
        Public Property ADDRESS1() As String
            Get
                Return fADDRESS1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS1", fADDRESS1, value)
            End Set
        End Property
        Dim fADDRESS2 As String
        <Size(61)> _
        Public Property ADDRESS2() As String
            Get
                Return fADDRESS2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS2", fADDRESS2, value)
            End Set
        End Property
        Dim fADDRESS3 As String
        <Size(61)> _
        Public Property ADDRESS3() As String
            Get
                Return fADDRESS3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ADDRESS3", fADDRESS3, value)
            End Set
        End Property
        Dim fCOUNTRY As String
        <Size(61)> _
        Public Property COUNTRY() As String
            Get
                Return fCOUNTRY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COUNTRY", fCOUNTRY, value)
            End Set
        End Property
        Dim fCITY As String
        <Size(35)> _
        Public Property CITY() As String
            Get
                Return fCITY
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CITY", fCITY, value)
            End Set
        End Property
        Dim fSTATE As String
        <Size(29)> _
        Public Property STATE() As String
            Get
                Return fSTATE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("STATE", fSTATE, value)
            End Set
        End Property
        Dim fZIP As String
        <Size(11)> _
        Public Property ZIP() As String
            Get
                Return fZIP
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ZIP", fZIP, value)
            End Set
        End Property
        Dim fPHONE1 As String
        <Size(21)> _
        Public Property PHONE1() As String
            Get
                Return fPHONE1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE1", fPHONE1, value)
            End Set
        End Property
        Dim fPHONE2 As String
        <Size(21)> _
        Public Property PHONE2() As String
            Get
                Return fPHONE2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE2", fPHONE2, value)
            End Set
        End Property
        Dim fPHONE3 As String
        <Size(21)> _
        Public Property PHONE3() As String
            Get
                Return fPHONE3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE3", fPHONE3, value)
            End Set
        End Property
        Dim fFAX As String
        <Size(21)> _
        Public Property FAX() As String
            Get
                Return fFAX
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FAX", fFAX, value)
            End Set
        End Property
        Dim fMODIFDT As DateTime
        Public Property MODIFDT() As DateTime
            Get
                Return fMODIFDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MODIFDT", fMODIFDT, value)
            End Set
        End Property
        Dim fCREATDDT As DateTime
        Public Property CREATDDT() As DateTime
            Get
                Return fCREATDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("CREATDDT", fCREATDDT, value)
            End Set
        End Property
        Dim fGPSFOINTEGRATIONID As String
        <Size(31)> _
        Public Property GPSFOINTEGRATIONID() As String
            Get
                Return fGPSFOINTEGRATIONID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("GPSFOINTEGRATIONID", fGPSFOINTEGRATIONID, value)
            End Set
        End Property
        Dim fINTEGRATIONSOURCE As Short
        Public Property INTEGRATIONSOURCE() As Short
            Get
                Return fINTEGRATIONSOURCE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("INTEGRATIONSOURCE", fINTEGRATIONSOURCE, value)
            End Set
        End Property
        Dim fINTEGRATIONID As String
        <Size(31)> _
        Public Property INTEGRATIONID() As String
            Get
                Return fINTEGRATIONID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("INTEGRATIONID", fINTEGRATIONID, value)
            End Set
        End Property
        Dim fCCode As String
        <Size(7)> _
        Public Property CCode() As String
            Get
                Return fCCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CCode", fCCode, value)
            End Set
        End Property
        Dim fDECLID As String
        <Size(15)> _
        Public Property DECLID() As String
            Get
                Return fDECLID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DECLID", fDECLID, value)
            End Set
        End Property
        Dim fLOCNCODE As String
        <Size(11)> _
        Public Property LOCNCODE() As String
            Get
                Return fLOCNCODE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("LOCNCODE", fLOCNCODE, value)
            End Set
        End Property
        Dim fSALSTERR As String
        <Size(15)> _
        Public Property SALSTERR() As String
            Get
                Return fSALSTERR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("SALSTERR", fSALSTERR, value)
            End Set
        End Property
        Dim fUSERDEF1 As String
        <Size(21)> _
        Public Property USERDEF1() As String
            Get
                Return fUSERDEF1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERDEF1", fUSERDEF1, value)
            End Set
        End Property
        Dim fUSERDEF2 As String
        <Size(21)> _
        Public Property USERDEF2() As String
            Get
                Return fUSERDEF2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERDEF2", fUSERDEF2, value)
            End Set
        End Property
        'Private _mShipToName As String
        'Public Property ShipToName As String
        '    Get
        '        Return _mShipToName
        '    End Get
        '    Set(ByVal Value As String)
        '        SetPropertyValue("ShipToName", _mShipToName, Value)
        '    End Set
        'End Property

#End Region

    End Class
End Namespace

