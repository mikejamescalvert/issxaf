Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.SOP


	Partial Public Class SOPSalesOrderLineItem

#Region "Behaviors"

		Public Function GetSopHeader() As SOPSalesOrderHeader
			Return Me.Session.FindObject(GetType(SOPSalesOrderHeader), New DevExpress.Data.Filtering.BinaryOperator("Oid.SOPNUMBE", Oid.SOPNUMBE, DevExpress.Data.Filtering.BinaryOperatorType.Equal))
		End Function

#End Region

#Region "Properties"

		<PersistentAlias("IVItem.ITMCLSCD")>
		Public ReadOnly Property ItemClassCode As String
			Get
				Return EvaluateAlias("ItemClassCode")
			End Get
		End Property
		

		<PersistentAlias("[<IVItem>][ITEMNMBR = ^.ITEMNMBR].Single()")>
		Public ReadOnly Property IVItem As IV.IVItem
			Get
				Return EvaluateAlias("IVItem")
			End Get
		End Property
		''' <summary>
		''' Returns True if the item is a kitted item
		''' </summary>
		''' <value></value>
		''' <returns></returns>
		''' <remarks></remarks>
		''' 
		Public ReadOnly Property IsKit As Boolean
			Get
				Return Helpers.SOPHelper.IsLineItemAKit(Me, Me.Session)
			End Get
		End Property


#End Region


	End Class
End Namespace

