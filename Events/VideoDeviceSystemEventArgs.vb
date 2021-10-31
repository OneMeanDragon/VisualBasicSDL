Imports SDL2

Namespace VisualBasicSDL.Events
    Public Class VideoDeviceSystemEventArgs
        Inherits GameEventArgs

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            MyBase.New(vRawEvent)
            mRawTimeStamp = vRawEvent.syswm.timestamp
        End Sub
    End Class
End Namespace
