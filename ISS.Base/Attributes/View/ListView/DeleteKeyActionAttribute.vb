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
    ''' This adds the delete key functionality to the grid of a list view.  You can choose to ignore it (default action) or delete the selected objects.
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.All, AllowMultiple:=False, Inherited:=True)> _
    Public Class DeleteKeyActionAttribute
        Inherits Attribute

#Region "Behaviors"
        Public Sub New(ByVal DeleteKeyAction As DeleteKeyActions)
            Me.DeleteKeyAction = DeleteKeyAction
        End Sub
#End Region

#Region "Non Persistent Properties"
        Private _mDeleteKeyAction As DeleteKeyActions
        Public Property DeleteKeyAction() As DeleteKeyActions
            Get
                Return _mDeleteKeyAction
            End Get
            Set(ByVal value As DeleteKeyActions)
                If _mDeleteKeyAction = value Then
                    Return
                End If
                _mDeleteKeyAction = value
            End Set
        End Property
#End Region

#Region "Enumerations"
        Public Enum DeleteKeyActions
            NoAction = 0
            DeleteObjects = 1
        End Enum
#End Region

    End Class
End Namespace
