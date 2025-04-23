Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.SystemModule

Namespace Attributes.Editors.PropertyDataObjectTypeEditor
    ''' <summary>
    ''' Indicates that the property is an email address.
    ''' </summary>
    ''' <remarks></remarks>
    <AttributeUsage(AttributeTargets.Property, Inherited:=True)> _
    Public Class PropertyDataObjectTypeMemberAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mMemberName As String
        Public Property MemberName() As String
            Get
                Return _mMemberName
            End Get
            Set(ByVal value As String)
                If _mMemberName = value Then
                    Return
                End If
                _mMemberName = value
            End Set
        End Property
#End Region

#Region "Behaviors"
        Public Sub New(ByVal MemberName As String)
            Me.MemberName = MemberName
        End Sub
#End Region

    End Class
End Namespace