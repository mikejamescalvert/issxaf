Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.ExpressApp
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.Persistent.Validation

' For more information on Controllers and their life cycle, check out the http://documentation.devexpress.com/#Xaf/CustomDocument2621 and http://documentation.devexpress.com/#Xaf/CustomDocument3118 help articles.
Public Class TabStopWindowController
    Inherits DevExpress.ExpressApp.WindowController
    ' Use this to do something when a Controller is instantiated (do not execute heavy operations here!).
    Public Sub New()
        MyBase.New()
        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        'For instance, you can specify activation conditions of a Controller or create its Actions (http://documentation.devexpress.com/#Xaf/CustomDocument2622).
        'TargetWindowType = WindowType.Main;
        'Dim myAction As SimpleAction = New SimpleAction(Me, "MyActionId", DevExpress.Persistent.Base.PredefinedCategory.RecordEdit)
        'Me.TargetWindowType = WindowType.Child
    End Sub

    ' Override to do something before Controllers are activated within the current Frame (their Window property is not yet assigned).
    Protected Overrides Sub OnFrameAssigned()
        MyBase.OnFrameAssigned()
        'For instance, you can access another Controller via the Frame.GetController(Of AnotherControllerType)() method to customize it or subscribe to its events.
    End Sub

    ' Override to do something when a Controller is activated and its Window is assigned.
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        AddHandler Me.Window.TemplateChanged, AddressOf Window_TemplateChanged


        'For instance, you can customize the current Window and its editors (http://documentation.devexpress.com/#Xaf/CustomDocument2729) or manage the Controller's Actions visibility and availability (http://documentation.devexpress.com/#Xaf/CustomDocument2728).
    End Sub

    ' Override to do something when a Controller is deactivated.
    Protected Overrides Sub OnDeactivated()
        ' For instance, you can unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub


Private Sub Window_TemplateChanged(sender As Object, e As EventArgs)
        If Me.Window.Template Is Nothing Then
            Return
        End If
        Dim frm As System.Windows.Forms.Form
        If TypeOf Me.Window.Template Is System.Windows.Forms.Form Then
            frm= Window.Template
            AddHandler frm.Activated, AddressOf Form_Activated
   AddHandler frm.Shown, AddressOf Form_Shown
        End If
 End Sub 


Private Sub Form_Activated(sender As Object, e As EventArgs)
        Dim frm As System.Windows.Forms.Form = sender
        frm.KeyPreview = True
        
 End Sub 

Private Sub Form_Shown(sender As Object, e As EventArgs)
        Dim frm As System.Windows.Forms.Form = sender
        frm.KeyPreview = True
        
 End Sub 


End Class
