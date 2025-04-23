Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.SystemModule

Namespace Attributes.RadioEditor
    ''' <summary>
    ''' Aligns all object editor buttons to the specified button position
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ColumnOverrideAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mNumberOfColumns As Integer = 0
        Public Property NumberOfColumns() As Integer
            Get
                Return _mNumberOfColumns
            End Get
            Set(ByVal value As Integer)
                If _mNumberOfColumns = value Then
                    Return
                End If
                _mNumberOfColumns = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal NumberOfColumns As Integer)
            Me.NumberOfColumns = NumberOfColumns
        End Sub
#End Region

    End Class
End Namespace