Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Events
    Public Class MouseWheelEventArgs
        Inherits GameEventArgs

        Public Property mWindowID As UInt32
        Public Property mMouseDeviceID As UInt32
        Public Property mHorizontalScrollAmount As Integer
        Public Property mVerticalScrollAmount As Integer

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            MyBase.New(vRawEvent)
            mRawTimeStamp = vRawEvent.wheel.timestamp
            mWindowID = vRawEvent.wheel.windowID
            mMouseDeviceID = vRawEvent.wheel.which
            mHorizontalScrollAmount = vRawEvent.wheel.x
            mVerticalScrollAmount = vRawEvent.wheel.y
        End Sub
    End Class
End Namespace
