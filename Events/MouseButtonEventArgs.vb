Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports SDL2
Imports VisualBasicSDL.Input

Namespace VisualBasicSDL.Events
    Public Class MouseButtonEventArgs
        Inherits GameEventArgs

        Public Property mWindowID As UInt32
        Public Property mMouseDeviceID As UInt32
        Public Property mMouseButton As MouseButtonCode
        Public Property mState As MouseButtonState
        Public Property mRelativeToWindowX As Integer
        Public Property mRelativeToWindowY As Integer

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            MyBase.New(vRawEvent)
            mRawTimeStamp = vRawEvent.button.timestamp
            mWindowID = vRawEvent.button.windowID
            mMouseDeviceID = vRawEvent.button.which
            mMouseButton = CType(vRawEvent.button.button, MouseButtonCode)
            mState = CType(vRawEvent.button.state, MouseButtonState)
            mRelativeToWindowX = vRawEvent.button.x
            mRelativeToWindowY = vRawEvent.button.y
        End Sub
    End Class
End Namespace
