Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports DevExpress.Utils
Imports DevExpress.Xpo
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.NodeWrappers
Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.SystemModule

Namespace Attributes.ObjectEditor
    ''' <summary>
    ''' This attribute determines the visibility of the object buttons.  These buttons are currently not driven by controllers.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ObjectEditorButtonsAttribute
        Inherits Attribute

#Region "Non Persistent Properties"
        Private _mIsClearVisible As Boolean = True
        Private _mIsDropDownVisible As Boolean = True
        Private _mIsEllipsisVisible As Boolean = True
        Private _mIsNewVisible As Boolean = True
        Public ReadOnly Property IsClearVisible() As Boolean
            Get
                Return _mIsClearVisible
            End Get
        End Property
        Public ReadOnly Property IsDropDownVisible() As Boolean
            Get
                Return _mIsDropDownVisible
            End Get
        End Property
        Public ReadOnly Property IsEllipsisVisible() As Boolean
            Get
                Return _mIsEllipsisVisible
            End Get
        End Property
        Public ReadOnly Property IsNewVisible() As Boolean
            Get
                Return _mIsNewVisible
            End Get
        End Property
        Private ReadOnly _mDepreciatedVersion As Boolean
        Public Function IsDepreciatedVersion() As Boolean
            Return _mDepreciatedVersion
        End Function
#End Region

#Region "Behaviors"
        <Obsolete("The IsEllipsisVisible property has been replaced by a new attribute called AllowOpenObject. Please use a constructor other than this one.")>
        Public Sub New(ByVal IsClearVisible As Boolean, ByVal IsDropDownVisible As Boolean, ByVal IsEllipsisVisible As Boolean, ByVal IsNewVisible As Boolean)
            _mIsClearVisible = IsClearVisible
            _mIsDropDownVisible = IsDropDownVisible
            _mIsEllipsisVisible = IsEllipsisVisible
            _mIsNewVisible = IsNewVisible
            _mDepreciatedVersion = True
        End Sub
        Public Sub New(ByVal IsClearVisible As Boolean, ByVal IsDropDownVisible As Boolean, ByVal IsNewVisible As Boolean)
            _mIsClearVisible = IsClearVisible
            _mIsDropDownVisible = IsDropDownVisible
            _mIsNewVisible = IsNewVisible
        End Sub
#End Region

    End Class

End Namespace