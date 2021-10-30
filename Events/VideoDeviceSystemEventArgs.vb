Imports SDL2

Namespace VisualBasicSDL.Events
    Public Class VideoDeviceSystemEventArgs
        Inherits GameEventArgs

        Public Sub New(ByVal rawEvent As SDL.SDL_Event)
            MyBase.New(rawEvent)
            RawTimeStamp = rawEvent.syswm.timestamp
        End Sub
    End Class
End Namespace
