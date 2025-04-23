Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.Base
Imports DevExpress.Xpo

Namespace Helpers
    Public Class SecurityHelper

        Public Shared Function GetUserObjectInSession(ByVal session As Session) As Object
            Return session.GetObjectByKey(DevExpress.ExpressApp.SecuritySystem.UserType, DevExpress.ExpressApp.SecuritySystem.CurrentUserId)
        End Function
        Public Shared Function GetUserObjectInObjectSpace(ByVal objectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace) As Object
            Return objectSpace.GetObjectByKey(DevExpress.ExpressApp.SecuritySystem.UserType, DevExpress.ExpressApp.SecuritySystem.CurrentUserId)
        End Function

    End Class
End Namespace
