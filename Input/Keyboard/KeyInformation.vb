Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Input
    Public Class KeyInformation
        Public Property PhysicalKey As PhysicalKeyCode
        Public Property VirtualKey As VirtualKeyCode
        Public Property Modifier As KeyModifier

        Public Sub New(ByVal physicalKey As SDL.SDL_Scancode, ByVal virtualKey As SDL.SDL_Keycode, ByVal modifier As SDL.SDL_Keymod)
            physicalKey = CType(physicalKey, PhysicalKeyCode)
            virtualKey = CType(virtualKey, VirtualKeyCode)
            modifier = CType(modifier, KeyModifier)
        End Sub
    End Class
End Namespace
