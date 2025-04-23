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
Imports DevExpress.XtraEditors.Repository

<DevExpress.ExpressApp.Editors.PropertyEditor(GetType(DateTime), False)>
Public Class FlatDatePropertyEditor
    Inherits DatePropertyEditor
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub


    Protected Overrides Function CreateControlCore() As Object
        Dim objControl = MyBase.CreateControlCore
        SetupRepositoryItem(objControl.Properties)
        Return objControl
    End Function

    Protected Overrides Function CreateRepositoryItem() As DevExpress.XtraEditors.Repository.RepositoryItem
        Dim oProperties As RepositoryItemDateTimeEdit = MyBase.CreateRepositoryItem
        SetupRepositoryItem(oProperties)
        Return oProperties
    End Function

    Protected Overrides Sub SetupRepositoryItem(item As RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        Dim itm As RepositoryItemDateTimeEdit = item
        itm.EditMask = "MMddyy"
        itm.Mask.EditMask = itm.EditMask
        itm.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
        itm.Mask.UseMaskAsDisplayFormat = True

        'itm.Mask.Culture = New Globalization.CultureInfo("en-US")
        'itm.Mask.Culture.DateTimeFormat.DateSeparator = String.Empty

        ''itm.Mask.Culture.NumberFormat.PercentDecimalSeparator = ""
    End Sub


End Class
