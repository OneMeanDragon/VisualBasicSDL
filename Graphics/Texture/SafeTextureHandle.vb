Imports Microsoft.Win32.SafeHandles
Imports SDL2

Namespace VisualBasicSDL.Graphics
    Friend Class SafeTextureHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid

        Public Sub New(ByVal vHandle As IntPtr)
            MyBase.New(True)
            SetHandle(vHandle)
        End Sub

        Protected Overrides Function ReleaseHandle() As Boolean
            SDL.SDL_DestroyTexture(MyBase.handle)
            Return True
        End Function
    End Class
End Namespace