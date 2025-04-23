Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace Objects.SOP
    ''' <summary>
    ''' GP Table SOP10106
    ''' </summary>
    <Persistent("SOP10106")>
    <OptimisticLocking(False)>
    Public Class SOPSalesOrderHeaderUserDefinedField
        Inherits XPLiteObject

        Public Structure SalesOrderHeaderUserDefinedFieldsKey
            Private fSOPTYPE As Short
            <Persistent("SOPTYPE")>
            Public Property SOPTYPE() As Short
                Get
                    Return fSOPTYPE
                End Get
                Set(ByVal value As Short)
                    fSOPTYPE = value
                End Set
            End Property
            Private fSOPNUMBE As String
            <Size(21)>
            <Persistent("SOPNUMBE")>
            Public Property SOPNUMBE() As String
                Get
                    Return fSOPNUMBE
                End Get
                Set(ByVal value As String)
                    fSOPNUMBE = value
                End Set
            End Property
        End Structure

        Dim fOid As SalesOrderHeaderUserDefinedFieldsKey
        <Key()>
        <Persistent()>
        Public Property Oid() As SalesOrderHeaderUserDefinedFieldsKey
            Get
                Return fOid
            End Get
            Set(ByVal value As SalesOrderHeaderUserDefinedFieldsKey)
                SetPropertyValue(Of SalesOrderHeaderUserDefinedFieldsKey)("Oid", fOid, value)
            End Set
        End Property


        Dim fUSRDAT01 As DateTime
        Public Property USRDAT01() As DateTime
            Get
                Return fUSRDAT01
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("USRDAT01", fUSRDAT01, value)
            End Set
        End Property
        Dim fUSRDAT02 As DateTime
        Public Property USRDAT02() As DateTime
            Get
                Return fUSRDAT02
            End Get
            Set(ByVal value As DateTime)
                SetPropertyValue(Of DateTime)("USRDAT02", fUSRDAT02, value)
            End Set
        End Property
        Dim fUSRTAB01 As String
        <Size(21)>
        Public Property USRTAB01() As String
            Get
                Return fUSRTAB01
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USRTAB01", fUSRTAB01, value)
            End Set
        End Property
        Dim fUSRTAB09 As String
        <Size(21)>
        Public Property USRTAB09() As String
            Get
                Return fUSRTAB09
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USRTAB09", fUSRTAB09, value)
            End Set
        End Property
        Dim fUSRTAB03 As String
        <Size(21)>
        Public Property USRTAB03() As String
            Get
                Return fUSRTAB03
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USRTAB03", fUSRTAB03, value)
            End Set
        End Property
        Dim fUSERDEF1 As String
        <Size(21)>
        Public Property USERDEF1() As String
            Get
                Return fUSERDEF1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERDEF1", fUSERDEF1, value)
            End Set
        End Property
        Dim fUSERDEF2 As String
        <Size(21)>
        Public Property USERDEF2() As String
            Get
                Return fUSERDEF2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USERDEF2", fUSERDEF2, value)
            End Set
        End Property
        Dim fUSRDEF03 As String
        <Size(21)>
        Public Property USRDEF03() As String
            Get
                Return fUSRDEF03
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USRDEF03", fUSRDEF03, value)
            End Set
        End Property
        Dim fUSRDEF04 As String
        <Size(21)>
        Public Property USRDEF04() As String
            Get
                Return fUSRDEF04
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USRDEF04", fUSRDEF04, value)
            End Set
        End Property
        Dim fUSRDEF05 As String
        <Size(21)>
        Public Property USRDEF05() As String
            Get
                Return fUSRDEF05
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("USRDEF05", fUSRDEF05, value)
            End Set
        End Property
        Dim fCOMMENT_1 As String
        <Size(51)>
        Public Property COMMENT_1() As String
            Get
                Return fCOMMENT_1
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT_1", fCOMMENT_1, value)
            End Set
        End Property
        Dim fCOMMENT_2 As String
        <Size(51)>
        Public Property COMMENT_2() As String
            Get
                Return fCOMMENT_2
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT_2", fCOMMENT_2, value)
            End Set
        End Property
        Dim fCOMMENT_3 As String
        <Size(51)>
        Public Property COMMENT_3() As String
            Get
                Return fCOMMENT_3
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT_3", fCOMMENT_3, value)
            End Set
        End Property
        Dim fCOMMENT_4 As String
        <Size(51)>
        Public Property COMMENT_4() As String
            Get
                Return fCOMMENT_4
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("COMMENT_4", fCOMMENT_4, value)
            End Set
        End Property

        '<Persistent("DEX_ROW_ID")> _
        'Private _mDEX_ROW_ID As Integer
        'Protected Overridable Sub SetDEX_ROW_ID(ByVal Value As Integer)
        '    SetPropertyValue("DEX_ROW_ID", _mDEX_ROW_ID, Value)
        'End Sub
        '<PersistentAlias("_mDEX_ROW_ID")> _
        'Public ReadOnly Property DEX_ROW_ID() As Integer
        '    Get
        '        Return _mDEX_ROW_ID
        '    End Get
        'End Property


        Dim fCMMTTEXT As String
        <Size(2147483647)>
        Public Property CMMTTEXT() As String
            Get
                Return fCMMTTEXT
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("CMMTTEXT", fCMMTTEXT, value)
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
