Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Input
    Public Enum MouseButtonCode As UInteger
        Left = SDL.SDL_BUTTON_LEFT
        Middle = SDL.SDL_BUTTON_MIDDLE
        Right = SDL.SDL_BUTTON_RIGHT
        X1 = SDL.SDL_BUTTON_X1
        X2 = SDL.SDL_BUTTON_X2
    End Enum
End Namespace
