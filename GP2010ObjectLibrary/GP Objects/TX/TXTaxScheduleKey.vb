Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.TX
    ''' <summary>
    ''' GP Table TX00101
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <OptimisticLocking(False)> _
    <DefaultProperty("TAXSCHID")> _
    <Persistent("TX00101")> _
        Public Class TXTaxScheduleKey
        Inherits XPBaseObject

#Region "Behaviors"

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub


        ''' <summary>
        ''' Returns a collection of tax details object related to this tax schedule
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTaxDetails() As XPCollection(Of TXTaxDetail)
            Dim xpoGO As New GroupOperator
            Dim xclAssignments As New XPCollection(Of TXTaxSheduleTaxDetailAssignment)(Session, New BinaryOperator("Oid.TAXSCHID", Me.TAXSCHID))
            If xclAssignments Is Nothing OrElse xclAssignments.Count = 0 Then
                Return Nothing
            End If
            With xpoGO
                .OperatorType = GroupOperatorType.Or
                For Each xpoAssignment As TXTaxSheduleTaxDetailAssignment In xclAssignments
                    With .Operands
                        .Add(New BinaryOperator("TAXDTLID", xpoAssignment.Oid.TAXDTLID))
                    End With
                Next
            End With
            Return New XPCollection(Of TXTaxDetail)(Session, xpoGO)

        End Function

        ''' <summary>
        ''' returns the tax amount computed against the amount provided
        ''' Works for
        ''' Percent of sales or purchase types
        ''' </summary>
        ''' <param name="TaxableValue"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetTaxAmount(TaxableValue As Double, TaxableValueType As TXTaxDetail.TaxDetailTypes) As Double
            If TaxableValue = 0 Then Return 0
            Dim xcl As XPCollection(Of TXTaxDetail) = Me.GetTaxDetails
            If xcl Is Nothing Then
                Return 0
            End If
            Dim dblTaxAmount As Double
            For Each xpo As TXTaxDetail In xcl
                If xpo.TXDTLTYP = TaxableValueType Then
                    Select Case xpo.TXDTLBSE
                        Case TXTaxDetail.TaxDetailFormulaTypes.PercentOfSaleOrPurchase
                            dblTaxAmount += ((xpo.TXDTLPCT / 100) * TaxableValue)
                    End Select

                End If


            Next
            Return dblTaxAmount

        End Function



#End Region

#Region "Non-Persistent Properties"


        Private _mTaxDetails As XPCollection(Of TX.TXTaxDetail)
        Public ReadOnly Property TaxDetails As XPCollection(Of TX.TXTaxDetail)
            Get
                If _mTaxDetails Is Nothing Then
                    _mTaxDetails = Me.GetTaxDetails
                End If

                Return _mTaxDetails
            End Get
        End Property
        



        

#End Region

#Region "Properties"


        Dim fTAXSCHID As String
        <Key()> _
        <Size(15)> _
        Public Property TAXSCHID() As String
            Get
                Return fTAXSCHID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TAXSCHID", fTAXSCHID, value)
            End Set
        End Property
        Dim fTXSCHDSC As String
        <Size(31)> _
        Public Property TXSCHDSC() As String
            Get
                Return fTXSCHDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TXSCHDSC", fTXSCHDSC, value)
            End Set
        End Property
        Dim fNOTEINDX As Decimal
        Public Property NOTEINDX() As Decimal
            Get
                Return fNOTEINDX
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("NOTEINDX", fNOTEINDX, value)
            End Set
        End Property
        Dim fDEX_ROW_ID As Integer
        Public Property DEX_ROW_ID() As Integer
            Get
                Return fDEX_ROW_ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DEX_ROW_ID", fDEX_ROW_ID, value)
            End Set
        End Property

#End Region

    End Class

End Namespace
