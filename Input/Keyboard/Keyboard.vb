Imports System
Imports System.Runtime.InteropServices
Imports System.Collections.Generic

Namespace VisualBasicSDL.Input
    Module Keyboard
        Sub StartTextInput()
            SDL2.SDL.SDL_StartTextInput()
        End Sub

        Sub StopTextInput()
            SDL2.SDL.SDL_StopTextInput()
        End Sub
    End Module
End Namespace
