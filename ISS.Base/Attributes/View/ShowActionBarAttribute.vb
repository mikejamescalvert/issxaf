Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.SystemModule

Namespace Attributes.View
    ''' <summary>
    ''' Enables and disables the action bar of the property or class.
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.All, AllowMultiple:=False, Inherited:=True)> _
    Public Class ShowActionBarAttribute
        Inherits Attribute
#Region "Non Persistent Properties"
        Private _mIsVisible As Boolean
        Public Property IsVisible() As Boolean
            Get
                Return _mIsVisible
            End Get
            Set(ByVal value As Boolean)
                If _mIsVisible = value Then
                    Return
                End If
                _mIsVisible = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal IsVisible As Boolean)
            Me.IsVisible = IsVisible
        End Sub
#End Region

    End Class
End Namespace
