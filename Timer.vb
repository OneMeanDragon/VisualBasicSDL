Imports SDL2
Imports System

Namespace VisualBasicSDL
    Public Class Timer
        Private mstartedAtTicks As UInteger = 0
        Private mpausedTicks As UInteger = 0
        Private misStarted As Boolean = False
        Private misPaused As Boolean = False

        Public ReadOnly Property StartedAtTime As TimeSpan
            Get
                Return TimeSpan.FromMilliseconds(CDbl(mstartedAtTicks))
            End Get
        End Property

        Public ReadOnly Property ElapsedTime As TimeSpan
            Get

                If isStarted Then

                    If isPaused Then
                        Return TimeSpan.FromMilliseconds(CDbl(mpausedTicks))
                    Else
                        Return TimeSpan.FromMilliseconds(CDbl((SDL.SDL_GetTicks() - mstartedAtTicks)))
                    End If
                Else
                    Return TimeSpan.Zero
                End If
            End Get
        End Property

        Public ReadOnly Property IsStarted As Boolean
            Get
                Return misStarted
            End Get
        End Property

        Public ReadOnly Property IsPaused As Boolean
            Get
                Return misPaused
            End Get
        End Property

        Public Sub Start()
            misStarted = True
            misPaused = False
            mstartedAtTicks = SDL.SDL_GetTicks()
        End Sub

        Public Sub [Stop]()
            misStarted = False
            misPaused = False
        End Sub

        Public Sub Pause()
            If isStarted AndAlso Not isPaused Then
                misPaused = True
                mpausedTicks = SDL.SDL_GetTicks() - mstartedAtTicks
            End If
        End Sub

        Public Sub Unpause()
            If isPaused Then
                misPaused = False
                mstartedAtTicks = SDL.SDL_GetTicks() - mpausedTicks
                mpausedTicks = 0
            End If
        End Sub
    End Class
End Namespace