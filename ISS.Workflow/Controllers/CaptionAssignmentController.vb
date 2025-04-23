Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp.Model

Public Class CaptionAssignmentController
    Inherits DevExpress.ExpressApp.ViewController

    Public Shared CaptionsLoaded As Boolean = False


    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()
        RegisterActions(components)

    End Sub

    Protected Overrides Sub OnViewControlsCreated()
        MyBase.OnViewControlsCreated()
        If CaptionsLoaded = False Then
            LoadCaptions()
            CaptionsLoaded = True
        End If
    End Sub

    Public Sub LoadCaptions()
        Dim lstCaptions As IList
        Dim mdcModelClass As IModelClass
        Dim mdmModelMember As IModelMember
        Dim blnViewModified As Boolean = False
        If View Is nothing Then
            Return
        End If
            If ObjectSpace Is Nothing Then
            Return
        End If
        lstCaptions = ObjectSpace.CreateCollection(GetType(ISSBaseCustomCaption))
        If lstCaptions Is nothing Then
            Return
        End If
        For Each oCaption As ISSBaseCustomCaption In lstCaptions
            If oCaption.ObjectCustomization Is Nothing OrElse oCaption.ObjectCustomization.ObjectType Is Nothing Then
                Continue For
            End If
            mdcModelClass = Application?.Model?.BOModel?.GetClass(oCaption.ObjectCustomization.ObjectType)
            If mdcModelClass IsNot Nothing AndAlso oCaption.PropertyName IsNot Nothing Then
                mdmModelMember = mdcModelClass.FindMember(oCaption.PropertyName)
                If mdmModelMember IsNot Nothing AndAlso mdmModelMember.Caption <> oCaption.NewCaption Then
                    blnViewModified = True
                    mdmModelMember.Caption = oCaption.NewCaption
                End If
            End If
        Next
        If blnViewModified = True Then
            View.LoadModel()
        End If
    End Sub
End Class
