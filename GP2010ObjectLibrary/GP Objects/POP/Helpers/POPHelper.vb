Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Objects.POP
    Public Class POPHelper
		Public Shared Function DoesPOReceiptExist(session As Session, POReceiptNumber As String) As Boolean
			If session.FindObject(Of POPReceiptHeaderWork)(CriteriaOperator.Parse("POPRCTNM=?", POReceiptNumber)) IsNot Nothing Then
				Return True
			End If
			If session.FindObject(Of POPReceiptHistory)(CriteriaOperator.Parse("POPRCTNM=?", POReceiptNumber)) IsNot Nothing Then
				Return True
			End If
			Return False
		End Function
        ''' <summary>
        ''' Return a collection of item purchase receipt data based. 
        ''' </summary>
        ''' <param name="Session"></param>
        ''' <param name="FromDate"></param>
        ''' <param name="ThroughDate"></param>
        ''' <param name="ItemKey"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetItemPurchaseSummary(ByVal Session As Session, ByVal ItemKey As String, ByVal Location As String, ByVal FromDate As Date?, ByVal ThroughDate As Date?) As ItemPurchaseSummary
            Dim objItemPurchaseSummary As ItemPurchaseSummary
            Dim xpoGPItem As GP2010ObjectLibrary.Module.Objects.IV.IVItem
            Dim decReceiptQty As Decimal


            xpoGPItem = GP2010ObjectLibrary.Module.Objects.IV.Helpers.IVHelper.GetItem(Session, ItemKey)
            decReceiptQty = GetPOPReceiptLineQuantityTotalForItem(Session, ItemKey, Location, FromDate, ThroughDate)
            objItemPurchaseSummary = New GP2010ObjectLibrary.Module.Objects.POP.ItemPurchaseSummary
            If decReceiptQty > 0 Then

                With objItemPurchaseSummary
                    .ItemKey = ItemKey
                    If xpoGPItem IsNot Nothing Then
                        .ItemDescription = xpoGPItem.ITEMDESC
                    Else
                        .ItemDescription = "ITEM NOT FOUND"
                    End If
                    .PurchaseQty += decReceiptQty
                End With
                Return objItemPurchaseSummary
            Else
                Return Nothing
            End If



        End Function
        Public Shared Function GetPOPReceiptLineQuantityTotalForItem(ByVal Session As Session, ByVal ItemKey As String, ByVal Location As String, ByVal FromDate As Date?, ByVal ThroughDate As Date?) As Decimal
            Dim decRecQty As Decimal
            Dim xpoGO As New GroupOperator
            With xpoGO
                If FromDate.HasValue Then
                    .Operands.Add(New BinaryOperator("DATERECD", FromDate.Value.Date, BinaryOperatorType.GreaterOrEqual))
                End If
                If ThroughDate.HasValue Then
                    .Operands.Add(New BinaryOperator("DATERECD", ThroughDate.Value.Date, BinaryOperatorType.LessOrEqual))
                End If

                .Operands.Add(New BinaryOperator("ITEMNMBR", ItemKey, BinaryOperatorType.Equal))
                .Operands.Add(New BinaryOperator("TRXLOCTN", Location, BinaryOperatorType.Equal))

            End With

            Dim xclPOReceiptLineQuantities As New XPCollection(Of POPReceiptLineQuantity)(Session, xpoGO)
            For Each xpoPRLQ As POPReceiptLineQuantity In xclPOReceiptLineQuantities
                decRecQty += xpoPRLQ.QTYSHPPD
            Next
            Return decRecQty
        End Function

        Public Shared Function GetTotalUnreceivedQuantityForPOLine(ByVal session As Session, ByVal PONumber As String, ByVal POLine As String) As Decimal
            Dim decRecQty As Decimal
            Dim xpoGO As New GroupOperator
            Dim polLine As POPLine
            With xpoGO
                .Operands.Add(New BinaryOperator("Oid.PONUMBER", PONumber, BinaryOperatorType.Equal))
                .Operands.Add(New BinaryOperator("Oid.POLNENUM", POLine, BinaryOperatorType.Equal))
            End With
            Dim xclPOReceiptLineQuantities As New XPCollection(Of POPReceiptLineQuantity)(session, xpoGO)

            xpoGO = New GroupOperator
            With xpoGO
                .Operands.Add(New BinaryOperator("Oid.PONUMBER", PONumber, BinaryOperatorType.Equal))
                .Operands.Add(New BinaryOperator("Oid.ORD", POLine, BinaryOperatorType.Equal))
            End With
            polLine = session.FindObject(Of POPLine)(xpoGO)

            If polLine Is Nothing Then
                Throw New Exception("No PO line found!")
            End If

            For Each xpoPRLQ As POPReceiptLineQuantity In xclPOReceiptLineQuantities
                decRecQty += xpoPRLQ.QTYSHPPD
            Next
            Return polLine.QTYORDER - decRecQty
        End Function


    End Class
End Namespace


