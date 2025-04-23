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
    ''' GP Table SOP10107
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("SOP10107")> _
    <OptimisticLocking(False)> _
    Public Class SOPTrackingNumber
        Inherits XPBaseObject
        Public Structure SOPTrackingNumbersKey

            Private fSOPNUMBE As String
            <Size(21)> _
            <Persistent("SOPNUMBE")> _
            Public Property SOPNUMBE() As String
                Get
                    Return fSOPNUMBE
                End Get
                Set(ByVal value As String)
                    fSOPNUMBE = value
                End Set
            End Property
            Private fSOPTYPE As Short
            <Persistent("SOPTYPE")> _
            Public Property SOPTYPE() As Short
                Get
                    Return fSOPTYPE
                End Get
                Set(ByVal value As Short)
                    fSOPTYPE = value
                End Set
            End Property
            Private fTracking_Number As String
            <Persistent("Tracking_Number")> _
            Public Property Tracking_Number() As String
                Get
                    Return fTracking_Number
                End Get
                Set(ByVal value As String)
                    fTracking_Number = value
                End Set
            End Property

        End Structure


#Region "Properties"

        Private _mOid As SOPTrackingNumbersKey
        <Key()> _
        <Persistent()> _
        Public Property Oid() As SOPTrackingNumbersKey
            Get
                Return _mOid
            End Get
            Set(ByVal Value As SOPTrackingNumbersKey)
                SetPropertyValue("Oid", _mOid, Value)
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
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
#End Region

    End Class
End Namespace

