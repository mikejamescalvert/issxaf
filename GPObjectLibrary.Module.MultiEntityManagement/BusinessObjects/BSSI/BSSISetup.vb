Imports DevExpress.Xpo
Imports GPObjectLibrary.Module.Objects.SY

Namespace BusinessObjects.BSSI
    <Persistent("B3900100")>
    <OptimisticLocking(False)>
    Public Class BSSISetup
        Inherits XPLiteObject
        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _mSETUPKEY As Integer
        <Key(False)>
        Property SETUPKEY As Integer
            Get
                Return _mSETUPKEY
            End Get
            Set(ByVal Value As Integer)
                SetPropertyValue("SETUPKEY", _mSETUPKEY, Value)
            End Set
        End Property
        Private _mFacilitySegmentDescription As String
        <Persistent("BSSI_Facility_Segment")>
        Property FacilitySegmentDescription As String
            Get
                Return _mFacilitySegmentDescription
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("FacilitySegmentDescription", _mFacilitySegmentDescription, Value)
            End Set
        End Property
        <PersistentAlias("[<SYAccountSegmentDescription>][SGMTNAME = ^.FacilitySegmentDescription].Single()")>
        Public ReadOnly Property FacilitySegment As SYAccountSegmentDescription
            Get
                Return EvaluateAlias("FacilitySegment")
            End Get
        End Property
    End Class
End Namespace

