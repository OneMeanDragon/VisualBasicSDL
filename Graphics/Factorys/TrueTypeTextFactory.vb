Imports Microsoft.Extensions.Logging

Namespace VisualBasicSDL.Graphics
    Public Class TrueTypeTextFactory
        Implements ITrueTypeTextFactory

        Private ReadOnly logger As ILogger(Of TrueTypeTextFactory)

        Public Sub New(ByVal vLogger As ILogger(Of TrueTypeTextFactory))
            Me.logger = vLogger
        End Sub

        Public Function CreateTrueTypeText(ByVal vRenderer As IRenderer, ByVal vFontPath As String, ByVal vText As String, ByVal vFontSize As Integer) As ITrueTypeText Implements ITrueTypeTextFactory.CreateTrueTypeText
            Return CreateTrueTypeText(vRenderer, vFontPath, vText, vFontSize, Colors.Black, 0)
        End Function

        Public Function CreateTrueTypeText(ByVal vRenderer As IRenderer, ByVal vFontPath As String, ByVal vText As String, ByVal vFontSize As Integer, ByVal vColor As SDLColor) As ITrueTypeText Implements ITrueTypeTextFactory.CreateTrueTypeText
            Return CreateTrueTypeText(vRenderer, vFontPath, vText, vFontSize, vColor, 0)
        End Function

        Public Function CreateTrueTypeText(ByVal vRenderer As IRenderer, ByVal vFontPath As String, ByVal vText As String, ByVal vFontSize As Integer, ByVal vColor As SDLColor, ByVal vWrapLength As Integer) As ITrueTypeText Implements ITrueTypeTextFactory.CreateTrueTypeText
            Dim locFont As Font = Nothing
            Dim locSurface As ISurface = Nothing
            Dim locTrueTypeText As ITrueTypeText = Nothing

            If vRenderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(vRenderer))
            End If

            If String.IsNullOrWhiteSpace(vFontPath) Then
                Throw New ArgumentNullException(NameOf(vFontPath))
            End If

            If vFontSize <= 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vFontSize), "Font size must be greater than 0.")
            End If

            If vText Is Nothing Then
                Throw New ArgumentNullException(NameOf(vText))
            End If

            Try
                locFont = New Font(vFontPath, vFontSize)
                locSurface = New Surface(locFont, vText, vColor, vWrapLength)
                locTrueTypeText = New TrueTypeText(vRenderer, locSurface, vText, locFont, vColor, vWrapLength)
                logger?.LogTrace($"TrueTypeText created. Width = {locTrueTypeText.Texture.Width}, Height = {locTrueTypeText.Texture.Height}, Font = {locTrueTypeText.Font.FilePath}, WrapLength = {locTrueTypeText.WrapLength}.")
                Return locTrueTypeText
            Catch ex As Exception
                logger.LogError(ex, "Error occurred while creating a TrueTypeText object.")
                locFont.Dispose()
                locSurface.Dispose()
                locTrueTypeText.Dispose()
                Throw
            End Try
        End Function
    End Class
End Namespace
