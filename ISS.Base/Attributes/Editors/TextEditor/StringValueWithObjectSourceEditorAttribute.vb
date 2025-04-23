Imports DevExpress.Xpo

Namespace Attributes.Editors.TextEditor
    Public Class StringValueWithObjectSourceEditorAttribute
        Inherits Attribute

        Private _mSourceObjectType As Type
        Property SourceObjectType As Type
            Get
                Return _mSourceObjectType
            End Get
            Set(ByVal Value As Type)
                _mSourceObjectType = Value
            End Set
        End Property

        Private _mTypePropertyName As String
        Property TypePropertyName As String
            Get
                Return _mTypePropertyName
            End Get
            Set(ByVal Value As String)
                _mTypePropertyName = Value
            End Set
        End Property

        Private _mValuePropertyName As String
        Property ValuePropertyName As String
            Get
                Return _mValuePropertyName
            End Get
            Set(ByVal Value As String)
                _mValuePropertyName = Value
            End Set
        End Property

        Private _mCriteriaString As String
        Property CriteriaString As String
            Get
                Return _mCriteriaString
            End Get
            Set(ByVal Value As String)
                _mCriteriaString = Value
            End Set
        End Property
        Private _mSortColumnIndex As Integer
        Property SortColumnIndex As Integer
            Get
                Return _mSortColumnIndex
            End Get
            Set(ByVal Value As Integer)
                _mSortColumnIndex = Value
            End Set
        End Property

        Private _mSortDirection As SortDirection
        Property SortDirection As SortDirection
            Get
                Return _mSortDirection
            End Get
            Set(value As SortDirection)
                _mSortDirection = value
            End Set
        End Property

        Private _mShowPopupOnEdit As Boolean
        Property ShowPopupOnEdit As Boolean
            Get
                Return _mShowPopupOnEdit
            End Get
            Set(value As Boolean)
                _mShowPopupOnEdit = value
            End Set
        End Property
        Private _mColumnstoDisplay As String
        Property ColumnstoDisplay As String
            Get
                Return _mColumnstoDisplay
            End Get
            Set(ByVal Value As String)
                _mColumnstoDisplay = Value
            End Set
        End Property
        Private _mCaptionsOfColumnsToDisplay As String
        Property CaptionsOfColumnsToDisplay As String
            Get
                Return _mCaptionsOfColumnsToDisplay
            End Get
            Set(ByVal Value As String)
                _mCaptionsOfColumnsToDisplay = Value
            End Set
        End Property
        Private _mColumnSizes As String
        Property ColumnSizes As String
            Get
                Return _mColumnSizes
            End Get
            Set(ByVal Value As String)
                _mColumnSizes = Value
            End Set
        End Property
        Private _mMinimumWindowWidth As Integer
        Property MinimumWindowWidth As Integer
            Get
                Return _mMinimumWindowWidth
            End Get
            Set(ByVal Value As Integer)
                _mMinimumWindowWidth = Value
            End Set
        End Property
        Private _mMinimumWindowHeight As Integer
        Property MinimumWindowHeight As Integer
            Get
                Return _mMinimumWindowHeight
            End Get
            Set(ByVal Value As Integer)
                _mMinimumWindowHeight = Value
            End Set
        End Property
        Private _mAllowManualEntry As Boolean
        Property AllowManualEntry As Boolean
            Get
                Return _mAllowManualEntry
            End Get
            Set(ByVal Value As Boolean)
                _mAllowManualEntry = Value
            End Set
        End Property

        'Private _mUsePropertyType As Boolean
        'Property UsePropertyValue As Boolean
        '    Get
        '        Return _mUsePropertyType
        '    End Get
        '    Set(value As Boolean)
        '        _mUsePropertyType = value
        '    End Set
        'End Property

        '''' <summary>
        '''' Use the actual type as the attribute argument.
        '''' </summary>
        '''' <param name="SourceObjectType">Type value of the object.</param>
        '''' <param name="ValuePropertyName">The name of the property in the target object type that holds the value.</param>
        '''' <param name="ColumnsToDisplay">Semi-colon separated (non-spaced) list of column names (Ex. "Col1;Col2;Col3").</param>
        '''' <param name="CaptionsOfColumnsToDisplay">Semi-colon separated (non-spaced) list of column captions to show (Ex. "Col1Name;Col2Name;Col3Name").</param>
        '''' <param name="ColumnSizes">The semi-colon separated sizes of each of the columns in the list (Ex. "100;250;175").</param>
        '''' <param name="CriteriaString">Criteria string to filter the list.</param>
        '''' <param name="ShowPopupOnEdit">Display the list popup on beginning editing. Default true.</param>
        '''' <param name="SortColumnIndex">The index of the property in the target object by which to sort the list. Default 0.</param>
        '''' <param name="SortDirection">The direction to sort the list. Default Ascending.</param>
        '''' <param name="MinimumWindowWidth">The minimum width of the list popup. Default 600.</param>
        '''' <param name="MinimumWindowHeight">The minimum height of the list popup. Default 500.</param>
        'Public Sub New(ByVal SourceObjectType As Type, ByVal ValuePropertyName As String, ByVal ColumnsToDisplay As String, ByVal CaptionsOfColumnsToDisplay As String, ByVal ColumnSizes As String, Optional ByVal CriteriaString As String = "", Optional ByVal ShowPopupOnEdit As Boolean = True, Optional ByVal SortColumnIndex As Integer = 0, Optional ByVal SortDirection As SortDirection = SortDirection.Ascending, Optional ByVal MinimumWindowWidth As Integer = 600, Optional ByVal MinimumWindowHeight As Integer = 500)
        '    Me.SourceObjectType = SourceObjectType

        '    Me.ValuePropertyName = ValuePropertyName
        '    Me.SortColumnIndex = SortColumnIndex
        '    Me.SortDirection = SortDirection

        '    Me.TypePropertyName = ""

        '    Me.CriteriaString = CriteriaString
        '    Me.ShowPopupOnEdit = ShowPopupOnEdit
        '    Me.ColumnstoDisplay = ColumnsToDisplay
        '    Me.CaptionsOfColumnsToDisplay = CaptionsOfColumnsToDisplay
        '    Me.ColumnSizes = ColumnSizes
        '    Me.MinimumWindowHeight = MinimumWindowHeight
        '    Me.MinimumWindowWidth = MinimumWindowWidth
        'End Sub

        '''' <summary>
        '''' Use a string value to determine the Type value.
        '''' </summary>
        '''' <param name="TypePropertyName">String that holds the value to evaluate for determining what Type to target.</param>
        '''' <param name="ValuePropertyName">The name of the property in the target object type that holds the value.</param>
        '''' <param name="ColumnsToDisplay">Semi-colon separated (non-spaced) list of column names (Ex. "Col1;Col2;Col3").</param>
        '''' <param name="CaptionsOfColumnsToDisplay">Semi-colon separated (non-spaced) list of column captions to show (Ex. "Col1Name;Col2Name;Col3Name").</param>
        '''' <param name="CriteriaString">Criteria string to filter the list.</param>
        '''' <param name="ShowPopupOnEdit">Display the list popup on beginning editing. Default true.</param>
        '''' <param name="SortColumnIndex">The index of the property in the target object by which to sort the list. Default 0.</param>
        '''' <param name="SortDirection">The direction to sort the list. Default Ascending.</param>
        '''' <param name="MinimumWindowWidth">The minimum width of the list popup. Default 600.</param>
        '''' <param name="MinimumWindowHeight">The minimum height of the list popup. Default 500.</param>
        '''' <param name="ColumnSizes">The semi-colon separated sizes of each of the columns in the list (Ex. "100;250;175").</param>
        'Public Sub New(ByVal TypePropertyName As String, ByVal ValuePropertyName As String, ByVal ColumnsToDisplay As String, ByVal CaptionsOfColumnsToDisplay As String, ByVal ColumnSizes As String, Optional ByVal CriteriaString As String = "", Optional ByVal ShowPopupOnEdit As Boolean = True, Optional ByVal SortColumnIndex As Integer = 0, Optional ByVal SortDirection As SortDirection = SortDirection.Ascending, Optional ByVal MinimumWindowWidth As Integer = 600, Optional ByVal MinimumWindowHeight As Integer = 500)
        '    Me.SourceObjectType = Nothing

        '    Me.ValuePropertyName = ValuePropertyName
        '    Me.SortColumnIndex = SortColumnIndex
        '    Me.SortDirection = SortDirection

        '    Me.TypePropertyName = TypePropertyName

        '    Me.CriteriaString = CriteriaString
        '    Me.ShowPopupOnEdit = ShowPopupOnEdit
        '    Me.ColumnstoDisplay = ColumnsToDisplay
        '    Me.CaptionsOfColumnsToDisplay = CaptionsOfColumnsToDisplay
        '    Me.ColumnSizes = ColumnSizes
        '    Me.MinimumWindowHeight = MinimumWindowHeight
        '    Me.MinimumWindowWidth = MinimumWindowWidth
        'End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="TargetPropertyName"></param>
        ''' <param name="ValuePropertyName"></param>
        ''' <param name="SortColumnIndex"></param>
        ''' <param name="SortDirection"></param>
        ''' <param name="CriteriaString"></param>
        ''' <param name="ShowPopupOnEdit"></param>
        ''' <param name="ColumnstoDisplay">Semi Colon Delimited List of Columns</param>
        ''' ''' <param name="CaptionsOfColumnsToDisplay">Semi Colon Delimited List of Column Captions to display in Lookup</param>
        Public Sub New(ByVal TypePropertyName As String, ByVal ValuePropertyName As String, ByVal SortColumnIndex As Integer, ByVal SortDirection As SortDirection, ByVal CriteriaString As String, ByVal ShowPopupOnEdit As Boolean, ByVal ColumnsToDisplay As String, ByVal CaptionsOfColumnsToDisplay As String, ByVal ColumnSizes As String, ByVal MinimumWindowWidth As Integer, ByVal MinimumWindowHeight As Integer, ByVal AllowManualEntry As Boolean)
            Me.TypePropertyName = TypePropertyName
            Me.ValuePropertyName = ValuePropertyName
            Me.SortColumnIndex = SortColumnIndex
            Me.SortDirection = SortDirection

            Me.CriteriaString = CriteriaString
            Me.ShowPopupOnEdit = ShowPopupOnEdit
            Me.ColumnstoDisplay = ColumnsToDisplay
            Me.CaptionsOfColumnsToDisplay = CaptionsOfColumnsToDisplay
            Me.ColumnSizes = ColumnSizes
            Me.MinimumWindowHeight = MinimumWindowHeight
            Me.MinimumWindowWidth = MinimumWindowWidth
            Me.AllowManualEntry = AllowManualEntry
        End Sub



        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="SourceObjectType"></param>
        ''' <param name="ValuePropertyName"></param>
        ''' <param name="SortColumnIndex"></param>
        ''' <param name="SortDirection"></param>
        ''' <param name="CriteriaString"></param>
        ''' <param name="ShowPopupOnEdit"></param>
        ''' <param name="ColumnstoDisplay">Semi Colon Delimited List of Columns</param>
        ''' ''' <param name="CaptionsOfColumnsToDisplay">Semi Colon Delimited List of Column Captions to display in Lookup</param>
        Public Sub New(ByVal SourceObjectType As Type, ByVal ValuePropertyName As String, ByVal SortColumnIndex As Integer, ByVal SortDirection As SortDirection, ByVal CriteriaString As String, ByVal ShowPopupOnEdit As Boolean, ByVal ColumnsToDisplay As String, ByVal CaptionsOfColumnsToDisplay As String, ByVal ColumnSizes As String, ByVal MinimumWindowWidth As Integer, ByVal MinimumWindowHeight As Integer, ByVal AllowManualEntry As Boolean)
            Me.SourceObjectType = SourceObjectType
            Me.ValuePropertyName = ValuePropertyName
            Me.SortColumnIndex = SortColumnIndex
            Me.SortDirection = SortDirection

            Me.CriteriaString = CriteriaString
            Me.ShowPopupOnEdit = ShowPopupOnEdit
            Me.ColumnstoDisplay = ColumnsToDisplay
            Me.CaptionsOfColumnsToDisplay = CaptionsOfColumnsToDisplay
            Me.ColumnSizes = ColumnSizes
            Me.MinimumWindowHeight = MinimumWindowHeight
            Me.MinimumWindowWidth = MinimumWindowWidth
            Me.AllowManualEntry = AllowManualEntry
        End Sub
    End Class
End Namespace
