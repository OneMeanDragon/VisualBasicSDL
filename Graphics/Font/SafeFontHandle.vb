Imports Microsoft.Win32.SafeHandles
Imports SDL2

Namespace VisualBasicSDL.Graphics
    Friend Class SafeFontHandle
        Inherits SafeHandleZeroOrMinusOneIsInvalid

        Public Sub New(ByVal vHandle As IntPtr)
            MyBase.New(True)
            SetHandle(vHandle)
        End Sub

        Protected Overrides Function ReleaseHandle() As Boolean
            ' Needs to be tracked down (happens when app is closed)
            '   An unhandled exception of type 'System.AccessViolationException' occurred in test.exe
            '   Attempted to read Or write protected memory. This Is often an indication that other memory Is corrupt.
            '   System.AccessViolationException: 'Attempted to read or write protected memory. This is often an indication that other memory is corrupt.'
            '   
            '   Fix was not a fix, was just a reminder to always unload your loaded content.. heh [UnloadContent()]
            SDL_ttf.TTF_CloseFont(MyBase.handle)
            Return True
        End Function
    End Class

End Namespace