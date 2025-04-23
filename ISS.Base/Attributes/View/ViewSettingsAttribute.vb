Imports System
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.Persistent.Base

Namespace Attributes.View
    ''' <summary>
    ''' A wrapper attribute for basic view actions.
    ''' </summary>
    ''' <remarks>
    ''' <example>
    ''' Allow Edit In View - Allows editing in the current view
    ''' </example>
    ''' <example>
    ''' Allow New In View - Enables the new action on the current view
    ''' </example>
    ''' <example>
    ''' Allow Delete In View - For detail views, allows the current object to be deleted.  In list views, allows the currently selected objects to be deleted.
    ''' </example>
    ''' <example>
    ''' Allow Open Object In View - Will disable or enable the open object action for child properties of this view.
    ''' </example>
    ''' <example>
    ''' View In Modal Window - When the object view is opened, it will be shown in a modal window vs. the standard window load path.
    ''' </example>
    ''' </remarks>
    Public Class ViewSettingsAttribute
        Inherits Attribute

#Region "Behaviors"
        Public Sub New(ByVal AllowEditInView As Boolean, ByVal AllowNewInView As Boolean, ByVal AllowDeleteInView As Boolean, ByVal AllowOpenObjectInView As Boolean, ByVal ViewInModalWindow As Boolean)
            Me.AllowEditInView = AllowEditInView
            Me.AllowNewInView = AllowNewInView
            Me.AllowDeleteInView = AllowDeleteInView
            Me.ViewInModalWindow = ViewInModalWindow
            Me.AllowOpenObjectInView = AllowOpenObjectInView
        End Sub
#End Region

#Region "Non Persistent Properties"


        Private _mAllowDeleteInView As Boolean = True
        Private _mAllowEditInView As Boolean = True

        Private _mAllowNewInView As Boolean = True

        Private _mAllowOpenObjectInView As Boolean = True
        Private _mViewInModalWindow As Boolean = False
        Public Property AllowDeleteInView() As Boolean
            Get
                Return _mAllowDeleteInView
            End Get
            Set(ByVal value As Boolean)
                If _mAllowDeleteInView = value Then
                    Return
                End If
                _mAllowDeleteInView = value
            End Set
        End Property
        Public Property AllowEditInView() As Boolean
            Get
                Return _mAllowEditInView
            End Get
            Set(ByVal value As Boolean)
                If _mAllowEditInView = value Then
                    Return
                End If
                _mAllowEditInView = value
            End Set
        End Property
        Public Property AllowNewInView() As Boolean
            Get
                Return _mAllowNewInView
            End Get
            Set(ByVal value As Boolean)
                If _mAllowNewInView = value Then
                    Return
                End If
                _mAllowNewInView = value
            End Set
        End Property
        Public Property AllowOpenObjectInView() As Boolean
            Get
                Return _mAllowOpenObjectInView
            End Get
            Set(ByVal value As Boolean)
                If _mAllowOpenObjectInView = value Then
                    Return
                End If
                _mAllowOpenObjectInView = value
            End Set
        End Property
        Public Property ViewInModalWindow() As Boolean
            Get
                Return _mViewInModalWindow
            End Get
            Set(ByVal value As Boolean)
                If _mViewInModalWindow = value Then
                    Return
                End If
                _mViewInModalWindow = value
            End Set
        End Property
#End Region

    End Class

End Namespace