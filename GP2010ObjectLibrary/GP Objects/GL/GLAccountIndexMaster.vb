Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.GL
	''' <summary>
	''' GP Table GL00105
	''' </summary>
	''' <remarks></remarks>
    <System.ComponentModel.DefaultProperty("SummaryInfo")>
    <Persistent("GL00105")> _
    <OptimisticLocking(False)> _
    Public Class GLAccountIndexMaster
        Inherits XPLiteObject
        Dim fACTINDX As Integer
        <Key()> _
        Public Property ACTINDX() As Integer
            Get
                Return fACTINDX
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("ACTINDX", fACTINDX, value)
                OnChanged("AccountTitle")
            End Set
        End Property
		<PersistentAlias("concat(ACTNUMST,' ',isnull(AccountMaster.ACTDESCR,''))")>
		Public ReadOnly Property SummaryInfo As String
			Get
				Return EvaluateAlias("SummaryInfo")	' String.Format("{0}/{1}", Me.ACTNUMST, Me.AccountTitle)
			End Get
		End Property

        'Dim fACTNUMBR_1 As String
        '<Size(9)>
        'Public Property ACTNUMBR_1() As String
        '    Get
        '        Return fACTNUMBR_1
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ACTNUMBR_1", fACTNUMBR_1, value)
        '    End Set
        'End Property
        'Dim fACTNUMBR_2 As String
        '<Size(9)>
        'Public Property ACTNUMBR_2() As String
        '    Get
        '        Return fACTNUMBR_2
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ACTNUMBR_2", fACTNUMBR_2, value)
        '    End Set
        'End Property
        'Dim fACTNUMBR_3 As String
        '<Size(9)>
        'Public Property ACTNUMBR_3() As String
        '    Get
        '        Return fACTNUMBR_3
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ACTNUMBR_3", fACTNUMBR_3, value)
        '    End Set
        'End Property
        'Dim fACTNUMBR_4 As String
        '<Size(9)>
        'Public Property ACTNUMBR_4() As String
        '    Get
        '        Return fACTNUMBR_4
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ACTNUMBR_4", fACTNUMBR_4, value)
        '    End Set
        'End Property
        'Dim fACTNUMBR_5 As String
        '<Size(9)>
        'Public Property ACTNUMBR_5() As String
        '    Get
        '        Return fACTNUMBR_5
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ACTNUMBR_5", fACTNUMBR_5, value)
        '    End Set
        'End Property
        'Dim fACTNUMBR_6 As String
        '<Size(9)>
        'Public Property ACTNUMBR_6() As String
        '    Get
        '        Return fACTNUMBR_6
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ACTNUMBR_6", fACTNUMBR_6, value)
        '    End Set
        'End Property
        'Dim fACTNUMBR_7 As String
        '<Size(9)>
        'Public Property ACTNUMBR_7() As String
        '    Get
        '        Return fACTNUMBR_7
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ACTNUMBR_7", fACTNUMBR_7, value)
        '    End Set
        'End Property
        'Dim fACTNUMBR_8 As String
        '<Size(9)>
        'Public Property ACTNUMBR_8() As String
        '    Get
        '        Return fACTNUMBR_8
        '    End Get
        '    Set(ByVal value As String)
        '        SetPropertyValue(Of String)("ACTNUMBR_8", fACTNUMBR_8, value)
        '    End Set
        'End Property
        Dim fACTNUMST As String
        <System.ComponentModel.DisplayName("Account Number")>
        <Size(129)> _
        Public Property ACTNUMST() As String
            Get
                Return fACTNUMST
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ACTNUMST", fACTNUMST, value)
            End Set
        End Property

		<PersistentAlias("[<GLAccountMaster>][ACTINDX = ^.ACTINDX].Single()")>
		Public ReadOnly Property AccountMaster As GLAccountMaster
			Get
				'Dim xpo As GLAccountMaster = Session.FindObject(Of GLAccountMaster)(New BinaryOperator("ACTINDX", Me.ACTINDX))
				'If xpo IsNot Nothing Then
				'    Return xpo.ACTDESCR
				'Else
				'    Return Nothing
				'End If
				Return EvaluateAlias("AccountMaster")
			End Get
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
