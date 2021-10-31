Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Input
    Public Class KeyInformation
        Public Property mPhysicalKey As PhysicalKeyCode
        Public Property mVirtualKey As VirtualKeyCode
        Public Property mModifier As KeyModifier

        Public Sub New(ByVal vPhysicalKey As SDL.SDL_Scancode, ByVal vVirtualKey As SDL.SDL_Keycode, ByVal vModifier As SDL.SDL_Keymod)
            mPhysicalKey = CType(vPhysicalKey, PhysicalKeyCode)
            mVirtualKey = CType(vVirtualKey, VirtualKeyCode)
            mModifier = CType(vModifier, KeyModifier)
        End Sub
    End Class
End Namespace
