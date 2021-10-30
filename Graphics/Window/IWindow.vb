Imports System
Imports System.Collections.Generic

Namespace VisualBasicSDL.Graphics

    Public Interface IWindow
        Inherits IDisposable

        Property Title As String
        Property X As Integer
        Property Y As Integer
        Property Width As Integer
        Property Height As Integer
        Property Flags As IEnumerable(Of WindowFlags)
        Property Handle As IntPtr
    End Interface

End Namespace