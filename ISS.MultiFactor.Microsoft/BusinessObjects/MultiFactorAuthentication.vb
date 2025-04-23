Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Linq
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Text
Imports DevExpress.Data.Filtering
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.DC
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports DevExpress.Xpo
Imports Microsoft.VisualBasic
Imports OtpNet
Imports QRCoder

'<ImageName("BO_Contact")> _
'<DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")> _
'<DefaultListViewOptions(MasterDetailMode.ListViewOnly, False, NewItemRowPosition.None)> _
'<Persistent("DatabaseTableName")> _
<NonPersistent>
Public Class MultiFactorAuthentication ' Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    Inherits BaseObject ' Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    ' Use CodeRush To create XPO classes And properties With a few keystrokes.
    ' https://docs.devexpress.com/CodeRushForRoslyn/118557
    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub
    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        ' Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    End Sub


    Private _mUserSettings As MultifactorAuthenticationUserSettings
    <VisibleInDetailView(False)>
    Property UserSettings As MultifactorAuthenticationUserSettings
        Get
            Return _mUserSettings
        End Get
        Set(ByVal Value As MultifactorAuthenticationUserSettings)
            SetPropertyValue(Nameof(UserSettings), _mUserSettings, Value)
        End Set
    End Property
    
    Private _mUsername As String
    <Size(SizeAttribute.DefaultStringMappingFieldSize)>
    <VisibleInDetailView(False)>
    Property Username As String
        Get
            Return _mUsername
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(NameOf(Username), _mUsername, Value)
        End Set
    End Property


    <Persistent(NameOf(QRCode))>
    Private _mQRCode As Drawing.Image
    <PersistentAlias(NameOf(_mQRCode))>
    <ImageEditor(ListViewImageEditorMode:=ImageEditorMode.PictureEdit, DetailViewImageEditorMode:=ImageEditorMode.PictureEdit, DetailViewImageEditorFixedHeight:=200, DetailViewImageEditorFixedWidth:=200)>
    ReadOnly Property QRCode As Drawing.Image
        Get
            Return _mQRCode
        End Get
    End Property


    'Private _mQRCode As Drawing.Image

    'Property QRCode As Drawing.Image
    '    Get
    '        Return _mQRCode
    '    End Get
    '    Set(ByVal Value As Drawing.Image)
    '        SetPropertyValue(NameOf(QRCode), _mQRCode, Value)
    '    End Set
    'End Property

    Private _mAuthenticationCode As String
    <Size(255)>
    Property AuthenticationCode As String
        Get
            Return _mAuthenticationCode
        End Get
        Set(ByVal Value As String)
            SetPropertyValue(Nameof(AuthenticationCode), _mAuthenticationCode, Value)
        End Set
    End Property


    Public Sub SetupSecretKeyAndQrCode()
        UserSettings = Session.FindObject(Of MultifactorAuthenticationUserSettings)(New BinaryOperator("UserName", _mUsername))
        Dim secretKey(19) As Byte
        Dim strSecretKeyString As String
        If UserSettings Is Nothing Then
            UserSettings = New MultifactorAuthenticationUserSettings(Session)
            UserSettings.UserName = _mUsername
        End If
        If UserSettings.SecretKey = String.Empty Then
            Using rng As New RNGCryptoServiceProvider()
                rng.GetBytes(secretKey)
            End Using
            UserSettings.SecretKey = Base32Encoding.ToString(secretKey)

        Else
            secretKey = Base32Encoding.ToBytes(UserSettings.SecretKey)

        End If
        strSecretKeyString = UserSettings.SecretKey

        Dim issuer As String = MicrosoftModule.ApplicationName ' Change to your app's name
        Dim userName As String = Me.Username
        Dim qrCodeUri As String = $"otpauth://totp/{issuer}:{userName}?secret={strSecretKeyString}&issuer={issuer}"

        Using qrGenerator As New QRCodeGenerator()
            Dim qrCodeData = qrGenerator.CreateQrCode(qrCodeUri, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode = New QRCode(qrCodeData)
            _mQRCode = qrCode.GetGraphic(20)
            OnChanged("QRCode")
            'Using qrCodeImage = qrCode.GetGraphic(20)
            '    Using ms As New MemoryStream()
            '        qrCodeImage.Save(ms, Imaging.ImageFormat.Png)
            '        Return ms.ToArray()
            '    End Using
            'End Using
        End Using

    End Sub

    'Private _PersistentProperty As String
    '<XafDisplayName("My display name"), ToolTip("My hint message")> _
    '<ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(False)> _
    '<Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)> _
    'Public Property PersistentProperty() As String
    '    Get
    '        Return _PersistentProperty
    '    End Get
    '    Set(ByVal value As String)
    '        SetPropertyValue(nameof(PersistentProperty), _PersistentProperty, value)
    '    End Set
    'End Property

    '<Action(Caption:="My UI Action", ConfirmationMessage:="Are you sure?", ImageName:="Attention", AutoCommit:=True)> _
    'Public Sub ActionMethod()
    '    ' Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
    '    Me.PersistentProperty = "Paid"
    'End Sub
End Class
