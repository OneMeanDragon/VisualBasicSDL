Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Events
    Public Class TextEditingEventArgs
        Inherits GameEventArgs

        Public Property mLength As Integer
        Public Property mStart As Integer
        Public Property mText As String
        Public Property mWindowID As UInt32

        Public Sub New(ByVal vRawEvent As SDL.SDL_Event)
            MyBase.New(vRawEvent)
            mRawTimeStamp = vRawEvent.edit.timestamp
        End Sub
    End Class
End Namespace
