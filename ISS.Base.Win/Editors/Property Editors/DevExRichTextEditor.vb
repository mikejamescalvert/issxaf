Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.ExpressApp.Model
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit.API.Native

<PropertyEditor(GetType(String), "RTF", False)> _
Public Class DevExRichTextEditor
    Inherits WinPropertyEditor
    Implements IInplaceEditSupport

    Public Sub New(ByVal objectType As Type, ByVal model As IModelMemberViewItem)
        MyBase.New(objectType, model)
        ControlBindingProperty = "RtfText"
    End Sub
    Private richEditUserControlCore As RichEditUserControl
    Public ReadOnly Property RichEditUserControl() As RichEditUserControl
        Get
            Return richEditUserControlCore
        End Get
    End Property
    Protected Overrides Function CreateControlCore() As Object
        richEditUserControlCore = New RichEditUserControl()
        UpdateReadOnly()
        Return richEditUserControlCore
    End Function
    Protected Overrides Sub OnAllowEditChanged()
        MyBase.OnAllowEditChanged()
        UpdateReadOnly()
    End Sub

    Private _mSecurityDisabled As Boolean
    Public Property SecurityDisable As Boolean

        Get
            Return _mSecurityDisabled
        End Get
        Set(value As Boolean)
            _mSecurityDisabled = value
        End Set
    End Property

    Private Sub UpdateReadOnly()
        If SecurityDisable = True Then
            If RichEditUserControl IsNot Nothing AndAlso RichEditUserControl.RichEditControl IsNot Nothing Then
                RichEditUserControl.RichEditControl.ReadOnly = True
            End If
        Else
            If RichEditUserControl IsNot Nothing AndAlso RichEditUserControl.RichEditControl IsNot Nothing Then
                RichEditUserControl.RichEditControl.ReadOnly = Not AllowEdit
            End If
        End If
    End Sub

#Region "IInplaceEditSupport Members"

    Public Function CreateRepositoryItem() As DevExpress.XtraEditors.Repository.RepositoryItem Implements IInplaceEditSupport.CreateRepositoryItem
        Return New RepositoryItemRtfEditEx()
    End Function

#End Region


    Public Sub AppendRTFText(ByVal RTFText As String)
        Dim pos As DocumentPosition
        If RichEditUserControl Is Nothing Then
            Return
        End If
        Clipboard.SetText(vbCrLf)
        pos = RichEditUserControl.RichEditControl1.Document.Range.End
        RichEditUserControl.RichEditControl1.Document.CaretPosition = pos
        RichEditUserControl.RichEditControl1.Paste()

        Dim rtbRichTextBox As New RichTextBox
        rtbRichTextBox.Rtf = RTFText

        rtbRichTextBox.SelectAll()
        rtbRichTextBox.Copy()
        pos = RichEditUserControl.RichEditControl1.Document.Range.End
        RichEditUserControl.RichEditControl1.Document.CaretPosition = pos
        RichEditUserControl.RichEditControl1.Paste()
        OnControlValueChanged()
        WriteValue()
    End Sub

End Class
