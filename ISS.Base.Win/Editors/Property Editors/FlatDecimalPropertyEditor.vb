Imports System
Imports System.Drawing
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Core
Imports DevExpress.XtraLayout
Imports DevExpress.XtraLayout.Utils

Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Model
Imports DevExpress.XtraEditors.Repository
Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Mask
Imports DevExpress.XtraEditors.Registrator
Imports DevExpress.Data.Mask
Imports System.Globalization
Imports System.ComponentModel
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Data.Mask.Internal

<PropertyEditor(GetType(Decimal), True)>
Public Class FlatDecimalPropertyEditor
    Inherits DecimalPropertyEditor

    Public Sub New(ByVal objectType As Type, ByVal model As IModelMemberViewItem)
        MyBase.New(objectType, model)
    End Sub

    Protected Overrides Function CreateControlCore() As Object
        Return New MyDecimalEdit()
    End Function

    Protected Overrides Function CreateRepositoryItem() As RepositoryItem
        Return New RepositoryItemMyDecimalEdit()
    End Function

    Protected Overrides Sub SetupRepositoryItem(ByVal item As RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        If View IsNot Nothing Then
            Dim ri As RepositoryItemMyDecimalEdit = CType(item, RepositoryItemMyDecimalEdit)
            ri.Mask.MaskType = MaskType.Custom
            ri.Mask.EditMask = "#################0\.00"
            ri.Mask.UseMaskAsDisplayFormat = False
            'Dim baseEdit As DevExpress.XtraEditors.BaseEdit = ri.CreateEditor()
        End If
    End Sub
End Class

Public Class RepositoryItemMyDecimalEdit
    Inherits RepositoryItemDecimalEdit

    Shared Sub New()
        RepositoryItemMyDecimalEdit.Register()
    End Sub

    'Protected Friend Const EditorName As String = "MyDecimalEdit"
    Protected Friend Shadows Const EditorName As String = "MyDecimalEdit"

    Protected Friend Overloads Shared Sub Register()
        If Not EditorRegistrationInfo.[Default].Editors.Contains(EditorName) Then
            EditorRegistrationInfo.[Default].Editors.Add(New EditorClassInfo(EditorName, GetType(MyDecimalEdit), GetType(RepositoryItemMyDecimalEdit), GetType(BaseSpinEditViewInfo), New ButtonEditPainter(), True, EditImageIndexes.SpinEdit, GetType(DevExpress.Accessibility.BaseSpinEditAccessible)))
        End If
    End Sub

    Public Sub New(ByVal editMask As String, ByVal displayFormat As String)
        MyBase.New()
        Init(editMask, displayFormat)
    End Sub

    Public ReadOnly Property MyIsNullInputAllowed As Boolean
        Get
            Return IsNullInputAllowed
        End Get
    End Property

    Public Overrides ReadOnly Property EditorTypeName As String
        Get
            Return RepositoryItemMyDecimalEdit.EditorName
        End Get
    End Property

    Public Sub New()
        MyBase.New()
    End Sub
End Class

<System.ComponentModel.ToolboxItem(False)>
Public Class MyDecimalEdit
    Inherits DecimalEdit

    Shared Sub New()
        RepositoryItemMyDecimalEdit.Register()
    End Sub
    Public Sub New()

    End Sub

    Public Sub New(ByVal editMask As String, ByVal displayFormat As String)
        MyBase.New(editMask, displayFormat)
    End Sub

    Public Overrides ReadOnly Property EditorTypeName As String
        Get
            Return RepositoryItemMyDecimalEdit.EditorName
        End Get
    End Property

    Protected Overrides Function CreateMaskManager(ByVal mask As MaskProperties) As MaskManager
        If mask.MaskType = MaskType.Custom Then
            Dim managerCultureInfo As CultureInfo = mask.Culture
            If managerCultureInfo Is Nothing Then managerCultureInfo = CultureInfo.CurrentCulture
            Dim editMask As String = mask.EditMask
            If editMask Is Nothing Then editMask = String.Empty
            Dim coreManager = New NumericMaskManager(editMask, managerCultureInfo, (CType(Me.Properties, RepositoryItemMyDecimalEdit)).MyIsNullInputAllowed)
            Return New MyDecimalMaskManager(coreManager)
        Else
            Return MyBase.CreateMaskManager(mask)
        End If
    End Function
End Class

Public Class MyDecimalMaskManager
    Inherits MaskManager

    Public ReadOnly CoreManager As MaskManager

    Public Sub New(ByVal _manager As MaskManager)
        Me.CoreManager = _manager
        AddHandler Me.CoreManager.EditTextChanged, AddressOf Nested_EditTextChanged
        AddHandler Me.CoreManager.EditTextChanging, AddressOf Nested_EditTextChanging
        AddHandler Me.CoreManager.LocalEditAction, AddressOf Nested_LocalEditAction
    End Sub

    Private Sub Nested_LocalEditAction(ByVal sender As Object, ByVal e As CancelEventArgs)
        e.Cancel = Not RaiseModifyWithoutEditValueChange()
    End Sub

    Private Sub Nested_EditTextChanging(ByVal sender As Object, ByVal e As MaskChangingEventArgs)
        e.Cancel = Not RaiseEditTextChanging(e.NewValue)
    End Sub

    Private Sub Nested_EditTextChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEditTextChanged()
    End Sub

    Public Overrides Function GetCurrentEditText() As String
        Dim text = CoreManager.GetCurrentEditText()
        Return NumericMaskLogic.Div100(text)
    End Function

    Public Overrides Function GetCurrentEditValue() As Object
        Dim temp = CoreManager.GetCurrentEditValue()
        Dim value As Decimal = Nothing

        If Decimal.TryParse(temp, value) = True Then
            Return value / 100
        Else
            Return temp
        End If

    End Function

    Public Overrides Sub SetInitialEditText(ByVal initialEditText As String)
        Dim text = NumericMaskLogic.Mul100(initialEditText)
        CoreManager.SetInitialEditText(text)
    End Sub

    Public Overrides Sub SetInitialEditValue(ByVal initialEditValue As Object)
        Dim temp = initialEditValue
        Dim value As Decimal = Nothing

        If Decimal.TryParse(temp, value) = True Then
            CoreManager.SetInitialEditValue(value * 100)
        Else
            CoreManager.SetInitialEditValue(temp)
        End If

    End Sub

    Public Overrides Sub SelectAll()
        CoreManager.SelectAll()
    End Sub

    Public Overrides ReadOnly Property IsEditValueAssignedAsFormattedText As Boolean
        Get
            Return CoreManager.IsEditValueAssignedAsFormattedText
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayText As String
        Get
            Return CoreManager.DisplayText
        End Get
    End Property

    Public Overrides ReadOnly Property DisplayCursorPosition As Integer
        Get
            Return CoreManager.DisplayCursorPosition
        End Get
    End Property

    Public Overrides ReadOnly Property DisplaySelectionAnchor As Integer
        Get
            Return CoreManager.DisplaySelectionAnchor
        End Get
    End Property

    Public Overrides Function Insert(ByVal insertion As String) As Boolean
        Return CoreManager.Insert(insertion)
    End Function

    Public Overrides Function Delete() As Boolean
        Return CoreManager.Delete()
    End Function

    Public Overrides Function Backspace() As Boolean
        Return CoreManager.Backspace()
    End Function

    Public Overrides ReadOnly Property CanUndo As Boolean
        Get
            Return CoreManager.CanUndo
        End Get
    End Property

    Public Overrides Function Undo() As Boolean
        Return CoreManager.Undo()
    End Function

    Public Overrides Function CursorToDisplayPosition(ByVal newPosition As Integer, ByVal forceSelection As Boolean) As Boolean
        Return CoreManager.CursorToDisplayPosition(newPosition, forceSelection)
    End Function

    Public Overrides Function CursorMoveFar(forceSelection As Boolean, isNeededKeyCheck As Boolean) As Boolean
        Return CoreManager.CursorMoveFar(forceSelection, isNeededKeyCheck)
    End Function

    Public Overrides Function CursorMoveNear(forceSelection As Boolean, isNeededKeyCheck As Boolean) As Boolean
        Return CoreManager.CursorMoveNear(forceSelection, isNeededKeyCheck)
    End Function

    Public Overrides Function CursorHome(ByVal forceSelection As Boolean) As Boolean
        Return CoreManager.CursorHome(forceSelection)
    End Function

    Public Overrides Function CursorEnd(ByVal forceSelection As Boolean) As Boolean
        Return CoreManager.CursorEnd(forceSelection)
    End Function

    Public Overrides Function SpinUp() As Boolean
        Return CoreManager.SpinUp()
    End Function

    Public Overrides Function SpinDown() As Boolean
        Return CoreManager.SpinDown()
    End Function

    Public Overrides Function FlushPendingEditActions() As Boolean
        Return CoreManager.FlushPendingEditActions()
    End Function

    Public Overrides ReadOnly Property IsFinal As Boolean
        Get
            Return CoreManager.IsFinal
        End Get
    End Property

    Public Overrides ReadOnly Property IsMatch As Boolean
        Get
            Return CoreManager.IsMatch
        End Get
    End Property


End Class

