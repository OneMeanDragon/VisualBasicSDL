Imports SDL2

Namespace Graphics

    <Flags>
    Public Enum BlendMode
        None = SDL.SDL_BlendMode.SDL_BLENDMODE_NONE
        Blend = SDL.SDL_BlendMode.SDL_BLENDMODE_BLEND
        Add = SDL.SDL_BlendMode.SDL_BLENDMODE_ADD
        [Mod] = SDL.SDL_BlendMode.SDL_BLENDMODE_MOD
    End Enum

End Namespace
