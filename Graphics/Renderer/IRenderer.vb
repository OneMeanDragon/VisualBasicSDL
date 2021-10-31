Imports System.Collections.Generic

Namespace VisualBasicSDL.Graphics
    Public Interface IRenderer
        Inherits IDisposable

        Property Window As IWindow
        Property Index As Integer
        Property Flags As IEnumerable(Of RendererFlags)
        Property Handle As IntPtr
        Sub ClearScreen()
        Sub RenderPresent()
        Sub RenderTexture(ByVal vtexture As ITexture, ByVal vpositionX As Single, ByVal vpositionY As Single, ByVal vsourceWidth As Integer, ByVal vsourceHeight As Integer, ByVal vangle As Double, ByVal vcenter As Vector2D)
        Sub RenderTexture(ByVal vtexture As ITexture, ByVal vpositionX As Single, ByVal vpositionY As Single, ByVal vsourceWidth As Integer, ByVal vsourceHeight As Integer)
        Sub RenderTexture(ByVal vtexture As ITexture, ByVal vpositionX As Single, ByVal vpositionY As Single, ByVal vsource As Rectangle)
        Sub ResetRenderTarget()
        Sub SetBlendMode(ByVal vblendMode As BlendMode)
        Sub SetDrawColor(ByVal vr As Byte, ByVal vg As Byte, ByVal vb As Byte, ByVal va As Byte)
        Sub SetRenderLogicalSize(ByVal vwidth As Integer, ByVal vheight As Integer)
        Sub SetRenderTarget(ByVal vrenderTarget As ITexture)
    End Interface
End Namespace