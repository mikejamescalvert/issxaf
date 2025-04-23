Imports System
Imports DevExpress.Xpo
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV10302
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("IV10302")> _
    <OptimisticLocking(False)> _
    <MasterProvider.Module.AllowDataModificationsInMasterProvider()> _
Public Class IVItemStockCountSerialLot
        Inherits XPLiteObject

        Private Structure ItemStockCountSerialLotKey
            <Persistent("STCKCNTID")> _
            <System.ComponentModel.Browsable(False)> _
            Public STCKCNTID As String
            <Persistent("ITEMNMBR")> _
            <System.ComponentModel.Browsable(False)> _
            Public ITEMNMBR As String
            <Persistent("LOCNCODE")> _
            <System.ComponentModel.Browsable(False)> _
            Public LOCNCODE As String
            <Persistent("BINNMBR")> _
            <System.ComponentModel.Browsable(False)> _
            Public BINNMBR As String
            <Persistent("DATERECD")> _
            <System.ComponentModel.Browsable(False)> _
            Public DATERECD As DateTime
            <Persistent("DTSEQNUM")> _
            <System.ComponentModel.Browsable(False)> _
            Public DTSEQNUM As Decimal
            <Persistent("SERLTNUM")> _
            <System.ComponentModel.Browsable(False)> _
            Public SERLTNUM As String

            'Dim fSTCKCNTID As String
            '<Size(15)> _
            '<Persistent("STCKCNTID")> _
            'Public Property STCKCNTID() As String
            '    Get
            '        Return fSTCKCNTID
            '    End Get
            '    Set(ByVal value As String)
            '        fSTCKCNTID = value
            '    End Set
            'End Property

            'Dim fITEMNMBR As String
            '<Size(31)> _
            '<Persistent("ITEMNMBR")> _
            'Public Property ITEMNMBR() As String
            '    Get
            '        Return fITEMNMBR
            '    End Get
            '    Set(ByVal value As String)
            '        fITEMNMBR = value
            '    End Set
            'End Property
            'Dim fLOCNCODE As String
            '<Size(11)> _
            '<Persistent("LOCNCODE")> _
            'Public Property LOCNCODE() As String
            '    Get
            '        Return fLOCNCODE
            '    End Get
            '    Set(ByVal value As String)
            '        fLOCNCODE = value
            '    End Set
            'End Property

            'Dim fBINNMBR As String
            '<Size(21)> _
            '<Persistent("BINNMBR")> _
            'Public Property BINNMBR() As String
            '    Get
            '        Return fBINNMBR
            '    End Get
            '    Set(ByVal value As String)
            '        fBINNMBR = value
            '    End Set
            'End Property

            'Dim fDATERECD As DateTime
            '<Persistent("DATERECD")> _
            'Public Property DATERECD() As DateTime
            '    Get
            '        Return fDATERECD
            '    End Get
            '    Set(ByVal value As DateTime)
            '        fDATERECD = value
            '    End Set
            'End Property

            'Dim fDTSEQNUM As Decimal
            '<Persistent("DTSEQNUM")> _
            'Public Property DTSEQNUM() As Decimal
            '    Get
            '        Return fDTSEQNUM
            '    End Get
            '    Set(ByVal value As Decimal)
            '        fDTSEQNUM = value
            '    End Set
            'End Property

            'Dim fSERLTNUM As String
            '<Size(21)> _
            '<Persistent("SERLTNUM")> _
            'Public Property SERLTNUM() As String
            '    Get
            '        Return fSERLTNUM
            '    End Get
            '    Set(ByVal value As String)
            '        fSERLTNUM = value
            '    End Set
            'End Property
        End Structure
        Private _mOid As ItemStockCountSerialLotKey
        <Key()> _
        <Persistent()> _
        Private Property Oid() As ItemStockCountSerialLotKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As ItemStockCountSerialLotKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property
        <PersistentAlias("Oid.STCKCNTID")> _
        Public Property STCKCNTID() As String
            Get
                Return CType(EvaluateAlias("STCKCNTID"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("STCKCNTID", _mOid.STCKCNTID, Value)
            End Set
        End Property
        <PersistentAlias("Oid.ITEMNMBR")> _
        Public Property ITEMNMBR() As String
            Get
                Return CType(EvaluateAlias("ITEMNMBR"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("ITEMNMBR", _mOid.ITEMNMBR, Value)
            End Set
        End Property
        <PersistentAlias("Oid.LOCNCODE")> _
        Public Property LOCNCODE() As String
            Get
                Return CType(EvaluateAlias("LOCNCODE"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("LOCNCODE", _mOid.LOCNCODE, Value)
            End Set
        End Property
        <PersistentAlias("Oid.BINNMBR")> _
        Public Property BINNMBR() As String
            Get
                Return CType(EvaluateAlias("BINNMBR"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("BINNMBR", _mOid.BINNMBR, Value)
            End Set
        End Property
        <PersistentAlias("Oid.DATERECD")> _
        Public Property DATERECD() As DateTime
            Get
                Return EvaluateAlias("DATERECD")
            End Get
            Set(ByVal Value As DateTime)
                SetPropertyValue("DATERECD", _mOid.DATERECD, Value)
            End Set
        End Property

        <PersistentAlias("Oid.DTSEQNUM")> _
        Public Property DTSEQNUM() As Decimal
            Get
                Return EvaluateAlias("DTSEQNUM")
            End Get
            Set(ByVal Value As Decimal)
                SetPropertyValue("DTSEQNUM", _mOid.DTSEQNUM, Value)
            End Set
        End Property
        <PersistentAlias("Oid.SERLTNUM")> _
        Public Property SERLTNUM() As String
            Get
                Return CType(EvaluateAlias("SERLTNUM"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("SERLTNUM", _mOid.SERLTNUM, Value)
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
        Dim fCAPTUREDQTY As Decimal
        Public Property CAPTUREDQTY() As Decimal
            Get
                Return fCAPTUREDQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("CAPTUREDQTY", fCAPTUREDQTY, value)
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

        Dim fSERIALSTATUS As Short
        Public Property SERIALSTATUS() As Short
            Get
                Return fSERIALSTATUS
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("SERIALSTATUS", fSERIALSTATUS, value)
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
        Dim fQTYTYPE As Short
        Public Property QTYTYPE() As Short
            Get
                Return fQTYTYPE
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("QTYTYPE", fQTYTYPE, value)
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
        Dim fMFGDATE As DateTime
        Public Property MFGDATE() As DateTime
            Get
                Return fMFGDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MFGDATE", fMFGDATE, value)
            End Set
        End Property
        Dim fEXPNDATE As DateTime
        Public Property EXPNDATE() As DateTime
            Get
                Return fEXPNDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("EXPNDATE", fEXPNDATE, value)
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