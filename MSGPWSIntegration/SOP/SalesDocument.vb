Imports System.Collections.Specialized

Namespace SOP

    Public Class SalesDocument

        Public Sub New()
            CreateHeader()
        End Sub

        Public Overridable Sub CreateHeader()
            SalesDocumentHeader = New SalesDocumentHeader
        End Sub

        Private _mSalesDocumentHeader As SalesDocumentHeader
        Public Property SalesDocumentHeader As SalesDocumentHeader
            Get
                Return _mSalesDocumentHeader
            End Get
            Set(ByVal Value As SalesDocumentHeader)
                _mSalesDocumentHeader = Value
            End Set
        End Property

        Private _mSalesDocumentDetails As New List(Of SalesDocumentDetail)
        Public Property SalesDocumentDetails As List(Of SalesDocumentDetail)
            Get
                Return _mSalesDocumentDetails
            End Get
            Set(ByVal Value As List(Of SalesDocumentDetail))
                _mSalesDocumentDetails = Value
            End Set
        End Property

        

    End Class
End Namespace

