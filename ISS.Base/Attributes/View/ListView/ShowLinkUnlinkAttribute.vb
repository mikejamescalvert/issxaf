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

Namespace Attributes.View.ListView
    ''' <summary>
    ''' Shows or hides the Link Unlink action from a list view
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.All, AllowMultiple:=False, Inherited:=True)> _
    Public Class ShowLinkUnlinkAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mIsLinkUnlinkVisible As Boolean
        Public Property IsLinkUnlinkVisible() As Boolean
            Get
                Return _mIsLinkUnlinkVisible
            End Get
            Set(ByVal value As Boolean)
                If _mIsLinkUnlinkVisible = value Then
                    Return
                End If
                _mIsLinkUnlinkVisible = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal IsLinkUnlinkVisible As Boolean)
            Me.IsLinkUnlinkVisible = IsLinkUnlinkVisible
        End Sub
#End Region

    End Class
End Namespace
