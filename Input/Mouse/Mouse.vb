Imports System.Linq
Imports SDL2
Imports System.Collections.Generic
Imports System
Imports VisualBasicSDL.[Shared]

Namespace VisualBasicSDL.Input
    Module Mouse
        Public Property X As Integer
        Public Property Y As Integer
        Public Property ButtonsPressed As IEnumerable(Of MouseButtonCode)
        Public Property PreviousButtonsPressed As IEnumerable(Of MouseButtonCode)

        Sub UpdateMousePosition(ByVal x As Integer, ByVal y As Integer)
            x = x
            y = y
        End Sub

        Sub UpdateMouseState()
            PreviousButtonsPressed = ButtonsPressed
            Dim currentMouseState = GetState()
            ButtonsPressed = currentMouseState.ButtonsPressed
        End Sub

        Private Function GetState() As MouseState
            Dim x As Integer = 0
            Dim y As Integer = 0
            Dim buttonBitMask As UInteger = SDL.SDL_GetMouseState(x, y)
            Dim buttonsPressed As List(Of MouseButtonCode) = New List(Of MouseButtonCode)()
            If IsButtonPressed(buttonBitMask, MouseButtonCode.Left) Then buttonsPressed.Add(MouseButtonCode.Left)
            If IsButtonPressed(buttonBitMask, MouseButtonCode.Right) Then buttonsPressed.Add(MouseButtonCode.Right)
            If IsButtonPressed(buttonBitMask, MouseButtonCode.Middle) Then buttonsPressed.Add(MouseButtonCode.Middle)
            If IsButtonPressed(buttonBitMask, MouseButtonCode.X1) Then buttonsPressed.Add(MouseButtonCode.X1)
            If IsButtonPressed(buttonBitMask, MouseButtonCode.X2) Then buttonsPressed.Add(MouseButtonCode.X2)
            Return New MouseState() With {
                .x = x,
                .y = y,
                .buttonsPressed = buttonsPressed
            }
        End Function

        Private Function IsButtonPressed(ByVal buttonsPressedBitmask As UInteger, ByVal mouseButtonCode As MouseButtonCode) As Boolean
            Dim buttonPressedMacroResult = SDL.SDL_BUTTON(CUInt(mouseButtonCode))
            Dim bitmaskComparisonResult = buttonsPressedBitmask And buttonPressedMacroResult
            Return bitmaskComparisonResult > 0
        End Function

        Sub ShowCursor()
            Dim result As Integer = SDL.SDL_ShowCursor(SDL.SDL_ENABLE)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_ShowCursor"))
            End If
        End Sub

        Sub HideCursor()
            Dim result As Integer = SDL.SDL_ShowCursor(SDL.SDL_DISABLE)
            If Utilities.IsError(result) Then Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_HideCursor"))
        End Sub
    End Module
End Namespace