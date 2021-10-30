Imports VisualBasicSDL.[Shared]
Imports System

Namespace VisualBasicSDL.Graphics
    Public Class TrueTypeText
        Implements ITrueTypeText

        Public Property Text As String Implements ITrueTypeText.Text
        Public Property Font As IFont Implements ITrueTypeText.Font
        Public Property Color As SDLColor Implements ITrueTypeText.Color
        Public Property Texture As ITexture Implements ITrueTypeText.Texture

        Public Property OutlineSize As Integer Implements ITrueTypeText.OutlineSize
            Get
                Return Font.OutlineSize
            End Get
            Private Set(value As Integer)
                Font.OutlineSize = value
            End Set
        End Property

        Public Property IsWrapped As Boolean Implements ITrueTypeText.IsWrapped
        Public Property WrapLength As Integer Implements ITrueTypeText.WrapLength

        Public Sub New(ByVal renderer As IRenderer, ByVal surface As ISurface, ByVal text As String, ByVal font As Font, ByVal color As SDLColor, ByVal wrapLength As Integer)
            If renderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(renderer))
            End If

            If surface Is Nothing Then
                Throw New ArgumentNullException(NameOf(surface))
            End If

            If text Is Nothing Then
                Throw New ArgumentNullException(NameOf(text))
            End If

            If font Is Nothing Then
                Throw New ArgumentNullException(NameOf(font))
            End If

            If wrapLength < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(wrapLength), "Wrap length must be greater than or equal to 0.")
            End If

            Texture = New Texture(renderer, surface)
            IsWrapped = wrapLength > 0
            text = text
            font = font
            color = color
            wrapLength = wrapLength
        End Sub

        Public Sub UpdateText(ByVal text As String) Implements ITrueTypeText.UpdateText
            UpdateText(text, 0)
        End Sub

        Public Sub UpdateText(ByVal text As String, ByVal wrapLength As Integer) Implements ITrueTypeText.UpdateText
            If Texture Is Nothing Then
                Throw New InvalidOperationException("Texture is null. Has it been disposed?")
            End If

            Dim surface As ISurface = New Surface(Font, text, Color, wrapLength)
            Texture.UpdateSurfaceAndTexture(surface)
            text = text
            IsWrapped = wrapLength > 0
        End Sub

        Public Sub SetOutlineSize(ByVal outlineSize As Integer) Implements ITrueTypeText.SetOutlineSize
            If Font Is Nothing Then
                Throw New InvalidOperationException("Font is null.")
            End If

            If outlineSize < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(outlineSize), "Outline size must be greater than or equal to 0.")
            End If

            Font.SetOutlineSize(outlineSize)
        End Sub

        Public Sub Dispose() Implements ITrueTypeText.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Private Sub Dispose(ByVal disposing As Boolean)
            If disposing Then

                If Texture IsNot Nothing Then
                    Texture.Dispose()
                End If

                If Font IsNot Nothing Then
                    Font.Dispose()
                End If
            End If
        End Sub
    End Class
End Namespace
