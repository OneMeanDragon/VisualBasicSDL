Imports SDL2

Namespace VisualBasicSDL.Events
    Public Interface IEventManager
        Event MouseWheelScrolling As EventHandler(Of MouseWheelEventArgs)
        Event MouseButtonPressed As EventHandler(Of MouseButtonEventArgs)
        Event MouseButtonReleased As EventHandler(Of MouseButtonEventArgs)
        Event MouseMoving As EventHandler(Of MouseMotionEventArgs)
        Event TextInputting As EventHandler(Of TextInputEventArgs)
        Event TextEditing As EventHandler(Of TextEditingEventArgs)
        Event KeyPressed As EventHandler(Of KeyboardEventArgs)
        Event KeyReleased As EventHandler(Of KeyboardEventArgs)
        Event VideoDeviceSystemEvent As EventHandler(Of VideoDeviceSystemEventArgs)
        Event Quitting As EventHandler(Of QuitEventArgs)
        Event Exiting As EventHandler(Of EventArgs)
        Event WindowShown As EventHandler(Of WindowEventArgs)
        Event WindowHidden As EventHandler(Of WindowEventArgs)
        Event WindowExposed As EventHandler(Of WindowEventArgs)
        Event WindowMoved As EventHandler(Of WindowEventArgs)
        Event WindowResized As EventHandler(Of WindowEventArgs)
        Event WindowSizeChanged As EventHandler(Of WindowEventArgs)
        Event WindowMinimized As EventHandler(Of WindowEventArgs)
        Event WindowMaximized As EventHandler(Of WindowEventArgs)
        Event WindowRestored As EventHandler(Of WindowEventArgs)
        Event WindowEntered As EventHandler(Of WindowEventArgs)
        Event WindowLeave As EventHandler(Of WindowEventArgs)
        Event WindowFocusGained As EventHandler(Of WindowEventArgs)
        Event WindowFocusLost As EventHandler(Of WindowEventArgs)
        Event WindowClosed As EventHandler(Of WindowEventArgs)
        Sub RaiseExiting(ByVal sender As Object, ByVal args As EventArgs)
        Sub RaiseEvents(ByVal rawEvent As SDL.SDL_Event)
    End Interface
End Namespace