Imports Microsoft.Win32.SafeHandles
Imports SDL2

Namespace VisualBasicSDL.Graphics

    Friend Class SafeSurfaceHandle : Inherits SafeHandleZeroOrMinusOneIsInvalid

        Public Sub New(vHandle As IntPtr)
            MyBase.New(True)
            SetHandle(vHandle)
        End Sub

        Protected Overrides Function ReleaseHandle() As Boolean
            SDL.SDL_FreeSurface(MyBase.handle)
            Return True
        End Function

    End Class

End Namespace