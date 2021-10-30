Imports SDL2

Namespace Graphics
    <Flags>
    Public Enum RendererFlags As UInteger
        None = 0
        RendererAccelerated = SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED
        RendererPresentVSync = SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC
        SupportRenderTargets = SDL.SDL_RendererFlags.SDL_RENDERER_TARGETTEXTURE
    End Enum
End Namespace