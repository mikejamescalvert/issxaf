Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Model
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.ExpressApp

<PropertyEditor(GetType(TransactionalDouble), True)>
Public Class TransactionalDoubleEditor
    Inherits DevExpress.ExpressApp.Win.Editors.DoublePropertyEditor
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub

    Private Shared _mHistoryImage As Drawing.Image
    Public ReadOnly Property HistoryImage As Drawing.Image
        Get
            If _mHistoryImage Is Nothing Then
                _mHistoryImage = DevExpress.ExpressApp.Utils.ImageLoader.Instance.GetImageInfo("Action_Chart_Printing_Preview").Image
            End If
            Return _mHistoryImage
        End Get
    End Property

    Private _mViewHistoryButton As EditorButton

    Public Function GetHistoryButton() As EditorButton
        _mViewHistoryButton = New EditorButton(ButtonPredefines.Glyph)
        With _mViewHistoryButton
            .Caption = "View History"
            .Tag = "ViewHistory"
            .Image = HistoryImage
        End With


        Return _mViewHistoryButton
    End Function

    Protected Overrides Sub SetupRepositoryItem(item As DevExpress.XtraEditors.Repository.RepositoryItem)
        MyBase.SetupRepositoryItem(item)
        If TypeOf Me.View Is DetailView Then
            Return
        End If
        RemoveHandler CType(item, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit).EditValueChanged, AddressOf PushValue
        AddHandler CType(item, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit).EditValueChanged, AddressOf PushValue

        For intLoop As Integer = CType(item, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit).Buttons.Count - 1 To 0 Step -1
            If CType(item, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit).Buttons(intLoop) Is _mViewHistoryButton Then
                CType(item, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit).Buttons.RemoveAt(intLoop)
            End If
        Next


        'AddHandler CType(item, DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit).ButtonClick, AddressOf Editor_ButtonPressed
    End Sub

    Protected Overrides Function CreateControlCore() As Object
        Dim speSpinEdit As DevExpress.XtraEditors.SpinEdit = MyBase.CreateControlCore
        speSpinEdit.Properties.Buttons.Add(GetHistoryButton)
        AddHandler speSpinEdit.EditValueChanged, AddressOf PushValue
        AddHandler speSpinEdit.ButtonClick, AddressOf Editor_ButtonPressed
        Return speSpinEdit
    End Function

    Protected Overrides Sub ReadValueCore()
        'MyBase.ReadValueCore()
        Dim xpoTransactionDouble As TransactionalDouble = PropertyValue
        If Me.Control IsNot Nothing Then
            Me.Control.EditValue = xpoTransactionDouble.CurrentValue
        End If


    End Sub

    Public Event TransactionalDoubleHistoryClicked(ByVal sender As Object, ByVal e As TransactionalDoubleClickedEventArgs)

    Public Class TransactionalDoubleClickedEventArgs
        Inherits EventArgs

        Public Sub New(ByVal ClickedTransactionalDouble As TransactionalDouble)
            MyBase.New()
            _mTransactionalDouble = ClickedTransactionalDouble
        End Sub

        Private _mTransactionalDouble As TransactionalDouble
        Public ReadOnly Property TransactionalDouble As TransactionalDouble
            Get
                Return _mTransactionalDouble
            End Get
        End Property


    End Class

    Public Sub Editor_ButtonPressed(ByVal sender As Object, ByVal e As ButtonPressedEventArgs)
        Dim edbEditorButton As EditorButton = e.Button
        Dim tdeEvent As TransactionalDoubleClickedEventArgs
        If edbEditorButton.Tag = "ViewHistory" Then
            tdeEvent = New TransactionalDoubleClickedEventArgs(PropertyValue)
            RaiseEvent TransactionalDoubleHistoryClicked(Me, tdeEvent)
        End If
    End Sub

    Public Sub PushValue(ByVal sender As Object, ByVal e As EventArgs)
        Dim xpoTransactionDouble As TransactionalDouble = PropertyValue
        If Me.Control IsNot Nothing Then
            xpoTransactionDouble.CurrentValue = Me.Control.EditValue
        End If
    End Sub



End Class
