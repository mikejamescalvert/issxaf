''' <summary>
''' Attribute which flags a persistent class to update the database schema if needed
''' </summary>
''' <remarks>All classes within the application database automatically do this</remarks>
Public Class AllowDatabaseUpdateInMasterProviderAttribute
    Inherits Attribute

End Class
