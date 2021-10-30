Namespace VisualBasicSDL.Graphics
    Interface ITextureFactory
        Function CreateTexture(ByVal renderer As IRenderer, ByVal width As Integer, ByVal height As Integer) As ITexture
        Function CreateTexture(ByVal renderer As IRenderer, ByVal width As Integer, ByVal height As Integer, ByVal pixelFormat As PixelFormat, ByVal accessMode As TextureAccessMode) As ITexture
        Function CreateTexture(ByVal renderer As IRenderer, ByVal surface As ISurface) As ITexture
    End Interface
End Namespace
