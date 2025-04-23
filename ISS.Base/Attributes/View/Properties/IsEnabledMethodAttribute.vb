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
    ''' Executes the method passed into the attribute, and enables/disables the property editor based on the results.
    ''' </summary>
    ''' <remarks>Expects that the method passed in will be a function which returns a boolean value.</remarks>
    <AttributeUsage(AttributeTargets.Property, AllowMultiple:=False, Inherited:=True)> _
    Public Class IsEnabledMethodAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mMethodName As String
        Public ReadOnly Property MethodName() As String
            Get
                Return _mMethodName
            End Get
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal MethodName As String)
            _mMethodName = MethodName
        End Sub
#End Region

    End Class
End Namespace
