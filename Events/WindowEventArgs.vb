Imports SDL2

Namespace VisualBasicSDL.Events
    Public Class WindowEventArgs
        Inherits GameEventArgs

        Public Property mData1 As Integer
        Public Property mData2 As Integer
        Public Property mSubEventType As WindowEventType
        Public Property mWindowID As UInt32

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            MyBase.New(vRawEvent)
            mSubEventType = CType(vRawEvent.window.windowEvent, WindowEventType)
            mData1 = vRawEvent.window.data1
            mData2 = vRawEvent.window.data2
            mRawTimeStamp = vRawEvent.window.timestamp
            mWindowID = vRawEvent.window.windowID
        End Sub
    End Class
End Namespace