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
    ''' Enables the editing of rows in the list views grid, as well as sets the position of a new item row.
    ''' </summary>
    ''' <remarks>Currently the new item row position is only functioning for the windows side.</remarks>
    <AttributeUsage(AttributeTargets.All, AllowMultiple:=False, Inherited:=True)> _
    Public Class EditableInListViewAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mNewItemRowPosition As DevExpress.ExpressApp.NewItemRowPosition
        Public Property NewItemRowPosition() As DevExpress.ExpressApp.NewItemRowPosition
            Get
                Return _mNewItemRowPosition
            End Get
            Set(ByVal value As DevExpress.ExpressApp.NewItemRowPosition)
                If _mNewItemRowPosition = value Then
                    Return
                End If
                _mNewItemRowPosition = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal NewItemRowPosition As DevExpress.ExpressApp.NewItemRowPosition)
            Me.NewItemRowPosition = NewItemRowPosition
        End Sub
        Public Sub New()

        End Sub
#End Region

    End Class
End Namespace
