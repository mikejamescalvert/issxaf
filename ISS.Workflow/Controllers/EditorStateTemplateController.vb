Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class EditorStateTemplateController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

    End Sub

    Private Sub btnGenerateTemplates_Execute(ByVal sender As System.Object, ByVal e As DevExpress.ExpressApp.Actions.SimpleActionExecuteEventArgs) Handles btnGenerateTemplates.Execute
        If Not (TypeOf View Is ListView) Then
            Return
        End If

        Dim lstView As ListView = View
        If Not (TypeOf lstView.CollectionSource Is PropertyCollectionSource) Then
            Return
        End If

        Dim pcsPropertyCollectionSource As PropertyCollectionSource = lstView.CollectionSource
        If Not (pcsPropertyCollectionSource.MasterObject IsNot Nothing AndAlso TypeOf pcsPropertyCollectionSource.MasterObject Is ISSBaseUserInterfaceTemplate) Then
            Return
        End If

        Dim uitUserInterfaceTemplate As ISSBaseUserInterfaceTemplate = pcsPropertyCollectionSource.MasterObject
        uitUserInterfaceTemplate.PreloadEditorTemplates()
        'Me.ObjectSpace.CommitChanges()
        'lstView.CollectionSource.Reload()
    End Sub

End Class
