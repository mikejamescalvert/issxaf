Imports DevExpress.Xpo

Namespace Objects.MOPS.Helpers
    Public Class ManufacturerSystemHelper
        Public Shared Function GetUpdateNextManufacturerNumber(ByVal theSession As Session) As String
            Dim mocManufactureOrderNumberCounter As ManufactureOrderNumberCounter = theSession.FindObject(Of ManufactureOrderNumberCounter)(Nothing)
            Dim strCurrentNumber As String
            Dim intCurrentNumber As Integer
            Dim strNextNumber As String
            Dim intCounter As Integer = 1
            Dim mfhHeader As WO.WOManufacturingOrderHeader
            Dim blnUseNumber As Boolean = False
            If mocManufactureOrderNumberCounter Is Nothing Then
                Throw New Exception("MO Counter Table Not Found (mops0100)!")
            End If
            strCurrentNumber = mocManufactureOrderNumberCounter.MANUFACTUREORDER_I.Trim
            intCurrentNumber = Integer.Parse(strCurrentNumber)
            strNextNumber = String.Empty
            While blnUseNumber = False
                strNextNumber = (intCurrentNumber + intCounter).ToString.PadLeft(strCurrentNumber.Length, "0")
                mfhHeader = theSession.GetObjectByKey(Of WO.WOManufacturingOrderHeader)(strNextNumber)
                If mfhHeader Is Nothing Then
                    blnUseNumber = True
                Else
                    intCounter += 1
                End If
            End While
            mocManufactureOrderNumberCounter.MANUFACTUREORDER_I = strNextNumber
            mocManufactureOrderNumberCounter.Save()
            Return strCurrentNumber
        End Function
    End Class
End Namespace

