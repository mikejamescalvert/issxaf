Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp.Win.Core
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Model
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraLayout
Imports System.Drawing

<PropertyEditor(GetType(Object), False)> _
Public Class ButtonStateEditor
    Inherits PropertyEditor


    Private _mFlowControl As ISSFlowControl
    Private _mStateButtonList As New List(Of CheckButton)
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub

    Protected Overrides Function CreateControlCore() As Object
        If _mFlowControl Is Nothing Then
            _mFlowControl = New ISSFlowControl

        End If
        PopulatePanel()
        Return _mFlowControl
    End Function

    Public Sub SetupButtonDisplay(ByVal Model As IDetailViewItem)
        For Each btn As CheckButton In _mStateButtonList
            WinLayoutHelper.SetupDevExpressControlWithDetailViewItem(btn, Model)
        Next
    End Sub

    Public Sub PopulatePanel()
        If _mFlowControl Is Nothing Then
            Return
        End If

        _mProcessCheckChange = False

        Dim btnButton As CheckButton
        Dim iList As IList = Nothing
        Dim strDisplayValue As String = String.Empty
        Dim oDisplayObject As Object
        Dim szoSize As System.Drawing.Size = Nothing
        Dim atrDataSourceProperty As DevExpress.Persistent.Base.DataSourcePropertyAttribute = Me.MemberInfo.FindAttribute(Of DevExpress.Persistent.Base.DataSourcePropertyAttribute)()
        Dim blnFoundNewButton As Boolean = False
        If atrDataSourceProperty IsNot Nothing Then
            iList = ISS.Base.Helpers.ReflectionHelper.GetObjectFromPropertyName(atrDataSourceProperty.DataSourceProperty, Me.CurrentObject)
        Else
            If Me.MemberInfo.MemberType.BaseType Is GetType([Enum]) Then
                iList = New List(Of Object)
                For Each oValue As Object In [Enum].GetValues(Me.MemberInfo.MemberType)
                    iList.Add(oValue)
                Next
            Else
                iList = Me.View.ObjectSpace.CreateCollection(Me.MemberInfo.MemberType)
            End If
        End If
        If iList Is Nothing Then
            Return
        End If
        _mFlowControl.BeginUpdate()
        For intLoop As Integer = _mFlowControl.Panel.Controls.Count - 1 To 0 Step -1

            If iList.Contains(_mFlowControl.Panel.Controls(intLoop).Tag) = False Then
                _mFlowControl.Panel.Controls(intLoop).Visible = False
                'RemoveHandler CType(_mFlowControl.Panel.Controls(intLoop), CheckButton).CheckedChanged, AddressOf ButtonPressed
                '_mFlowControl.Panel.Controls.RemoveAt(intLoop)
            Else
                _mFlowControl.Panel.Controls(intLoop).Visible = True
            End If
        Next

        For Each oItem As Object In iList
            btnButton = _mFlowControl.Panel.GetControlForDataItem(oItem)
            If btnButton Is Nothing Then
                strDisplayValue = String.Empty
                If Me.MemberInfo.MemberTypeInfo.DefaultMember IsNot Nothing Then
                    oDisplayObject = Me.MemberInfo.MemberTypeInfo.DefaultMember.GetValue(oItem)
                    If oDisplayObject IsNot Nothing Then
                        strDisplayValue = oDisplayObject.ToString
                    End If
                End If

                If strDisplayValue = String.Empty Then
                    strDisplayValue = oItem.ToString
                End If
                btnButton = New CheckButton
                btnButton.Text = DevExpress.ExpressApp.Utils.CaptionHelper.ConvertCompoundName(strDisplayValue)
                btnButton.Tag = oItem
                btnButton.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                AddHandler btnButton.CheckedChanged, AddressOf ButtonPressed
                _mStateButtonList.Add(btnButton)
                _mFlowControl.Panel.Controls.Add(btnButton)
                WinLayoutHelper.SetupDevExpressControlWithDetailViewItem(btnButton, Me.Model)
                blnFoundNewButton = True
            End If
            btnButton.Checked = IsButtonChecked(btnButton)
            szoSize = btnButton.Size
        Next
        If blnFoundNewButton = True Then
            _mFlowControl.Panel.MinimumSize = New Size(szoSize.Width + 35, szoSize.Height)
            _mFlowControl.Panel.Size = New Size(szoSize.Width + 35, 0)
            UpdateButtonEnabled(Not Me.MemberInfo.IsReadOnly)

        End If

        _mProcessCheckChange = True
        _mFlowControl.EndUpdate()
    End Sub

    Private _mProcessCheckChange As Boolean = True
    Public Sub ButtonPressed(ByVal sender As Object, ByVal e As EventArgs)
        If _mProcessCheckChange = False Then
            Return
        End If
        Dim btnButton As CheckButton = sender
        If btnButton.Checked = True Then
            Me.MemberInfo.SetValue(View.CurrentObject, btnButton.Tag)
        Else
            Me.MemberInfo.SetValue(View.CurrentObject, Nothing)
        End If
        WinLayoutHelper.SetupDevExpressControlWithDetailViewItem(btnButton, Me.Model)
        UpdateButtonValues()
        '_mFlowControl.Refresh()
    End Sub

    Public Sub UpdateButtonEnabled(ByVal IsEnabled As Boolean)
        For Each btnButton As CheckButton In _mStateButtonList
            btnButton.Enabled = IsEnabled
        Next
    End Sub

    Public Function IsButtonChecked(ByVal Button As CheckButton) As Boolean
        Dim objValue As Object = Me.MemberInfo.GetValue(View.CurrentObject)
        If Me.MemberInfo.MemberType.IsEnum = True Then
            If objValue <> Button.Tag Then
                Return False
            Else
                Return True
            End If
        Else
            If objValue IsNot Button.Tag Then
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Public Sub UpdateButtonValues()
        _mProcessCheckChange = False
        Dim objValue As Object = Me.MemberInfo.GetValue(View.CurrentObject)
        For Each btnButton As CheckButton In _mStateButtonList
            btnButton.Checked = IsButtonChecked(btnButton)
            WinLayoutHelper.SetupDevExpressControlWithDetailViewItem(btnButton, Model)
        Next
        
        _mProcessCheckChange = True
    End Sub

    Protected Overrides Function GetControlValueCore() As Object
        For Each btnButton As CheckButton In _mStateButtonList
            If btnButton.Checked = True Then
                Return btnButton.Tag
            End If
        Next
        Return Nothing
    End Function


    Public Overrides Sub Refresh()
        MyBase.Refresh()
        PopulatePanel()

    End Sub

    Protected Overrides Sub ReadValueCore()
        'PopulatePanel()
        '_mFlowControl.Refresh()
    End Sub


End Class
