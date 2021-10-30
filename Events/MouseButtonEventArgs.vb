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

        Public Property WindowID As UInt32
        Public Property MouseDeviceID As UInt32
        Public Property MouseButton As MouseButtonCode
        Public Property State As MouseButtonState
        Public Property RelativeToWindowX As Integer
        Public Property RelativeToWindowY As Integer

        Public Sub New(ByVal rawEvent As SDL.SDL_Event)
            MyBase.New(rawEvent)
            RawTimeStamp = rawEvent.button.timestamp
            WindowID = rawEvent.button.windowID
            MouseDeviceID = rawEvent.button.which
            MouseButton = CType(rawEvent.button.button, MouseButtonCode)
            State = CType(rawEvent.button.state, MouseButtonState)
            RelativeToWindowX = rawEvent.button.x
            RelativeToWindowY = rawEvent.button.y
        End Sub
    End Class
End Namespace
