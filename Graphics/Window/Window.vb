Imports Microsoft.Extensions.Logging
Imports SDL2
Imports System.Collections.Generic

Namespace VisualBasicSDL.Graphics
    Public Class Window
        Implements IWindow

        Private ReadOnly logger As ILogger(Of Window)
        Private safeHandle As SafeWindowHandle = Nothing
        Private mTitle As String
        Private mX As Integer
        Private mY As Integer
        Private mWidth As Integer
        Private mHeight As Integer
        Private mFlags As IEnumerable(Of WindowFlags)

        Public Property Title As String Implements IWindow.Title
            Get
                Return mTitle
            End Get
            Private Set(value As String)
                mTitle = value
            End Set
        End Property

        Public Property X As Integer Implements IWindow.X
            Get
                Return mX
            End Get
            Private Set(value As Integer)
                mX = value
            End Set
        End Property

        Public Property Y As Integer Implements IWindow.Y
            Get
                Return mY
            End Get
            Private Set(value As Integer)
                mY = value
            End Set
        End Property

        Public Property Width As Integer Implements IWindow.Width
            Get
                Return mWidth
            End Get
            Private Set(value As Integer)
                mWidth = value
            End Set
        End Property

        Public Property Height As Integer Implements IWindow.Height
            Get
                Return mHeight
            End Get
            Private Set(value As Integer)
                mHeight = value
            End Set
        End Property

        Public Property Flags As IEnumerable(Of WindowFlags) Implements IWindow.Flags
            Get
                Return mFlags
            End Get
            Private Set(value As IEnumerable(Of WindowFlags))
                mFlags = value
            End Set
        End Property

        Public Property Handle As IntPtr Implements IWindow.Handle
            Get
                Return safeHandle.DangerousGetHandle()
            End Get
            Private Set(value As IntPtr)
                If safeHandle Is Nothing Then
                    safeHandle = New SafeWindowHandle(value)
                Else
                    Throw New NotImplementedException()
                End If
            End Set
        End Property

        Friend Sub New(vtitle As String, vx As Integer, vy As Integer, vwidth As Integer, vheight As Integer, ByVal vflags As WindowFlags, ByVal Optional vlogger As ILogger(Of Window) = Nothing)
            If String.IsNullOrWhiteSpace(Title) Then
                Title = "Window Title"
            End If

            If vwidth < 0 Then
                Width = 0
            End If

            If vheight < 0 Then
                Height = 0
            End If

            Me.logger = vlogger
            Title = vtitle
            X = vx
            Y = vy
            Width = vwidth
            Height = vheight
            Dim copyFlags As List(Of WindowFlags) = New List(Of WindowFlags)()
            Dim outFlags As UInteger = 0

            For Each flag As WindowFlags In [Enum].GetValues(GetType(WindowFlags))

                If vflags.HasFlag(flag) Then
                    copyFlags.Add(flag)
                    outFlags &= flag
                End If
            Next

            Flags = copyFlags
            Dim unsafeHandle As IntPtr = SDL.SDL_CreateWindow(Me.Title, Me.X, Me.Y, Me.Width, Me.Height, CType(outFlags, SDL.SDL_WindowFlags))

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException($"SDL_CreateWindow: {SDL.SDL_GetError()}")
            End If

            Handle = unsafeHandle
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Private Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                safeHandle.Dispose()
            End If
        End Sub
    End Class
End Namespace