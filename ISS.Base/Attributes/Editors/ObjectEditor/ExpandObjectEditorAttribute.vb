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
    Public Class ExpandObjectEditorAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mEditMode As ExpandObjectEditMode
        Public Property EditMode() As ExpandObjectEditMode
            Get
                Return _mEditMode
            End Get
            Set(ByVal value As ExpandObjectEditMode)
                If _mEditMode = value Then
                    Return
                End If
                _mEditMode = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal EditMode As ExpandObjectEditMode)
            Me.EditMode = EditMode
        End Sub
#End Region

#Region "Enumerations"
        Public Enum ExpandObjectEditMode
            EditOnForm = 0
            EditInNew = 1
        End Enum
#End Region

    End Class
End Namespace
