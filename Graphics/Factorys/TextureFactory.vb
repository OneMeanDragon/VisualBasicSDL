Imports Microsoft.Extensions.Logging

Namespace Graphics
    Public Class TextureFactory
        Implements ITextureFactory

        Private ReadOnly logger As ILogger(Of TextureFactory)

        Public Sub New(ByVal Optional logger As ILogger(Of TextureFactory) = Nothing)
            Me.logger = logger
        End Sub

        Public Function CreateTexture(ByVal renderer As IRenderer, ByVal width As Integer, ByVal height As Integer) As ITexture Implements ITextureFactory.CreateTexture
            Return CreateTexture(renderer, width, height, PixelFormat.RGBA8888, TextureAccessMode.[Static])
        End Function

        Public Function CreateTexture(ByVal renderer As IRenderer, ByVal width As Integer, ByVal height As Integer, ByVal pixelFormat As PixelFormat, ByVal accessMode As TextureAccessMode) As ITexture Implements ITextureFactory.CreateTexture
            Try
                Dim texture = New Texture(renderer, width, height, pixelFormat, accessMode)
                logger?.LogTrace($"Texture created. Width = {texture.Width}, Height = {texture.Height}, PixelFormat = {texture.PixelFormat}, AccessMode = {texture.AccessMode}, Handle = {texture.Handle}.")
                Return texture
            Catch ex As Exception
                logger?.LogError(ex, ex.Message)
                Throw
            End Try
        End Function

        Public Function CreateTexture(ByVal renderer As IRenderer, ByVal surface As ISurface) As ITexture Implements ITextureFactory.CreateTexture
            Try
                Dim texture = New Texture(renderer, surface)
                logger?.LogTrace($"Texture created from surface. Width = {texture.Width}, Height = {texture.Height}, PixelFormat = {texture.PixelFormat}, AccessMode = {texture.AccessMode}, Handle = {texture.Handle}.")
                Return texture
            Catch ex As Exception
                logger?.LogError(ex, ex.Message)
                Throw
            End Try
        End Function
    End Class
End Namespace
