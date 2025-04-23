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
    Public Class ToolTipDisplayPropertyAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mPropertyName As String
        Public Property PropertyName() As String
            Get
                Return _mPropertyName
            End Get
            Set(ByVal value As String)
                If _mPropertyName = value Then
                    Return
                End If
                _mPropertyName = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal PropertyName As String)
            Me.PropertyName = PropertyName
        End Sub
#End Region

    End Class

End Namespace
