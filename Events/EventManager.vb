Imports SDL2
Imports VisualBasicSDL.Input

Namespace VisualBasicSDL.Events
    Public Class EventManager
        Implements IEventManager

        Public Event MouseWheelScrolling As EventHandler(Of MouseWheelEventArgs) Implements IEventManager.MouseWheelScrolling
        Public Event MouseButtonPressed As EventHandler(Of MouseButtonEventArgs) Implements IEventManager.MouseButtonPressed
        Public Event MouseButtonReleased As EventHandler(Of MouseButtonEventArgs) Implements IEventManager.MouseButtonReleased
        Public Event MouseMoving As EventHandler(Of MouseMotionEventArgs) Implements IEventManager.MouseMoving
        Public Event TextInputting As EventHandler(Of TextInputEventArgs) Implements IEventManager.TextInputting
        Public Event TextEditing As EventHandler(Of TextEditingEventArgs) Implements IEventManager.TextEditing
        Public Event KeyPressed As EventHandler(Of KeyboardEventArgs) Implements IEventManager.KeyPressed
        Public Event KeyReleased As EventHandler(Of KeyboardEventArgs) Implements IEventManager.KeyReleased
        Public Event VideoDeviceSystemEvent As EventHandler(Of VideoDeviceSystemEventArgs) Implements IEventManager.VideoDeviceSystemEvent
        Public Event Quitting As EventHandler(Of QuitEventArgs) Implements IEventManager.Quitting
        Public Event Exiting As EventHandler(Of EventArgs) Implements IEventManager.Exiting
        Public Event WindowShown As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowShown
        Public Event WindowHidden As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowHidden
        Public Event WindowExposed As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowExposed
        Public Event WindowMoved As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowMoved
        Public Event WindowResized As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowResized
        Public Event WindowSizeChanged As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowSizeChanged
        Public Event WindowMinimized As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowMinimized
        Public Event WindowMaximized As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowMaximized
        Public Event WindowRestored As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowRestored
        Public Event WindowEntered As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowEntered
        Public Event WindowLeave As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowLeave
        Public Event WindowFocusGained As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowFocusGained
        Public Event WindowFocusLost As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowFocusLost
        Public Event WindowClosed As EventHandler(Of WindowEventArgs) Implements IEventManager.WindowClosed

        Public Sub RaiseExiting(ByVal sender As Object, ByVal args As EventArgs) Implements IEventManager.RaiseExiting
            RaiseEvent Exiting(sender, args)
        End Sub

        Public Sub RaiseEvents(ByVal rawEvent As SDL.SDL_Event) Implements IEventManager.RaiseEvents
            Dim eventType = CType(rawEvent.type, GameEventType)
            Dim argEventData = CreateEventArgs(Of EventArgs)(rawEvent)
            If argEventData Is Nothing Then
                Return
            End If

            Select Case eventType
                Case GameEventType.First
                    Return
                Case GameEventType.Window
                    Dim windowEventType = CType(rawEvent.window.windowEvent, WindowEventType)

                    Select Case windowEventType
                        Case WindowEventType.Close
                            RaiseEvent WindowClosed(Me, argEventData) 'RaiseEvents(WindowClosed, rawEvent)
                        Case WindowEventType.Enter
                            RaiseEvent WindowEntered(Me, argEventData) 'RaiseEvents(WindowEntered, rawEvent)
                        Case WindowEventType.Exposed
                            RaiseEvent WindowExposed(Me, argEventData) 'RaiseEvents(WindowExposed, rawEvent)
                        Case WindowEventType.FocusGained
                            RaiseEvent WindowFocusGained(Me, argEventData) 'RaiseEvents(WindowFocusGained, rawEvent)
                        Case WindowEventType.FocusLost
                            RaiseEvent WindowFocusLost(Me, argEventData) 'RaiseEvents(WindowFocusLost, rawEvent)
                        Case WindowEventType.Hidden
                            RaiseEvent WindowHidden(Me, argEventData) 'RaiseEvents(WindowHidden, rawEvent)
                        Case WindowEventType.Leave
                            RaiseEvent WindowLeave(Me, argEventData) 'RaiseEvents(WindowLeave, rawEvent)
                        Case WindowEventType.Maximized
                            RaiseEvent WindowMaximized(Me, argEventData) 'RaiseEvents(WindowMaximized, rawEvent)
                        Case WindowEventType.Minimized
                            RaiseEvent WindowMinimized(Me, argEventData) 'RaiseEvents(WindowMinimized, rawEvent)
                        Case WindowEventType.Moved
                            RaiseEvent WindowMoved(Me, argEventData) 'RaiseEvents(WindowMoved, rawEvent)
                        Case WindowEventType.Resized
                            RaiseEvent WindowResized(Me, argEventData) 'RaiseEvents(WindowResized, rawEvent)
                        Case WindowEventType.Restored
                            RaiseEvent WindowRestored(Me, argEventData) 'RaiseEvents(WindowRestored, rawEvent)
                        Case WindowEventType.Shown
                            RaiseEvent WindowShown(Me, argEventData) 'RaiseEvents(WindowShown, rawEvent)
                        Case WindowEventType.SizeChanged
                            RaiseEvent WindowSizeChanged(Me, argEventData) 'RaiseEvents(WindowSizeChanged, rawEvent)
                    End Select

                Case GameEventType.Quit
                    RaiseEvent Quitting(Me, argEventData) 'RaiseEvents(Quitting, rawEvent)
                Case GameEventType.VideoDeviceSystemEvent
                    RaiseEvent VideoDeviceSystemEvent(Me, argEventData) 'RaiseEvents(VideoDeviceSystemEvent, rawEvent)
                Case GameEventType.TextEditing
                    RaiseEvent TextEditing(Me, argEventData) 'RaiseEvents(TextEditing, rawEvent)
                Case GameEventType.TextInput
                    RaiseEvent TextInputting(Me, argEventData) 'RaiseEvents(TextInputting, rawEvent)
                Case GameEventType.KeyDown, GameEventType.KeyUp
                    Dim keyState = CType(rawEvent.key.state, KeyState)

                    If keyState = KeyState.Pressed Then
                        RaiseEvent KeyPressed(Me, argEventData) 'RaiseEvents(KeyPressed, rawEvent)
                    ElseIf keyState = KeyState.Released Then
                        RaiseEvent KeyReleased(Me, argEventData) 'RaiseEvents(KeyReleased, rawEvent)
                    End If

                Case GameEventType.MouseMotion
                    Mouse.UpdateMousePosition(rawEvent.motion.x, rawEvent.motion.y)
                    RaiseEvent MouseMoving(Me, argEventData) 'RaiseEvents(MouseMoving, rawEvent)
                Case GameEventType.MouseButtonDown, GameEventType.MouseButtonUp
                    Dim mouseButtonState = CType(rawEvent.button.state, MouseButtonState)

                    If mouseButtonState = MouseButtonState.Pressed Then
                        RaiseEvent MouseButtonPressed(Me, argEventData) 'RaiseEvents(MouseButtonPressed, rawEvent)
                    ElseIf mouseButtonState = MouseButtonState.Released Then
                        RaiseEvent MouseButtonReleased(Me, argEventData) 'RaiseEvents(MouseButtonReleased, rawEvent)
                    End If

                Case GameEventType.MouseWheel
                    RaiseEvent MouseWheelScrolling(Me, argEventData) 'RaiseEvents(MouseWheelScrolling, rawEvent)
            End Select
        End Sub

        Private Sub RaiseEvents(Of T As EventArgs)(ByVal vEventHandler As EventHandler(Of T), ByVal rawEvent As SDL.SDL_Event)
            Dim eventArgs = CreateEventArgs(Of T)(rawEvent)
            RaiseEvents(vEventHandler, eventArgs)
        End Sub

        Private Sub RaiseEvents(Of T As EventArgs)(ByVal vEventHandler As EventHandler(Of T), ByVal eventArgs As T)
            If vEventHandler IsNot Nothing Then
                'RaiseEvent vEventHandler(Me, eventArgs)
                vEventHandler(Me, eventArgs)
            End If
        End Sub

        Private Shared Function CreateEventArgs(Of T As Class)(ByVal rawEvent As SDL.SDL_Event) As T
            Try
                Return Activator.CreateInstance(GetType(T), New Object() {rawEvent}) 'TryCast(Activator.CreateInstance(GetType(T), New Object() {rawEvent}), T)
            Catch ex As Exception
                ' Failed
                Return Nothing
            End Try
        End Function
    End Class
End Namespace