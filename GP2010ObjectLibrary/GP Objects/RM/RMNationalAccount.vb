Imports System
Imports DevExpress.Xpo
Namespace Objects.RM
    ''' <summary>
    ''' GP Table RM00105 - National Account Master Table
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("RM00105")>
	Public Class RMNationalAccount
		Inherits XPLiteObject

#Region "Properties"
		Private _mCPRCSTNM As String
		<Key>
		<Size(15)>
		Public Property CPRCSTNM As String
			Get
				Return _mCPRCSTNM
			End Get
			Set(ByVal Value As String)
				_mCPRCSTNM = Value
			End Set
		End Property
		Private _mNAALLOWRECEIPTS As Byte
		Public Property NAALLOWRECEIPTS As Byte
			Get
				Return _mNAALLOWRECEIPTS
			End Get
			Set(ByVal Value As Byte)
				_mNAALLOWRECEIPTS = Value
			End Set
		End Property

		Private _mNACREDITCHECK As Byte
		Public Property NACREDITCHECK As Byte
			Get
				Return _mNACREDITCHECK
			End Get
			Set(ByVal Value As Byte)
				_mNACREDITCHECK = Value
			End Set
		End Property
		Private _mNAFINANCECHARGE As Byte
		Public Property NAFINANCECHARGE As Byte
			Get
				Return _mNAFINANCECHARGE
			End Get
			Set(ByVal Value As Byte)
				_mNAFINANCECHARGE = Value
			End Set
		End Property
		Private _mNAHOLDINACTIVE As Byte
		Public Property NAHOLDINACTIVE As Byte
			Get
				Return _mNAHOLDINACTIVE
			End Get
			Set(ByVal Value As Byte)
				_mNAHOLDINACTIVE = Value
			End Set
		End Property
		Private _mNADEFPARENTVEN As Byte
		Public Property NADEFPARENTVEN As Byte
			Get
				Return _mNADEFPARENTVEN
			End Get
			Set(ByVal Value As Byte)
				_mNADEFPARENTVEN = Value
			End Set
		End Property
		Private _mNOTEINDX As Decimal
		Public Property NOTEINDX As Decimal
			Get
				Return _mNOTEINDX
			End Get
			Set(ByVal Value As Decimal)
				_mNOTEINDX = Value
			End Set
		End Property
		Private _mCREATDDT As DateTime
		Public Property CREATDDT As DateTime

			Get
				Return _mCREATDDT
			End Get
			Set(ByVal Value As DateTime)
				_mCREATDDT = Value
			End Set
		End Property
		Private _mMODIFDT As DateTime
		Public Property MODIFDT As DateTime
			Get
				Return _mMODIFDT
			End Get
			Set(ByVal Value As DateTime)
				_mMODIFDT = Value
			End Set
		End Property




#End Region


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
