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
Public Class TabStopViewController
    Inherits DevExpress.ExpressApp.ViewController
    ' Use this to do something when a Controller is instantiated (do not execute heavy operations here!).
    Public Sub New()
        MyBase.New()
        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)
        Me.TargetViewType = ViewType.DetailView
        'For instance, you can specify activation conditions of a Controller or create its Actions (http://documentation.devexpress.com/#Xaf/CustomDocument2622).
        'TargetObjectType = typeof(DomainObject1)
        'TargetViewType = ViewType.DetailView
        'TargetViewId = "DomainObject1_DetailView"
        'TargetViewNesting = Nesting.Root
        'Dim myAction As SimpleAction = New SimpleAction(Me, "MyActionId", DevExpress.Persistent.Base.PredefinedCategory.RecordEdit)
    End Sub

    ' Override to do something before Controllers are activated within the current Frame (their View property is not yet assigned).
    Protected Overrides Sub OnFrameAssigned()
        MyBase.OnFrameAssigned()
        'For instance, you can access another Controller via the Frame.GetController(Of AnotherControllerType)() method to customize it or subscribe to its events.
    End Sub

    ' Override to do something when a Controller is activated and its View is assigned.
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        'For instance, you can customize the current View and its editors (http://documentation.devexpress.com/#Xaf/CustomDocument2729) or manage the Controller's Actions visibility and availability (http://documentation.devexpress.com/#Xaf/CustomDocument2728).
    End Sub

    Public ReadOnly Property DetailView As DetailView
        Get
            return TryCast(View,DetailView)
        End Get
    End Property

    ' Override to access the controls of a View for which the current Controller is intended.
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        Dim ctrControl As System.Windows.Forms.Control
        For Each dpeEditor As PropertyEditor In DetailView.GetItems(Of PropertyEditor)
            ctrControl = TryCast(dpeEditor.Control,System.Windows.Forms.Control)
            If (dpeEditor.MemberInfo.IsReadOnly = True OrElse dpeEditor.AllowEdit = False) AndAlso ctrControl IsNot Nothing Then
                ctrControl.TabStop = False
            End If
        Next

        ' For instance, refer to the http://documentation.devexpress.com/Xaf/CustomDocument3165.aspx help article to see how to access grid control properties.
    End Sub

    ' Override to do something when a Controller is deactivated.
    Protected Overrides Sub OnDeactivated()
        ' For instance, you can unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

Private Sub Window_Hit_Execute( sender As Object,  e As SimpleActionExecuteEventArgs) 

End Sub
End Class
