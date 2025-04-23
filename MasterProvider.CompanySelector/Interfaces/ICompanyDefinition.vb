Public Interface ICompanyDefinition
    Property Name As String
    Property CompanyId As String
    Property ERPType As ERPTypes
    Property ERPCompanyId As String
End Interface

Public Enum ERPTypes
    DynamicsGP = 1
    DynamicsNAV = 2
End Enum
