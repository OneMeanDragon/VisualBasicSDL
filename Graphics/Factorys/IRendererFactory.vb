
Namespace VisualBasicSDL.Graphics
    Public Interface IRendererFactory
        Function CreateRenderer(ByVal window As IWindow) As IRenderer
        Function CreateRenderer(ByVal window As IWindow, ByVal index As Integer) As IRenderer
        Function CreateRenderer(ByVal window As IWindow, ByVal index As Integer, ByVal flags As RendererFlags) As IRenderer
    End Interface
End Namespace