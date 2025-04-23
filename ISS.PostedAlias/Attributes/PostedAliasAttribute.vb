<AttributeUsage(AttributeTargets.Method,AllowMultiple:=True)>
Public Class PostedAliasAttribute
    Inherits Attribute

    ' Fields...
    Private _mPersistentAlias As String
    Public Property PersistentAlias As String
        Get
            Return _mPersistentAlias
        End Get
        Set(ByVal Value As String)
            _mPersistentAlias = Value
        End Set
    End Property
    Private _mDependentObjectType As Type
    Public Property DependentObjectType As Type
        Get
            Return _mDependentObjectType
        End Get
        Set(ByVal Value As Type)
            _mDependentObjectType = Value
        End Set
    End Property
    Private _mDependentMemberName As String
    Public Property DependentMemberName As String
        Get
            Return _mDependentMemberName
        End Get
        Set(ByVal Value As String)
            _mDependentMemberName = Value
        End Set
    End Property
    Private _mPathToParentFromMember As String
    Public Property PathToParentFromMember As String
        Get
            Return _mPathToParentFromMember
        End Get
        Set(ByVal Value As String)
            _mPathToParentFromMember = Value
        End Set
    End Property

    Public Sub New(ByVal PersistentAlias As String, ByVal DependentObjectType As Type, ByVal DependentMemberName As String, ByVal PathToParentFromMember As String)
        Me.PersistentAlias = PersistentAlias
        Me.DependentObjectType = DependentObjectType
        Me.DependentMemberName = DependentMemberName
        Me.PathToParentFromMember = PathToParentFromMember
    End Sub


End Class
