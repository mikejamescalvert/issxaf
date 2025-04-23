Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports DevExpress.Data.Filtering
Imports DevExpress.Persistent.Base

Public Class EnumCriteriaParser
    Inherits CriteriaProcessorBase

    Private _values As Dictionary(Of String, OperandValue) = New Dictionary(Of String, OperandValue)()

    Private Shared Sub UnsupportedCriteria()
        Throw New InvalidEnumArgumentException("Unsupported criteria.")
    End Sub

    Private Sub UpdatePropertyName(ByVal operand As CriteriaOperator)
        Dim operandProperty = TryCast(operand, OperandProperty)
        If (ReferenceEquals(operandProperty, Nothing)) OrElse (Not operandProperty.PropertyName.Equals(PropertyName)) Then UnsupportedCriteria()
        operandProperty.PropertyName = "Value"
    End Sub

    Private Sub ToValue(ByVal operands As IList(Of CriteriaOperator))
        Dim operandValue As CriteriaOperator

        For i As Integer = 0 To operands.Count - 1
            If ToValue(operands(i), operandValue) Then operands(i) = operandValue
        Next
    End Sub

    Private Function ToValue(ByVal operand As CriteriaOperator, <Out> ByRef operandValue As CriteriaOperator) As Boolean
        operandValue = Nothing
        Dim valueName As String

        If TypeOf operand Is OperandProperty Then
            valueName = (CType(operand, OperandProperty)).PropertyName
        ElseIf TypeOf operand Is OperandValue AndAlso TypeOf (CType(operand, OperandValue)).Value Is String Then
            valueName = CStr((CType(operand, OperandValue)).Value)
        Else
            Return False
        End If

        operandValue = _values(valueName)
        Return True
    End Function

    Public Sub New(ByVal propertyName As String, ByVal enumType As Type)
        propertyName = propertyName

        If enumType.IsGenericType Then
            Dim types = enumType.GetGenericArguments()
            If types.Length = 1 AndAlso GetType(Nullable(Of)).MakeGenericType(types(0)).Equals(enumType) Then enumType = types(0)
        End If

        enumType = enumType

        For Each value As Object In [Enum].GetValues(enumType)
            _values.Add(value.ToString(), New OperandValue(value))
        Next
    End Sub

    Public Function Visit(ByVal theOperator As InOperator) As Object
        UpdatePropertyName(theOperator.LeftOperand)
        ToValue(theOperator.Operands)
        Return theOperator
    End Function

    Protected Overrides Sub Process(ByVal theOperator As InOperator)
        UpdatePropertyName(theOperator.LeftOperand)
        ToValue(theOperator.Operands)
        MyBase.Process(theOperator)
    End Sub

    Protected Overrides Sub Process(ByVal theOperator As UnaryOperator)
        Select Case theOperator.OperatorType
            Case UnaryOperatorType.IsNull
                UpdatePropertyName(theOperator.Operand)
            Case UnaryOperatorType.[Not]
                theOperator.Operand.Accept(Me)
        End Select

        MyBase.Process(theOperator)
    End Sub

    Protected Overrides Sub Process(ByVal theOperator As BinaryOperator)
        UpdatePropertyName(theOperator.LeftOperand)
        Dim operandValue As CriteriaOperator

        If ToValue(theOperator.RightOperand, operandValue) Then
            theOperator.RightOperand = operandValue
        Else
            theOperator.RightOperand.Accept(Me)
        End If

        MyBase.Process(theOperator)
    End Sub

    Protected Overrides Sub Process(ByVal theOperator As BetweenOperator)
        UpdatePropertyName(theOperator.TestExpression)
        Dim operandValue As CriteriaOperator

        If ToValue(CType(theOperator.BeginExpression, OperandProperty), operandValue) Then
            theOperator.BeginExpression = operandValue
        Else
            theOperator.BeginExpression.Accept(Me)
        End If

        If ToValue(CType(theOperator.EndExpression, OperandProperty), operandValue) Then
            theOperator.EndExpression = operandValue
        Else
            theOperator.EndExpression.Accept(Me)
        End If

        MyBase.Process(theOperator)
    End Sub

    Public Property PropertyName As String
    Public Property EnumType As Type
End Class