Imports SDL2
Imports VisualBasicSDL.Input
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Events
    Public Enum KeyState
        Pressed = SDL.SDL_PRESSED
        Released = SDL.SDL_RELEASED
    End Enum

    Public Class KeyboardEventArgs
        Inherits GameEventArgs

        Private repeat As Byte
        Public Property KeyInformation As KeyInformation
        Public Property State As KeyState
        Public Property WindowID As UInt32

        Public ReadOnly Property IsRepeat As Boolean
            Get

                If repeat <> 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Sub New(ByVal rawEvent As SDL.SDL_Event)
            MyBase.New(rawEvent)
            RawTimeStamp = rawEvent.key.timestamp
            repeat = rawEvent.key.repeat
            KeyInformation = New KeyInformation(rawEvent.key.keysym.scancode, rawEvent.key.keysym.sym, rawEvent.key.keysym.[mod])
            State = CType(rawEvent.key.state, KeyState)
            WindowID = rawEvent.key.windowID
        End Sub
    End Class
End Namespace
