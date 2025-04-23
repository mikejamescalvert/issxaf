Imports System
Imports DevExpress.Xpo

Namespace Objects.MOP

    Public Structure UnpostedSerialNumberKey
        Private _mMANUFACTUREORDER_I As String
        <Persistent("MANUFACTUREORDER_I")> _
        Public Property MANUFACTUREORDER_I() As String
            Get
                Return _mMANUFACTUREORDER_I
            End Get
            Set(ByVal value As String)
                If _mMANUFACTUREORDER_I = value Then
                    Return
                End If
                _mMANUFACTUREORDER_I = value
            End Set
        End Property
        Private _mITEMNMBR As String
        <Persistent("ITEMNMBR")> _
        Public Property ITEMNMBR() As String
            Get
                Return _mITEMNMBR
            End Get
            Set(ByVal value As String)
                If _mITEMNMBR = value Then
                    Return
                End If
                _mITEMNMBR = value
            End Set
        End Property
        Private _mSERLNMBR As String
        <Persistent("SERLNMBR")> _
        Public Property SERLNMBR() As String
            Get
                Return _mSERLNMBR
            End Get
            Set(ByVal value As String)
                If _mSERLNMBR = value Then
                    Return
                End If
                _mSERLNMBR = value
            End Set
        End Property
    End Structure
    ''' <summary>
    ''' GP Table MOP1042
    ''' </summary>
    <Persistent("MOP1042")> _
    <OptimisticLocking(False)> _
    Public Class MOPUnpostedSerialNumber
        Inherits XPLiteObject
        Dim fOid As UnpostedSerialNumberKey
        <Key()> _
        <Persistent()> _
        Public Property Oid() As UnpostedSerialNumberKey
            Get
                Return fOid
            End Get
            Set(ByVal value As UnpostedSerialNumberKey)
                SetPropertyValue(Of UnpostedSerialNumberKey)("Oid", fOid, value)
            End Set
        End Property
        'Dim fMANUFACTUREORDER_I As String
        '<Size(31)> _
        'Public Property MANUFACTUREORDER_I() As String
        '    Get
        '        Return fMANUFACTUREORDER_I
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("MANUFACTUREORDER_I", fMANUFACTUREORDER_I, value)
        '    End Set
        'End Property
        'Dim fITEMNMBR As String
        '<Size(31)> _
        'Public Property ITEMNMBR() As String
        '    Get
        '        Return fITEMNMBR
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ITEMNMBR", fITEMNMBR, value)
        '    End Set
        'End Property
        'Dim fSERLNMBR As String
        '<Size(21)> _
        'Public Property SERLNMBR() As String
        '    Get
        '        Return fSERLNMBR
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("SERLNMBR", fSERLNMBR, value)
        '    End Set
        'End Property
        Dim fSERLTQTY As Decimal
        Public Property SERLTQTY() As Decimal
            Get
                Return fSERLTQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SERLTQTY", fSERLTQTY, value)
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
