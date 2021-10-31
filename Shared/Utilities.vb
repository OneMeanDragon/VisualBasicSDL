Imports SDL2

Namespace VisualBasicSDL.[Shared]
    Module Utilities
        Function IsError(ByVal vErrorCode As Integer) As Boolean
            If vErrorCode < 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Function GetErrorMessage(ByVal vMethod As String) As String
            Return $"{vMethod}: {SDL.SDL_GetError()}"
        End Function
    End Module
End Namespace