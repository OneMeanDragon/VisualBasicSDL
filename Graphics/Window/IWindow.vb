Imports System
Imports System.Collections.Generic

Namespace Graphics

    Interface IWindow
        Inherits IDisposable

        ReadOnly Property Title As String
        ReadOnly Property X As Integer
        ReadOnly Property Y As Integer
        ReadOnly Property Width As Integer
        ReadOnly Property Height As Integer
        ReadOnly Property Flags As IEnumerable(Of WindowFlags)
        ReadOnly Property Handle As IntPtr
    End Interface

End Namespace