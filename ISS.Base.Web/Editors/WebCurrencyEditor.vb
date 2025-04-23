Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.ExpressApp.Model

<DevExpress.ExpressApp.Editors.PropertyEditor(GetType(Decimal), True)> _
Public Class WebCurrencyEditor
    Inherits DevExpress.ExpressApp.Web.Editors.ASPx.ASPxStringPropertyEditor


    Protected Overrides Sub SetupControl(ByVal control As System.Web.UI.WebControls.WebControl)
        MyBase.SetupControl(control)

        If TypeOf control Is DevExpress.Web.ASPxTextBox Then
            _mTextBox = control
            _mTextBox.MaskSettings.Mask = "$<0..9999999999g>.<00..99>"
            _mTextBox.MaskSettings.ShowHints = False
            '_mTextBox.DisplayFormatString = "$0.00"
            _mTextBox.MaskSettings.IncludeLiterals = DevExpress.Web.MaskIncludeLiteralsMode.DecimalSymbol
            _mTextBox.MaskSettings.PromptChar = "0"
            _mTextBox.ValidationSettings.CausesValidation = False
            _mTextBox.ValidationSettings.ValidateOnLeave = False
        End If
    End Sub

    Private _mTextBox As DevExpress.Web.ASPxTextBox
    Public Sub New(ByVal objectType As System.Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)
        
    End Sub


    Protected Overrides Sub WriteValueCore()
        If _mTextBox IsNot Nothing Then
            If _mTextBox.Text > String.Empty Then
                Decimal.TryParse(_mTextBox.Text.Replace("$", ""), Me.PropertyValue)
            Else
                Me.PropertyValue = 0
            End If

        End If
        'Dim txtBox As DevExpress.Web.ASPxTextBox = Me.Control

        'MyBase.WriteValueCore()
    End Sub

End Class
