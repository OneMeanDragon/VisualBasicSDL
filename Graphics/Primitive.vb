Imports VisualBasicSDL.[Shared]

Namespace Graphics
    'Suppose this could have been a Structure at this point.
    Public Class Primitive
        Public Shared Sub DrawLine(ByVal renderer As IRenderer, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
            If renderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(renderer))
            End If

            Dim result As Integer = SDL2.SDL.SDL_RenderDrawLine(renderer.Handle, x1, y1, x2, y2)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_RenderDrawLine: {0}"))
            End If
        End Sub
    End Class
End Namespace
