Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.Persistent.Validation

<System.ComponentModel.ReadOnly(False)> _
<System.ComponentModel.DisplayName("CriteriaTemplate")> _
<Serializable()> _
 Public Class ISSBaseCriteriaTemplate
    Inherits BaseObject

    Public Sub New()
        MyBase.New()
    End Sub

#Region "Behaviors"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Function GetEvaluator() As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator
        Dim xpoObjectCustomization As ISSBaseBusinessRules = Me.ObjectCustomization
        Dim ctoCriteriaOperator As CriteriaOperator = Session.ParseCriteria(Criteria)
        Dim dxeExpressionEvaluator As DevExpress.Data.Filtering.Helpers.ExpressionEvaluator
        Dim dcdDescriptorDefault As DevExpress.Data.Filtering.Helpers.EvaluatorContextDescriptorDefault
        
        If xpoObjectCustomization Is Nothing
            xpoObjectCustomization = DefaultSaveValidationObjectCustomization
        End If

        If xpoObjectCustomization Is Nothing Then
            Return Nothing
        End If

        If xpoObjectCustomization.ObjectType Is Nothing Then
            Return Nothing
        End If

        dcdDescriptorDefault = New DevExpress.Data.Filtering.Helpers.EvaluatorContextDescriptorDefault(xpoObjectCustomization.ObjectType)
        dxeExpressionEvaluator = New DevExpress.Data.Filtering.Helpers.ExpressionEvaluator(dcdDescriptorDefault, ctoCriteriaOperator)
        Return dxeExpressionEvaluator
    End Function
    Public Function IsValidObject(ByVal Target As Object) As Boolean
        Dim xpoObjectCustomization As ISSBaseBusinessRules = Me.ObjectCustomization
        
        If xpoObjectCustomization Is Nothing
            xpoObjectCustomization = DefaultSaveValidationObjectCustomization
        End If

        If xpoObjectCustomization Is Nothing Then
            Return False
        End If

        If xpoObjectCustomization.ObjectType Is Nothing Then
            Return False
        End If
       
        Return xpoObjectCustomization.IsValidObject(Target, GetEvaluator())
    End Function

    Private Sub ISSBaseCriteriaTemplate_Changed(sender As Object, e As ObjectChangeEventArgs) Handles Me.Changed
        Select e.PropertyName
            Case "ObjectCustomization"
                OnChanged("ObjectType")
                OnChanged("Criteria")
        End Select
    End Sub



#End Region

#Region "Persistent Properties"

    <VisibleInDetailView(False)>
    <VisibleInListView(False)>
    Private Readonly Property ObjectType As Type
        Get
            If ObjectCustomization IsNot Nothing
                Return ObjectCustomization.ObjectType
            End If
            If DefaultSaveValidationObjectCustomization IsNot Nothing
                Return DefaultSaveValidationObjectCustomization.ObjectType
            End If
            Return Nothing
        End Get
    End Property

    Private _mCriteria As String
    <CriteriaOptions("ObjectType")> _
    <Index(3)> _
    <Size(SizeAttribute.Unlimited)> _
    Property Criteria As String
        Get
            Return _mCriteria
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("Criteria", _mCriteria, Value)
        End Set
    End Property

    Private _mCriteriaName As String
    <Index(0)> _
    <Size(255)> _
    Property CriteriaName As String
        Get
            Return _mCriteriaName
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("CriteriaName", _mCriteriaName, Value)
        End Set
    End Property

    Private _mDefaultSaveValidationObjectCustomization As ISSBaseBusinessRules
    <Association("DefaultSaveValidationObjectCustomization-SaveValidationCriteriaTemplates")> _
<Browsable(False)> _
<Xml.Serialization.XmlIgnore()> _
Public Property DefaultSaveValidationObjectCustomization() As ISSBaseBusinessRules
        Get
            Return _mDefaultSaveValidationObjectCustomization
        End Get
        Set(ByVal Value As ISSBaseBusinessRules)
            SetPropertyValue("DefaultSaveValidationObjectCustomization", _mDefaultSaveValidationObjectCustomization, Value)
        End Set
    End Property
    
    Private _mExceptionMessage As String
    <Size(255)>
    <Index(1)> _
    Property ExceptionMessage As String
        Get
            Return _mExceptionMessage
        End Get
        Set(ByVal Value As String)
            SetPropertyValue("ExceptionMessage", _mExceptionMessage, Value)
        End Set
    End Property
    


    Private _mObjectCustomization As ISSBaseBusinessRules
    <Association("ObjectCustomization-CriteriaTemplates")> _
<Browsable(False)> _
<Xml.Serialization.XmlIgnore()> _
Public Property ObjectCustomization() As ISSBaseBusinessRules
        Get
            Return _mObjectCustomization
        End Get
        Set(ByVal Value As ISSBaseBusinessRules)
            SetPropertyValue("ObjectCustomization", _mObjectCustomization, Value)
        End Set
    End Property

    Private _mShowFilterInExceptionMessage As Boolean
    <Index(2)> _
    Property ShowFilterInExceptionMessage As Boolean
        Get
            Return _mShowFilterInExceptionMessage
        End Get
        Set(ByVal Value As Boolean)
            SetPropertyValue("ShowFilterInExceptionMessage", _mShowFilterInExceptionMessage, Value)
        End Set
    End Property
    
#End Region

#Region "Non Persistent Properties"
    <Browsable(False)> _
    Public ReadOnly Property FullExceptionMessage() As String
        Get
            If ShowFilterInExceptionMessage = True Then
                Return String.Format("({0}) ({1})", ExceptionMessage, Criteria)
            Else
                Return String.Format("{0}", ExceptionMessage)
            End If
        End Get
    End Property
#End Region

#Region "Associations"
    <Association("CriteriaTemplates-WorkflowSteps")> _
    Public ReadOnly Property WorkflowSteps() As XPCollection(Of ISSBaseWorkflowStep)
        Get
            Return GetCollection(Of ISSBaseWorkflowStep)("WorkflowSteps")
        End Get
    End Property
#End Region



End Class
