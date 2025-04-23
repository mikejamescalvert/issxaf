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

Namespace Attributes.ObjectEditor
    ''' <summary>
    ''' This attribute will determine if the object editor will manipulate a detail view on the current form, or create a new detail view.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ToolTipTextAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mToolTipText As String
        Public Property ToolTipText() As String
            Get
                Return _mToolTipText
            End Get
            Set(ByVal value As String)
                If _mToolTipText = value Then
                    Return
                End If
                _mToolTipText = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal ToolTipText As String)
            Me.ToolTipText = ToolTipText
        End Sub
#End Region

    End Class

End Namespace
