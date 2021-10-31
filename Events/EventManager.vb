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

        Public Sub RaiseExiting(ByVal vSender As Object, ByVal vArgs As EventArgs) Implements IEventManager.RaiseExiting
            RaiseEvent Exiting(vSender, vArgs)
        End Sub

        Public Sub RaiseEvents(ByVal vRawEvent As SDL.SDL_Event) Implements IEventManager.RaiseEvents
            Dim eventType = CType(vRawEvent.type, GameEventType)
            'Dim argEventData = CreateEventArgs(Of EventArgs)(vRawEvent)
            'If argEventData Is Nothing Then
            '    Return
            'End If

            Select Case eventType
                Case GameEventType.First
                    Return
                Case GameEventType.Window
                    Dim windowEventType = CType(vRawEvent.window.windowEvent, WindowEventType)

                    Select Case windowEventType
                        Case WindowEventType.Close
                            RaiseEvent WindowClosed(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowClosed, rawEvent)
                        Case WindowEventType.Enter
                            RaiseEvent WindowEntered(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowEntered, rawEvent)
                        Case WindowEventType.Exposed
                            RaiseEvent WindowExposed(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowExposed, rawEvent)
                        Case WindowEventType.FocusGained
                            RaiseEvent WindowFocusGained(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowFocusGained, rawEvent)
                        Case WindowEventType.FocusLost
                            RaiseEvent WindowFocusLost(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowFocusLost, rawEvent)
                        Case WindowEventType.Hidden
                            RaiseEvent WindowHidden(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowHidden, rawEvent)
                        Case WindowEventType.Leave
                            RaiseEvent WindowLeave(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowLeave, rawEvent)
                        Case WindowEventType.Maximized
                            RaiseEvent WindowMaximized(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowMaximized, rawEvent)
                        Case WindowEventType.Minimized
                            RaiseEvent WindowMinimized(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowMinimized, rawEvent)
                        Case WindowEventType.Moved
                            RaiseEvent WindowMoved(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowMoved, rawEvent)
                        Case WindowEventType.Resized
                            RaiseEvent WindowResized(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowResized, rawEvent)
                        Case WindowEventType.Restored
                            RaiseEvent WindowRestored(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowRestored, rawEvent)
                        Case WindowEventType.Shown
                            RaiseEvent WindowShown(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowShown, rawEvent)
                        Case WindowEventType.SizeChanged
                            RaiseEvent WindowSizeChanged(Me, CreateEventArgs(Of WindowEventArgs)(vRawEvent)) 'RaiseEvents(WindowSizeChanged, rawEvent)
                    End Select

                Case GameEventType.Quit
                    RaiseEvent Quitting(Me, CreateEventArgs(Of QuitEventArgs)(vRawEvent)) 'RaiseEvents(Quitting, rawEvent)
                Case GameEventType.VideoDeviceSystemEvent
                    RaiseEvent VideoDeviceSystemEvent(Me, CreateEventArgs(Of VideoDeviceSystemEventArgs)(vRawEvent)) 'RaiseEvents(VideoDeviceSystemEvent, rawEvent)
                Case GameEventType.TextEditing
                    RaiseEvent TextEditing(Me, CreateEventArgs(Of TextEditingEventArgs)(vRawEvent)) 'RaiseEvents(TextEditing, rawEvent)
                Case GameEventType.TextInput
                    RaiseEvent TextInputting(Me, CreateEventArgs(Of TextInputEventArgs)(vRawEvent)) 'RaiseEvents(TextInputting, rawEvent)
                Case GameEventType.KeyDown, GameEventType.KeyUp
                    Dim keyState = CType(vRawEvent.key.state, KeyState)

                    If keyState = KeyState.Pressed Then
                        RaiseEvent KeyPressed(Me, CreateEventArgs(Of KeyboardEventArgs)(vRawEvent)) 'RaiseEvents(KeyPressed, rawEvent)
                    ElseIf keyState = KeyState.Released Then
                        RaiseEvent KeyReleased(Me, CreateEventArgs(Of KeyboardEventArgs)(vRawEvent)) 'RaiseEvents(KeyReleased, rawEvent)
                    End If

                Case GameEventType.MouseMotion
                    Mouse.UpdateMousePosition(vRawEvent.motion.x, vRawEvent.motion.y)
                    RaiseEvent MouseMoving(Me, CreateEventArgs(Of MouseMotionEventArgs)(vRawEvent)) 'RaiseEvents(MouseMoving, vRawEvent)
                Case GameEventType.MouseButtonDown, GameEventType.MouseButtonUp
                    Dim mouseButtonState = CType(vRawEvent.button.state, MouseButtonState)

                    If mouseButtonState = MouseButtonState.Pressed Then
                        RaiseEvent MouseButtonPressed(Me, CreateEventArgs(Of MouseButtonEventArgs)(vRawEvent)) 'RaiseEvents(MouseButtonPressed, rawEvent)
                    ElseIf mouseButtonState = MouseButtonState.Released Then
                        RaiseEvent MouseButtonReleased(Me, CreateEventArgs(Of MouseButtonEventArgs)(vRawEvent)) 'RaiseEvents(MouseButtonReleased, rawEvent)
                    End If

                Case GameEventType.MouseWheel
                    RaiseEvent MouseWheelScrolling(Me, CreateEventArgs(Of MouseWheelEventArgs)(vRawEvent)) 'RaiseEvents(MouseWheelScrolling, rawEvent)
            End Select
        End Sub

        Private Sub RaiseEvents(Of T As EventArgs)(ByVal vEventHandler As EventHandler(Of T), ByVal vRawEvent As SDL.SDL_Event)
            Dim locEventArgs = CreateEventArgs(Of T)(vRawEvent)
            RaiseEvents(vEventHandler, locEventArgs)
        End Sub

        Private Sub RaiseEvents(Of T As EventArgs)(ByVal vEventHandler As EventHandler(Of T), ByVal vEventArgs As T)
            If vEventHandler IsNot Nothing Then
                'RaiseEvent vEventHandler(Me, vEventArgs)
                vEventHandler(Me, vEventArgs)
            End If
        End Sub

        Private Shared Function CreateEventArgs(Of T As Class)(ByVal vRawEvent As SDL.SDL_Event) As T
            Return TryCast(Activator.CreateInstance(GetType(T), New Object() {vRawEvent}), T)
        End Function
    End Class
End Namespace