Imports System.Collections.Generic

Namespace Graphics
    Public Interface IRenderer
        Inherits IDisposable

        Property Window As IWindow
        Property Index As Integer
        Property Flags As IEnumerable(Of RendererFlags)
        Property Handle As IntPtr
        Sub ClearScreen()
        Sub RenderPresent()
        Sub RenderTexture(ByVal texture As ITexture, ByVal positionX As Single, ByVal positionY As Single, ByVal sourceWidth As Integer, ByVal sourceHeight As Integer, ByVal angle As Double, ByVal center As Vector2D)
        Sub RenderTexture(ByVal texture As ITexture, ByVal positionX As Single, ByVal positionY As Single, ByVal sourceWidth As Integer, ByVal sourceHeight As Integer)
        Sub RenderTexture(ByVal texture As ITexture, ByVal positionX As Single, ByVal positionY As Single, ByVal source As Rectangle)
        Sub ResetRenderTarget()
        Sub SetBlendMode(ByVal blendMode As BlendMode)
        Sub SetDrawColor(ByVal r As Byte, ByVal g As Byte, ByVal b As Byte, ByVal a As Byte)
        Sub SetRenderLogicalSize(ByVal width As Integer, ByVal height As Integer)
        Sub SetRenderTarget(ByVal renderTarget As ITexture)
    End Interface
End Namespace