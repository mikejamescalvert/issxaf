Imports System
Imports DevExpress.Xpo
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10402
    ''' </summary>
    <Persistent("IV10402")>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class IVPricesheetLineItemDetailPrice
        Inherits XPLiteObject

        Public Structure IVPriceSheetItemDetailPriceKey
            Private fPRCSHID As String
            <Size(15)>
            <Persistent("PRCSHID")>
            Public Property PRCSHID() As String
                Get
                    Return fPRCSHID
                End Get
                Set(ByVal value As String)
                    fPRCSHID = value
                End Set
            End Property
            Private fEPITMTYP As Char
            <Persistent("EPITMTYP")>
            Public Property EPITMTYP() As Char
                Get
                    Return fEPITMTYP
                End Get
                Set(ByVal value As Char)
                    fEPITMTYP = value
                End Set
            End Property
            Private fITEMNMBR As String
            <Size(31)>
            <Persistent("ITEMNMBR")>
            Public Property ITEMNMBR() As String
                Get
                    Return fITEMNMBR
                End Get
                Set(ByVal value As String)
                    fITEMNMBR = value
                End Set
            End Property
            Private fUOFM As String
            <Size(9)>
            <Persistent("UOFM")>
            Public Property UOFM() As String
                Get
                    Return fUOFM
                End Get
                Set(ByVal value As String)
                    fUOFM = value
                End Set
            End Property
            Private fQTYFROM As Decimal
            <Persistent("QTYFROM")>
            Public Property QTYFROM() As Decimal
                Get
                    Return fQTYFROM
                End Get
                Set(ByVal value As Decimal)
                    fQTYFROM = value
                End Set
            End Property
            Private fQTYTO As Decimal
            <Persistent("QTYTO")>
            Public Property QTYTO() As Decimal
                Get
                    Return fQTYTO
                End Get
                Set(ByVal value As Decimal)
                    fQTYTO = value
                End Set
            End Property
        End Structure

        Dim fOid As IVPriceSheetItemDetailPriceKey
        <Key()>
        <Persistent()>
        Public Property Oid() As IVPriceSheetItemDetailPriceKey
            Get
                Return fOid
            End Get
            Set(ByVal value As IVPriceSheetItemDetailPriceKey)
                SetPropertyValue(Of IVPriceSheetItemDetailPriceKey)("Oid", fOid, value)
            End Set
        End Property


        Dim fPSITMVAL As Decimal
        Public Property PSITMVAL() As Decimal
            Get
                Return fPSITMVAL
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("PSITMVAL", fPSITMVAL, value)
            End Set
        End Property
        Dim fEQUOMQTY As Decimal
        Public Property EQUOMQTY() As Decimal
            Get
                Return fEQUOMQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("EQUOMQTY", fEQUOMQTY, value)
            End Set
        End Property
        Dim fQTYBSUOM As Decimal
        Public Property QTYBSUOM() As Decimal
            Get
                Return fQTYBSUOM
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYBSUOM", fQTYBSUOM, value)
            End Set
        End Property
        Dim fSEQNUMBR As Integer
        Public Property SEQNUMBR() As Integer
            Get
                Return fSEQNUMBR
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("SEQNUMBR", fSEQNUMBR, value)
            End Set
        End Property
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
        End Sub
    End Class

End Namespace
