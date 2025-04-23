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
    ''' Determines if a view will open when an object is clicked.
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.All, AllowMultiple:=False, Inherited:=True)> _
    Public Class ObjectDoubleClickActionAttribute
        Inherits Attribute

#Region "Behaviors"
        Public Sub New(ByVal DoubleClickAction As ObjectDoubleClickActions)
            Me.DoubleClickAction = DoubleClickAction
        End Sub
#End Region

#Region "Non Persistent Properties"
        Private _mDoubleClickAction As ObjectDoubleClickActions
        Public Property DoubleClickAction() As ObjectDoubleClickActions
            Get
                Return _mDoubleClickAction
            End Get
            Set(ByVal value As ObjectDoubleClickActions)
                If _mDoubleClickAction = value Then
                    Return
                End If
                _mDoubleClickAction = value
            End Set
        End Property
#End Region

#Region "Enumerations"
        Public Enum ObjectDoubleClickActions
            NoAction = 0
            OpenDetailView = 1
        End Enum
#End Region

    End Class
End Namespace
