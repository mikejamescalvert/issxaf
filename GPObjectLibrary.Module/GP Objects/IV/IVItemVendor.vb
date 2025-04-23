Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV00103
    ''' </summary>
    <Persistent("IV00103")>
    <System.ComponentModel.DefaultProperty("Oid.ITEMNMBR")>
    <OptimisticLocking(False)>
    Public Class IVItemVendor
        Inherits XPLiteObject

        Public Structure IVItemVendorKey
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
            Private fVENDORID As String
            <Size(15)>
            <Persistent("VENDORID")>
            Public Property VENDORID() As String
                Get
                    Return fVENDORID
                End Get
                Set(ByVal value As String)
                    fVENDORID = value
                End Set
            End Property
            Private fITMVNDTY As Short
            <Persistent("ITMVNDTY")>
            Public Property ITMVNDTY() As Short
                Get
                    Return fITMVNDTY
                End Get
                Set(ByVal value As Short)
                    fITMVNDTY = value
                End Set
            End Property
        End Structure


        Private _mOid As IVItemVendorKey
        <Key()>
        <Persistent()>
        Public Property Oid As IVItemVendorKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As IVItemVendorKey)
                SetPropertyValue(Of IVItemVendorKey)("Oid", _mOid, Value)

            End Set
        End Property



        Dim fVNDITNUM As String
        <Size(31)>
        Public Property VNDITNUM() As String
            Get
                Return fVNDITNUM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDITNUM", fVNDITNUM, value)
            End Set
        End Property
        Dim fQTYRQSTN As Decimal
        Public Property QTYRQSTN() As Decimal
            Get
                Return fQTYRQSTN
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYRQSTN", fQTYRQSTN, value)
            End Set
        End Property
        Dim fQTYONORD As Decimal
        Public Property QTYONORD() As Decimal
            Get
                Return fQTYONORD
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTYONORD", fQTYONORD, value)
            End Set
        End Property
        Dim fQTY_Drop_Shipped As Decimal
        Public Property QTY_Drop_Shipped() As Decimal
            Get
                Return fQTY_Drop_Shipped
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("QTY_Drop_Shipped", fQTY_Drop_Shipped, value)
            End Set
        End Property
        Dim fLSTORDDT As DateTime
        Public Property LSTORDDT() As DateTime
            Get
                Return fLSTORDDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSTORDDT", fLSTORDDT, value)
            End Set
        End Property
        Dim fLSORDQTY As Decimal
        Public Property LSORDQTY() As Decimal
            Get
                Return fLSORDQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LSORDQTY", fLSORDQTY, value)
            End Set
        End Property
        Dim fLRCPTQTY As Decimal
        Public Property LRCPTQTY() As Decimal
            Get
                Return fLRCPTQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LRCPTQTY", fLRCPTQTY, value)
            End Set
        End Property
        Dim fLSRCPTDT As DateTime
        Public Property LSRCPTDT() As DateTime
            Get
                Return fLSRCPTDT
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("LSRCPTDT", fLSRCPTDT, value)
            End Set
        End Property
        Dim fLRCPTCST As Decimal
        Public Property LRCPTCST() As Decimal
            Get
                Return fLRCPTCST
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("LRCPTCST", fLRCPTCST, value)
            End Set
        End Property
        Dim fAVRGLDTM As Integer
        Public Property AVRGLDTM() As Integer
            Get
                Return fAVRGLDTM
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("AVRGLDTM", fAVRGLDTM, value)
            End Set
        End Property
        Dim fNORCTITM As Short
        Public Property NORCTITM() As Short
            Get
                Return fNORCTITM
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("NORCTITM", fNORCTITM, value)
            End Set
        End Property
        Dim fMINORQTY As Decimal
        Public Property MINORQTY() As Decimal
            Get
                Return fMINORQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MINORQTY", fMINORQTY, value)
            End Set
        End Property
        Dim fMAXORDQTY As Decimal
        Public Property MAXORDQTY() As Decimal
            Get
                Return fMAXORDQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("MAXORDQTY", fMAXORDQTY, value)
            End Set
        End Property
        Dim fECORDQTY As Decimal
        Public Property ECORDQTY() As Decimal
            Get
                Return fECORDQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ECORDQTY", fECORDQTY, value)
            End Set
        End Property
        Dim fVNDITDSC As String
        <Size(101)>
        Public Property VNDITDSC() As String
            Get
                Return fVNDITDSC
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("VNDITDSC", fVNDITDSC, value)
            End Set
        End Property
        Dim fLast_Originating_Cost As Decimal
        Public Property Last_Originating_Cost() As Decimal
            Get
                Return fLast_Originating_Cost
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("Last_Originating_Cost", fLast_Originating_Cost, value)
            End Set
        End Property
        Dim fLast_Currency_ID As String
        <Size(15)>
        Public Property Last_Currency_ID() As String
            Get
                Return fLast_Currency_ID
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Last_Currency_ID", fLast_Currency_ID, value)
            End Set
        End Property
        Dim fFREEONBOARD As Short
        Public Property FREEONBOARD() As Short
            Get
                Return fFREEONBOARD
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("FREEONBOARD", fFREEONBOARD, value)
            End Set
        End Property
        Dim fPRCHSUOM As String
        <Size(9)>
        Public Property PRCHSUOM() As String
            Get
                Return fPRCHSUOM
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("PRCHSUOM", fPRCHSUOM, value)
            End Set
        End Property
        Dim fCURRNIDX As Short
        Public Property CURRNIDX() As Short
            Get
                Return fCURRNIDX
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("CURRNIDX", fCURRNIDX, value)
            End Set
        End Property
        Dim fPLANNINGLEADTIME As Short
        Public Property PLANNINGLEADTIME() As Short
            Get
                Return fPLANNINGLEADTIME
            End Get
            Set(ByVal value As Short)
                SetPropertyValue(Of Short)("PLANNINGLEADTIME", fPLANNINGLEADTIME, value)
            End Set
        End Property
        Dim fORDERMULTIPLE As Decimal
        Public Property ORDERMULTIPLE() As Decimal
            Get
                Return fORDERMULTIPLE
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("ORDERMULTIPLE", fORDERMULTIPLE, value)
            End Set
        End Property
        Dim fMNFCTRITMNMBR As String
        <Size(31)>
        Public Property MNFCTRITMNMBR() As String
            Get
                Return fMNFCTRITMNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("MNFCTRITMNMBR", fMNFCTRITMNMBR, value)
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
