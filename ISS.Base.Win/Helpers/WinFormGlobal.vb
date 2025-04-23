Imports System.Drawing
Imports DevExpress.ExpressApp.Model

Public Class WinFormGlobal

    Public Shared Sub SetButtonDefaults(ByRef Button As DevExpress.XtraEditors.SimpleButton)
        Button.StyleController = Nothing
        Button.LookAndFeel.UseDefaultLookAndFeel = False
        Button.LookAndFeel.SetUltraFlatStyle()
        Button.Appearance.BackColor = Color.Transparent
        Button.Appearance.BackColor2 = Color.Transparent
        Button.Appearance.BorderColor = Color.Transparent
        Button.Appearance.Options.UseBackColor = True
        Button.Appearance.Options.UseBorderColor = True
        Button.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
        Button.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
    End Sub
    Public Shared Sub SetAdminButtonDefaults(ByRef Button As DevExpress.XtraEditors.SimpleButton)
        Button.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Button.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Button.MaximumSize = New System.Drawing.Size(75, 75)
        Button.MinimumSize = New System.Drawing.Size(75, 75)
    End Sub
    Public Shared Function GetSimpleButton(ByVal ButtonText As String, ByVal IsAdminButton As Boolean) As DevExpress.XtraEditors.SimpleButton
        Dim objButton As DevExpress.XtraEditors.SimpleButton = Nothing
        Try
            objButton = New DevExpress.XtraEditors.SimpleButton
            objButton.Text = ButtonText
            If IsAdminButton = False Then
                SetButtonDefaults(objButton)
            Else
                SetAdminButtonDefaults(objButton)
            End If
        Catch ex As Exception
        End Try
        Return objButton
    End Function
    Public Shared Function GetCustomHotTrackButton(ByVal ButtonText As String, ByVal IsAdminButton As Boolean) As ISS.Base.Win.CustomHotTrackButton
        Dim objButton As ISS.Base.Win.CustomHotTrackButton = Nothing
        Try
            objButton = New ISS.Base.Win.CustomHotTrackButton
            objButton.Text = ButtonText
            If IsAdminButton = False Then
                SetButtonDefaults(objButton)
            Else
                SetAdminButtonDefaults(objButton)
            End If
        Catch ex As Exception
        End Try
        Return objButton
    End Function
    Public Shared Function GetSimpleLayoutGroup(ByVal DisplayName As String, ByVal ParentControl As DevExpress.XtraLayout.LayoutControl, ByVal ButtonPadding As Integer) As DevExpress.XtraLayout.LayoutControlGroup
        Dim objGroup As DevExpress.XtraLayout.LayoutControlGroup = Nothing
        Try
            objGroup = ParentControl.AddGroup(DisplayName)
            objGroup.TextVisible = False
            objGroup.GroupBordersVisible = False
            objGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(ButtonPadding, ButtonPadding, ButtonPadding, ButtonPadding)
        Catch ex As Exception
        End Try
        Return objGroup
    End Function
    Public Shared Function GetSimpleLayoutGroup(ByVal DisplayName As String, ByVal ParentControlGroup As DevExpress.XtraLayout.LayoutControlGroup, ByVal ButtonPadding As Integer) As DevExpress.XtraLayout.LayoutControlGroup
        Dim objGroup As DevExpress.XtraLayout.LayoutControlGroup = Nothing
        Try
            objGroup = ParentControlGroup.AddGroup(DisplayName)
            objGroup.TextVisible = False
            objGroup.GroupBordersVisible = False
            objGroup.Padding = New DevExpress.XtraLayout.Utils.Padding(ButtonPadding, ButtonPadding, ButtonPadding, ButtonPadding)
            objGroup.ContentImageAlignment = ContentAlignment.MiddleCenter
        Catch ex As Exception
        End Try
        Return objGroup
    End Function
    Public Shared Function GetSimpleLayoutControlItem(ByVal Control As System.Windows.Forms.Control, ByVal Group As DevExpress.XtraLayout.LayoutControlGroup) As DevExpress.XtraLayout.LayoutControlItem
        Dim objControlItem As DevExpress.XtraLayout.LayoutControlItem
        Try
            objControlItem = Group.AddItem
            objControlItem.Control = Control
            objControlItem.ControlAlignment = ContentAlignment.MiddleCenter
            objControlItem.AllowHotTrack = False
            objControlItem.TextVisible = False
            Return objControlItem
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Shared Function HasViewPermission(ByVal ModelView As IModelView) As Boolean
        Dim sytType As System.Type = Nothing
        Dim objAccess As DevExpress.ExpressApp.Security.ObjectAccessPermission

        If TypeOf ModelView Is IModelListView Then
            sytType = CType(ModelView, IModelListView).ModelClass.TypeInfo.Type
        ElseIf TypeOf ModelView Is IModelDetailView Then
            sytType = CType(ModelView, IModelDetailView).ModelClass.TypeInfo.Type
        End If
        objAccess = New DevExpress.ExpressApp.Security.ObjectAccessPermission(sytType, DevExpress.ExpressApp.Security.ObjectAccess.Navigate, DevExpress.ExpressApp.Security.ObjectAccessModifier.Allow)

        Return DevExpress.ExpressApp.SecuritySystem.IsGranted(objAccess)
    End Function


End Class
