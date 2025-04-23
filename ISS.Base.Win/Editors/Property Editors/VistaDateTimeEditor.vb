Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors.Controls
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
Imports DevExpress.ExpressApp.Model

<PropertyEditor(GetType(System.DateTime), False)> _
Public Class VistaDateTimeEditor
    Inherits DatePropertyEditor

    Public Sub New(ByVal objectType As Type, ByVal model As IModelMemberViewItem)
        MyBase.New(objectType, model)
        
    End Sub

    Protected Overrides Sub SetupRepositoryItem(ByVal item As DevExpress.XtraEditors.Repository.RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        CType(item, RepositoryItemDateTimeEdit).VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True
        CType(item, RepositoryItemDateTimeEdit).VistaEditTime = DevExpress.Utils.DefaultBoolean.True
        CType(item, RepositoryItemDateTimeEdit).Mask.EditMask = "F"
    End Sub

End Class
