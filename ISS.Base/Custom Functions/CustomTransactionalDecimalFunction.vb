Imports DevExpress.Data.Filtering
Imports DevExpress.Xpo
Imports System.Text
Imports DevExpress.Xpo.DB

Public Class CustomTransactionalDoubleFunction
    Implements ICustomFunctionOperatorBrowsable, ICustomFunctionOperatorFormattable, ICustomFunctionOperatorQueryable

    Public Const FunctionName As String = "TransactionalDoubleFromDate"
    Private Shared ReadOnly instance As New CustomTransactionalDoubleFunction()
    Public Shared Sub Register()
        Unregister()
        CriteriaOperator.RegisterCustomFunction(instance)
    End Sub
    Public Shared Function Unregister() As Boolean
        Return CriteriaOperator.UnregisterCustomFunction(instance)
    End Function

    Public Function Evaluate(ParamArray operands() As Object) As Object Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Evaluate
        Dim tsdTransactionalDouble As TransactionalDouble = operands(0)
        If tsdTransactionalDouble Is Nothing Then
            Return 0
        End If
        Return tsdTransactionalDouble.GetRateAtDateTime(operands(1))
    End Function

    Public ReadOnly Property Name As String Implements DevExpress.Data.Filtering.ICustomFunctionOperator.Name
        Get
            Return FunctionName
        End Get
    End Property

    Public Function ResultType(ParamArray operands() As System.Type) As System.Type Implements DevExpress.Data.Filtering.ICustomFunctionOperator.ResultType
        Return GetType(Double)
    End Function

    Public ReadOnly Property Category As DevExpress.Data.Filtering.FunctionCategory Implements DevExpress.Data.Filtering.ICustomFunctionOperatorBrowsable.Category
        Get
            Return FunctionCategory.Text
        End Get
    End Property

    Public ReadOnly Property Description As String Implements DevExpress.Data.Filtering.ICustomFunctionOperatorBrowsable.Description
        Get
            Return "Custom function to return back the current cost for a transactional Double by date"
        End Get
    End Property

    Public Function IsValidOperandCount(count As Integer) As Boolean Implements DevExpress.Data.Filtering.ICustomFunctionOperatorBrowsable.IsValidOperandCount
        Return count = 2
    End Function

    Public Function IsValidOperandType(operandIndex As Integer, operandCount As Integer, type As System.Type) As Boolean Implements DevExpress.Data.Filtering.ICustomFunctionOperatorBrowsable.IsValidOperandType
        If operandIndex = 0 Then
            Return type Is GetType(TransactionalDouble)
        Else
            Return type Is GetType(DateTime)
        End If
    End Function

    Public ReadOnly Property MaxOperandCount As Integer Implements DevExpress.Data.Filtering.ICustomFunctionOperatorBrowsable.MaxOperandCount
        Get
            Return 2
        End Get
    End Property

    Public ReadOnly Property MinOperandCount As Integer Implements DevExpress.Data.Filtering.ICustomFunctionOperatorBrowsable.MinOperandCount
        Get
            Return 2
        End Get
    End Property

    Public Function Format(providerType As System.Type, ParamArray operands() As String) As String Implements DevExpress.Data.Filtering.ICustomFunctionOperatorFormattable.Format
        Dim strSQLFormat As String = " (select top 1 case fromvalue " & _
                                        "when null then " & _
                                            "currentvalue " & _
                                        "else fromvalue " & _
                                    "end " & _
                                    "as resultvalue from (select  tdh.oid as rateoid,td.oid as mainoid, tdh.fromvalue,td.currentvalue, tdh.transactiondate from TransactionalDouble td " & _
                                    "left join transactionalDoublehistory tdh " & _
                                    "on tdh.transactionalDouble = td.oid " & _
                                    "where td.oid = {0} and (tdh.transactiondate is null or tdh.transactiondate >= {1})) tdh " & _
                                    "order by tdh.transactiondate asc) "
        Dim strResult As String
        If providerType Is GetType(MSSqlConnectionProvider) Then
            strResult = String.Format(strSQLFormat, operands(0), operands(1))
            Return strResult
        End If
        Throw New NotSupportedException(providerType.FullName)
    End Function

    ' The method name must match the function name (specified via FunctionName) 
    Public Shared Function TransactionalDoubleFromDate(ByVal DateTime As DateTime) As Double
        Return CStr(instance.Evaluate(DateTime))
    End Function

    Public Function GetMethodInfo() As System.Reflection.MethodInfo Implements DevExpress.Xpo.ICustomFunctionOperatorQueryable.GetMethodInfo
        Return GetType(CustomTransactionalDoubleFunction).GetMethod(FunctionName)
    End Function

End Class
