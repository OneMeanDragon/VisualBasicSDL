Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Input
    Public Enum KeyModifier
        None = SDL.SDL_Keymod.KMOD_NONE
        LeftShift = SDL.SDL_Keymod.KMOD_LSHIFT
        RightShift = SDL.SDL_Keymod.KMOD_RSHIFT
        Shift = SDL.SDL_Keymod.KMOD_SHIFT
        LeftControl = SDL.SDL_Keymod.KMOD_LCTRL
        RightControl = SDL.SDL_Keymod.KMOD_RCTRL
        Control = SDL.SDL_Keymod.KMOD_CTRL
        LeftAlt = SDL.SDL_Keymod.KMOD_LALT
        RightAlt = SDL.SDL_Keymod.KMOD_RALT
        Alt = SDL.SDL_Keymod.KMOD_ALT
        LeftWindowsKey = SDL.SDL_Keymod.KMOD_LGUI
        RightWindowsKey = SDL.SDL_Keymod.KMOD_RGUI
        WindowsKey = SDL.SDL_Keymod.KMOD_GUI
        NumLock = SDL.SDL_Keymod.KMOD_NUM
    End Enum
End Namespace
