Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Namespace Objects.SOP.Helpers
	Public Class SOPHelper

		Public Shared Function IsDuplicateDocument(Session As Session, SopNumber As String, SOPtype As SOPGlobals.SOPDocumentTypes) As Boolean
			Dim gpSOPKey As New SOPSalesOrderHeader.SalesOrderHeaderKey
			Dim gpSOPHKey As New SOPHistoricalSalesOrderHeader.HistoricalSalesOrderHeaderKey
			With gpSOPKey
				.SOPNUMBE = SopNumber
				.SOPTYPE = SOPtype.GetHashCode
			End With
			With gpSOPHKey
				.SOPNUMBE = SopNumber
				.SOPTYPE = SOPtype.GetHashCode

			End With
			If Session.GetObjectByKey(Of SOP.SOPSalesOrderHeader)(gpSOPKey) Is Nothing Then
				If Session.GetObjectByKey(Of SOPHistoricalSalesOrderHeader)(gpSOPHKey) Is Nothing Then
					Return False
				End If
			End If
			Return True
		End Function


		Public Shared Function GetNextSopNumber(ByVal DocID As String, ByVal SopType As Short, ByVal CurrentSession As Session) As String
			Dim sdcDocType As SOPSalesDocumentType
			Dim gpoGroupOperator As New GroupOperator
			gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.DOCID", DocID))
			gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.SOPTYPE", SopType))
			sdcDocType = CurrentSession.FindObject(Of SOPSalesDocumentType)(gpoGroupOperator)
			If sdcDocType Is Nothing Then
				Throw New Exception("Cannot find doc type information in GP!")
			End If
			Return sdcDocType.SOPNUMBE
		End Function
		Public Shared Function GetWorkflowDescriptionById(ByVal WorkflowID As Short, ByVal CurrentSession As Session) As String
			Dim swkWorkflow As SOPWorkflow = CurrentSession.GetObjectByKey(Of SOPWorkflow)(WorkflowID)
			If swkWorkflow Is Nothing Then
				Return String.Empty
			End If
			Return swkWorkflow.SOPSTSDESCR
		End Function


		Public Shared Function GetSalesOrderHeader(ByVal SopNumber As String, ByVal CurrentSession As Session) As SOPSalesOrderHeader
			Return CurrentSession.FindObject(Of SOPSalesOrderHeader)(New BinaryOperator("Oid.SOPNUMBE", SopNumber))
		End Function

		Public Shared Function GetSalesOrderLines(ByVal SopNumber As String, ByVal CurrentSession As Session) As XPCollection(Of SOPSalesOrderLineItem)
			Return New XPCollection(Of SOPSalesOrderLineItem)(CurrentSession, New BinaryOperator("Oid.SOPNUMBE", SopNumber))
		End Function
		Public Shared Function GetSalesOrderLine(ByVal SopNumber As String, ByVal LineNumber As Integer, ByVal CurrentSession As Session) As SOPSalesOrderLineItem
			Dim gpoGroupOperator As New GroupOperator
			gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.SOPNUMBE", SopNumber))
			gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LNITMSEQ", LineNumber))
			Return CurrentSession.FindObject(Of SOPSalesOrderLineItem)(gpoGroupOperator)
		End Function
		''' <summary>
		''' Returns true if the line item is a kit line item
		''' </summary>
		''' <param name="SopNumber"></param>
		''' <param name="LineNumber"></param>
		''' <param name="CurrentSession"></param>
		''' <returns></returns>
		''' <remarks></remarks>
		Public Shared Function IsLineItemAKit(ByVal SopNumber As String, ByVal LineNumber As Integer, ByVal CurrentSession As Session) As Boolean
			Dim xpoLine As SOPSalesOrderLineItem
			Dim gpoGroupOperator As New GroupOperator
			gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.SOPNUMBE", SopNumber))
			gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LNITMSEQ", LineNumber))
			gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.CMPNTSEQ", 0))
			xpoLine = CurrentSession.FindObject(Of SOPSalesOrderLineItem)(gpoGroupOperator)
			Return SOPHelper.IsLineItemAKit(xpoLine, CurrentSession)

		End Function
		Public Shared Function IsLineItemAKit(ByVal SOPLine As SOPSalesOrderLineItem, ByVal CurrentSession As Session) As Boolean
			If SOPLine IsNot Nothing AndAlso SOPHelper.GetKitComponentLines(SOPLine.Oid.SOPNUMBE, SOPLine.Oid.LNITMSEQ, CurrentSession) IsNot Nothing Then
				Return True
			Else
				Return False
			End If

		End Function

		Public Shared Function GetKitComponentLines(ByVal SopNumber As String, ByVal LineNumber As Integer, ByVal CurrentSession As Session) As XPCollection(Of SOPSalesOrderLineItem)
			Dim xpoGO As New GroupOperator
			Dim xclKitLines As XPCollection(Of SOPSalesOrderLineItem)
			With xpoGO
				.Operands.Add(New BinaryOperator("Oid.SOPNUMBE", SopNumber))
				.Operands.Add(New BinaryOperator("Oid.LNITMSEQ", LineNumber))
				.Operands.Add(New BinaryOperator("Oid.CMPNTSEQ", 0, BinaryOperatorType.Greater))
			End With
			xclKitLines = New XPCollection(Of SOPSalesOrderLineItem)(CurrentSession, xpoGO)
			If xclKitLines.Count > 1 Then
				Return xclKitLines
			Else
				Return Nothing
			End If
		End Function

		Public Shared Function GetHistoricalSalesOrderHeader(ByVal SopNumber As String, ByVal CurrentSession As Session) As SOPHistoricalSalesOrderHeader
			Return CurrentSession.FindObject(Of SOPHistoricalSalesOrderHeader)(New BinaryOperator("Oid.SOPNUMBE", SopNumber))
		End Function
		Public Shared Function GetHistoricalSalesOrderHeader(ByVal VoidStatus As Short, ByVal CurrentSession As Session) As SOPHistoricalSalesOrderHeader
			Return CurrentSession.FindObject(Of SOPHistoricalSalesOrderHeader)(New BinaryOperator("VOIDSTTS", VoidStatus))
		End Function

		Public Shared Function GetHistoricalSalesOrderHeaderFromOriginalNumber(ByVal OriginalNumber As String, ByVal CurrentSession As Session) As SOPHistoricalSalesOrderHeader
			Return CurrentSession.FindObject(Of SOPHistoricalSalesOrderHeader)(New BinaryOperator("ORIGNUMB", OriginalNumber))
		End Function

		Public Shared Function GetHistoricalSalesOrderLines(ByVal SopNumber As String, ByVal CurrentSession As Session) As XPCollection(Of SOPHistoricalSalesOrderLineItem)
			Return New XPCollection(Of SOPHistoricalSalesOrderLineItem)(CurrentSession, New BinaryOperator("Oid.SOPNUMBE", SopNumber))
		End Function
		Public Shared Function GetHistoricalSalesOrderLines(ByVal SopNumber As String, ByVal LineNumber As Integer, ByVal CurrentSession As Session) As XPCollection(Of SOPHistoricalSalesOrderLineItem)
			Dim gpoGroupOperator As New GroupOperator
			gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.SOPNUMBE", SopNumber))
			gpoGroupOperator.Operands.Add(New BinaryOperator("Oid.LNITMSEQ", LineNumber))
			Return New XPCollection(Of SOPHistoricalSalesOrderLineItem)(CurrentSession, gpoGroupOperator)
		End Function
	End Class
End Namespace
