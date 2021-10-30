Imports SDL2
Imports VisualBasicSDL.Input
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Events
    Public Class MouseMotionEventArgs
        Inherits GameEventArgs

        Public Property WindowID As UInt32
        Public Property MouseDeviceID As UInt32
        Public Property MouseButtonsPressed As IEnumerable(Of MouseButtonCode)
        Public Property RelativeToWindowX As Integer
        Public Property RelativeToWindowY As Integer
        Public Property RelativeToLastMotionEventX As Integer
        Public Property RelativeToLastMotionEventY As Integer

        Public Sub New(ByVal rawEvent As SDL.SDL_Event)
            MyBase.New(rawEvent)
            RawTimeStamp = rawEvent.motion.timestamp
            WindowID = rawEvent.motion.windowID
            MouseDeviceID = rawEvent.motion.which
            RelativeToWindowX = rawEvent.motion.x
            RelativeToWindowY = rawEvent.motion.y
            RelativeToLastMotionEventX = rawEvent.motion.xrel
            RelativeToLastMotionEventY = rawEvent.motion.yrel
            Dim buttonsPressed As List(Of MouseButtonCode) = New List(Of MouseButtonCode)()
            If SDL.SDL_BUTTON(rawEvent.motion.state) = SDL.SDL_BUTTON_LEFT Then buttonsPressed.Add(MouseButtonCode.Left)
            If SDL.SDL_BUTTON(rawEvent.motion.state) = SDL.SDL_BUTTON_MIDDLE Then buttonsPressed.Add(MouseButtonCode.Middle)
            If SDL.SDL_BUTTON(rawEvent.motion.state) = SDL.SDL_BUTTON_RIGHT Then buttonsPressed.Add(MouseButtonCode.Right)
            If SDL.SDL_BUTTON(rawEvent.motion.state) = SDL.SDL_BUTTON_X1 Then buttonsPressed.Add(MouseButtonCode.X1)
            If SDL.SDL_BUTTON(rawEvent.motion.state) = SDL.SDL_BUTTON_X2 Then buttonsPressed.Add(MouseButtonCode.X2)
            MouseButtonsPressed = buttonsPressed
        End Sub
    End Class
End Namespace
