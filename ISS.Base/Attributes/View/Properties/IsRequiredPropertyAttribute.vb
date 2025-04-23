Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Namespace Attributes.View.Properties
    ''' <summary>
    ''' If the property type is a boolean, the boolean value will be the result of the property being required.  Otherwise, if the property is null the editor will not be required, if it is not it will be required.
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    <AttributeUsage(AttributeTargets.Property, AllowMultiple:=False, Inherited:=True)> _
    Public Class IsRequiredPropertyAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mPropertyName As String
        Public ReadOnly Property PropertyName() As String
            Get
                Return _mPropertyName
            End Get
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal PropertyName As String)
            _mPropertyName = PropertyName
        End Sub
#End Region

    End Class
End Namespace
