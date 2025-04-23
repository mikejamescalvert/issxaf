Imports System.Web.UI.WebControls

Public Class ImageReplacement
    Inherits Image

    Private _mPropertyName As String
    Public Property PropertyName() As String
        Get
            Return _mPropertyName
        End Get
        Set(ByVal Value As String)
            _mPropertyName = Value
        End Set
    End Property

    Public Overrides ReadOnly Property ClientID() As String
        Get
            Return PropertyName.Replace(".", "_") + "_image"
        End Get
    End Property


    Public Overrides Property ID() As String
        Get
            Return PropertyName.Replace(".", "_") + "_image"
        End Get
        Set(ByVal value As String)
            'PropertyName = value
        End Set
    End Property
End Class
