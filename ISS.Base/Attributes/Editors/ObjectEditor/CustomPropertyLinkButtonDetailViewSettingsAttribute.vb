Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Namespace Attributes.ObjectEditor
    Public Class CustomPropertyLinkButtonViewSettingsAttribute
        Inherits Attributes.View.ViewSettingsAttribute

#Region "Behaviors"
        Public Sub New(ByVal EditableInView As Boolean, ByVal AllowNewInView As Boolean, ByVal AllowDeleteInView As Boolean, ByVal ViewInModalWindow As Boolean, ByVal IsOpenObjectVisible As Boolean)
            MyBase.New(EditableInView, AllowNewInView, AllowDeleteInView, ViewInModalWindow, IsOpenObjectVisible)
        End Sub
#End Region

    End Class

End Namespace