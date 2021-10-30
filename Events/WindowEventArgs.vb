Imports SDL2

Namespace VisualBasicSDL.Events
    Public Class WindowEventArgs
        Inherits GameEventArgs

        Public Property Data1 As Integer
        Public Property Data2 As Integer
        Public Property SubEventType As WindowEventType
        Public Property WindowID As UInt32

        Public Sub New(ByVal rawEvent As SDL.SDL_Event)
            MyBase.New(rawEvent)
            SubEventType = CType(rawEvent.window.windowEvent, WindowEventType)
            Data1 = rawEvent.window.data1
            Data2 = rawEvent.window.data2
            RawTimeStamp = rawEvent.window.timestamp
            WindowID = rawEvent.window.windowID
        End Sub
    End Class
End Namespace