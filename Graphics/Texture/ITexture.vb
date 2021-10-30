Imports System

Namespace VisualBasicSDL.Graphics
    Public Interface ITexture
        Inherits IDisposable

        Property Width As Integer
        Property Height As Integer
        Property PixelFormat As PixelFormat
        Property AccessMode As TextureAccessMode
        Property Handle As IntPtr
        Sub UpdateSurfaceAndTexture(ByVal surface As ISurface)
        Sub SetBlendMode(ByVal blendMode As BlendMode)
        Sub Draw(ByVal x As Integer, ByVal y As Integer)
        Sub Draw(ByVal x As Single, ByVal y As Single)
        Sub Draw(ByVal x As Integer, ByVal y As Integer, ByVal sourceBounds As Rectangle)
        Sub Draw(ByVal x As Single, ByVal y As Single, ByVal sourceBounds As Rectangle)
        Sub Draw(ByVal x As Integer, ByVal y As Integer, ByVal angle As Double, ByVal center As Vector2D)
    End Interface
End Namespace