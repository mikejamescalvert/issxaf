Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.XtraLayout
Imports System.Linq
Imports DevExpress.ExpressApp.Win.Layout
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp.Templates

Public Class WorkflowPropertyEditorsController
    Inherits ViewController

    Private _mObjectCustomization As ISSBaseBusinessRules
    Public ReadOnly Property ObjectCustomization() As ISSBaseBusinessRules
        Get
            Return _mObjectCustomization
        End Get
    End Property

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.DetailView

    End Sub

    Public ReadOnly Property ThisDetailView As DetailView
        Get
            Return View
        End Get
    End Property

    Private WithEvents ViewWithEvents As View

    Private _mTextWidth As Integer
    Private _mCurrentWorkflow As ISSBaseWorkflowStep
    Private _mWorkflowObject As Interfaces.IWorkflow

#Region "Behavior"
    Private Sub WorkflowController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        If Me.View.ObjectTypeInfo.IsPersistent = False Then
            Return
        End If
        RemoveHandler Me.View.CurrentObjectChanged, AddressOf InitWorkflow
        AddHandler Me.View.CurrentObjectChanged, AddressOf InitWorkflow
        'RemoveHandler Me.View.ObjectSpace.Committed, AddressOf InitWorkflow
        'AddHandler Me.View.ObjectSpace.Committed, AddressOf InitWorkflow
        RemoveHandler Me.View.ObjectSpace.ObjectChanged, AddressOf InitWorkflow
        AddHandler Me.View.ObjectSpace.ObjectChanged, AddressOf InitWorkflow
        Helpers.WorkflowHelper.ClearWorkflowDefinitionCache()
        InitWorkflow(Me, New EventArgs)




    End Sub




#End Region

#Region "Functions"
    Private Sub InitWorkflow(ByVal sender As Object, ByVal e As EventArgs)
        Dim oObjectChangedEventArgs As ObjectChangedEventArgs
        If TypeOf e Is ObjectChangedEventArgs Then
            oObjectChangedEventArgs = e
            If String.IsNullOrEmpty(oObjectChangedEventArgs.PropertyName) Then
                Return
            End If
        End If

        If Me.View Is Nothing Then
            Return
        End If

        If Me.View.CurrentObject Is Nothing Then
            Return
        End If


        If View.ObjectTypeInfo.Implements(Of Interfaces.IWorkflow)() Then
            _mWorkflowObject = Me.View.CurrentObject
            If _mWorkflowObject IsNot Nothing Then
                SetupDefaultWorkflowValues()
                If _mCurrentWorkflow IsNot _mWorkflowObject.WorkflowStatus Then
                    ResetLookupTags()
                    _mCurrentWorkflow = _mWorkflowObject.WorkflowStatus
                End If
            End If
        End If

        SetupDetailPropertyEditorsWithViewOverrides()

        SetupFormControls()

        ApplyRulesToControls()
    End Sub

    Private _mWorkflowEnabled As Boolean = True
    Public Property WorkflowEnabled() As Boolean
        Get
            Return _mWorkflowEnabled
        End Get
        Set(ByVal Value As Boolean)
            _mWorkflowEnabled = Value
            InitWorkflow(Me, New EventArgs)
        End Set
    End Property

    Public Sub SetupDetailPropertyEditorsWithViewOverrides
        Dim obj As Object
        Dim strNewId As String
        For Each dpeDetailPropertyEditor As DetailPropertyEditor In ThisDetailView.GetItems(Of DetailPropertyEditor)
            obj = dpeDetailPropertyEditor.MemberInfo.GetValue(View.CurrentObject)
            If obj IsNot Nothing
                strNewId = GetViewIdForType(obj, dpeDetailPropertyEditor.MemberInfo.MemberType)
                If strNewId > String.Empty
                    If Application.Model.Views.FirstOrDefault(Function (m) m.Id = strNewId) IsNot Nothing
                        If dpeDetailPropertyEditor.DetailView Is Nothing OrElse dpeDetailPropertyEditor.DetailView.Id <> strNewId Then
                            dpeDetailPropertyEditor.Frame.SetView(Application.CreateDetailView(ObjectSpace, strNewId, False, obj))
                            CType(CType(dpeDetailPropertyEditor.Frame, NestedFrame).Template, ISupportActionsToolbarVisibility).SetVisible(False)
                            dpeDetailPropertyEditor.Frame.View.Refresh()
                        End If
                    End If
                End If
                
            End If
            
        Next
    End Sub

    Public Function GetViewIdForType(ByVal ObjectReference As Object, ByVal MemberType As Type) As String
        Dim xpoRule As ISSBaseBusinessRules
        Dim lstFoundConditionlView As New List(Of ISSBaseConditionalView)
        xpoRule = ObjectSpace.FindObject(Of ISSBaseBusinessRules)(New BinaryOperator("SavedType", MemberType.FullName))
        If xpoRule IsNot Nothing
            If ObjectReference IsNot Nothing
                For Each xpoConditions In xpoRule.ISSBaseConditionalViews
                    If xpoConditions.IsValidObject(ObjectReference)
                        lstFoundConditionlView.Add(xpoConditions)
                    End If
                Next
            End If
            
            If lstFoundConditionlView.Count > 1 Then
                Throw New Exception("Multiple conditional views found for single object!")
            ElseIf lstFoundConditionlView.Count = 1 AndAlso lstFoundConditionlView(0).ViewId > String.Empty
                Return lstFoundConditionlView(0).ViewId
            ElseIf xpoRule.DefaultViewIdOverride > String.Empty
                Return xpoRule.DefaultViewIdOverride
            End If
        End If
        Return String.Empty
    End Function

    Private Sub SetupDefaultWorkflowValues()
        If Me.View.CurrentObject Is Nothing Then
            Return
        End If

        Dim dtiType As TypeInfo = XafTypesInfo.Instance.FindTypeInfo(Me.View.CurrentObject.GetType)

        If dtiType Is Nothing Then
            Return
        End If

        Dim dtiChildType As TypeInfo
        Dim strParentProperty As String = String.Empty
        Dim objTemp As Object = Nothing
        Dim dvoDetailView As DetailView = View
        Dim dviDetailViewItem As PropertyEditor

        If dtiType.Implements(Of Interfaces.IWorkflow)() Then
            Helpers.WorkflowHelper.SetWorkflowStep(View.CurrentObject)
        End If
        For Each dviDetailViewItem In dvoDetailView.GetItems(Of PropertyEditor)()
            If Not dviDetailViewItem.MemberInfo.Name.Contains(".") Then
                Continue For
            End If

            strParentProperty = ISS.Base.Helpers.ReflectionHelper.GetParentProperty(dviDetailViewItem.MemberInfo.Name)
            objTemp = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(strParentProperty, Me.View.CurrentObject)
            If objTemp IsNot Nothing Then
                dtiChildType = XafTypesInfo.Instance.FindTypeInfo(objTemp.GetType)
                If dtiChildType.Implements(Of Interfaces.IWorkflow)() Then
                    Helpers.WorkflowHelper.SetWorkflowStep(objTemp)
                End If
            End If
            While strParentProperty.Contains(".")
                strParentProperty = ISS.Base.Helpers.ReflectionHelper.GetParentProperty(strParentProperty)
                objTemp = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(strParentProperty, Me.View.CurrentObject)
                If objTemp Is Nothing Then
                    Continue While
                End If

                dtiChildType = XafTypesInfo.Instance.FindTypeInfo(objTemp.GetType)
                If dtiChildType.Implements(Of Interfaces.IWorkflow)() Then
                    Helpers.WorkflowHelper.SetWorkflowStep(objTemp)
                End If
            End While
        Next
    End Sub
    Private Sub SetupFormControls()
        Dim swcControl As System.Windows.Forms.Control
        Dim objDetailView As DetailView = Me.View
        Dim dlcControl As DevExpress.XtraLayout.LayoutControl = objDetailView.Control
        If dlcControl Is Nothing Then
            Return
        End If

        dlcControl.BeginUpdate()
        For Each objDetailViewItem As ViewItem In CType(View, DetailView).Items
            If TypeOf objDetailViewItem Is ListPropertyEditor Then
                WorkflowWinHelper.SetupWorkflowListView(objDetailViewItem, Me.View.CurrentObject, objDetailViewItem.Id, Me.View.ObjectTypeInfo.Type, Application, Not WorkflowEnabled)
            Else
                If TypeOf objDetailViewItem Is DetailPropertyEditor Then
                    Continue For
                End If
                If Me.View.ObjectTypeInfo.Type.FullName.StartsWith("DevExpress.ExpressApp.Security") Then
                    Continue For
                End If
                swcControl = objDetailViewItem.Control
                If swcControl Is Nothing Then
                    Continue For
                End If
                'objDetailViewItem.Refresh()
                WorkflowWinHelper.SetupWorkflowControl(swcControl, Me.View.CurrentObject, objDetailViewItem.Id, Me.View.ObjectTypeInfo.Type, Application, Not WorkflowEnabled)
            End If
        Next
        dlcControl.EndUpdate()
    End Sub
    Private Sub ResetLookupTags()
        For Each objLookupEditor As DevExpress.ExpressApp.Win.Editors.LookupPropertyEditor In CType(View, DetailView).GetItems(Of DevExpress.ExpressApp.Win.Editors.LookupPropertyEditor)()
            If objLookupEditor.Control IsNot Nothing Then
                objLookupEditor.Control.Tag = Nothing
            End If
        Next
    End Sub
    Private Sub ApplyRulesToControls()
        Dim oObject As Object = Me.View.CurrentObject

        Dim vpaRequiredMethodAttribute As ISS.Base.Attributes.View.Properties.IsRequiredMethodAttribute
        Dim vpaEnabledMethodAttribute As ISS.Base.Attributes.View.Properties.IsEnabledMethodAttribute
        Dim vpaRequiredPropertyAttribute As ISS.Base.Attributes.View.Properties.IsRequiredPropertyAttribute
        Dim vpaEnabledPropertyAttribute As ISS.Base.Attributes.View.Properties.IsEnabledPropertyAttribute
        Dim oCurrentObject As Object = View.CurrentObject

        Dim blnPropertyEnabled As Boolean = True
        Dim blnPropertyRequired As Boolean = False
        Dim oPropertyValue As Object
        Try
            For Each objDetailViewItem As PropertyEditor In CType(View, DetailView).GetItems(Of PropertyEditor)()
                blnPropertyEnabled = True
                blnPropertyRequired = False
                vpaRequiredMethodAttribute = objDetailViewItem.MemberInfo.FindAttribute(Of ISS.Base.Attributes.View.Properties.IsRequiredMethodAttribute)()
                If vpaRequiredMethodAttribute IsNot Nothing AndAlso vpaRequiredMethodAttribute.MethodName > String.Empty Then
                    If oCurrentObject IsNot Nothing Then
                        If oCurrentObject.GetType.GetMethod(vpaRequiredMethodAttribute.MethodName) IsNot Nothing Then
                            blnPropertyRequired = oCurrentObject.GetType.GetMethod(vpaRequiredMethodAttribute.MethodName).Invoke(oCurrentObject, Nothing)
                            If objDetailViewItem.MemberInfo.IsList = False Then
                                ISS.Base.Win.WinLayoutHelper.SetPropertyEditorRequired(objDetailViewItem.Control, blnPropertyRequired)
                            End If
                        End If
                    End If
                End If
                vpaRequiredPropertyAttribute = objDetailViewItem.MemberInfo.FindAttribute(Of ISS.Base.Attributes.View.Properties.IsRequiredPropertyAttribute)()
                If vpaRequiredPropertyAttribute IsNot Nothing AndAlso vpaRequiredPropertyAttribute.PropertyName > String.Empty Then
                    If oCurrentObject IsNot Nothing Then
                        oPropertyValue = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(vpaRequiredPropertyAttribute.PropertyName, oCurrentObject)
                        If oPropertyValue IsNot Nothing Then
                            If TypeOf oPropertyValue Is Boolean Then
                                ISS.Base.Win.WinLayoutHelper.SetPropertyEditorRequired(objDetailViewItem.Control, oPropertyValue)
                            Else
                                ISS.Base.Win.WinLayoutHelper.SetPropertyEditorRequired(objDetailViewItem.Control, True)
                            End If
                        Else
                            ISS.Base.Win.WinLayoutHelper.SetPropertyEditorRequired(objDetailViewItem.Control, False)
                        End If
                    End If
                End If

                vpaEnabledMethodAttribute = objDetailViewItem.MemberInfo.FindAttribute(Of ISS.Base.Attributes.View.Properties.IsEnabledMethodAttribute)()
                If vpaEnabledMethodAttribute IsNot Nothing AndAlso vpaEnabledMethodAttribute.MethodName > String.Empty Then
                    If oCurrentObject IsNot Nothing Then
                        If oCurrentObject.GetType.GetMethod(vpaEnabledMethodAttribute.MethodName) IsNot Nothing Then
                            blnPropertyEnabled = oCurrentObject.GetType.GetMethod(vpaEnabledMethodAttribute.MethodName).Invoke(oCurrentObject, Nothing)
                            If objDetailViewItem.MemberInfo.IsList = True Then
                                ISS.Base.Win.WinLayoutHelper.SetListViewControllersEnabled(objDetailViewItem, blnPropertyEnabled)
                            Else
                                ISS.Base.Win.WinLayoutHelper.SetPropertyEditorEnabled(objDetailViewItem.Control, blnPropertyEnabled)
                            End If
                        End If
                    End If
                End If

                vpaEnabledPropertyAttribute = objDetailViewItem.MemberInfo.FindAttribute(Of ISS.Base.Attributes.View.Properties.IsEnabledPropertyAttribute)()
                If vpaEnabledPropertyAttribute IsNot Nothing AndAlso vpaEnabledPropertyAttribute.PropertyName > String.Empty Then
                    If oCurrentObject IsNot Nothing Then
                        oPropertyValue = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(vpaEnabledPropertyAttribute.PropertyName, oCurrentObject)
                        If oPropertyValue IsNot Nothing Then
                            If TypeOf oPropertyValue Is Boolean Then
                                If objDetailViewItem.MemberInfo.IsList = True Then
                                    ISS.Base.Win.WinLayoutHelper.SetListViewControllersEnabled(objDetailViewItem, oPropertyValue)
                                Else
                                    ISS.Base.Win.WinLayoutHelper.SetPropertyEditorEnabled(objDetailViewItem.Control, oPropertyValue)
                                End If
                            Else
                                If objDetailViewItem.MemberInfo.IsList = True Then
                                    ISS.Base.Win.WinLayoutHelper.SetListViewControllersEnabled(objDetailViewItem, True)
                                Else
                                    ISS.Base.Win.WinLayoutHelper.SetPropertyEditorEnabled(objDetailViewItem.Control, True)
                                End If
                            End If
                        Else
                            If objDetailViewItem.MemberInfo.IsList = True Then
                                ISS.Base.Win.WinLayoutHelper.SetListViewControllersEnabled(objDetailViewItem, False)
                            Else
                                ISS.Base.Win.WinLayoutHelper.SetPropertyEditorEnabled(objDetailViewItem.Control, False)
                            End If
                        End If
                    End If
                End If

            Next
        Catch ex As Exception
            Throw New Exception("Error During UI Rule Execution", ex)
        End Try

    End Sub
#End Region


End Class

