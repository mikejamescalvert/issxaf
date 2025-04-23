Imports Microsoft.VisualBasic
Imports System

Partial Public Class SalesPadWindowsFormsApplication
	''' <summary> 
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary> 
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed otherwise, false.</param>
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
		Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
        Me.module2 = New DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule()
		Me.module3 = New Global.ISS.Module.ISSModule()
		Me.module4 = New Global.GPObjectLibrary.Module.SalesPad.Module.Win.SalesPadWindowsFormsModule()
        Me.objectsModule = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
		CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        ' 
		' SalesPadWindowsFormsApplication
		' 
        Me.ApplicationName = "ISS"
        Me.CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema
        Me.Modules.Add(Me.module1)
		Me.Modules.Add(Me.module2)
		Me.Modules.Add(Me.module3)
		Me.Modules.Add(Me.module4)
        Me.Modules.Add(Me.objectsModule)
        Me.UseOldTemplates = False

		CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

	End Sub

#End Region

	Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
    Private module2 As DevExpress.ExpressApp.Win.SystemModule.SystemWindowsFormsModule
	Private module3 As Global.ISS.Module.ISSModule
    Private module4 As Global.GPObjectLibrary.Module.SalesPad.Module.Win.SalesPadWindowsFormsModule
    Private objectsModule As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
End Class
