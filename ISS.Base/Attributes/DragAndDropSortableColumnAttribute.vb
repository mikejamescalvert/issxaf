Namespace Attributes
    ''' <summary>
    ''' Allows drag and drop of rows within list views to set the values of a column
    ''' </summary>
    <AttributeUsage(AttributeTargets.Class, AllowMultiple:=False, Inherited:=True)>
    Public Class DragAndDropSortableColumnAttribute
        Inherits Attribute

        Private _mSortedColumnName As String
        Property SortedColumnName As String
            Get
                Return _mSortedColumnName
            End Get
            Set(ByVal Value As String)
                _mSortedColumnName = Value
            End Set
        End Property


        Public Sub New(ByVal SortedColumnName As String)
            Me.SortedColumnName = SortedColumnName
        End Sub
    End Class
End Namespace

