Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Events
    Public Class TextEditingEventArgs
        Inherits GameEventArgs

        Public Property Length As Integer
        Public Property Start As Integer
        Public Property Text As String
        Public Property WindowID As UInt32

        Public Sub New(ByVal rawEvent As SDL.SDL_Event)
            MyBase.New(rawEvent)
            RawTimeStamp = rawEvent.edit.timestamp
        End Sub
    End Class
End Namespace
