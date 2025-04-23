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
Imports System.Windows.Forms

' For more information on Controllers and their life cycle, check out the http://documentation.devexpress.com/#Xaf/CustomDocument2621 and http://documentation.devexpress.com/#Xaf/CustomDocument3118 help articles.
Public Class DetailViewController
    Inherits DevExpress.ExpressApp.ViewController(Of DetailView)
    ' Use this to do something when a Controller is instantiated (do not execute heavy operations here!).
    Public Sub New()
        MyBase.New()
        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

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

    Private _mControls As New Dictionary(Of Windows.Forms.Control, String)

    ' Override to access the controls of a View for which the current Controller is intended.
    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        Dim xlcLayoutControl As DevExpress.ExpressApp.Win.Layout.XafLayoutControl = View.LayoutManager.Container
        
        'xlcLayoutControl.OptionsFocus.EnableAutoTabOrder = False
        _mControls.Clear()
        Dim ctrWindowsControl As Windows.Forms.Control
        Dim imdModelItem As IModelDetailViewItem
        For Each dpePropertyEditor As PropertyEditor In View.Items
            imdModelItem = dpePropertyEditor.Model
            ctrWindowsControl = dpePropertyEditor.Control
            If ctrWindowsControl Is Nothing Then
                Continue For
            End If
            AddHandler ctrWindowsControl.KeyDown, AddressOf Control_KeyDown
            _mControls.Add(ctrWindowsControl, dpePropertyEditor.PropertyName)
        Next
        'ioeOrderedEnum = lstItems.OrderByDescending(Function(wfc) wfc.TabIndex)
        'For intLoop As Integer = 0 To ioeOrderedEnum.Count  - 1
        '    ioeOrderedEnum(intLoop).TabIndex = intLoop
        'Next

        ' For instance, refer to the http://documentation.devexpress.com/Xaf/CustomDocument3165.aspx help article to see how to access grid control properties.
    End Sub

    ' Override to do something when a Controller is deactivated.
    Protected Overrides Sub OnDeactivated()
        ' For instance, you can unsubscribe from previously subscribed events and release other references and resources.
        MyBase.OnDeactivated()
    End Sub

Private Sub Control_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Tab Then
            Stop
        End If
 End Sub 

End Class
