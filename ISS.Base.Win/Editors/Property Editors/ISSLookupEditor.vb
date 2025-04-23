Imports DevExpress.ExpressApp.Editors

<PropertyEditor(GetType(Object), EditorAliases.LookupPropertyEditor, False)>
Public Class ISSLookupEditor
    Inherits ISSBaseEditor
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub

End Class
