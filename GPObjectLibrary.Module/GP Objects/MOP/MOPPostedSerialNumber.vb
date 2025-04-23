Imports System
Imports DevExpress.Xpo

Namespace Objects.MOP

    Public Structure PostedSerialNumberKey
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
        Private _mDOCNUMBR As String
        <Persistent("DOCNUMBR")> _
        Public Property DOCNUMBR() As String
            Get
                Return _mDOCNUMBR
            End Get
            Set(ByVal value As String)
                If _mDOCNUMBR = value Then
                    Return
                End If
                _mDOCNUMBR = value
            End Set
        End Property
        Private _mCALLEDBY As Short
        <Persistent("CALLEDBY")> _
        Public Property CALLEDBY() As Short
            Get
                Return _mCALLEDBY
            End Get
            Set(ByVal value As Short)
                If _mCALLEDBY = value Then
                    Return
                End If
                _mCALLEDBY = value
            End Set
        End Property
        Private _mSERLTNUM As String
        <Persistent("SERLTNUM")> _
        Public Property SERLTNUM() As String
            Get
                Return _mSERLTNUM
            End Get
            Set(ByVal value As String)
                If _mSERLTNUM = value Then
                    Return
                End If
                _mSERLTNUM = value
            End Set
        End Property
        Private _mLineNumber As Short
        <Persistent("LineNumber")> _
        Public Property LineNumber() As Short
            Get
                Return _mLineNumber
            End Get
            Set(ByVal value As Short)
                If _mLineNumber = value Then
                    Return
                End If
                _mLineNumber = value
            End Set
        End Property

    End Structure
    ''' <summary>
    ''' GP Table MOP1040
    ''' </summary>
    <OptimisticLocking(False)> _
    <Persistent("MOP1040")> _
    Public Class MOPPostedSerialNumber
        Inherits XPLiteObject
        Dim fOid As PostedSerialNumberKey
        <Key()> _
        <Persistent()> _
        Public Property Oid() As PostedSerialNumberKey
            Get
                Return fOid
            End Get
            Set(ByVal value As PostedSerialNumberKey)
                SetPropertyValue(Of PostedSerialNumberKey)("Oid", fOid, value)
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
        'Dim fDOCNUMBR As String
        '<Size(21)> _
        'Public Property DOCNUMBR() As String
        '    Get
        '        Return fDOCNUMBR
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("DOCNUMBR", fDOCNUMBR, value)
        '    End Set
        'End Property
        'Dim fCALLEDBY As Short
        'Public Property CALLEDBY() As Short
        '    Get
        '        Return fCALLEDBY
        '    End Get
        '    Set(ByVal value As Short)
        '        SetPropertyValue(Of Short)("CALLEDBY", fCALLEDBY, value)
        '    End Set
        'End Property
        'Dim fSERLTNUM As String
        '<Size(21)> _
        'Public Property SERLTNUM() As String
        '    Get
        '        Return fSERLTNUM
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("SERLTNUM", fSERLTNUM, value)
        '    End Set
        'End Property
        'Dim fLineNumber As Short
        'Public Property LineNumber() As Short
        '    Get
        '        Return fLineNumber
        '    End Get
        '    Set(ByVal value As Short)
        '        SetPropertyValue(Of Short)("LineNumber", fLineNumber, value)
        '    End Set
        'End Property
        Dim fITEMNMBR As String
        <Size(31)> _
        Public Property ITEMNMBR() As String
            Get
                Return fITEMNMBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ITEMNMBR", fITEMNMBR, value)
            End Set
        End Property
        Dim fSERLTQTY As Decimal
        Public Property SERLTQTY() As Decimal
            Get
                Return fSERLTQTY
            End Get
            Set(ByVal value As Decimal)
                SetPropertyValue(Of Decimal)("SERLTQTY", fSERLTQTY, value)
            End Set
        End Property
        Dim fIVDOCNBR As String
        <Size(17)> _
        Public Property IVDOCNBR() As String
            Get
                Return fIVDOCNBR
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("IVDOCNBR", fIVDOCNBR, value)
            End Set
        End Property
        Dim fBIN As String
        <Size(15)> _
        Public Property BIN() As String
            Get
                Return fBIN
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("BIN", fBIN, value)
            End Set
        End Property
        Dim fTO_SITE_I As String
        <Size(11)> _
        Public Property TO_SITE_I() As String
            Get
                Return fTO_SITE_I
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("TO_SITE_I", fTO_SITE_I, value)
            End Set
        End Property
        Dim fPRENTRDNMBR As Byte
        Public Property PRENTRDNMBR() As Byte
            Get
                Return fPRENTRDNMBR
            End Get
            Set(ByVal value As Byte)
                SetPropertyValue(Of Byte)("PRENTRDNMBR", fPRENTRDNMBR, value)
            End Set
        End Property
        Dim fParent_Component_ID As Integer
        Public Property Parent_Component_ID() As Integer
            Get
                Return fParent_Component_ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("Parent_Component_ID", fParent_Component_ID, value)
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
        Dim fMFGDATE As DateTime
        Public Property MFGDATE() As DateTime
            Get
                Return fMFGDATE
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("MFGDATE", fMFGDATE, value)
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
