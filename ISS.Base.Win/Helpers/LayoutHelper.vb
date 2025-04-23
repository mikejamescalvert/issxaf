Public Class LayoutHelper

    Public Shared Function GetLayoutControlItemFromParentLayout(ByVal ControlReference As System.Windows.Forms.Control, ByVal LayoutControl As DevExpress.XtraLayout.LayoutGroup) As DevExpress.XtraLayout.LayoutControlItem
        Dim dlcLayoutControlTempItem As DevExpress.XtraLayout.LayoutControlItem
        If LayoutControl IsNot Nothing Then
            For intLoop As Integer = 0 To LayoutControl.Items.Count - 1
                If TypeOf LayoutControl.Items(intLoop) Is DevExpress.XtraLayout.LayoutControlItem Then
                    dlcLayoutControlTempItem = LayoutControl.Items(intLoop)
                    If dlcLayoutControlTempItem.Control Is ControlReference Then
                        Return dlcLayoutControlTempItem
                    End If
                Else
                    If TypeOf LayoutControl.Items(intLoop) Is DevExpress.XtraLayout.TabbedControlGroup Then
                        dlcLayoutControlTempItem = GetLayoutControlItemFromParentLayout(ControlReference, CType(LayoutControl.Items(intLoop), DevExpress.XtraLayout.TabbedControlGroup))
                    Else
                        dlcLayoutControlTempItem = GetLayoutControlItemFromParentLayout(ControlReference, CType(LayoutControl.Items(intLoop), DevExpress.XtraLayout.LayoutGroup))
                    End If
                    If dlcLayoutControlTempItem IsNot Nothing Then
                        Return dlcLayoutControlTempItem
                    End If
                End If
            Next
        End If
        Return Nothing
    End Function

    Public Shared Function GetLayoutControlItemFromParentLayout(ByVal ControlReference As System.Windows.Forms.Control, ByVal LayoutControl As DevExpress.XtraLayout.TabbedControlGroup) As DevExpress.XtraLayout.LayoutControlItem
        Dim dlcLayoutControlTempItem As DevExpress.XtraLayout.LayoutControlItem
        Dim dlcLayoutControlTempGroup As DevExpress.XtraLayout.LayoutControlGroup
        If LayoutControl IsNot Nothing Then
            For intLoop As Integer = 0 To LayoutControl.TabPages.Count - 1
                dlcLayoutControlTempGroup = LayoutControl.TabPages(intLoop)
                dlcLayoutControlTempItem = GetLayoutControlItemFromParentLayout(ControlReference, dlcLayoutControlTempGroup)
                If dlcLayoutControlTempItem IsNot Nothing Then
                    Return dlcLayoutControlTempItem
                End If
            Next
        End If
        Return Nothing
    End Function

    Public Shared Function GetLayoutControlItemFromParentLayout(ByVal ControlReference As System.Windows.Forms.Control, ByVal LayoutControl As DevExpress.XtraLayout.LayoutControl) As DevExpress.XtraLayout.LayoutControlItem
        Dim dlcLayoutControlTempItem As DevExpress.XtraLayout.LayoutControlItem
        If LayoutControl IsNot Nothing Then
            For intLoop As Integer = 0 To LayoutControl.Items.Count - 1
                If TypeOf LayoutControl.Items(intLoop) Is DevExpress.XtraLayout.LayoutControlItem Then
                    dlcLayoutControlTempItem = LayoutControl.Items(intLoop)
                    If dlcLayoutControlTempItem.Control Is ControlReference Then
                        Return dlcLayoutControlTempItem
                    End If
                Else
                    If TypeOf LayoutControl.Items(intLoop) Is DevExpress.XtraLayout.TabbedControlGroup Then
                        dlcLayoutControlTempItem = GetLayoutControlItemFromParentLayout(ControlReference, CType(LayoutControl.Items(intLoop), DevExpress.XtraLayout.TabbedControlGroup))
                    Else
                        dlcLayoutControlTempItem = GetLayoutControlItemFromParentLayout(ControlReference, CType(LayoutControl.Items(intLoop), DevExpress.XtraLayout.LayoutGroup))
                    End If
                End If

            Next
        End If
        Return Nothing
    End Function

End Class
