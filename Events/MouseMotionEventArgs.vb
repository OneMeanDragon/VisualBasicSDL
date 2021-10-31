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

        Public Property mWindowID As UInt32
        Public Property mMouseDeviceID As UInt32
        Public Property mMouseButtonsPressed As IEnumerable(Of MouseButtonCode)
        Public Property mRelativeToWindowX As Integer
        Public Property mRelativeToWindowY As Integer
        Public Property mRelativeToLastMotionEventX As Integer
        Public Property mRelativeToLastMotionEventY As Integer

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            MyBase.New(vRawEvent)
            mRawTimeStamp = vRawEvent.motion.timestamp
            mWindowID = vRawEvent.motion.windowID
            mMouseDeviceID = vRawEvent.motion.which
            mRelativeToWindowX = vRawEvent.motion.x
            mRelativeToWindowY = vRawEvent.motion.y
            mRelativeToLastMotionEventX = vRawEvent.motion.xrel
            mRelativeToLastMotionEventY = vRawEvent.motion.yrel
            Dim buttonsPressed As List(Of MouseButtonCode) = New List(Of MouseButtonCode)()
            If SDL.SDL_BUTTON(vRawEvent.motion.state) = SDL.SDL_BUTTON_LEFT Then buttonsPressed.Add(MouseButtonCode.Left)
            If SDL.SDL_BUTTON(vRawEvent.motion.state) = SDL.SDL_BUTTON_MIDDLE Then buttonsPressed.Add(MouseButtonCode.Middle)
            If SDL.SDL_BUTTON(vRawEvent.motion.state) = SDL.SDL_BUTTON_RIGHT Then buttonsPressed.Add(MouseButtonCode.Right)
            If SDL.SDL_BUTTON(vRawEvent.motion.state) = SDL.SDL_BUTTON_X1 Then buttonsPressed.Add(MouseButtonCode.X1)
            If SDL.SDL_BUTTON(vRawEvent.motion.state) = SDL.SDL_BUTTON_X2 Then buttonsPressed.Add(MouseButtonCode.X2)
            mMouseButtonsPressed = buttonsPressed
        End Sub
    End Class
End Namespace
