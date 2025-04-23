Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.PM
    ''' <summary>
    ''' GP Table PM00300
    ''' </summary>
    <Persistent("PM00300")>
    <System.ComponentModel.DefaultProperty("Oid.ADRSCODE")>
    <OptimisticLocking(False)>
    Public Class PMVendorAddress
        Inherits XPLiteObject

        Public Structure VendorAddressKey

            Private fVENDORID As String
            <Size(15)>
            <Persistent("VENDORID")>
            Public Property VENDORID() As String
                Get
                    Return fVENDORID
                End Get
                Set(ByVal value As String)
                    fVENDORID = value
                End Set
            End Property
            Private fADRSCODE As String
            <Size(15)>
            <Persistent("ADRSCODE")>
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

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub


        'Public Function GetEmailAddress() As String
        '    Dim gpINet As SY.SYInternetAddressDetail
        '    gpINet = SY.Helpers.SYHelper.GetInternetDetailsForVendorAddress(Me.Oid.VENDORID, Me.Oid.ADRSCODE, Me.Session)
        '    If gpINet IsNot Nothing Then
        '        Return gpINet.INET1
        '    Else
        '        Return Nothing
        '    End If
        'End Function

#End Region

#Region "Non Persistent Properties"
        <PersistentAlias("[<SYInternetAddressDetail>][Oid.Master_Type = 'VEN' AND Oid.Master_ID = ^.Oid.VENDORID AND Oid.ADRSCODE = ^.Oid.ADRSCODE].Single(INET1)")>
        Public ReadOnly Property EmailAddress As String
            Get
                ' Return Me.GetEmailAddress
                Return EvaluateAlias("EmailAddress")
            End Get
        End Property
        ''' <summary>
        ''' Return a multi line address for printing on envelopes, etc.
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property FormattedAddressMultiLine As String
            Get
                Dim str As New System.Text.StringBuilder
                If Not String.IsNullOrEmpty(ADDRESS1.Trim) Then
                    str.AppendLine(ADDRESS1.Trim)
                End If
                If Not String.IsNullOrEmpty(ADDRESS2) Then
                    str.AppendLine(ADDRESS2.Trim)
                End If
                If Not String.IsNullOrEmpty(ADDRESS3) Then
                    str.AppendLine(ADDRESS3.Trim)
                End If

                If Not String.IsNullOrEmpty(CITY) Then
                    str.Append(CITY.Trim & ", ")
                End If
                If Not String.IsNullOrEmpty(STATE) Then
                    str.Append(STATE.Trim & " ")
                End If
                If Not String.IsNullOrEmpty(ZIPCODE) Then
                    str.AppendLine(ZIPCODE)

                End If
                Return str.ToString
            End Get
        End Property
        ''' <summary>
        ''' Returns a single line formatted full address
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
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
                If Not String.IsNullOrEmpty(ZIPCODE) Then
                    str.Append(ZIPCODE)

                End If
                Return str.ToString.Trim
            End Get
        End Property

#End Region


#Region "Properties"





        Dim fOid As VendorAddressKey
        <Key()>
        <Persistent()>
        Public Property Oid() As VendorAddressKey
            Get
                Return fOid
            End Get
            Set(ByVal value As VendorAddressKey)
                SetPropertyValue(Of VendorAddressKey)("Oid", fOid, value)
            End Set
        End Property


        Dim fVNDCNTCT As String
        <Size(61)>
        Public Property VNDCNTCT() As String
            Get
                Return fVNDCNTCT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDCNTCT", fVNDCNTCT, value)
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
        Dim fUPSZONE As String
        <Size(3)>
        Public Property UPSZONE() As String
            Get
                Return fUPSZONE
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UPSZONE", fUPSZONE, value)
            End Set
        End Property
        Dim fPHNUMBR1 As String
        <Size(21)>
        Public Property PHNUMBR1() As String
            Get
                Return fPHNUMBR1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHNUMBR1", fPHNUMBR1, value)
            End Set
        End Property
        Dim fPHNUMBR2 As String
        <Size(21)>
        Public Property PHNUMBR2() As String
            Get
                Return fPHNUMBR2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHNUMBR2", fPHNUMBR2, value)
            End Set
        End Property
        Dim fPHONE3 As String
        <Size(21)>
        Public Property PHONE3() As String
            Get
                Return fPHONE3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PHONE3", fPHONE3, value)
            End Set
        End Property
        Dim fFAXNUMBR As String
        <Size(21)>
        Public Property FAXNUMBR() As String
            Get
                Return fFAXNUMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("FAXNUMBR", fFAXNUMBR, value)
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
        Dim fTAXSCHID As String
        <Size(15)>
        Public Property TAXSCHID() As String
            Get
                Return fTAXSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXSCHID", fTAXSCHID, value)
            End Set
        End Property
        Dim fEmailPOs As Byte
        Public Property EmailPOs() As Byte
            Get
                Return fEmailPOs
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("EmailPOs", fEmailPOs, value)
            End Set
        End Property
        Dim fPOEmailRecipient As String
        <Size(81)>
        Public Property POEmailRecipient() As String
            Get
                Return fPOEmailRecipient
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("POEmailRecipient", fPOEmailRecipient, value)
            End Set
        End Property
        Dim fEmailPOFormat As Short
        Public Property EmailPOFormat() As Short
            Get
                Return fEmailPOFormat
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("EmailPOFormat", fEmailPOFormat, value)
            End Set
        End Property
        Dim fFaxPOs As Byte
        Public Property FaxPOs() As Byte
            Get
                Return fFaxPOs
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("FaxPOs", fFaxPOs, value)
            End Set
        End Property
        Dim fPOFaxNumber As String
        <Size(21)>
        Public Property POFaxNumber() As String
            Get
                Return fPOFaxNumber
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("POFaxNumber", fPOFaxNumber, value)
            End Set
        End Property
        Dim fFaxPOFormat As Short
        Public Property FaxPOFormat() As Short
            Get
                Return fFaxPOFormat
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("FaxPOFormat", fFaxPOFormat, value)
            End Set
        End Property
        Dim fCCode As String
        <Size(7)>
        Public Property CCode() As String
            Get
                Return fCCode
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CCode", fCCode, value)
            End Set
        End Property
        Dim fDECLID As String
        <Size(15)>
        Public Property DECLID() As String
            Get
                Return fDECLID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("DECLID", fDECLID, value)
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

#End Region

    End Class

End Namespace
