Imports SDL2

Namespace VisualBasicSDL.Events
    Public MustInherit Class GameEventArgs
        Inherits EventArgs

        Protected Property RawEvent As SDL.SDL_Event
        Protected Property RawTimeStamp As UInteger
        Public Property EventType As GameEventType

        Public ReadOnly Property TimeStamp As TimeSpan
            Get
                Return New TimeSpan(RawTimeStamp)
            End Get
        End Property

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            RawEvent = vRawEvent
            EventType = CType(vRawEvent.type, GameEventType)
        End Sub
    End Class
End Namespace