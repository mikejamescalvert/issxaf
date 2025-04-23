Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Model
Public Class MyExtendedCriteriaPropertyEditor
    Inherits CriteriaPropertyEditor
    Public Sub New(ByVal objectType As Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)
        
    End Sub


End Class
