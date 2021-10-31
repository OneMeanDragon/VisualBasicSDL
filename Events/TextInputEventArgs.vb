﻿Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Events
    Public Class TextInputEventArgs
        Inherits GameEventArgs

        Public Property Text As String
        Public Property WindowID As UInt32

        Public Sub New(ByVal rawEvent As SDL.SDL_Event)
            MyBase.New(rawEvent)
            RawTimeStamp = rawEvent.text.timestamp
            WindowID = rawEvent.text.windowID
            Dim rawBytes As Byte() = New Byte(SDL2.SDL.SDL_TEXTINPUTEVENT_TEXT_SIZE - 1) {}

            '// we have an unsafe pointer to a char array from SDL, explicitly marshal this to a byte array of fixed size
            'unsafe {
            'Marshal.Copy(CType(rawEvent.text.text, IntPtr), rawBytes, 0, SDL.SDL_TEXTINPUTEVENT_TEXT_SIZE)
            '}
            ''' 
            Dim gh As GCHandle = GCHandle.Alloc(rawEvent.text.text, GCHandleType.Pinned)
            Dim AddrOfMyText As IntPtr = gh.AddrOfPinnedObject()
            'Console.WriteLine(AddrOfMyText.ToString())
            Marshal.Copy(AddrOfMyText, rawBytes, 0, SDL.SDL_TEXTINPUTEVENT_TEXT_SIZE)
            gh.Free()

            Dim length As Integer = Array.IndexOf(rawBytes, CByte(0))
            Text = Encoding.UTF8.GetString(rawBytes, 0, length)
        End Sub
    End Class
End Namespace