Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.Base

Namespace Helpers
    Public Class ApplicationHelper
        Private Shared _mXAFApplication As XafApplication
        Public Shared Property XAFApplication() As XafApplication
            Get
                Return _mXAFApplication
            End Get
            Set(ByVal value As XafApplication)
                If _mXAFApplication Is value Then
                    Return
                End If
                _mXAFApplication = value
            End Set
        End Property

    End Class

End Namespace