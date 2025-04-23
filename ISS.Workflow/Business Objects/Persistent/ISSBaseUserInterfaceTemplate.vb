Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.Reflection

<System.ComponentModel.ReadOnly(False)> _
<System.ComponentModel.DisplayName("UserInterfaceTemplate")> _
<Serializable()> _
Public Class ISSBaseUserInterfaceTemplate
    Inherits BaseObject

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal session As Session)
        MyBase.New(session)
    End Sub

#Region "Associations"
    <Association("ObjectTemplate-PropertyTemplates")> _
    <Aggregated()> _
    Public ReadOnly Property PropertyTemplates() As XPCollection(Of ISSBaseEditorStateTemplate)
        Get
            Return GetCollection(Of ISSBaseEditorStateTemplate)("PropertyTemplates")
        End Get
    End Property
#End Region

#Region "Persistent Properties"
    Private _mObjectCustomization As ISSBaseBusinessRules
    Private _mTemplateName As String
    <Association("ObjectCustomization-ObjectTemplates")> _
    <Xml.Serialization.XmlIgnore()> _
    Public Property ObjectCustomization() As ISSBaseBusinessRules
        Get
            Return _mObjectCustomization
        End Get
        Set(ByVal value As ISSBaseBusinessRules)
            If _mObjectCustomization Is value Then
                Return
            End If
            _mObjectCustomization = value
            'If Me.IsLoading = False Then
            '    BuildDefaultProperties()
            'End If
        End Set
    End Property
    Public Property TemplateName() As String
        Get
            Return _mTemplateName
        End Get
        Set(ByVal value As String)
            If String.Compare(_mTemplateName, value, False) = 0 Then
                Return
            End If
            _mTemplateName = value
        End Set
    End Property
#End Region

    Protected Overrides Sub OnLoading()
        MyBase.OnLoading()
    End Sub

    Protected Overrides Sub OnLoaded()
        MyBase.OnLoaded()
        'BuildDefaultProperties()
    End Sub

    Public Sub PreloadEditorTemplates()
        SetupValues()
    End Sub

    Private _mBuildProperties As New List(Of Type)

    Public Function DoesTemplateContainEditorStateTemplate(ByVal PropertyInfo As PropertyInfo) As Boolean
        For Each oEditorStateTemplate As ISSBaseEditorStateTemplate In PropertyTemplates
            If String.Compare(PropertyInfo.ReflectedType.FullName, oEditorStateTemplate.ObjectTypeName, False) = 0 Then
                If String.Compare(PropertyInfo.Name, oEditorStateTemplate.PropertyName, False) = 0 Then
                    Return True
                End If
            End If
        Next
        Return False
    End Function
    Public Sub SetupValues()
        Dim rpiPropertyInfo As PropertyInfo
        Dim oEditorStateTemplate As ISSBaseEditorStateTemplate
        Try
            If ObjectCustomization Is Nothing Then
                Return
            End If
            'RepositoryItemComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem(objPropertyInfo.Name, objPropertyInfo))
            _mBuildProperties.Clear()
            _mBuildProperties.Add(_mObjectCustomization.ObjectType)
            For Each rpiPropertyInfo In ObjectCustomization.ObjectType.GetProperties
                If rpiPropertyInfo.DeclaringType Is GetType(XPCustomObject) Then
                    Continue For
                End If

                If rpiPropertyInfo.DeclaringType Is GetType(XPBaseObject) Then
                    Continue For
                End If

                If rpiPropertyInfo.DeclaringType Is GetType(BaseObject) Then
                    Continue For
                End If

                If rpiPropertyInfo.DeclaringType Is GetType(PersistentBase) Then
                    Continue For
                End If

                If DoesTemplateContainEditorStateTemplate(rpiPropertyInfo) = False Then
                    oEditorStateTemplate = New ISSBaseEditorStateTemplate(Session)
                    oEditorStateTemplate.TrueEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.Default
                    oEditorStateTemplate.FalseEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.Default
                    oEditorStateTemplate.ObjectTemplate = Me
                    oEditorStateTemplate.PropertyValue = rpiPropertyInfo
                    oEditorStateTemplate.Save()
                    PropertyTemplates.Add(oEditorStateTemplate)
                    Save()
                End If

                If _mBuildProperties.Contains(rpiPropertyInfo.PropertyType) = True Then
                    Continue For
                End If

                _mBuildProperties.Add(rpiPropertyInfo.PropertyType)
                If rpiPropertyInfo.PropertyType.IsSubclassOf(GetType(PersistentBase)) Then
                    BuildChildProperties(rpiPropertyInfo.PropertyType)
                End If
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub BuildChildProperties(ByVal ObjectType As Type)
        Dim rpiPropertyInfo As PropertyInfo
        Dim oEditorStateTemplate As ISSBaseEditorStateTemplate
        For Each rpiPropertyInfo In ObjectType.GetProperties
            If rpiPropertyInfo.DeclaringType Is GetType(XPCustomObject) Then
                Continue For
            End If

            If rpiPropertyInfo.DeclaringType Is GetType(XPBaseObject) Then
                Continue For
            End If

            If rpiPropertyInfo.DeclaringType Is GetType(BaseObject) Then
                Continue For
            End If

            If rpiPropertyInfo.DeclaringType Is GetType(PersistentBase) Then
                Continue For
            End If

            If DoesTemplateContainEditorStateTemplate(rpiPropertyInfo) = False Then
                oEditorStateTemplate = New ISSBaseEditorStateTemplate(Session)
                oEditorStateTemplate.TrueEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.Default
                oEditorStateTemplate.FalseEditorStateType = ISSBaseEditorStateTemplate.EditorStateTypes.Default
                oEditorStateTemplate.ObjectTemplate = Me
                oEditorStateTemplate.PropertyValue = rpiPropertyInfo
                oEditorStateTemplate.Save()
                PropertyTemplates.Add(oEditorStateTemplate)
                Save()
            End If

            If _mBuildProperties.Contains(rpiPropertyInfo.PropertyType) = True Then
                Continue For
            End If

            _mBuildProperties.Add(rpiPropertyInfo.PropertyType)
            If rpiPropertyInfo.PropertyType.IsSubclassOf(GetType(PersistentBase)) Then
                BuildChildProperties(rpiPropertyInfo.PropertyType)
            End If
        Next
    End Sub


    Public Overrides Sub AfterConstruction()
        MyBase.AfterConstruction()
        'BuildDefaultProperties()
    End Sub

End Class
