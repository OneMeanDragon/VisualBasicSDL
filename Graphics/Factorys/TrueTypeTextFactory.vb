Imports Microsoft.Extensions.Logging

Namespace VisualBasicSDL.Graphics
    Public Class TrueTypeTextFactory
        Implements ITrueTypeTextFactory

        Private ReadOnly logger As ILogger(Of TrueTypeTextFactory)

        Public Sub New(ByVal logger As ILogger(Of TrueTypeTextFactory))
            Me.logger = logger
        End Sub

        Public Function CreateTrueTypeText(ByVal renderer As IRenderer, ByVal fontPath As String, ByVal text As String, ByVal fontSize As Integer) As ITrueTypeText Implements ITrueTypeTextFactory.CreateTrueTypeText
            Return CreateTrueTypeText(renderer, fontPath, text, fontSize, Colors.Black, 0)
        End Function

        Public Function CreateTrueTypeText(ByVal renderer As IRenderer, ByVal fontPath As String, ByVal text As String, ByVal fontSize As Integer, ByVal color As SDLColor) As ITrueTypeText Implements ITrueTypeTextFactory.CreateTrueTypeText
            Return CreateTrueTypeText(renderer, fontPath, text, fontSize, color, 0)
        End Function

        Public Function CreateTrueTypeText(ByVal renderer As IRenderer, ByVal fontPath As String, ByVal text As String, ByVal fontSize As Integer, ByVal color As SDLColor, ByVal wrapLength As Integer) As ITrueTypeText Implements ITrueTypeTextFactory.CreateTrueTypeText
            Dim font As Font = Nothing
            Dim surface As ISurface = Nothing
            Dim trueTypeText As ITrueTypeText = Nothing

            If renderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(renderer))
            End If

            If String.IsNullOrWhiteSpace(fontPath) Then
                Throw New ArgumentNullException(NameOf(fontPath))
            End If

            If fontSize <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(fontSize), "Font size must be greater than 0.")
            End If

            If text Is Nothing Then
                Throw New ArgumentNullException(NameOf(text))
            End If

            Try
                font = New Font(fontPath, fontSize)
                surface = New Surface(font, text, color, wrapLength)
                trueTypeText = New TrueTypeText(renderer, surface, text, font, color, wrapLength)
                logger?.LogTrace($"TrueTypeText created. Width = {trueTypeText.Texture.Width}, Height = {trueTypeText.Texture.Height}, Font = {trueTypeText.Font.FilePath}, WrapLength = {trueTypeText.WrapLength}.")
                Return trueTypeText
            Catch ex As Exception
                logger.LogError(ex, "Error occurred while creating a TrueTypeText object.")
                font.Dispose()
                surface.Dispose()
                trueTypeText.Dispose()
                Throw
            End Try
        End Function
    End Class
End Namespace
