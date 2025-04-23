Imports System.Windows.Forms
Imports DevExpress.XtraEditors.Controls

Public Class frmPicker

    Public Sub New(ByVal TargetType As Type)
        InitializeComponent()
        Me.fldPicker.Properties.TextEditStyle = TextEditStyles.DisableTextEditor
        Me.fldPicker.Properties.ClassType = TargetType
    End Sub

    Private _mSelectedProperty As String
    Public Property SelectedProperty As String
        Get
            Return _mSelectedProperty
        End Get
        Set(ByVal Value As String)
            _mSelectedProperty = Value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If fldPicker.EditValue > String.Empty Then
            SelectedProperty = String.Format("[{0}]", fldPicker.EditValue)
        End If

        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
