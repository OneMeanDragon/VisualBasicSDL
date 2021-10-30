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

        Public Sub New(ByVal vrenderer As IRenderer, ByVal vsurface As ISurface,
                       ByVal vtext As String, ByVal vfont As Font,
                       ByVal vcolor As SDLColor, ByVal vwrapLength As Integer)
            If vrenderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(vrenderer))
            End If

            If vsurface Is Nothing Then
                Throw New ArgumentNullException(NameOf(vsurface))
            End If

            If vtext Is Nothing Then
                Throw New ArgumentNullException(NameOf(vtext))
            End If

            If vfont Is Nothing Then
                Throw New ArgumentNullException(NameOf(vfont))
            End If

            If vwrapLength < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vwrapLength), "Wrap length must be greater than or equal to 0.")
            End If

            Texture = New Texture(vrenderer, vsurface)
            IsWrapped = vwrapLength > 0
            Text = vtext
            Font = vfont
            Color = vcolor
            WrapLength = vwrapLength
        End Sub

        Public Sub UpdateText(ByVal vtext As String) Implements ITrueTypeText.UpdateText
            UpdateText(vtext, 0)
        End Sub

        Public Sub UpdateText(ByVal vtext As String, ByVal vwrapLength As Integer) Implements ITrueTypeText.UpdateText
            If Texture Is Nothing Then
                Throw New InvalidOperationException("Texture is null. Has it been disposed?")
            End If

            Dim surface As ISurface = New Surface(Font, vtext, Color, vwrapLength)
            Texture.UpdateSurfaceAndTexture(surface)
            Text = vtext
            IsWrapped = vwrapLength > 0
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
