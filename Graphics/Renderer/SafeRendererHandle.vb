Imports Microsoft.Win32.SafeHandles
Imports SDL2

Namespace VisualBasicSDL.Graphics
    Friend Class SafeRendererHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid

        Public Sub New(ByVal handle As IntPtr)
            MyBase.New(True)
            SetHandle(handle)
        End Sub

        Protected Overrides Function ReleaseHandle() As Boolean
            SDL.SDL_DestroyRenderer(handle)
            Return True
        End Function
    End Class
End Namespace