Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports ISS.Base.Attributes

Public Class VisibleInReportsOnlyController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()
        Me.TargetViewType = ViewType.ListView
    End Sub

    Public ReadOnly Property ListView As ListView
        Get
            Return View
        End Get
    End Property
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        'TODO: Set visible in detailview/listview off by default
        Dim listEditor As ColumnsListEditor = TryCast(ListView.Editor, ColumnsListEditor)
        Dim vslVisibleInReportsOnly As VisibleInReportsOnlyAttribute
        Dim imiMemberInfo As DC.IMemberInfo
        If listEditor IsNot Nothing Then
            For Each column As ColumnWrapper In listEditor.Columns
                If column.PropertyName = String.Empty Then
                    Continue For
                End If
                imiMemberInfo = Me.View.ObjectTypeInfo.FindMember(column.PropertyName)
                If imiMemberInfo Is Nothing Then
                    Continue For
                End If
                vslVisibleInReportsOnly = imiMemberInfo.FindAttribute(Of VisibleInReportsOnlyAttribute)()
                If vslVisibleInReportsOnly IsNot Nothing Then
                    column.ShowInCustomizationForm = False
                    column.VisibleIndex = -1
                End If
            Next column
        End If
    End Sub

End Class
