Imports System
Imports DevExpress.Xpo
Imports System.ComponentModel
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace Objects.IV
    ''' <summary>
    ''' GP Table IV40600
    ''' </summary>
    <Persistent("IV40600")>
    <OptimisticLocking(False)>
    Public Class IVCategoryValue
        Inherits XPLiteObject

        Public Structure IVCategoryValueKeyStructure
            Private _mUSCATVAL As String
            <Persistent("USCATVAL")>
            <Size(11)>
            <Browsable(False)>
            Public Property USCATVAL() As String
                Get
                    Return _mUSCATVAL
                End Get
                Set(ByVal value As String)
                    _mUSCATVAL = value
                End Set
            End Property
            Private _mUSCATNUM As Short
            <Persistent("USCATNUM")>
            <Browsable(False)>
            Public Property USCATNUM() As Short
                Get
                    Return _mUSCATNUM
                End Get
                Set(ByVal value As Short)
                    _mUSCATNUM = value
                End Set
            End Property
        End Structure

        Private _mIVCategoryValueKey As IVCategoryValueKeyStructure
        <Persistent()>
        <Key()>
        Public Property Oid() As IVCategoryValueKeyStructure
            Get
                Return _mIVCategoryValueKey
            End Get
            Set(ByVal value As IVCategoryValueKeyStructure)
                _mIVCategoryValueKey = value
            End Set
        End Property

        <PersistentAlias("Oid.USCATVAL")>
        Public Property USCATVAL() As String
            Get
                Return CType(EvaluateAlias("USCATVAL"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("USCATVAL", _mIVCategoryValueKey.USCATVAL, Value)
            End Set
        End Property

        <PersistentAlias("Oid.USCATNUM")>
        Public Property USCATNUM() As String
            Get
                Return CType(EvaluateAlias("USCATNUM"), String)
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("USCATNUM", _mIVCategoryValueKey.USCATVAL, Value)
            End Set
        End Property



        Dim fImage_URL As String
        <Size(255)>
        Public Property Image_URL() As String
            Get
                Return fImage_URL
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("Image_URL", fImage_URL, value)
            End Set
        End Property
        Dim fUserCatLongDescr As String
        <Size(255)>
        Public Property UserCatLongDescr() As String
            Get
                Return fUserCatLongDescr
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("UserCatLongDescr", fUserCatLongDescr, value)
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