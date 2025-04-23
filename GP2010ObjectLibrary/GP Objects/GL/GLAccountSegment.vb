Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.GL
    ''' <summary>
    ''' GP Table GL40200
    ''' </summary>
    ''' <remarks></remarks>
    <System.ComponentModel.DefaultProperty("DSCRIPTN")>
    <Persistent("GL40200")> _
    <OptimisticLocking(False)> _
    Public Class GLAccountSegment
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


        Public Structure SegmentKey
            Private _mSGMTNUMB As Integer
            <Persistent("SGMTNUMB")>
            Public Property SGMTNUMB As Integer
                Get
                    Return _mSGMTNUMB
                End Get
                Set(ByVal Value As Integer)
                    _mSGMTNUMB = Value
                End Set
            End Property
            Private _mSGMNTID As String
            <Persistent("SGMNTID")>
            Public Property SGMNTID As String
                Get
                    Return _mSGMNTID
                End Get
                Set(ByVal Value As String)
                    _mSGMNTID = Value
                End Set
            End Property
        End Structure

        Private _mOid As SegmentKey
        <Key()>
        <Persistent()>
        Public Property Oid As SegmentKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As SegmentKey)
                SetPropertyValue("Oid", _mOid, Value)
            End Set
        End Property
        Private _mDSCRIPTN As String
        Public Property DSCRIPTN As String
            Get
                Return _mDSCRIPTN
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("DSCRIPTN", _mDSCRIPTN, Value)
            End Set
        End Property
        Private _mSEGCOUNT As Integer
        Public Property SEGCOUNT As Integer
            Get
                Return _mSEGCOUNT
            End Get
            Set(ByVal Value As Integer)
                SetPropertyValue("SEGCOUNT", _mSEGCOUNT, Value)
            End Set
        End Property
        Private _mNOTEINDX As Integer
        Public Property NOTEINDX As Integer
            Get
                Return _mNOTEINDX
            End Get
            Set(ByVal Value As Integer)
                SetPropertyValue("NOTEINDX", _mNOTEINDX, Value)
            End Set
        End Property
        Private _mDEX_ROW_TS As Date
        Public Property DEX_ROW_TS As Date
            Get
                Return _mDEX_ROW_TS
            End Get
            Set(ByVal Value As Date)
                SetPropertyValue("DEX_ROW_TS", _mDEX_ROW_TS, Value)
            End Set
        End Property
        Private _mDEX_ROW_ID As Integer
        Public Property DEX_ROW_ID As Integer
            Get
                Return _mDEX_ROW_ID
            End Get
            Set(ByVal Value As Integer)
                SetPropertyValue("DEX_ROW_ID", _mDEX_ROW_ID, Value)
            End Set
        End Property


    End Class
End Namespace

