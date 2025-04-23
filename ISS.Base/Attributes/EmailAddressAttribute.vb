Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.SystemModule

Namespace Attributes
    ''' <summary>
    ''' Indicates that the property is an email address.
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.Property, AllowMultiple:=False, Inherited:=True)> _
    Public Class EmailAddressAttribute
        Inherits Attribute

    End Class
End Namespace