Imports ISS.DHLParcel.Model
Imports RestSharp

Public Class ShipmentService
    Private _mConfig As DhlParcelConfiguration
    Private _mAuthenticationService As AuthenticationService
    Public Sub New(ByVal Config As DhlParcelConfiguration)
        _mConfig = Config
        _mAuthenticationService = New AuthenticationService(Config)
    End Sub

    Public Function CreateShipment(ByVal Shipment As DhlShipment) As DhlCreateShipmentResponse
        Dim rtn As New DhlShipmentData
        Dim rstClient As New RestSharp.RestClient
        Dim rsrRequest As New RestSharp.RestRequest(String.Format("{0}/shipments", _mConfig.BaseUrl), RestSharp.Method.POST)
        Dim rspResponse As RestSharp.RestResponse
        'Dim dhrResponse As DhlCreateShipmentResponse
        'Dim lbl As DhlLabel
        rsrRequest.AddHeader("Authorization", "Bearer " + _mAuthenticationService.GetAccessToken())
        rsrRequest.AddJsonBody(Shipment)

        rspResponse = rstClient.Execute(rsrRequest)
        If rspResponse.StatusCode = Net.HttpStatusCode.Created Then
            'dhrResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DhlCreateShipmentResponse)(rspResponse.Content)
            Return Newtonsoft.Json.JsonConvert.DeserializeObject(Of DhlCreateShipmentResponse)(rspResponse.Content)
            'rtn.ShipmentId = dhrResponse.shipmentId
            'rtn.CustomDeclarationId = dhrResponse.customsDeclarationId
            'rtn.TrackerCode = dhrResponse.shipmentTrackerCode
            'For Each objPieces In dhrResponse.pieces
            '    rsrRequest = New RestRequest(String.Format("{0}/labels/{1}", _mConfig.BaseUrl, objPieces.labelId))
            '    rsrRequest.AddHeader("Authorization", "Bearer " + _mAuthenticationService.GetAccessToken())

            '    rspResponse = rstClient.Execute(rsrRequest)
            '    If rspResponse.StatusCode = Net.HttpStatusCode.OK Then
            '        lbl = New DhlLabel
            '        With lbl
            '            .LabelId = objPieces.labelId
            '            .LabelData = rspResponse.RawBytes
            '            .TrackingCode = objPieces.trackerCode
            '        End With
            '        rtn.Labels.Add(lbl)
            '    End If

            'Next
        Else
            Throw New Exception("Error fetching shipment: " + rspResponse.Content)
        End If
        Return Nothing
    End Function

    Public Function GetLabels(ByVal ShipmentId As String) As List(Of DhlLabel)
        Dim rstClient As New RestSharp.RestClient
        Dim rsrRequest As New RestSharp.RestRequest(String.Format("{0}/shipments/{1}", _mConfig.BaseUrl, ShipmentId), RestSharp.Method.GET)
        Dim rspResponse As RestSharp.RestResponse
        Dim dhrResponse As DhlCreateShipmentResponse
        Dim lstLabels As New List(Of DhlLabel)
        Dim lbl As DhlLabel
        rsrRequest.AddHeader("Authorization", "Bearer " + _mAuthenticationService.GetAccessToken())
        'rsrRequest.AddJsonBody(Shipment)

        rspResponse = rstClient.Execute(rsrRequest)
        If rspResponse.StatusCode = Net.HttpStatusCode.OK Then
            dhrResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(Of DhlCreateShipmentResponse)(rspResponse.Content)
            For Each objPieces In dhrResponse.pieces
                rsrRequest = New RestRequest(String.Format("{0}/labels/{1}", _mConfig.BaseUrl, objPieces.labelId))
                rsrRequest.AddHeader("Authorization", "Bearer " + _mAuthenticationService.GetAccessToken())
                rsrRequest.AddHeader("Accept", "application/pdf")

                rspResponse = rstClient.Execute(rsrRequest)
                If rspResponse.StatusCode = Net.HttpStatusCode.OK Then
                    lbl = New DhlLabel
                    With lbl
                        .LabelId = objPieces.labelId
                        .LabelData = rspResponse.RawBytes
                        .TrackingCode = objPieces.trackerCode
                    End With
                    lstLabels.Add(lbl)
                End If

            Next

        End If
        Return lstLabels
    End Function

    Public Function GetCustomsDeclarationDocuments(ByVal CustomsDeclarationsId As String) As List(Of DhlLabel)
        Dim rstClient As New RestSharp.RestClient
        Dim rsrRequest As New RestSharp.RestRequest(String.Format("{0}/customs/declarations/{1}/documents", _mConfig.BaseUrl, CustomsDeclarationsId), RestSharp.Method.GET)
        Dim rspResponse As RestSharp.RestResponse
        Dim dhrResponse As DhlCreateShipmentResponse
        Dim lstLabels As New List(Of DhlLabel)
        Dim lbl As DhlLabel
        rsrRequest.AddHeader("Authorization", "Bearer " + _mAuthenticationService.GetAccessToken())
        'rsrRequest.AddJsonBody(Shipment)

        rspResponse = rstClient.Execute(rsrRequest)
        If rspResponse.StatusCode = Net.HttpStatusCode.OK Then

            lbl = New DhlLabel
            With lbl
                .LabelId = "CustomsDocuments"
                .LabelData = rspResponse.RawBytes
            End With
            lstLabels.Add(lbl)

        End If
        Return lstLabels
    End Function


End Class
