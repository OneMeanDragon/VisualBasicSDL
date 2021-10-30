Imports Microsoft.Extensions.Logging

Namespace Graphics
    Public Class RendererFactory
        Implements IRendererFactory

        Private ReadOnly logger As ILogger(Of RendererFactory)
        Private ReadOnly loggerRenderer As ILogger(Of Renderer)

        Public Sub New(ByVal Optional logger As ILogger(Of RendererFactory) = Nothing, ByVal Optional loggerRenderer As ILogger(Of Renderer) = Nothing)
            Me.logger = logger
            Me.loggerRenderer = loggerRenderer
        End Sub

        Public Function CreateRenderer(ByVal window As IWindow) As IRenderer Implements IRendererFactory.CreateRenderer
            Return CreateRenderer(window, -1, RendererFlags.None)
        End Function

        Public Function CreateRenderer(ByVal window As IWindow, ByVal index As Integer) As IRenderer Implements IRendererFactory.CreateRenderer
            Return CreateRenderer(window, index, RendererFlags.None)
        End Function

        Public Function CreateRenderer(ByVal window As IWindow, ByVal index As Integer, ByVal flags As RendererFlags) As IRenderer Implements IRendererFactory.CreateRenderer
            Try
                Dim renderer = New Renderer(window, index, flags, loggerRenderer)
                logger?.LogTrace($"Renderer created. Handle = {renderer.Handle}, Window Title = {window.Title}, Window Handle = {window.Handle}.")
                SDL2.SDL.SDL_SetHint(SDL2.SDL.SDL_HINT_RENDER_SCALE_QUALITY, "linear")
                Return renderer
            Catch ex As Exception
                logger?.LogError(ex, ex.Message)
                Throw
            End Try
        End Function
    End Class
End Namespace
