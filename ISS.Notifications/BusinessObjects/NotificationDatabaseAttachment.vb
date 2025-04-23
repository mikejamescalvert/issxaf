Imports Microsoft.VisualBasic
Imports System
Imports System.Linq
Imports System.Text
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports System.ComponentModel
Imports DevExpress.ExpressApp.DC
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports ISS.Attachments

Public Class NotificationDatabaseAttachment ' Specify more UI options using a declarative approach (http://documentation.devexpress.com/#Xaf/CustomDocument2701).
    Inherits NotificationAttachment


    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (http://documentation.devexpress.com/#Xaf/CustomDocument2834).
    End Sub

    Private _mContent As Byte()
    Public Overrides Property Content As Byte()
        Get
            Return _mContent
        End Get
        Set(ByVal Value As Byte())
            SetPropertyValue("Content", _mContent, Value)
        End Set
    End Property


    Public Overrides Function GetContent() As Byte()
        Return Content
    End Function
End Class
