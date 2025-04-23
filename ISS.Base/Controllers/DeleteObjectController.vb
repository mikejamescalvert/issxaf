Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.SystemModule

Public Class DeleteObjectController
    Inherits DevExpress.ExpressApp.ViewController

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub

    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        'Change delete Objects Context
        UpdateDeleteMessage()
        AddHandler View.SelectionChanged, AddressOf UpdateDeleteMessage
    End Sub

    Public Sub UpdateDeleteMessage()
        Dim dvcDeleteViewController As DeleteObjectsViewController = Frame.GetController(Of DeleteObjectsViewController)()
        Dim strName As String
        If dvcDeleteViewController IsNot Nothing Then
            If TypeOf View Is DetailView OrElse View.SelectedObjects.Count = 1 Then
                dvcDeleteViewController.DeleteAction.ConfirmationMessage = String.Format("Are you sure you want to delete this {0}?", View.ObjectTypeInfo.Name)
            Else
                strName = "Objects"
                If View.ObjectTypeInfo IsNot Nothing Then
                    strName = View.ObjectTypeInfo.Name
                End If
                dvcDeleteViewController.DeleteAction.ConfirmationMessage = String.Format("Are you sure you want to delete these {0} {1}?", View.SelectedObjects.Count, strName)
            End If
        End If
    End Sub

End Class
