
Namespace Graphics
    Public Class Image
        Implements IDisposable

        Private disposedValue As Boolean
        Public Property Format As ImageFormat
        Public Property Texture As ITexture

        Public Sub New(ByVal renderer As IRenderer, ByVal surface As ISurface, ByVal imageFormat As ImageFormat)
            If renderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(renderer))
            End If

            If surface Is Nothing Then
                Throw New ArgumentNullException(NameOf(surface))
            End If

            If surface.Type = SurfaceType.Text Then
                Throw New InvalidOperationException("Cannot create images from text surfaces.")
            End If

            Format = imageFormat

            If surface.Type = SurfaceType.BMP Then
                Format = ImageFormat.BMP
            ElseIf surface.Type = SurfaceType.PNG Then
                Format = ImageFormat.PNG
            ElseIf surface.Type = SurfaceType.JPG Then
                Format = ImageFormat.JPG
            End If

            Texture = New Texture(renderer, surface)
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