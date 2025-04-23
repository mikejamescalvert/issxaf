Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class DhlTests

    Public Function GetConfiguration() As ISS.DHLParcel.DhlParcelConfiguration
        Dim cfg As New DhlParcelConfiguration()
        With cfg
            .ApiKey = "3052d748-fd4e-438f-9175-3c7945b535a7"
            .UserId = "25471c33-02a8-4126-ae8b-bc028038ac8d"
        End With
        Return cfg
    End Function

    Public Function GetShipmentId() As Model.DhlCreateShipmentResponse
        Dim svc As New DHLParcel.ShipmentService(GetConfiguration)
        Dim shp As New DHLParcel.Model.DhlShipment
        Dim spdData As DHLParcel.Model.DhlCreateShipmentResponse
        With shp
            .shipmentId = (System.Guid.NewGuid).ToString
            .orderReference = "ORD0001"
            .receiver = New Model.DhlReceiver
            .receiver.name = New Model.DhlName("Mike", "Calvert", String.Empty, String.Empty)
            .receiver.address = New Model.DhlAddress("GB", "WC2N 5DN", "London", "Trafalgar Square", String.Empty, String.Empty, False, String.Empty)
            .receiver.email = "mike.calvert@issusa.com"
            .receiver.phoneNumber = "088-345 43 00"
            .shipper = New Model.DhlShipper
            .shipper.name = New Model.DhlName(String.Empty, String.Empty, "Integrated Systems Solutions", String.Empty)
            .shipper.address = New Model.DhlAddress("NL", "3542AD", "Utrecht", "Reactorweg", String.Empty, "25", True, String.Empty)
            .shipper.email = "mike.calvert@issusa.com"
            .shipper.phoneNumber = "088-345 43 00"
            .shipper.vatNumber = "NL0123456789B01"
            .shipper.eoriNumber = "GB123456789"
            .accountId = "06170146"
            .options = New List(Of Model.DhlOption)
            .options.Add(New Model.DhlOption("REFERENCE", "ORD0001"))
            .customsDeclaration = New Model.DhlCustomsDeclaration
            .customsDeclaration.currency = "EUR"
            .customsDeclaration.invoiceNumber = "INV0001"
            .customsDeclaration.invoiceType = "Commercial"
            .customsDeclaration.exportType = "Permanent"
            .customsDeclaration.exportReason = "SaleOfGoods"
            .customsDeclaration.customsGoods = New List(Of Model.DhlCustomsGood)
            .customsDeclaration.customsGoods.Add(New Model.DhlCustomsGood("04069078", "Goudse Kaas", "NL", 1, 19.95, 10.5))
            .customsDeclaration.customsGoods.Add(New Model.DhlCustomsGood("0406901300", "Emmentaler", "NL", 1, 29.95, 11.5))
            .customsDeclaration.incoTerms = "DAP"
            .customsDeclaration.incoTermsCity = "Plymouth"
            .customsDeclaration.senderInboundVatNumber = "GB123456123456"
            .customsDeclaration.shippingFee = New Model.DhlShippingFee("EUR", 20)
            .returnLabel = False
            .pieces = New List(Of Model.DhlPiece)
            .pieces.Add(New Model.DhlPiece("SMALL", 1, 1, Nothing, String.Empty, String.Empty))
        End With
        spdData = svc.CreateShipment(shp)
        Assert.IsNotNull(spdData)
        Assert.IsTrue(spdData.ShipmentId > String.Empty)
        Return spdData
    End Function

    <TestMethod()>
    Public Sub CreateShipmentWithAcumaticaData()
        Dim rst = GetShipmentIdTestData()

    End Sub
    Public Function GetShipmentIdTestData() As Model.DhlCreateShipmentResponse
        Dim svc As New DHLParcel.ShipmentService(GetConfiguration)
        Dim shp As New DHLParcel.Model.DhlShipment
        Dim spdData As DHLParcel.Model.DhlCreateShipmentResponse
        With shp
            .shipmentId = "e9303201-e88d-4380-ac63-af707539b282"
            .orderReference = "EME000364"
            .receiver = New Model.DhlReceiver
            .receiver.name = New Model.DhlName(String.Empty, String.Empty, "DAMICO GUITARS ET BASSES", String.Empty)
            .receiver.address = New Model.DhlAddress("FR", "78530", "Buc", "501 RUE FOURNY ZI HT BUC", String.Empty, String.Empty, False, String.Empty)
            .receiver.email = "damicog@aol.com"
            .receiver.phoneNumber = "+33 1 30 64 12 26"
            .shipper = New Model.DhlShipper
            .shipper.name = New Model.DhlName(String.Empty, String.Empty, "Integrated Systems Solutions", String.Empty)
            .shipper.address = New Model.DhlAddress("NL", "3641 RZ", "Mijdrecht", "Ondernemingsweg 11", String.Empty, String.Empty, False, String.Empty)
            .shipper.email = String.Empty
            .shipper.phoneNumber = String.Empty
            .shipper.vatNumber = "NL0123456789B01"
            .shipper.eoriNumber = "GB123456789"

            .accountId = "06170146"
            .options = New List(Of Model.DhlOption)
            .options.Add(New Model.DhlOption("REFERENCE", "EME000364"))
            .customsDeclaration = New Model.DhlCustomsDeclaration
            .customsDeclaration.currency = "EUR"
            .customsDeclaration.invoiceNumber = "INV0001"
            .customsDeclaration.invoiceType = "Commercial"
            .customsDeclaration.exportType = "Permanent"
            .customsDeclaration.exportReason = "SaleOfGoods"
            .customsDeclaration.customsGoods = New List(Of Model.DhlCustomsGood)
            .customsDeclaration.customsGoods.Add(New Model.DhlCustomsGood("04069078", "Goudse Kaas", "NL", 1, 19.95, 10.5))
            .customsDeclaration.customsGoods.Add(New Model.DhlCustomsGood("04061300", "Emmentaler", "NL", 1, 29.95, 11.5))
            .customsDeclaration.incoTerms = "DAP"
            .customsDeclaration.incoTermsCity = "Plymouth"

            '.customsDeclaration.senderInboundVatNumber = "GB123456789"
            .customsDeclaration.shippingFee = New Model.DhlShippingFee("EUR", 20)
            .returnLabel = False
            .pieces = New List(Of Model.DhlPiece)
            .pieces.Add(New Model.DhlPiece("SMALL", 1, 0, New Model.DhlDimensions(20, 25, 30), String.Empty, String.Empty))
            .pieces.Add(New Model.DhlPiece("SMALL", 2, 0, New Model.DhlDimensions(20, 25, 30), String.Empty, String.Empty))
            .pieces.Add(New Model.DhlPiece("SMALL", 1, 0, New Model.DhlDimensions(20, 25, 30), String.Empty, String.Empty))
            .pieces.Add(New Model.DhlPiece("SMALL", 1, 0, New Model.DhlDimensions(20, 25, 30), String.Empty, String.Empty))
            .pieces.Add(New Model.DhlPiece("SMALL", 3, 0, New Model.DhlDimensions(20, 25, 30), String.Empty, String.Empty))
        End With
        spdData = svc.CreateShipment(shp)
        Assert.IsNotNull(spdData)
        Assert.IsTrue(spdData.shipmentId > String.Empty)
        Return spdData
    End Function

    <TestMethod()> Public Sub CreateShipment()
        Dim rst = GetShipmentId()

    End Sub

    Public Function GetTrackingForShipment() As List(Of Model.DhlPiece)
        Dim rst = GetShipmentId()
        Dim lstResults As New List(Of String)
        Assert.IsNotNull(rst.pieces)
        Assert.IsTrue(rst.pieces.Count > 0)
        Return rst.pieces
    End Function
    <TestMethod()> Public Sub ReceiveTrackingForShipment()
        Dim lstMethods As List(Of Model.DhlPiece) = GetTrackingForShipment()
        Assert.IsNotNull(lstMethods)
        Assert.IsTrue(lstMethods.Count > 0)
    End Sub

    <TestMethod()> Public Sub RetrieveLabelForShipment()
        Dim rst = GetShipmentId()
        Dim svc As New DHLParcel.ShipmentService(GetConfiguration)
        Dim lstLabels = svc.GetLabels(rst.shipmentId)
        Assert.IsNotNull(lstLabels)
        Assert.IsTrue(lstLabels.Count > 0)
        For Each objLabel In lstLabels
            IO.File.WriteAllBytes(objLabel.FileName, objLabel.LabelData)
        Next


    End Sub
    <TestMethod()> Public Sub RetrieveCustomsDocumentation()
        Throw New NotImplementedException
    End Sub


End Class