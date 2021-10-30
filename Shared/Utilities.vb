Imports SDL2

Namespace VisualBasicSDL.[Shared]
    Module Utilities
        Function IsError(ByVal errorCode As Integer) As Boolean
            If errorCode < 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Function GetErrorMessage(ByVal method As String) As String
            Return $"{method}: {SDL.SDL_GetError()}"
        End Function
    End Module
End Namespace