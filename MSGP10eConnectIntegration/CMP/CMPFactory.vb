Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Text
Imports Microsoft.Dynamics.GP

Namespace CMP
    Public Class CMPFactory

        Private _mMSGPConnectionString As String
        Private _mExceptionMessages As New System.Collections.Specialized.StringCollection

#Region "Properties"
        Public Property MSGPConnectionString() As String
            Get
                Return _mMSGPConnectionString
            End Get
            Set(ByVal value As String)
                If _mMSGPConnectionString = value Then
                    Return
                End If
                _mMSGPConnectionString = value
            End Set
        End Property
        Public ReadOnly Property ExceptionMessages() As System.Collections.Specialized.StringCollection
            Get
                Return _mExceptionMessages
            End Get
        End Property
#End Region

        ''' <summary>
        ''' converts enumeration into its equivalent string
        ''' </summary>
        ''' <param name="Enumeration"></param>
        ''' <returns></returns>
        ''' <remarks>the string values are based on the eConnect help file</remarks>
        Public Shared Function ConvertMasterTypeToString(ByVal Enumeration As CMPInternetAddress.CMPMasterType) As String
            Select Case Enumeration
                Case CMPInternetAddress.CMPMasterType.CustomerRecord
                    Return "CUS"
                Case CMPInternetAddress.CMPMasterType.ItemRecord
                    Return "ITM"
                Case CMPInternetAddress.CMPMasterType.CompanyRecord
                    Return "CMP"
                Case CMPInternetAddress.CMPMasterType.SalespersonRecord
                    Return "SLP"
                Case CMPInternetAddress.CMPMasterType.EmployeeRecord
                    Return "EMP"
                Case Else
                    Return String.Empty
            End Select
        End Function

        Public Function CreateInternetAddress(ByVal InternetAddress As CMPInternetAddress) As Boolean
            Me._mExceptionMessages.Clear()

            Dim BT As New eConnect.Serialization.CMPInternetAddressType
            Dim taINTERNETADDRESS As New eConnect.Serialization.taCreateInternetAddresses
            Try
                'validate this object
                Helper.ValidateMSGPRequiredFieldsComplete(InternetAddress)

                With taINTERNETADDRESS
                    .Master_Type = CMPFactory.ConvertMasterTypeToString(InternetAddress.MasterType)
                    .Master_ID = InternetAddress.MasterID
                    .INET1 = InternetAddress.Internet1
                    .ADRSCODE = InternetAddress.AddressCode
                End With
                BT.taCreateInternetAddresses = taINTERNETADDRESS
                CommonLogic.eConnectCreate(Me.MSGPConnectionString, BT)
                Return True
            Catch ex As MSGPRequiredFieldValidationException
                Me.ExceptionMessages.Add(ex.Message)
                Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class

End Namespace