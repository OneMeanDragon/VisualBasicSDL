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

        Private mRepeat As Byte
        Public Property mKeyInformation As KeyInformation
        Public Property mState As KeyState
        Public Property mWindowID As UInt32

        Public ReadOnly Property IsRepeat As Boolean
            Get

                If mRepeat <> 0 Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            MyBase.New(vRawEvent)
            mRawTimeStamp = vRawEvent.key.timestamp
            mRepeat = vRawEvent.key.repeat
            mKeyInformation = New KeyInformation(vRawEvent.key.keysym.scancode, vRawEvent.key.keysym.sym, vRawEvent.key.keysym.[mod])
            mState = CType(vRawEvent.key.state, KeyState)
            mWindowID = vRawEvent.key.windowID
        End Sub
    End Class
End Namespace
