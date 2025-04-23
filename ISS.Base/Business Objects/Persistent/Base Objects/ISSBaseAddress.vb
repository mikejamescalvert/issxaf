Imports System

Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.Validation
Imports DevExpress.Persistent.BaseImpl

<System.ComponentModel.DefaultProperty("FullAddress"), ObjectCaptionFormat("Address")> _
<System.ComponentModel.ReadOnly(False)> _
<System.ComponentModel.DisplayName("Address")> _
Public Class ISSBaseAddress
    Inherits BaseObject

#Region "Non Persistent Properties"
    Public ReadOnly Property FullAddress() As String
        Get
            Return String.Format("{0} {1} {2} {3} {4} {5}", _mStreet1, _mStreet2, _mCity, _mState, _mZipCode, _mCounty)
        End Get
    End Property
#End Region
#Region "Persistent Properties"
    Private _mCity As String
    Private _mCounty As String
    Private _mState As String
    Private _mStreet1 As String
    Private _mStreet2 As String
    Private _mZipCode As String
    <Size(150)> _
    Public Property City() As String
        Get
            Return _mCity
        End Get
        Set(ByVal value As String)
            SetPropertyValue("City", _mCity, value)
        End Set
    End Property
    <Size(150)> _
    Public Property County() As String
        Get
            Return _mCounty
        End Get
        Set(ByVal value As String)
            SetPropertyValue("County", _mCounty, value)
        End Set
    End Property
    Public Property State() As String
        Get
            Return _mState
        End Get
        Set(ByVal value As String)
            SetPropertyValue("State", _mState, value)
        End Set
    End Property
    <Size(150)> _
    Public Property Street1() As String
        Get
            Return _mStreet1
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Street1", _mStreet1, value)
        End Set
    End Property
    <Size(150)> _
    Public Property Street2() As String
        Get
            Return _mStreet2
        End Get
        Set(ByVal value As String)
            SetPropertyValue("Street2", _mStreet2, value)
        End Set
    End Property
    Public Property ZipCode() As String
        Get
            Return _mZipCode
        End Get
        Set(ByVal value As String)
            SetPropertyValue("ZipCode", _mZipCode, value)
        End Set
    End Property
#End Region
#Region "Behaviors"
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
#End Region

End Class
