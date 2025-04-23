Imports Microsoft.VisualBasic
Imports System

Partial Public Class ISSAspNetModule
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing AndAlso (Not components Is Nothing) Then
			components.Dispose()
		End If
		MyBase.Dispose(disposing)
	End Sub

#Region "Component Designer generated code"

	''' <summary> 
	''' Required method for Designer support - do not modify 
	''' the contents of this method with the code editor.
	''' </summary>
	Private Sub InitializeComponent()
		'
		'ISSAspNetModule
		'
		Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.ModelDifference))
		Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.BaseObject))
		Me.AdditionalExportedTypes.Add(GetType(DevExpress.Persistent.BaseImpl.ModelDifferenceAspect))
		Me.AdditionalExportedTypes.Add(GetType(DevExpress.Xpo.XPCustomObject))
		Me.AdditionalExportedTypes.Add(GetType(DevExpress.Xpo.XPBaseObject))
		Me.AdditionalExportedTypes.Add(GetType(DevExpress.Xpo.PersistentBase))
		Me.RequiredModuleTypes.Add(GetType(ISS.[Module].ISSModule))
		Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule))
		Me.RequiredModuleTypes.Add(GetType(DevExpress.ExpressApp.Validation.Web.ValidationAspNetModule))

	End Sub

#End Region
End Class