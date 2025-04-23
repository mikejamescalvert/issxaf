Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class MPConnectionController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
        RegisterActions(components)
        Me.TargetObjectType = GetType(MPConnectionInformation)
    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        BindToObject(Me, New EventArgs)
        AddHandler View.CurrentObjectChanged, AddressOf BindToObject
    End Sub

    Public Sub BindToObject(ByVal sender As Object, ByVal e As EventArgs)
        If View.CurrentObject Is Nothing Then
            Me.MPConnectionInformation_Save.Enabled("ObjectAvailable") = False
            Me.MPConnectionInformation_Test.Enabled("ObjectAvailable") = False
            Me.MPConnectionInformation_Save.Enabled("TestExecuted") = False
        Else
            Me.MPConnectionInformation_Save.Enabled("ObjectAvailable") = True
            Me.MPConnectionInformation_Test.Enabled("ObjectAvailable") = True
            AddHandler CType(View.CurrentObject, MPConnectionInformation).Changed, AddressOf UpdateActionState
            UpdateActionState(sender, e)
        End If
        
    End Sub

    Public Sub UpdateActionState(ByVal sender As Object, ByVal e As EventArgs)
        Me.MPConnectionInformation_Save.Enabled("TestExecuted") = False
    End Sub


    Private Sub MPConnectionInformation_Test_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles MPConnectionInformation_Test.Execute
        Try
            CType(Me.View.CurrentObject, MPConnectionInformation).ValidateConnection()
            Me.MPConnectionInformation_Save.Enabled("TestExecuted") = True
        Catch ex As Exception
            Me.MPConnectionInformation_Save.Enabled("TestExecuted") = False
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error Validating Connection")
        End Try

    End Sub

    Private Sub MPConnectionInformation_Save_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles MPConnectionInformation_Save.Execute
        CType(Me.View.CurrentObject, MPConnectionInformation).WriteConnectionToRegistry()
    End Sub

End Class
