Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Web.Editors.ASPx
Imports System.Web.UI.WebControls
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.Web.Internal
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Web.Editors

Public Class LinkButtonEditor
    Inherits ASPxObjectPropertyEditorBase

    Private _mControl As LabelEditControl

    Private _mLookUpHelper As WebLookupEditorHelper

    Public Shadows ReadOnly Property Control() As LabelEditControl
        Get
            Return _mControl
        End Get
    End Property

    'Protected Overrides Function GetPropertyDisplayValue() As String
    '    Return (_mLookUpHelper.GetDisplayText(MemberInfo.GetValue(CurrentObject), EmptyValue, DisplayFormat))
    'End Function

    Protected Overrides Sub ReadEditModeValueCore()
        If _mControl IsNot Nothing Then
            _mControl.Text = GetPropertyDisplayValue()
        End If

        MyBase.ReadEditModeValueCore()
    End Sub

    Protected Overrides Sub ReadViewModeValueCore()
        If _mControl IsNot Nothing Then
            _mControl.Text = GetPropertyDisplayValue()
        End If

        MyBase.ReadViewModeValueCore()
    End Sub

    Protected Overrides Function CreateEditModeControlCore() As System.Web.UI.WebControls.WebControl
        Return GetControl()
    End Function

    Protected Overrides Function CreateViewModeControlCore() As System.Web.UI.WebControls.WebControl
        Return GetControl()
    End Function
    Protected Overrides Function CanShowLink() As Boolean
        Return False

    End Function

    Public Function GetControl() As WebControl
        _mControl = New LabelEditControl
        _mControl.NavigateURL = NavigateURL
        _mControl.ButtonImageName = ButtonImageName
        Return _mControl
    End Function

    Private _mNavigateURL As String
    Public Property NavigateURL() As String
        Get
            Return _mNavigateURL
        End Get
        Set(ByVal value As String)
            _mNavigateURL = value
            If _mControl IsNot Nothing Then
                _mControl.NavigateURL = value
            End If
        End Set
    End Property

    Private _mButtonImageName As String = "Editor_Edit"
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub

    Protected Overrides Sub SetupControl(ByVal control As System.Web.UI.WebControls.WebControl)
        MyBase.SetupControl(control)

    End Sub

    Public Overrides Sub Setup(ByVal objectSpace As DevExpress.ExpressApp.IObjectSpace, ByVal application As DevExpress.ExpressApp.XafApplication)
        MyBase.Setup(objectSpace, application)
        _mLookUpHelper = New WebLookupEditorHelper(application, objectSpace, DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(ObjectType), Model)
    End Sub

    Public Property ButtonImageName() As String
        Get
            Return _mButtonImageName
        End Get
        Set(ByVal value As String)
            _mButtonImageName = value
            If _mControl IsNot Nothing Then
                _mControl.ButtonImageName = _mButtonImageName
            End If
        End Set
    End Property

    'Protected Overrides Function GetControlValueCore() As Object
    '    Return MemberInfo.GetValue(CurrentObject)

    'End Function

End Class
