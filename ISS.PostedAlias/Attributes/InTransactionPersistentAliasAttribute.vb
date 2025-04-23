''' <summary>
''' Apply to an attribute with the persistent alias attribute in order for the value to be updated with transaction changes
''' </summary>
''' <remarks></remarks>
Public Class InTransactionPersistentAliasAttribute
    Inherits Attribute

    Public Sub New(ByVal DependentObjectType As Type, ByVal PathToProperty As String, ByVal PathToCollection As String)
        Me.DependentObjectType = DependentObjectType
        Me.PathToProperty = PathToProperty
        Me.PathToCollection = PathToCollection
    End Sub

    Private _mDependentObjectType As Type
    Public Property DependentObjectType As Type
        Get
            Return _mDependentObjectType
        End Get
        Set(ByVal Value As Type)
            _mDependentObjectType = Value
        End Set
    End Property

    Private _mPathToProperty As String
    Public Property PathToProperty As String
        Get
            Return _mPathToProperty
        End Get
        Set(ByVal Value As String)
            _mPathToProperty = Value
        End Set
    End Property
    
    Private _mPathToCollection As String
    Public Property PathToCollection As String
        Get
            Return _mPathToCollection
        End Get
        Set(ByVal Value As String)
            _mPathToCollection = Value
        End Set
    End Property
    

End Class
