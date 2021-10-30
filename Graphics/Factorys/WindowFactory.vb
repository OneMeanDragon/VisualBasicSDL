Imports System
Imports Microsoft.Extensions.Logging

Namespace VisualBasicSDL.Graphics
    Public Class WindowFactory
        Implements IWindowFactory

        Private ReadOnly logger As ILogger(Of WindowFactory)
        Private ReadOnly loggerWindow As ILogger(Of Window)

        Public Sub New(ByVal Optional logger As ILogger(Of WindowFactory) = Nothing, ByVal Optional loggerWindow As ILogger(Of Window) = Nothing)
            Me.logger = logger
            Me.loggerWindow = loggerWindow
        End Sub

        Public Function CreateWindow(ByVal title As String) As IWindow Implements IWindowFactory.CreateWindow
            Return CreateWindow(title, 100, 100, 1280, 720, WindowFlags.Shown)
        End Function

        Public Function CreateWindow(ByVal title As String, ByVal x As Integer, ByVal y As Integer) As IWindow Implements IWindowFactory.CreateWindow
            Return CreateWindow(title, x, y, 1280, 720, WindowFlags.Shown)
        End Function

        Public Function CreateWindow(ByVal title As String, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer) As IWindow Implements IWindowFactory.CreateWindow
            Return CreateWindow(title, x, y, width, height, WindowFlags.Shown)
        End Function

        Public Function CreateWindow(ByVal title As String, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal flags As WindowFlags) As IWindow Implements IWindowFactory.CreateWindow
            Try
                Dim window = New Window(title, x, y, width, height, flags, loggerWindow)
                logger?.LogTrace($"Window created. Title = {window.Title}, X = {window.X}, Y = {window.Y}, Width = {window.Width}, Height = {window.Height}, Handle = {window.Handle}.")
                Return window
            Catch ex As Exception
                logger?.LogError(ex, ex.Message)
                Throw
            End Try
        End Function
    End Class
End Namespace