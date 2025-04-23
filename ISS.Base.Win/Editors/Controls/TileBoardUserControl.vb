Imports DevExpress.XtraEditors
Imports DevExpress.XtraLayout

Public Class TileBoardUserControl


    Private _mGroups As New List(Of String)
    Private _mItems As New List(Of Object)

    Public Sub AddItem(ByVal Item As Object, ByVal Caption As String, ByVal GroupName As String)
        Dim tliItem As LayoutControlItem
        _mItems.Add(Item)
        If _mGroups.Contains(GroupName) = False Then
            _mGroups.Add(GroupName)
            AddGroup(GroupName)
        End If
        tliItem = GetGroupByName(GroupName).AddItem(Caption)
        tliItem.Tag = Item
        tliItem.Text = Caption


    End Sub

    Public Function GetGroupByName(ByVal GroupName As String) As LayoutControlGroup
        Dim obj As Object
        Dim grp As LayoutControlGroup
        For Each obj In Me.LayoutControl1.Items
            grp = TryCast(obj, LayoutControlGroup)
            If grp Is Nothing Then
                Continue For
            End If
            If grp.Text = GroupName Then
                Return grp
            End If
        Next
        Return Nothing
    End Function


    Public Sub AddGroup(ByVal GroupName As String)
        Dim lcgGroup As LayoutControlGroup = Me.LayoutControl1.AddGroup(GroupName)
    End Sub

    Public Sub Clear()
        Me.LayoutControl1.Items.Clear()
    End Sub

End Class