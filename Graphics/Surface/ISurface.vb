
Namespace Graphics

    Public Interface ISurface : Inherits IDisposable
        ''' <summary> Surface's content direct file path </summary>
        ReadOnly Property FilePath() As String

        ''' <summary> Surface renderable Width </summary>
        ReadOnly Property Width() As Integer

        ''' <summary> Surface renderable Height </summary>
        ReadOnly Property Height() As Integer

        ''' <summary> Image type of the Surface </summary>
        ReadOnly Property Type() As SurfaceType

        ''' <summary> Unsafe native api handle returned by the SDL library </summary>
        ReadOnly Property Handle() As IntPtr

    End Interface

End Namespace