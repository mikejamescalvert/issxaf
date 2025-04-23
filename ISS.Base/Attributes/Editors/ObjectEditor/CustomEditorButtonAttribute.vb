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
    ''' Adds a custom button to the ISS property editor which will execute the given method in the controller type passed in.
    ''' </summary>
    ''' <remarks> The controller must exist in the view that contains the editor </remarks>
    <AttributeUsage(AttributeTargets.Property, AllowMultiple:=True)> _
    Public Class CustomEditorButtonAttribute
        Inherits Attribute

#Region "Behaviors"
        Public Sub New(ByVal ControllerFullTypeName As String, ByVal ButtonExecuteMethod As String, Optional ByVal ButtonImageName As String = Nothing, Optional ByVal ToolTipText As String = Nothing)
            _mControllerFullTypeName = ControllerFullTypeName
            _mButtonImageName = ButtonImageName
            _mButtonExecuteMethod = ButtonExecuteMethod
            _mToolTipText = ToolTipText
        End Sub
#End Region

#Region "Non Persistent Properties"
        Private _mButtonExecuteMethod As String
        Private _mButtonImageName As String
        Private _mControllerFullTypeName As String
        Private _mToolTipText As String
        Public ReadOnly Property ButtonExecuteMethod() As String
            Get
                Return _mButtonExecuteMethod
            End Get
        End Property
        Public ReadOnly Property ButtonImageName() As String
            Get
                Return _mButtonImageName
            End Get
        End Property
        Public ReadOnly Property ControllerFullTypeName() As String
            Get
                Return _mControllerFullTypeName
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
