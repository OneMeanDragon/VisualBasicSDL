Imports Microsoft.Win32.SafeHandles
Imports SDL2

Namespace Graphics

    Friend Class SafeFontHandle : Inherits SafeHandleZeroOrMinusOneIsInvalid
        Public Sub New(handle As IntPtr)
            MyBase.New(True)
            SetHandle(handle)
        End Sub

        Protected Overrides Function ReleaseHandle() As Boolean
            SDL_ttf.TTF_CloseFont(handle)
            Return True
        End Function
    End Class

End Namespace