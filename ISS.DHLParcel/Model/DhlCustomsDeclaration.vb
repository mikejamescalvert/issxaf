Namespace Model

    Public Class DhlCustomsDeclaration
        Public Property certificateNumber As String
        Public Property currency As String
        Public Property invoiceNumber As String
        Public Property licenceNumber As String
        Public Property remarks As String
        Public Property invoiceType As String
        Public Property exportType As String
        Public Property exportReason As String
        Public Property customsGoods As New List(Of DhlCustomsGood)
        Public Property incoTerms As String
        Public Property incoTermsCity As String
        Public Property senderInboundVatNumber As String
        Public Property attachmentIds As New List(Of String)
        Public Property shippingFee As DhlShippingFee
        Public Property importerOfRecord As DhlImporterOfRecord
        Public Property defermentAccountDuties As String
        Public Property defermentAccountVat As String
        Public Property vatReverseCharge As Boolean
    End Class

End Namespace
