<AttributeUsage(AttributeTargets.Class,AllowMultiple:=False)>
Public Class AttachmentFilterAttribute
    Inherits Attribute

    ' Fields...
    Private _mAllowedTypes As String
    Public Property AllowedTypes As String
        Get
            Return _mAllowedTypes
        End Get
        Set(ByVal Value As String)
            _mAllowedTypes = Value
        End Set
    End Property
    
    ''' <summary>
    ''' Defines the allowed file types for a class that inherits from the ISS.Attachments.Attachment object
    ''' </summary>
    ''' <param name="AllowedTypes">Comma delimited list of file extensions such as (jpg,gif)</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal AllowedTypes As String)
        Me.AllowedTypes = AllowedTypes
    End Sub
    Protected Sub New()
        
    End Sub

End Class
