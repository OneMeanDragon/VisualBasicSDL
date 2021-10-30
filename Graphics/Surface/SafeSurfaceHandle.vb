Imports Microsoft.Win32.SafeHandles
Imports SDL2

Namespace VisualBasicSDL.Graphics

    Friend Class SafeSurfaceHandle : Inherits SafeHandleZeroOrMinusOneIsInvalid

        Public Sub New(handle As IntPtr)
            MyBase.New(True)
            SetHandle(handle)
        End Sub

        Protected Overrides Function ReleaseHandle() As Boolean
            SDL.SDL_FreeSurface(handle)
            Return True
        End Function

    End Class

End Namespace