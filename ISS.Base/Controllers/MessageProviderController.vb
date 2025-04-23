Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Public Class MessageProviderController
	Inherits DevExpress.ExpressApp.ViewController

	Public Sub New()
		MyBase.New()

		'This call is required by the Component Designer.
		InitializeComponent()
		RegisterActions(components) 

    End Sub

    Private Sub MessageProviderController_ViewControlsCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ViewControlsCreated
        If TypeOf View Is DashboardView Then
            Return
        End If
        If Not Me.View.ObjectTypeInfo.Implements(Of Interfaces.IMessageProvider)() Then
            Return
        End If

        RemoveHandler View.CurrentObjectChanged, AddressOf SetupMessageEvents
        AddHandler View.CurrentObjectChanged, AddressOf SetupMessageEvents
        SetupMessageEvents(Me, Nothing)
    End Sub

    Private Sub SetupMessageEvents(ByVal sender As Object, ByVal e As EventArgs)
        Dim impMessageProvider As Interfaces.IMessageProvider
        If Me.View.CurrentObject Is Nothing Then
            Return
        End If

        impMessageProvider = Me.View.CurrentObject
        AddHandler impMessageProvider.SendMessage, AddressOf HandleMessage
        AddHandler impMessageProvider.SendMessageCollection, AddressOf HandleMessageCollection
    End Sub

    Private Sub HandleMessage(ByVal MessageHeader As String, ByVal Message As String, ByVal MessageType As ISSBaseEndUserMessage.MessageTypes)
        Helpers.MessageHelper.ShowMessage(CType(Me.ObjectSpace, Xpo.XPObjectSpace).Session, MessageHeader, Message, MessageType)
    End Sub

    Private Sub HandleMessageCollection(ByVal MessageHeader As String, ByVal Messages As List(Of String), ByVal MessageType As ISSBaseEndUserMessage.MessageTypes)
        Helpers.MessageHelper.ShowMessage(CType(Me.ObjectSpace, Xpo.XPObjectSpace).Session, MessageHeader, Messages, MessageType)
    End Sub

End Class
