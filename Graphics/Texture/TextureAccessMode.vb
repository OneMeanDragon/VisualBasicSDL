Imports SDL2

Namespace Graphics
    Public Enum TextureAccessMode As Integer
        [Static] = SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STATIC
        Streaming = SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STREAMING
        Target = SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_TARGET
    End Enum
End Namespace
