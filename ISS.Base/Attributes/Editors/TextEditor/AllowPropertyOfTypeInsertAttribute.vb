Namespace Attributes.Editors.TextEditor

    ''' <summary>
    ''' Shows a member picker in the context menu of a text editor for a string property and inserts returned value at cursor.
    ''' </summary>
    ''' <remarks>Currently works with regular and large text editors</remarks>
    Public Class AllowPropertyOfTypeInsertAttribute
        Inherits Attribute

        Private _mTargetProperty As String

        Public Function GetTargetPropertyType(ByVal TargetObject As Object) As Type
            If TargetObject Is Nothing Then
                Return Nothing
            End If
            Dim dtiTypeInfo As DevExpress.ExpressApp.DC.ITypeInfo = DevExpress.ExpressApp.XafTypesInfo.Instance.FindTypeInfo(TargetObject.GetType)
            If dtiTypeInfo.FindMember(_mTargetProperty) IsNot Nothing Then
                Return dtiTypeInfo.FindMember(_mTargetProperty).GetValue(TargetObject)
            End If
            Return Nothing
        End Function

        Public Sub New(ByVal TargetPropertyToCollectionTypeFrom As String)
            _mTargetProperty = TargetPropertyToCollectionTypeFrom
        End Sub

    End Class
End Namespace

