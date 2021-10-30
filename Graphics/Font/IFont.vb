
Namespace VisualBasicSDL.Graphics

    Public Interface IFont : Inherits IDisposable
        Property FilePath As String
        Property PointSize As Integer
        Property Handle As IntPtr
        Property OutlineSize As Integer
        Sub SetOutlineSize(vOutlineSize As Integer)
        ' Not all of the text rendering requires an outline
        ' there is also solid, and shadowed
    End Interface

End Namespace