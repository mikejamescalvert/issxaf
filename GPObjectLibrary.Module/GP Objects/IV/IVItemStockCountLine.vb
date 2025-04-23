Imports System
Imports DevExpress.Xpo
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10301
    ''' </summary>
    <Persistent("IV10301")>
    <OptimisticLocking(False)>
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()>
    Public Class IVItemStockCountLine
        Inherits XPLiteObject
        Public Structure ItemStockCountLineKey
            <Persistent("STCKCNTID")>
            <System.ComponentModel.Browsable(False)>
            Public STCKCNTID As String
            <Persistent("ITEMNMBR")>
            <System.ComponentModel.Browsable(False)>
            Public ITEMNMBR As String
            <Persistent("LOCNCODE")>
            <System.ComponentModel.Browsable(False)>
            Public LOCNCODE As String
            <Persistent("BINNMBR")>
            <System.ComponentModel.Browsable(False)>
            Public BINNMBR As String
            '    Dim fSTCKCNTID As String
            '    '<Size(15)> _
            '    <Persistent("STCKCNTID")> _
            '    Public Property STCKCNTID() As String
            '        Get
            '            Return fSTCKCNTID
            '        End Get
            '        Set(ByVal value As String)
            '            fSTCKCNTID = value
            '        End Set
            '    End Property

            '    Dim fITEMNMBR As String
            '    '<Size(31)> _
            '    <Persistent("ITEMNMBR")> _
            'Public Property ITEMNMBR() As String
            '        Get
            '            Return fITEMNMBR
            '        End Get
            '        Set(ByVal value As String)
            '            fITEMNMBR = value
            '        End Set
            '    End Property
            '    Dim fLOCNCODE As String
            '    '<Size(11)> _
            '    <Persistent("LOCNCODE")> _
            '    Public Property LOCNCODE() As String
            '        Get
            '            Return fLOCNCODE
            '        End Get
            '        Set(ByVal value As String)
            '            fLOCNCODE = value
            '        End Set
            '    End Property

            '    Dim fBINNMBR As String
            '    '<Size(21)> _
            '    <Persistent("BINNMBR")> _
            '    Public Property BINNMBR() As String
            '        Get
            '            Return fBINNMBR
            '        End Get
            '        Set(ByVal value As String)
            '            fBINNMBR = value
            '        End Set
            '    End Property
        End Structure

        Private _mItemStockCountLineMultiKey As ItemStockCountLineKey
        <Key()>
        <Persistent()>
        Public Property Oid() As ItemStockCountLineKey
            Get
                Return _mItemStockCountLineMultiKey
            End Get
            Set(ByVal Value As ItemStockCountLineKey)
                _mItemStockCountLineMultiKey = Value
            End Set
        End Property
        <PersistentAlias("Oid.STCKCNTID")>
        Public Property STCKCNTID() As String
            Get
                Return EvaluateAlias("STCKCNTID")
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("STCKCNTID", _mItemStockCountLineMultiKey.STCKCNTID, Value)
            End Set
        End Property
        <PersistentAlias("Oid.ITEMNMBR")>
        Public Property ITEMNMBR() As String
            Get
                Return EvaluateAlias("ITEMNMBR")
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("ITEMNMBR", _mItemStockCountLineMultiKey.ITEMNMBR, Value)
            End Set
        End Property
        <PersistentAlias("Oid.LOCNCODE")>
        Public Property LOCNCODE() As String
            Get
                Return EvaluateAlias("LOCNCODE")
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("LOCNCODE", _mItemStockCountLineMultiKey.LOCNCODE, Value)
            End Set
        End Property
        <PersistentAlias("Oid.BINNMBR")>
        Public Property BINNMBR() As String
            Get
                Return CType(EvaluateAlias("BINNMBR"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("LOCNCODE", _mItemStockCountLineMultiKey.BINNMBR, Value)
            End Set
        End Property

        Dim fCAPTUREDQTY As Decimal
        Public Property CAPTUREDQTY() As Decimal
            Get
                Return fCAPTUREDQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CAPTUREDQTY", fCAPTUREDQTY, value)
            End Set
        End Property
        Dim fCOUNTEDQTY As Decimal
        Public Property COUNTEDQTY() As Decimal
            Get
                Return fCOUNTEDQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("COUNTEDQTY", fCOUNTEDQTY, value)
            End Set
        End Property
        Dim fCOUNTDATE As DateTime
        Public Property COUNTDATE() As DateTime
            Get
                Return fCOUNTDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("COUNTDATE", fCOUNTDATE, value)
            End Set
        End Property
        Dim fCOUNTTIME As DateTime
        Public Property COUNTTIME() As DateTime
            Get
                Return fCOUNTTIME
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("COUNTTIME", fCOUNTTIME, value)
            End Set
        End Property
        Dim fDECPLQTY As Short
        Public Property DECPLQTY() As Short
            Get
                Return fDECPLQTY
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("DECPLQTY", fDECPLQTY, value)
            End Set
        End Property
        Dim fITMTRKOP As Short
        Public Property ITMTRKOP() As Short
            Get
                Return fITMTRKOP
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("ITMTRKOP", fITMTRKOP, value)
            End Set
        End Property
        Dim fIVIVINDX As Integer
        Public Property IVIVINDX() As Integer
            Get
                Return fIVIVINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVIVINDX", fIVIVINDX, value)
            End Set
        End Property
        Dim fStock_Serial_Lot_Count As Decimal
        Public Property Stock_Serial_Lot_Count() As Decimal
            Get
                Return fStock_Serial_Lot_Count
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Stock_Serial_Lot_Count", fStock_Serial_Lot_Count, value)
            End Set
        End Property
        Dim fSTCKSRLLTVRNC As Decimal
        Public Property STCKSRLLTVRNC() As Decimal
            Get
                Return fSTCKSRLLTVRNC
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("STCKSRLLTVRNC", fSTCKSRLLTVRNC, value)
            End Set
        End Property
        Dim fIVVARIDX As Integer
        Public Property IVVARIDX() As Integer
            Get
                Return fIVVARIDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("IVVARIDX", fIVVARIDX, value)
            End Set
        End Property
        Dim fVARIANCEQTY As Decimal
        Public Property VARIANCEQTY() As Decimal
            Get
                Return fVARIANCEQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("VARIANCEQTY", fVARIANCEQTY, value)
            End Set
        End Property
        Dim fVERIFIED As Byte
        Public Property VERIFIED() As Byte
            Get
                Return fVERIFIED
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("VERIFIED", fVERIFIED, value)
            End Set
        End Property
        Dim fTemp_Allocated_Quantity As Decimal
        Public Property Temp_Allocated_Quantity() As Decimal
            Get
                Return fTemp_Allocated_Quantity
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Temp_Allocated_Quantity", fTemp_Allocated_Quantity, value)
            End Set
        End Property
        Dim fACTIVE As Byte
        Public Property ACTIVE() As Byte
            Get
                Return fACTIVE
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("ACTIVE", fACTIVE, value)
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