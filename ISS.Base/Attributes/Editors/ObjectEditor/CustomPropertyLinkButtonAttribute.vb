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
    ''' Adds a button to the object editor which will display a view for the property arguement passed in.
    ''' </summary>
    ''' <remarks>The property type will determine the view type: XPO will be detail view, Collections will be list view.</remarks>
    <AttributeUsage(AttributeTargets.Property, AllowMultiple:=True)> _
    Public Class CustomPropertyLinkButtonAttribute
        Inherits Attribute

#Region "Behaviors"
        Public Sub New(ByVal PropertyName As String, Optional ByVal ButtonImageName As String = Nothing, Optional ByVal ToolTipText As String = Nothing)
            _mPropertyName = PropertyName
            _mButtonImageName = ButtonImageName
            _mToolTipText = ToolTipText
        End Sub
#End Region

#Region "Non Persistent Properties"
        Private _mButtonImageName As String

        Private _mPropertyName As String

        Private _mToolTipText As String
        Public ReadOnly Property ButtonImageName() As String
            Get
                Return _mButtonImageName
            End Get
        End Property
        Public ReadOnly Property PropertyName() As String
            Get
                Return _mPropertyName
            End Get
        End Property
        Public ReadOnly Property ToolTipText() As String
            Get
                Return _mToolTipText
            End Get
        End Property
#End Region


    End Class
End Namespace
