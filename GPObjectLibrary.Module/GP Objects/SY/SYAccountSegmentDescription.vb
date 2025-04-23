Imports System
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering
Namespace Objects.SY
    ''' <summary>
    ''' GP Table SY00300
    ''' </summary>
    ''' <remarks></remarks>
    <Persistent("SY00300")>
    Public Class SYAccountSegmentDescription
        Inherits XPLiteObject

        Private _mSGMTNUMB As Integer
        <Key(True)>
        Property SGMTNUMB As Integer
            Get
                Return _mSGMTNUMB
            End Get
            Set(ByVal Value As Integer)
                SetPropertyValue("SGMTNUMB", _mSGMTNUMB, Value)
            End Set
        End Property

        Private _mSGMTNAME As String
        Property SGMTNAME As String
            Get
                Return _mSGMTNAME
            End Get
            Set(ByVal Value As String)
                SetPropertyValue("SGMTNAME", _mSGMTNAME, Value)
            End Set
        End Property

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Public Sub New()
            MyBase.New(Session.DefaultSession)
        End Sub
    End Class

End Namespace
