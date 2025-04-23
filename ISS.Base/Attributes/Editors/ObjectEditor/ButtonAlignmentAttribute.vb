Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.SystemModule

Namespace Attributes.ObjectEditor
    ''' <summary>
    ''' Aligns all object editor buttons to the specified button position
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ButtonAlignmentAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mButtonAlignment As ButtonAlignments
        Public Property ButtonAlignment() As ButtonAlignments
            Get
                Return _mButtonAlignment
            End Get
            Set(ByVal value As ButtonAlignments)
                If _mButtonAlignment = value Then
                    Return
                End If
                _mButtonAlignment = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal ButtonAlignment As ButtonAlignments)
            Me.ButtonAlignment = ButtonAlignment
        End Sub
#End Region

#Region "Enumerations"
        Public Enum ButtonAlignments
            Left = 0
            Right = 1
        End Enum
#End Region

    End Class
End Namespace