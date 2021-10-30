Imports SDL2

Namespace VisualBasicSDL.Events
    Public Class QuitEventArgs
        Inherits GameEventArgs

        Public Sub New(ByVal rawEvent As SDL.SDL_Event)
            MyBase.New(rawEvent)
            RawTimeStamp = rawEvent.quit.timestamp
        End Sub
    End Class
End Namespace