Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Win.Editors
<PropertyEditor(GetType(String), False)>
Public Class PhoneNumberEditor
    Inherits StringPropertyEditor
    Public Sub New(ByVal objectType As Type, ByVal info As IModelMemberViewItem)
        MyBase.New(objectType, info)
    End Sub
    Protected Overrides Sub SetupRepositoryItem(ByVal item As RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        Dim TextProperties As RepositoryItemTextEdit = CType(item, RepositoryItemTextEdit)
        With TextProperties
            With .Mask
                .EditMask = "(000) 000-0000"
                .UseMaskAsDisplayFormat = True
                .MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
                .SaveLiteral = True
                .PlaceHolder = " "
            End With
        End With
    End Sub

End Class
