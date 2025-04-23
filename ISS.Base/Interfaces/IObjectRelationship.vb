Namespace Interfaces
    Public Interface IObjectRelationship
        Sub ParentReferenceSet(ByVal Parent As Object, ByVal IsAggregated As Boolean)
        Sub ParentReferenceCleared(ByVal Parent As Object, ByVal IsAggregated As Boolean)
        Sub ParentReferenceState(ByVal Parent As Object, ByVal IsAggregated As Boolean)
    End Interface
End Namespace
