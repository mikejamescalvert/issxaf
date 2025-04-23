Imports System
Imports System.ComponentModel

Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation
Imports System.IO
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.XtraEditors
Imports DevExpress.ExpressApp.Model

<PropertyEditor(GetType(DiskImage), True)> _
Public Class DiskImageEditor
    Inherits DevExpress.ExpressApp.Win.Editors.WinPropertyEditor
    Public Sub New(ByVal objectType As Type, ByVal model As DevExpress.ExpressApp.Model.IModelMemberViewItem)
        MyBase.New(objectType, model)

    End Sub


    Public ReadOnly Property CurrentDiskImage() As DiskImage
        Get
            Return Me.PropertyValue
        End Get
    End Property

    Protected Overrides Function CreateControlCore() As Object
        Dim imgImage As New DevExpress.XtraEditors.PictureEdit
        imgImage.MinimumSize = New System.Drawing.Size(150, 150)
        imgImage.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        AddHandler imgImage.ImageChanged, AddressOf ImageChanged
        Return imgImage
    End Function

    Public Sub ImageChanged(ByVal sender As Object, ByVal e As EventArgs)
        If ReadingValue = False Then
            PersistImage()
        End If
    End Sub

    Public Shared ReadingValue As Boolean = False
    Protected Overrides Sub ReadValueCore()
        MyBase.ReadValueCore()
        ReadingValue = True
        If Me.Control IsNot Nothing Then
            If CurrentDiskImage Is Nothing Then
                CType(Me.Control, DevExpress.XtraEditors.PictureEdit).Enabled = False
            Else
                CType(Me.Control, DevExpress.XtraEditors.PictureEdit).Enabled = True
                If CurrentDiskImage.GetFullDiskFileName = String.Empty Then
                    CType(Me.Control, DevExpress.XtraEditors.PictureEdit).Image = Nothing
                Else
                    If IO.File.Exists(CurrentDiskImage.GetFullDiskFileName) = False Then
                        CType(Me.Control, DevExpress.XtraEditors.PictureEdit).Image = Nothing
                    Else
                        CType(Me.Control, DevExpress.XtraEditors.PictureEdit).Image = System.Drawing.Image.FromFile(CurrentDiskImage.GetFullDiskFileName)
                    End If
                End If
            End If
        End If
        ReadingValue = False
    End Sub

    Public Sub PersistImage()
        Dim obsSpace As Xpo.XPObjectSpace
        If CurrentDiskImage Is Nothing Then
            Return
        End If
        obsSpace = Xpo.XPObjectSpace.FindObjectSpaceByObject(CurrentDiskImage)
        If Me.Control Is Nothing OrElse CType(Control, PictureEdit).Image Is Nothing Then
            CurrentDiskImage.ImageFileName = String.Empty
            Return
        End If


        Dim strNewName As String
        Dim strBasePath As String = CurrentDiskImage.GetImageDirectory
        Dim strFileName As String = String.Empty
        Dim intAttempts As Integer = 0
        If strFileName = String.Empty Then
            strFileName = CurrentDiskImage.GetNewImageName
        End If
        If strBasePath.EndsWith("\") = False Then
            strBasePath = strBasePath + "\"
        End If
        strNewName = String.Format("{0}{1}", strBasePath, strFileName)
        While IO.File.Exists(strNewName) = True
            intAttempts += 1
            strFileName = CurrentDiskImage.GetNewImageName
            'strFileName = String.Format("{0}{1}.jpg", strFileName, intAttempts)
            strNewName = String.Format("{0}{1}", strBasePath, strFileName)
        End While
        If IO.Directory.Exists(strBasePath) = False Then
            IO.Directory.CreateDirectory(strBasePath)
        End If
        CType(Control, PictureEdit).Image.Save(strNewName, System.Drawing.Imaging.ImageFormat.Jpeg)
        CurrentDiskImage.ImageFileName = strFileName
    End Sub



End Class
