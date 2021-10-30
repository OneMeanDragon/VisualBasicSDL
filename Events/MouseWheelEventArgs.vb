Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Events
    Public Class MouseWheelEventArgs
        Inherits GameEventArgs

        Public Property WindowID As UInt32
        Public Property MouseDeviceID As UInt32
        Public Property HorizontalScrollAmount As Integer
        Public Property VerticalScrollAmount As Integer

        Public Sub New(ByVal rawEvent As SDL.SDL_Event)
            MyBase.New(rawEvent)
            RawTimeStamp = rawEvent.wheel.timestamp
            WindowID = rawEvent.wheel.windowID
            MouseDeviceID = rawEvent.wheel.which
            HorizontalScrollAmount = rawEvent.wheel.x
            VerticalScrollAmount = rawEvent.wheel.y
        End Sub
    End Class
End Namespace
