Public Interface ISchemaNamingEngine
    Function GetTableName(ByVal OriginalName As String, ByVal Type As Type) As String
    'Function GetConstraintName(ByVal OriginalName As String) As String
    'Function GetColumnName(ByVal OriginalName As String) As String
    'Function GetIndexName(ByVal OriginalName As String) As String

End Interface
