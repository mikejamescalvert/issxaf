Imports DevExpress.Xpo

Namespace Attributes.Editors.TextEditor
    Public Class StringValueWithPropertySourceEditorAttribute
        Inherits Attribute

        Private _mSourceCollectionPropertyName As String
        Property SourceCollectionPropertyName As String
            Get
                Return _mSourceCollectionPropertyName
            End Get
            Set(ByVal Value As String)
                _mSourceCollectionPropertyName = Value
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
        Public Sub New(ByVal SourceCollectionPropertyName As String, ByVal ValuePropertyName As String, ByVal SortColumnIndex As Integer, ByVal SortDirection As SortDirection, ByVal CriteriaString As String, ByVal ShowPopupOnEdit As Boolean, ByVal ColumnsToDisplay As String, ByVal CaptionsOfColumnsToDisplay As String, ByVal ColumnSizes As String, ByVal MinimumWindowWidth As Integer, ByVal MinimumWindowHeight As Integer, ByVal AllowManualEntry As Boolean)
            Me.SourceCollectionPropertyName = SourceCollectionPropertyName
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
