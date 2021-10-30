
Namespace VisualBasicSDL.Graphics
    Public Class Image
        Implements IDisposable

        Private disposedValue As Boolean
        Public Property Format As ImageFormat
        Public Property [Texture] As ITexture

        Public Sub New(ByVal vRenderer As IRenderer, ByVal vSurface As ISurface, ByVal vImageFormat As ImageFormat)
            If vRenderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(vRenderer))
            End If

            If vSurface Is Nothing Then
                Throw New ArgumentNullException(NameOf(vSurface))
            End If

            If vSurface.Type = SurfaceType.Text Then
                Throw New InvalidOperationException("Cannot create images from text surfaces.")
            End If

            Format = vImageFormat

            If vSurface.Type = SurfaceType.BMP Then
                Format = ImageFormat.BMP
            ElseIf vSurface.Type = SurfaceType.PNG Then
                Format = ImageFormat.PNG
            ElseIf vSurface.Type = SurfaceType.JPG Then
                Format = ImageFormat.JPG
            End If

            [Texture] = New Texture(vRenderer, vSurface)
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    If Texture IsNot Nothing Then
                        Texture.Dispose()
                    End If
                End If
                disposedValue = True
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub
    End Class
End Namespace