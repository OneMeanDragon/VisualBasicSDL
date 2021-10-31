Imports SDL2

Namespace VisualBasicSDL.Events
    Public Class QuitEventArgs
        Inherits GameEventArgs

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            MyBase.New(vRawEvent)
            mRawTimeStamp = vRawEvent.quit.timestamp
        End Sub
    End Class
End Namespace