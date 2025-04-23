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
    Public Class ObjectClickActionAttribute
        Inherits Attribute

#Region "Behaviors"
        Public Sub New(ByVal ClickAction As ObjectClickActions, ByVal AllowRowLabelDoubleClick As Boolean)
            Me.AllowRowLabelDoubleClick = AllowRowLabelDoubleClick
            Me.ClickAction = ClickAction
        End Sub
#End Region

#Region "Non Persistent Properties"

        Private _mAllowRowLabelDoubleClick As Boolean
        Property AllowRowLabelDoubleClick As Boolean
            Get
                Return _mAllowRowLabelDoubleClick
            End Get
            Set(ByVal Value As Boolean)
                _mAllowRowLabelDoubleClick = Value
            End Set
        End Property
        

        Private _mClickAction As ObjectClickActions
        Public Property ClickAction() As ObjectClickActions
            Get
                Return _mClickAction
            End Get
            Set(ByVal value As ObjectClickActions)
                If _mClickAction = value Then
                    Return
                End If
                _mClickAction = value
            End Set
        End Property
#End Region

#Region "Enumerations"
        Public Enum ObjectClickActions
            NoAction = 0
            OpenDetailView = 1
        End Enum
#End Region

    End Class
End Namespace
