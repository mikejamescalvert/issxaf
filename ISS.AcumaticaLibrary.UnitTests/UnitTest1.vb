Imports System.Text
Imports ISS.AcumaticaLibrary.Services
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    Public Function GetMakrLocalConfiguration() As AcumaticaLibrary.Models.AcumaticaConfiguration
        'Eastman Configuration
        Dim cfg As New Models.AcumaticaConfiguration
        With cfg
            .AcumaticaUrl = "http://localhost/acumaticaerp"
            .ApiPassword = "in$pire34"
            .ApiUsername = "admin"
            .Company = "Makr Furniture"
            .EndpointName = "eCommerce"
            .EndpointVersion = "20.200.001"
        End With
        Return cfg
    End Function

    Public Function GetGeminiUatConfiguration() As AcumaticaLibrary.Models.AcumaticaConfiguration
        'Eastman Configuration
        Dim cfg As New Models.AcumaticaConfiguration
        With cfg
            .AcumaticaUrl = "https://geminifoodcorporation.acumatica.com/"
            .ApiPassword = "ISS2022!"
            .ApiUsername = "admin"
            .Company = "Gemini UAT"
            .EndpointName = "eCommerce"
            .EndpointVersion = "22.200.001"
        End With
        Return cfg
    End Function
    Public Function GetLedLightingConfiguration() As AcumaticaLibrary.Models.AcumaticaConfiguration
        'Eastman Configuration
        Dim cfg As New Models.AcumaticaConfiguration
        With cfg
            .AcumaticaUrl = "https://ledlightingsolutions.acumatica.com/"
            .ApiPassword = "In$pire34"
            .ApiUsername = "tbakken"
            .Company = "UAT"
            .EndpointName = "eCommerce"
            .EndpointVersion = "22.200.001"
        End With
        Return cfg
    End Function
    <TestMethod()> Public Sub GetCustomers()
        Dim svc As New CustomerService(GetLedLightingConfiguration)
        Dim rst As Models.CustomerResults
        Dim intPage As Integer = 1
        rst = svc.GetAllCustomersWithPaging(intPage)
        Assert.IsNotNull(rst)
        While rst.Customers.Count > 0
            intPage += 1
            rst = svc.GetAllCustomersWithPaging(intPage)
            Assert.IsNotNull(rst)
        End While
    End Sub
    <TestMethod()> Public Sub GetCustomerById()
        Dim svc As New CustomerService(GetLedLightingConfiguration)
        Dim rst As Models.JSON.Customer
        Dim intPage As Integer = 1
        rst = svc.GetCustomerByCustomerId("C012573")
        Assert.IsNotNull(rst)
        Assert.IsNotNull(rst.Contacts)


    End Sub
    <TestMethod>
    Public Sub CreateUpdateCustomer()
        Dim svc As New CustomerService(GetLedLightingConfiguration)
        Dim cst As New Models.JSON.Customer
        Dim intPage As Integer = 1
        Dim rst As Models.JSON.Customer
        With cst
            .CustomerID = New Models.JSON.JsonStringValue("C012574")
            .CustomerName = New Models.JSON.JsonStringValue("Mike Calvert")
            .CustomerClass = New Models.JSON.JsonStringValue("DEFAULT")
            .Email = New Models.JSON.JsonStringValue("mikejamescalvert@gmail.com")

            .MainContact = New Models.JSON.Contact
            .MainContact.Address = New Models.JSON.Address
            .MainContact.Address.AddressLine1 = New Models.JSON.JsonStringValue("2932 Bogue Creek")
            .MainContact.Address.Country = New Models.JSON.JsonStringValue("US")
            .MainContact.FirstName = New Models.JSON.JsonStringValue("Mike")
            .MainContact.LastName = New Models.JSON.JsonStringValue("Calvert")
            .MainContact.Address.City = New Models.JSON.JsonStringValue("Howell")
            .MainContact.Address.State = New Models.JSON.JsonStringValue("MI")
            .MainContact.Address.PostalCode = New Models.JSON.JsonStringValue("48855")
            .MainContact.Email = New Models.JSON.JsonStringValue("mikejamescalvert@gmail.com")
            .MainContact.Phone1 = New Models.JSON.JsonStringValue("9496323875")
            .MainContact.DisplayName = New Models.JSON.JsonStringValue("Mike Calvert")
            .ShippingContactOverride = New Models.JSON.JsonBooleanValue(True)
            .ShippingAddressOverride = New Models.JSON.JsonBooleanValue(True)
            .ShippingContact = New Models.JSON.Contact
            .ShippingContact.Address = New Models.JSON.Address
            .ShippingContact.Address.AddressLine1 = New Models.JSON.JsonStringValue("2932 Bogue Creek")
            .ShippingContact.Address.Country = New Models.JSON.JsonStringValue("US")
            .ShippingContact.FirstName = New Models.JSON.JsonStringValue("Shipping")
            .ShippingContact.LastName = New Models.JSON.JsonStringValue("Calvert")
            .ShippingContact.Address.City = New Models.JSON.JsonStringValue("Howell")
            .ShippingContact.Address.State = New Models.JSON.JsonStringValue("MI")
            .ShippingContact.Address.PostalCode = New Models.JSON.JsonStringValue("48855")
            .ShippingContact.Email = New Models.JSON.JsonStringValue("mikejamescalvert@gmail.com")
            .ShippingContact.Phone1 = New Models.JSON.JsonStringValue("9496323875")
            .ShippingContact.DisplayName = New Models.JSON.JsonStringValue("Mike Calvert")
            .BillingContactOverride = New Models.JSON.JsonBooleanValue(True)
            .BillingAddressOverride = New Models.JSON.JsonBooleanValue(True)
            .BillingContact = New Models.JSON.Contact
            .BillingContact.Address = New Models.JSON.Address
            .BillingContact.Address.AddressLine1 = New Models.JSON.JsonStringValue("2932 Bogue Creek")
            .BillingContact.Address.Country = New Models.JSON.JsonStringValue("US")
            .BillingContact.FirstName = New Models.JSON.JsonStringValue("Money")
            .BillingContact.LastName = New Models.JSON.JsonStringValue("Calvert")
            .BillingContact.Address.City = New Models.JSON.JsonStringValue("Howell")
            .BillingContact.Address.State = New Models.JSON.JsonStringValue("MI")
            .BillingContact.Address.PostalCode = New Models.JSON.JsonStringValue("48855")
            .BillingContact.Email = New Models.JSON.JsonStringValue("mikejamescalvert@gmail.com")
            .BillingContact.Phone1 = New Models.JSON.JsonStringValue("9496323875")
            .BillingContact.DisplayName = New Models.JSON.JsonStringValue("Mike Calvert")

            .Salespersons.Add(New ISS.AcumaticaLibrary.Salesperson())
            With .Salespersons(0)
                .SalespersonID = New ISS.AcumaticaLibrary.Models.JSON.JsonStringValue("OTHER")
            End With
        End With

        rst = svc.CreateUpdateCustomer(cst)
        Assert.IsNotNull(rst)
        Assert.IsNotNull(rst.CustomerID)

    End Sub


    <TestMethod>
    Public Sub CreateUpdateCustomerContact()
        Dim svc As New CustomerService(GetLedLightingConfiguration)
        Dim cst As Models.JSON.Customer = svc.GetCustomerByCustomerId("C012574")
        Dim cnt As Models.JSON.Contact
        Dim intPage As Integer = 1
        Dim rst As Models.JSON.Contact



        cnt = New Models.JSON.Contact
        With cnt
            .BusinessAccount = New Models.JSON.JsonStringValue("C012574")
            .Email = New Models.JSON.JsonStringValue("mike.calvert@issusa.com")
            .FirstName = New Models.JSON.JsonStringValue("Mike")
            .LastName = New Models.JSON.JsonStringValue("Calvert")

            .Address = New Models.JSON.Address
            .Address.AddressLine1 = New Models.JSON.JsonStringValue("12320 NE 109th Way")
            .Address.City = New Models.JSON.JsonStringValue("Vancouver")
            .Address.State = New Models.JSON.JsonStringValue("WA")
            .Address.PostalCode = New Models.JSON.JsonStringValue("92688")
            .Address.Country = New Models.JSON.JsonStringValue("US")
        End With

        rst = svc.CreateUpdateContact(cnt)
        Assert.IsNotNull(rst)
        Assert.IsNotNull(rst.Address)
        Assert.IsNotNull(rst.BusinessAccount)
        cst = svc.GetCustomerByCustomerId("C012574")

        Assert.IsNotNull(cst)
        Assert.IsNotNull(cst.Contacts)

        'For Each cnt In cst.Contacts
        '    Assert.IsNotNull(cnt.BusinessAccount)
        'Next

    End Sub

    <TestMethod>
    Public Sub CreateUpdateCustomerLocation()
        Dim svc As New CustomerService(GetLedLightingConfiguration)
        Dim clr As Models.CustomerLocationResults = svc.GetCustomerLocationsForCustomerWithPaging("C012574", 1)
        Dim lct As Models.JSON.CustomerLocation
        Dim intPage As Integer = 1
        Dim rst As Models.JSON.CustomerLocation

        For Each lct In clr.CustomerLocations
            Assert.IsNotNull(lct.LocationContact)
            Assert.IsNotNull(lct.LocationContact.Address)
        Next

        lct = New Models.JSON.CustomerLocation
        With lct
            .AddressOverride = New Models.JSON.JsonBooleanValue(True)
            .ContactOverride = New Models.JSON.JsonBooleanValue(True)
            .LocationContact = New Models.JSON.Contact
            .LocationContact.Address = New Models.JSON.Address
            .Customer = New Models.JSON.JsonStringValue("C012574")
            .LocationContact.Email = New Models.JSON.JsonStringValue("mike.calvert@issusa.com")
            .LocationContact.FirstName = New Models.JSON.JsonStringValue("Mike")
            .LocationContact.LastName = New Models.JSON.JsonStringValue("Calvert")
            .LocationContact.Address.AddressLine1 = New Models.JSON.JsonStringValue("12320 NE 109th Way")
            .LocationContact.Address.City = New Models.JSON.JsonStringValue("Vancouver")
            .LocationContact.Address.State = New Models.JSON.JsonStringValue("WA")
            .LocationContact.Address.PostalCode = New Models.JSON.JsonStringValue("92688")
            .LocationName = New Models.JSON.JsonStringValue("SAMPLE")
            .LocationID = New Models.JSON.JsonStringValue("SAMPLE")
        End With

        rst = svc.CreateUpdateCustomerLocation(lct)
        Assert.IsNotNull(rst)
        Assert.IsNotNull(rst.LocationContact)
        Assert.IsNotNull(rst.LocationContact.Address)
    End Sub
    <TestMethod()> Public Sub GetSalesPricesByDate()
        Dim svc As New ItemService(GetGeminiUatConfiguration)
        Dim rst As Models.SalesPriceResults
        Dim spqRequest As New Models.JSON.SalesPriceRequest
        With spqRequest
            .EffectiveAsOfDate = New Models.JSON.JsonDateTimeValue
            .EffectiveAsOfDate.value = Now
            .InventoryID = New Models.JSON.JsonStringValue
            .InventoryID.value = "1200"
        End With
        rst = svc.GetSalesPrices(spqRequest)
        Assert.IsNotNull(rst)
        Assert.IsTrue(rst.SalesPriceDetails.Count > 0)

    End Sub

    <TestMethod()> Public Sub CreateUpdateSalesPriceWorksheet()
        Dim svc As New ItemService(GetGeminiUatConfiguration)
        Dim rqsWorksheet As New Models.JSON.SalesPriceWorksheet
        Dim rqdDetail As New Models.JSON.SalesPriceWorksheetDetail

        With rqsWorksheet
            .Description = New Models.JSON.JsonStringValue("Test Worksheet")
            .EffectiveDate = New Models.JSON.JsonDateTimeValue(Today)
            .OverwriteOverlappingPrices = New Models.JSON.JsonBooleanValue(True)
            .ReferenceNbr = New Models.JSON.JsonStringValue("000003")
        End With

        With rqdDetail
            .PriceType = New Models.JSON.JsonStringValue("Base")
            .InventoryID = New Models.JSON.JsonStringValue("0001")
            .UOM = New Models.JSON.JsonStringValue("EACH")
            .PendingPrice = New Models.JSON.JsonDoubleValue(15)
        End With

        rqsWorksheet.SalesPrices.Add(rqdDetail)

        rqdDetail = New Models.JSON.SalesPriceWorksheetDetail

        With rqdDetail
            .PriceType = New Models.JSON.JsonStringValue("Customer")
            .PriceCode = New Models.JSON.JsonStringValue("AK003")
            .InventoryID = New Models.JSON.JsonStringValue("0001")
            .UOM = New Models.JSON.JsonStringValue("EACH")
            .PendingPrice = New Models.JSON.JsonDoubleValue(12)
        End With

        rqsWorksheet.SalesPrices.Add(rqdDetail)

        rqdDetail = New Models.JSON.SalesPriceWorksheetDetail
        With rqdDetail
            .PriceType = New Models.JSON.JsonStringValue("Customer Price Class")
            .PriceCode = New Models.JSON.JsonStringValue("CA")
            .InventoryID = New Models.JSON.JsonStringValue("0001")
            .UOM = New Models.JSON.JsonStringValue("EACH")
            .PendingPrice = New Models.JSON.JsonDoubleValue(8)
        End With

        rqsWorksheet.SalesPrices.Add(rqdDetail)

        rqsWorksheet = svc.CreateUpdateSalesPriceWorksheet(rqsWorksheet)
        Assert.IsNotNull(rqsWorksheet)
        Assert.IsTrue(rqsWorksheet.SalesPrices.Count > 0)

    End Sub

    <TestMethod()> Public Sub GetCustomerAddresses()
        Dim svc As New CustomerService(GetMakrLocalConfiguration)
        Dim rst As Models.CustomerLocationResults
        Dim intPage As Integer = 1
        rst = svc.GetCustomerLocationsForCustomerWithPaging("TONG", intPage)
        Assert.IsNotNull(rst)
        While rst.CustomerLocations.Count > 0
            Assert.IsNotNull(rst.CustomerLocations(0))
            Assert.IsNotNull(rst.CustomerLocations(0).LocationContact)
            Assert.IsNotNull(rst.CustomerLocations(0).LocationContact.Address)
            intPage += 1
            rst = svc.GetCustomerLocationsForCustomerWithPaging("TONG", intPage)
            Assert.IsNotNull(rst)
        End While
    End Sub
    <TestMethod>
    Public Sub GetSalesOrders()
        Dim svcSalesService As New SalesOrderService(GetLedLightingConfiguration)
        Dim rst = svcSalesService.GetAllSalesOrdersWithPaging(1, String.Format("$filter=OrderType eq 'SO'", Today.AddDays(-30)), "&$custom=Document.AttributeSOQUEUE")

        Assert.IsNotNull(rst)

    End Sub

    <TestMethod>
    Public Sub CreateSalesOrder()
        Dim svcSalesService As New SalesOrderService(GetMakrLocalConfiguration)
        Dim objOrder As New Models.JSON.SalesOrder
        Dim objOrderLine As New Models.JSON.SalesOrderLine
        Dim rst As Models.JSON.SalesOrder
        With objOrder
            .CustomerID = New Models.JSON.JsonStringValue("APCF")
            .OrderType = New Models.JSON.JsonStringValue("SO")
            .LocationID = New Models.JSON.JsonStringValue("MAIN")
        End With

        With objOrderLine
            .InventoryID = New Models.JSON.JsonStringValue("1200")
            .OrderQty = New Models.JSON.JsonDoubleValue(1)
        End With
        objOrder.Details.Add(objOrderLine)
        objOrderLine = New Models.JSON.SalesOrderLine
        With objOrderLine
            .InventoryID = New Models.JSON.JsonStringValue("1200")
            .OrderQty = New Models.JSON.JsonDoubleValue(2)
        End With
        objOrder.Details.Add(objOrderLine)

        rst = svcSalesService.CreateSalesOrder(objOrder, String.Empty)
        Assert.IsNotNull(rst)
        Assert.IsNotNull(rst.OrderNbr)
        Assert.IsTrue(rst.OrderNbr.value > String.Empty)
    End Sub


End Class