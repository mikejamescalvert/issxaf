Imports System
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Security
Imports DevExpress.Xpo
Imports ISS.Base.Helpers
Imports DevExpress.ExpressApp.Model


Public Class HyperlinkObjectEditor
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
