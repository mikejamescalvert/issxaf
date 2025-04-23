Public Class XmlUserFilter
    Public Name As String
    Public ShowGroupPanel As Boolean
    Public CreatedByUserID As Guid
    Public Description As String
    Public IsPublic As Boolean
    Public Layout As String
    Public SavedObjectTypeName As String
    Public Criterion As String
    Public ColumnInfos As New List(Of XmlUserFilterColumnInfo)
    
End Class
