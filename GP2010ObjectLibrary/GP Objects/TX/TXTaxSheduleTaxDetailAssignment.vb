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
    ''' GP Table TX00102
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    <OptimisticLocking(False)> _
       <Persistent("TX00102")> _
    Public Class TXTaxSheduleTaxDetailAssignment
        Inherits XPBaseObject

#Region "Key Structure"
        Public Structure TaxKey
            Private fTAXSCHID As String
            <Persistent("TAXSCHID")>
            <Size(15)> _
            Public Property TAXSCHID() As String
                Get
                    Return fTAXSCHID
                End Get
                Set(ByVal value As String)
                    fTAXSCHID = value
                End Set
            End Property

            Private fTAXDTLID As String
            <Persistent("TAXDTLID")>
            <Size(15)> _
            Public Property TAXDTLID() As String
                Get
                    Return fTAXDTLID
                End Get
                Set(ByVal value As String)
                    fTAXDTLID = value
                End Set
            End Property
        End Structure

#End Region

#Region "Behaviors"


        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub

#End Region



#Region "Properties"

        Private _mOid As TaxKey
        <Key()>
        <Persistent()>
        Public Property Oid As TaxKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As TaxKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property


        Dim fTXDTLBSE As Short
        Public Property TXDTLBSE() As Short
            Get
                Return fTXDTLBSE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("TXDTLBSE", fTXDTLBSE, value)
            End Set
        End Property
        Dim fTDTAXTAX As Byte
        Public Property TDTAXTAX() As Byte
            Get
                Return fTDTAXTAX
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("TDTAXTAX", fTDTAXTAX, value)
            End Set
        End Property
        Dim fAuto_Calculate As Byte
        Public Property Auto_Calculate() As Byte
            Get
                Return fAuto_Calculate
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("Auto_Calculate", fAuto_Calculate, value)
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
