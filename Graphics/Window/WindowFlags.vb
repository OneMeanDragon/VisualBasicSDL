Imports SDL2

Namespace VisualBasicSDL.Graphics

    <Flags>
    Public Enum WindowFlags As UInteger
        Shown = SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN
        Fullscreen = SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN
        FullscreenDesktop = SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN_DESKTOP
        OpenGL = SDL.SDL_WindowFlags.SDL_WINDOW_OPENGL
        Hidden = SDL.SDL_WindowFlags.SDL_WINDOW_HIDDEN
        Borderless = SDL.SDL_WindowFlags.SDL_WINDOW_BORDERLESS
        Resizable = SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE
        Minimized = SDL.SDL_WindowFlags.SDL_WINDOW_MINIMIZED
        Maximized = SDL.SDL_WindowFlags.SDL_WINDOW_MAXIMIZED
        GrabbedInputFocus = SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_GRABBED
        InputFocus = SDL.SDL_WindowFlags.SDL_WINDOW_INPUT_FOCUS
        MouseFocus = SDL.SDL_WindowFlags.SDL_WINDOW_MOUSE_FOCUS
        Foreign = SDL.SDL_WindowFlags.SDL_WINDOW_FOREIGN
    End Enum

End Namespace