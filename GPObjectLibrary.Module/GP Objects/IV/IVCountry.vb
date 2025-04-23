Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Namespace Objects.IV
    ''' <summary>
    ''' GP Table VAT10007
    ''' </summary>
    <Persistent("VAT10007")>
    <OptimisticLocking(False)>
    <System.ComponentModel.DefaultProperty("Oid.INTRSTTFLD")>
    Public Class IVCountry
        Inherits XPLiteObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
            ' This constructor is used when an object is loaded from a persistent storage.
            ' Do not place any code here or place it only when the IsLoading property is false:
            ' if (!IsLoading){
            '   It is now OK to place your initialization code here.
            ' }
            ' or as an alternative, move your initialization code into the AfterConstruction method.
        End Sub
        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            ' Place here your initialization code.
        End Sub

        Public Structure IVCountryKey
            Private _mINTRSTTTYP As Short
            <Persistent("INTRSTTTYP")>
            Public Property INTRSTTTYP As Short
                Get
                    Return _mINTRSTTTYP
                End Get
                Set(ByVal Value As Short)
                    _mINTRSTTTYP = Value
                End Set
            End Property
            Private _mINTRSTTFLD As String
            <Persistent("INTRSTTFLD")>
            <Size(7)>
            Public Property INTRSTTFLD As String
                Get
                    Return _mINTRSTTFLD
                End Get
                Set(ByVal Value As String)
                    _mINTRSTTFLD = Value
                End Set
            End Property
        End Structure


#Region "Properties"
        <Key()>
        <Persistent()>
        Private _mOid As IVCountryKey
        Public Property Oid As IVCountryKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As IVCountryKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property


        Private _mINTRSTTFLDDSC As String
        <Size(31)>
        Public Property INTRSTTFLDDSC As String
            Get
                Return _mINTRSTTFLDDSC
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("INTRSTTFLDDSC", _mINTRSTTFLDDSC, Value)
            End Set
        End Property

        Private _mNOTEINDX As Double
        Public Property NOTEINDX As Double
            Get
                Return _mNOTEINDX
            End Get
            Set(ByVal Value As Double)
                SetPropertyValue("NOTEINDX", _mNOTEINDX, Value)
            End Set
        End Property

        Dim _mDEX_ROW_ID As Integer
        Public Property DEX_ROW_ID() As Integer
            Get
                Return _mDEX_ROW_ID
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("DEX_ROW_ID", _mDEX_ROW_ID, value)
            End Set
        End Property

#End Region
    End Class
End Namespace

