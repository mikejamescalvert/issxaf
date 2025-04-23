Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.DC

Namespace Helpers
    Public Class ObjectSpaceParentRelationship
        Private _mChildObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace
        Private _mParentObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace

        Public Property ChildObjectSpace() As DevExpress.ExpressApp.Xpo.XPObjectSpace
            Get
                Return _mChildObjectSpace
            End Get
            Set(ByVal value As DevExpress.ExpressApp.Xpo.XPObjectSpace)
                If _mChildObjectSpace Is value Then
                    Return
                End If
                _mChildObjectSpace = value
            End Set
        End Property
        Public Property ParentObjectSpace() As DevExpress.ExpressApp.Xpo.XPObjectSpace
            Get
                Return _mParentObjectSpace
            End Get
            Set(ByVal value As DevExpress.ExpressApp.Xpo.XPObjectSpace)
                If _mParentObjectSpace Is value Then
                    Return
                End If
                _mParentObjectSpace = value
            End Set
        End Property

        Public Sub New(ByVal ChildObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace, ByVal ParentObjectSpace As DevExpress.ExpressApp.Xpo.XPObjectSpace)
            Me.ChildObjectSpace = ChildObjectSpace
            Me.ParentObjectSpace = ParentObjectSpace
        End Sub
    End Class
    'Namespace Wrappers
    '    Public Class DetailViewSaveWrapper
    '        Private WithEvents _mObjectSpace As ObjectSpace
    '        Public Property ObjectSpace() As ObjectSpace
    '            Get
    '                Return _mObjectSpace
    '            End Get
    '            Set(ByVal value As ObjectSpace)
    '                If _mObjectSpace Is value Then
    '                    Return
    '                End If
    '                _mObjectSpace = Value
    '            End Set
    '        End Property
    '        Private _mIsCommitted As Boolean
    '        Public Property IsCommitted() As Boolean
    '            Get
    '                Return _mIsCommitted
    '            End Get
    '            Set(ByVal value As Boolean)
    '                If _mIsCommitted = Value Then
    '                    Return
    '                End If
    '                _mIsCommitted = Value
    '            End Set
    '        End Property
    '        Private Sub _mObjectSpace_Committed(ByVal sender As Object, ByVal e As System.EventArgs) Handles _mObjectSpace.Committed
    '            Me.IsCommitted = True
    '        End Sub
    '    End Class
    'End Namespace
End Namespace


