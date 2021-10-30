Imports System
Imports SDL2

Namespace VisualBasicSDL
    <Flags>
    Public Enum GameEngineInitializeType As UInteger
        Timer = SDL.SDL_INIT_TIMER
        Audio = SDL.SDL_INIT_AUDIO
        Video = SDL.SDL_INIT_VIDEO
        Joystick = SDL.SDL_INIT_JOYSTICK
        Haptic = SDL.SDL_INIT_HAPTIC
        GameController = SDL.SDL_INIT_GAMECONTROLLER
        Events = SDL.SDL_INIT_EVENTS
        Sensor = SDL.SDL_INIT_SENSOR
        Everything = SDL.SDL_INIT_EVERYTHING
        NoParachute = SDL.SDL_INIT_NOPARACHUTE
    End Enum
End Namespace
