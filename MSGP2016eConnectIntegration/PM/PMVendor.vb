Imports System
Imports DevExpress.Xpo

Namespace PM

    Public Class PMVendor
        Private _mVendorID As String
        Public Property VendorID As String
            Get
                Return _mVendorID
            End Get
            Set(ByVal Value As String)
                _mVendorID = Value
            End Set
        End Property
        Private _mVendorName As String
        Public Property VendorName As String
            Get
                Return _mVendorName
            End Get
            Set(ByVal Value As String)
                _mVendorName = Value
            End Set
        End Property
        Private _mAddress1 As String
        Public Property Address1 As String
            Get
                Return _mAddress1
            End Get
            Set(ByVal Value As String)
                _mAddress1 = Value
            End Set
        End Property
        Private _mAddress2 As String
        Public Property Address2 As String
            Get
                Return _mAddress2
            End Get
            Set(ByVal Value As String)
                _mAddress2 = Value
            End Set
        End Property
        Private _mAddress3 As String
        Public Property Address3 As String
            Get
                Return _mAddress3
            End Get
            Set(ByVal Value As String)
                _mAddress3 = Value
            End Set
        End Property
        Private _mCity As String
        Public Property City As String
            Get
                Return _mCity
            End Get
            Set(ByVal Value As String)
                _mCity = Value
            End Set
        End Property
        Private _mState As String
        Public Property State As String
            Get
                Return _mState
            End Get
            Set(ByVal Value As String)
                _mState = Value
            End Set
        End Property
        Private _mZipCode As String
        Public Property ZipCode As String
            Get
                Return _mZipCode
            End Get
            Set(ByVal Value As String)
                _mZipCode = Value
            End Set
        End Property
        Private _mCountry As String
        Public Property Country As String
            Get
                Return _mCountry
            End Get
            Set(ByVal Value As String)
                _mCountry = Value
            End Set
        End Property
        Private _mVendorClassId As String
        Public Property VendorClassId As String
            Get
                Return _mVendorClassId
            End Get
            Set(ByVal Value As String)
                _mVendorClassId = Value
            End Set
        End Property

        
        
    End Class

End Namespace