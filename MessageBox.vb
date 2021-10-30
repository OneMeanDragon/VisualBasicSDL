Imports SDL2
Imports VisualBasicSDL.Graphics

Namespace VisualBasicSDL

    Public Enum MessageBoxType
        [Error] = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_ERROR
        Information = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_INFORMATION
        Warning = SDL.SDL_MessageBoxFlags.SDL_MESSAGEBOX_WARNING
    End Enum

    Module MessageBox
        Sub Show(ByVal messageBoxType As MessageBoxType, ByVal title As String, ByVal message As String, ByVal Optional parentWindow As Window = Nothing)
            Dim parentWindowHandle As IntPtr = IntPtr.Zero
            If parentWindow IsNot Nothing Then parentWindowHandle = parentWindow.Handle
            SDL.SDL_ShowSimpleMessageBox(CType(messageBoxType, SDL.SDL_MessageBoxFlags), title, message, parentWindowHandle)
        End Sub
    End Module

End Namespace