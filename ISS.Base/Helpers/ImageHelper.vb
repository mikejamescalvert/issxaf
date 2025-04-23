Imports System.Drawing
Namespace Helpers
    Public Class ImageHelper
        Public Shared Function GetLargeImage(ByVal ImageName As String) As System.Drawing.Image
            Dim objImage As System.Drawing.Image
            objImage = GetImageWithPrefix(ImageName, "Large")
            If objImage Is Nothing Then
                Return GetImageWithPrefix(ImageName, "Large")
            Else
                Return objImage
            End If
        End Function
        Public Shared Function GetButtonNavImage(ByVal ImageName As String) As System.Drawing.Image
            Dim objImage As System.Drawing.Image
            objImage = GetImageWithPrefix(ImageName, "ButtonNav")
            If objImage Is Nothing Then
                Return GetLargeImage(ImageName)
            Else
                Return objImage
            End If
        End Function
        Public Shared Function GetBackgroundImage(ByVal ImageName As String) As System.Drawing.Image
            Return GetImageWithPrefix(ImageName, "Background")
        End Function
        Public Shared Function GetImageWithPrefix(ByVal ImageName As String, ByVal Prefix As String)
            Return GetImageByImageName(ImageName + "_" + Prefix + ".png")
        End Function
        Public Shared Function GetImageByImageName(ByVal ImageName As String) As System.Drawing.Image
            Dim oStream As System.IO.Stream
            Dim oAssembly As System.Reflection.Assembly
            Dim oAssemblySearch As System.Reflection.Assembly
            Dim oImage As System.Drawing.Image = Nothing
            Dim strAssemblyName As System.Reflection.AssemblyName
            oAssembly = System.Reflection.Assembly.GetEntryAssembly
            For Each strAssemblyName In oAssembly.GetReferencedAssemblies
                oAssemblySearch = System.Reflection.Assembly.Load(strAssemblyName)
                oStream = Nothing
                If strAssemblyName.Name.Contains("Images") = False Then
                    oStream = oAssemblySearch.GetManifestResourceStream(strAssemblyName.Name + ".Images." + ImageName)
                    If oStream Is Nothing Then
                        oStream = oAssemblySearch.GetManifestResourceStream("DevExpress.ExpressApp.Images.Images." + ImageName)
                    End If
                End If
                If oStream IsNot Nothing Then
                    oImage = CType(Image.FromStream(oStream), System.Drawing.Image)
                    Return oImage
                End If
            Next

            Return Nothing
        End Function
    End Class
End Namespace

