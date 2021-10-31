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

        Sub UpdateMousePosition(ByVal vX As Integer, ByVal vY As Integer)
            X = vX
            Y = vY
        End Sub

        Sub UpdateMouseState()
            PreviousButtonsPressed = ButtonsPressed
            Dim currentMouseState = GetState()
            ButtonsPressed = currentMouseState.ButtonsPressed
        End Sub

        Private Function GetState() As MouseState
            Dim locX As Integer = 0
            Dim locY As Integer = 0
            Dim buttonBitMask As UInteger = SDL.SDL_GetMouseState(locX, locY)
            Dim buttonsPressed As List(Of MouseButtonCode) = New List(Of MouseButtonCode)()
            If IsButtonPressed(buttonBitMask, MouseButtonCode.Left) Then buttonsPressed.Add(MouseButtonCode.Left)
            If IsButtonPressed(buttonBitMask, MouseButtonCode.Right) Then buttonsPressed.Add(MouseButtonCode.Right)
            If IsButtonPressed(buttonBitMask, MouseButtonCode.Middle) Then buttonsPressed.Add(MouseButtonCode.Middle)
            If IsButtonPressed(buttonBitMask, MouseButtonCode.X1) Then buttonsPressed.Add(MouseButtonCode.X1)
            If IsButtonPressed(buttonBitMask, MouseButtonCode.X2) Then buttonsPressed.Add(MouseButtonCode.X2)
            Return New MouseState() With {
                .X = locX,
                .Y = locY,
                .ButtonsPressed = buttonsPressed
            }
        End Function

        Private Function IsButtonPressed(ByVal vButtonsPressedBitmask As UInteger, ByVal vMouseButtonCode As MouseButtonCode) As Boolean
            Dim locButtonPressedMacroResult = SDL.SDL_BUTTON(CUInt(vMouseButtonCode))
            Dim LocBitmaskComparisonResult = vButtonsPressedBitmask And locButtonPressedMacroResult
            Return LocBitmaskComparisonResult > 0
        End Function

        Sub ShowCursor()
            Dim locResult As Integer = SDL.SDL_ShowCursor(SDL.SDL_ENABLE)

            If Utilities.IsError(locResult) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_ShowCursor"))
            End If
        End Sub

        Sub HideCursor()
            Dim locResult As Integer = SDL.SDL_ShowCursor(SDL.SDL_DISABLE)
            If Utilities.IsError(locResult) Then Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_HideCursor"))
        End Sub
    End Module
End Namespace