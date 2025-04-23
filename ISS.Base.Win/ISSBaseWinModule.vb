Imports System
Imports System.Reflection
Imports System.Collections.Generic

Imports DevExpress.ExpressApp

Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Win
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.ExpressApp.Model.Core

Public NotInheritable Class ISSBaseWinModule
    Inherits ModuleBase
    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overrides Sub AddGeneratorUpdaters(ByVal updaters As ModelNodesGeneratorUpdaters)
        MyBase.AddGeneratorUpdaters(updaters)
        updaters.Add(New ModelDetailViewItemsNodesGeneratorUpdater)
        ' ... 
    End Sub
    Public Overrides Sub ExtendModelInterfaces(ByVal extenders As ModelInterfaceExtenders)
        MyBase.ExtendModelInterfaces(extenders)
        extenders.Add(Of IModelViewItem, IModelDetailViewItem)()
        extenders.Add(Of IModelApplication, IModelExtension)()
        extenders.Add(Of IModelColumn, IModelColumnExtension)()
        extenders.Add(Of IModelListView, IISSListView)()
    End Sub
    Public Overrides Sub Setup(application As DevExpress.ExpressApp.XafApplication)
        MyBase.Setup(application)


        AddHandler application.CustomProcessShortcut, AddressOf application_CustomerProcessShortcut
        AddHandler application.DetailViewCreated, AddressOf application_OnDetailViewCreated
        AddHandler application.LoggedOn, AddressOf application_LoggedOn

    End Sub

    Private Sub application_CustomerProcessShortcut(sender As Object, e As CustomProcessShortcutEventArgs)
        Dim obsObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace
        Dim imvModelView As IModelView
        Dim idvDetailView As IModelDetailView
        Dim itiTypeInfo As ITypeInfo
        imvModelView = Application.Model.Views.GetNode(e.Shortcut.ViewId)
        If imvModelView IsNot Nothing AndAlso TypeOf imvModelView Is IModelDetailView Then
            idvDetailView = imvModelView
            itiTypeInfo = XafTypesInfo.Instance.FindTypeInfo(idvDetailView.ModelClass.Name)
            If itiTypeInfo IsNot Nothing AndAlso itiTypeInfo.IsPersistent = False Then
                obsObjectSpace = Application.CreateObjectSpace()
                e.View = Application.CreateDetailView(obsObjectSpace, obsObjectSpace.CreateObject(itiTypeInfo.Type))
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub application_OnDetailViewCreated(sender As Object, e As DetailViewCreatedEventArgs)
        If e.View.CurrentObject Is Nothing AndAlso e.View.ObjectTypeInfo IsNot Nothing AndAlso TypeOf e.View Is DetailView AndAlso e.View.ObjectTypeInfo.IsPersistent = False AndAlso e.View.ObjectTypeInfo.Type.IsSubclassOf(GetType(PersistentPermission)) Then
            Dim xafOS As DevExpress.ExpressApp.Xpo.XPObjectSpace = e.View.ObjectSpace
            Dim xpoObject As Object = xafOS.CreateObject(e.View.ObjectTypeInfo.Type)
            e.View.CurrentObject = xpoObject
        End If
    End Sub

    Private Sub application_LoggedOn(sender As Object, e As LogonEventArgs)
        CType(Application, WinApplication).SplashScreen = New CustomSplashScreen


    End Sub



End Class
