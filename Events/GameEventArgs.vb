Imports SDL2

Namespace VisualBasicSDL.Events
    Public MustInherit Class GameEventArgs
        Inherits EventArgs

        Protected Property mRawEvent As SDL.SDL_Event
        Protected Property mRawTimeStamp As UInteger
        Public Property mEventType As GameEventType

        Public ReadOnly Property TimeStamp As TimeSpan
            Get
                Return New TimeSpan(mRawTimeStamp)
            End Get
        End Property

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            mRawEvent = vRawEvent
            mEventType = CType(vRawEvent.type, GameEventType)
        End Sub
    End Class
End Namespace