Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<DefaultProperty("StatusMessage")> _
 Public Class ObjectState
    Inherits BaseObject
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
        'AddHandler _mImages.ListChanged, AddressOf OnImageAdded
    End Sub

    Private _mStatusMessage As String
    Public Property StatusMessage() As String
        Get
            Return _mStatusMessage
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("StatusMessage", _mStatusMessage, Value)
        End Set
    End Property

    <Association("ObjectState-ObjectStateInstances")> _
    Public ReadOnly Property ObjectStateInstances() As XPCollection(Of ObjectStateInstance)
        Get
            Return GetCollection(Of ObjectStateInstance)("ObjectStateInstances")
        End Get
    End Property

    Private _mSortIndex As Integer
    Public Property SortIndex() As Integer
        Get
            Return _mSortIndex
        End Get
        Set(ByVal Value As Integer)
            _mSortIndex = Value
        End Set
    End Property
    
    'Private _mImages As New BindingList(Of ObjectStateInstance)
    'Public ReadOnly Property Images() As BindingList(Of ObjectStateInstance)
    '    Get
    '        Return _mImages
    '    End Get
    'End Property

    'Public Sub OnImageAdded()
    '    RaiseEvent ImageAdded()
    'End Sub

    'Public Event ImageAdded()

    Public Sub OnActionExecuted(ByVal CellClickAction As CellClickAction)
        RaiseEvent ActionExecuted(CellClickAction)
    End Sub

    Public Event ActionExecuted(ByVal CellClickAction As CellClickAction)

    Public Class CellClickAction
        Public Sub New(ByVal GridImage As ObjectStateInstance, ByVal PropertyName As String, ByVal CurrentObject As Object, ByVal GridImageStatus As ObjectState)
            Me.GridImage = GridImage
            Me.PropertyName = PropertyName
            Me.SelectedObject = CurrentObject
            Me.GridImageStatus = GridImageStatus
        End Sub

        Private _mGridImage As ObjectStateInstance
        Public Property GridImage() As ObjectStateInstance
            Get
                Return _mGridImage
            End Get
            Set(ByVal Value As ObjectStateInstance)
                _mGridImage = Value
            End Set
        End Property

        Private _mPropertyName As String
        Public Property PropertyName() As String
            Get
                Return _mPropertyName
            End Get
            Set(ByVal Value As String)
                _mPropertyName = Value
            End Set
        End Property

        Private _mSelectedObject As Object
        Public Property SelectedObject() As Object
            Get
                Return _mSelectedObject
            End Get
            Set(ByVal Value As Object)
                _mSelectedObject = Value
            End Set
        End Property

        Private _mGridImageStatus As ObjectState
        Public Property GridImageStatus() As ObjectState
            Get
                Return _mGridImageStatus
            End Get
            Set(ByVal Value As ObjectState)
                _mGridImageStatus = Value
            End Set
        End Property


    End Class

End Class
