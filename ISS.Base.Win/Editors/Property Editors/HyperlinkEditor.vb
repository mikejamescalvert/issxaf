Imports System
Imports System.Drawing
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Core
Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Utils

Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model

<DevExpress.ExpressApp.Editors.PropertyEditor(GetType(String), False)>
Public Class HyperlinkEditor
    Inherits DXPropertyEditor
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub


    Protected Overrides Function CreateControlCore() As Object
        Dim oHyperLinkEdit As New DevExpress.XtraEditors.HyperLinkEdit
        Configure(oHyperLinkEdit.Properties)
        Return oHyperLinkEdit
    End Function

    Protected Overrides Function CreateRepositoryItem() As DevExpress.XtraEditors.Repository.RepositoryItem
        Dim oProperties As New DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit
        Configure(oProperties)
        Return oProperties
    End Function

    Private Sub Configure(ByVal RepositoryItem As DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit)
        RepositoryItem.SingleClick = True
        RepositoryItem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
    End Sub

End Class
