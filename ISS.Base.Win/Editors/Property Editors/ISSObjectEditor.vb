Imports DevExpress.ExpressApp.Editors

<PropertyEditor(GetType(Object), EditorAliases.ObjectPropertyEditor, False)>
Public Class ISSObjectEditor
    Inherits ISSBaseEditor
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub

End Class
