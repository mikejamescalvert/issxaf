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
    ''' The display messaged passed in will be displayed as the text of the object editor regardless of which object is selected.
    ''' </summary>
    ''' <remarks>The object drop down will still show the correct object's display value.</remarks>
    Public Class ObjectEditorDisplayValueAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mDisplayMessage As String
        Public Property DisplayMessage() As String
            Get
                Return _mDisplayMessage
            End Get
            Set(ByVal value As String)
                If _mDisplayMessage = value Then
                    Return
                End If
                _mDisplayMessage = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal DisplayMessage As String)
            Me.DisplayMessage = DisplayMessage
        End Sub
#End Region

    End Class
End Namespace

