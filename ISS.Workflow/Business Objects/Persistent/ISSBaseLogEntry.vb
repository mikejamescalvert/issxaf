Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

<System.ComponentModel.ReadOnly(False)> _
<Serializable()> _
<System.ComponentModel.DisplayName("LogEntry")> _
Public Class ISSBaseLogEntry
    Inherits BaseObject

    Public Sub New()
        MyBase.New()
    End Sub


#Region "Behaviors"

    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        Me.TransactionDateTime = Now
        Me.ChangedBy = DevExpress.ExpressApp.SecuritySystem.CurrentUserName
    End Sub
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

    Public Sub Setup(ByVal Key As String)
        _mKey = Key
    End Sub
#End Region

#Region "Persistent Properties"



    Private _mChangedBy As String
    Private _mKey As String
    Private _mNewValue As String
    Private _mOldValue As String
    Private _mPropertyName As String

    Private _mSavedType As String
    Private _mTransactionDateTime As String
    <Size(255)> _
    <Index(6)> _
    Public Property ChangedBy() As String
        Get
            Return _mChangedBy
        End Get
        Set(ByVal value As String)
            If _mChangedBy = value Then
                Return
            End If
            _mChangedBy = value
        End Set
    End Property
    <Size(SizeAttribute.Unlimited)> _
    <Browsable(False)> _
    Public Property Key() As String
        Get
            Return _mKey
        End Get
        Set(ByVal value As String)
            If _mKey = value Then
                Return
            End If
            _mKey = value
        End Set
    End Property


    <Index(4)> _
    <Size(SizeAttribute.Unlimited)> _
    Public Property NewValue() As String
        Get
            Return _mNewValue
        End Get
        Set(ByVal value As String)
            If _mNewValue = value Then
                Return
            End If
            _mNewValue = value
        End Set
    End Property
    <RuleRequiredField("LogEntry.ObjectTypeRequired", DefaultContexts.Save, "Object Type Is Required")> _
    <Index(0)> _
    Public Property ObjectType() As Type
        Get
            Return DevExpress.Persistent.Base.ReflectionHelper.FindType(_mSavedType)
        End Get
        Set(ByVal value As Type)
            SavedType = value.FullName
        End Set
    End Property
    <Index(3)> _
    <Size(SizeAttribute.Unlimited)> _
    Public Property OldValue() As String
        Get
            Return _mOldValue
        End Get
        Set(ByVal value As String)
            If _mOldValue = value Then
                Return
            End If
            _mOldValue = value
        End Set
    End Property
    <Browsable(False)> _
    Public Property PropertyName() As String
        Get
            Return _mPropertyName
        End Get
        Set(ByVal value As String)
            If _mPropertyName = value Then
                Return
            End If
            _mPropertyName = value
        End Set
    End Property
    <Browsable(False)> _
    Public Property SavedType() As String
        Get
            Return _mSavedType
        End Get
        Set(ByVal value As String)
            If _mSavedType = value Then
                Return
            End If
            _mSavedType = value
        End Set
    End Property
    <Index(1)> _
    Public Property TransactionDateTime() As String
        Get
            Return _mTransactionDateTime
        End Get
        Set(ByVal value As String)
            If _mTransactionDateTime = value Then
                Return
            End If
            _mTransactionDateTime = value
        End Set
    End Property
#End Region

#Region "Non Persistent Properties"

    <Index(2)> _
    Public ReadOnly Property ChangedProperty() As String
        Get
            Dim dmiMemberInfo As DevExpress.ExpressApp.DC.IMemberInfo = Nothing
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = Nothing
            If ObjectType Is Nothing OrElse PropertyName = String.Empty Then
                Return String.Empty
            End If
            Return DevExpress.ExpressApp.Utils.CaptionHelper.GetMemberCaption(ObjectType, PropertyName)
        End Get
    End Property
    <Browsable(False)> _
    Public ReadOnly Property ObjectInstance() As Object
        Get
            Dim gudKey As System.Guid
            Dim objKey As Object
            If ObjectType.GetProperty("Oid").PropertyType Is GetType(System.Guid) Then
                gudKey = New System.Guid(_mKey)
                objKey = gudKey
            ElseIf ObjectType.GetProperty("Oid").PropertyType Is GetType(Integer) Then
                objKey = CType(_mKey, Integer)
            Else
                objKey = Nothing
            End If
            Dim objInstance As Object = Session.GetObjectByKey(ObjectType, objKey)
            Return objInstance
        End Get
    End Property
#End Region

End Class
