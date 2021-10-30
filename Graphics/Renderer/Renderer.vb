Imports Microsoft.Extensions.Logging
Imports SDL2
Imports VisualBasicSDL.[Shared]
Imports System.Collections.Generic

Namespace VisualBasicSDL.Graphics
    Public Class Renderer
        Implements IRenderer

        Private ReadOnly logger As ILogger(Of Renderer)
        Private safeHandle As SafeRendererHandle = Nothing
        Private mFlags As List(Of RendererFlags) = New List(Of RendererFlags)()
        Public Property Window As IWindow Implements IRenderer.Window
        Public Property Index As Integer Implements IRenderer.Index

        Public Property Flags As IEnumerable(Of RendererFlags) Implements IRenderer.Flags
            Get
                Return mFlags
            End Get
            Private Set(value As IEnumerable(Of RendererFlags))
                mFlags = value
            End Set
        End Property

        Public Property Handle As IntPtr Implements IRenderer.Handle
            Get
                Return safeHandle.DangerousGetHandle()
            End Get
            Private Set(value As IntPtr)
                If safeHandle Is Nothing Then
                    safeHandle = New SafeRendererHandle(value)
                Else
                    Throw New ArgumentOutOfRangeException(NameOf(Handle))
                End If
            End Set
        End Property

        Friend Sub New(ByVal window As IWindow, ByVal Optional logger As ILogger(Of Renderer) = Nothing)
            Me.New(window, 0, RendererFlags.None)
        End Sub

        Friend Sub New(ByVal window As IWindow, ByVal index As Integer, ByVal flags As RendererFlags, ByVal Optional logger As ILogger(Of Renderer) = Nothing)
            If window Is Nothing Then
                Throw New ArgumentNullException(NameOf(window), "Window has not been initialized. You must first create a Window before creating a Renderer.")
            End If

            If index < -1 Then
                Throw New ArgumentOutOfRangeException(NameOf(index))
            End If

            Me.logger = logger
            window = window
            index = index
            Dim copyFlags As List(Of RendererFlags) = New List(Of RendererFlags)()

            For Each flag As RendererFlags In [Enum].GetValues(GetType(RendererFlags))

                If flags.HasFlag(flag) Then
                    Me.mFlags.Add(flag)
                End If
            Next

            Dim unsafeHandle As IntPtr = SDL.SDL_CreateRenderer(window.Handle, index, CType(flags, SDL.SDL_RendererFlags))

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_CreateRenderer"))
            End If

            Handle = unsafeHandle
        End Sub

        Public Sub ClearScreen() Implements IRenderer.ClearScreen
            Dim result As Integer = SDL.SDL_RenderClear(Handle)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_RenderClear"))
            End If
        End Sub

        Public Sub RenderTexture(ByVal texture As ITexture, ByVal positionX As Single, ByVal positionY As Single, ByVal sourceWidth As Integer, ByVal sourceHeight As Integer, ByVal angle As Double, ByVal center As Vector2D) Implements IRenderer.RenderTexture
            If texture.Handle = IntPtr.Zero Then
                Throw New ArgumentNullException(NameOf(texture.Handle))
            End If

            Dim destinationRectangle As SDL.SDL_Rect = New SDL.SDL_Rect() With {
                .x = CInt(positionX),
                .y = CInt(positionY),
                .w = sourceWidth,
                .h = sourceHeight
            }
            Dim sourceRectangle As SDL.SDL_Rect = New SDL.SDL_Rect() With {
                .x = 0,
                .y = 0,
                .w = sourceWidth,
                .h = sourceHeight
            }
            Dim centerPoint As SDL.SDL_Point = New SDL.SDL_Point() With {
                .x = CInt(center.X),
                .y = CInt(center.Y)
            }
            Dim result As Integer = SDL.SDL_RenderCopyEx(Handle, texture.Handle, sourceRectangle, destinationRectangle, angle, centerPoint, SDL.SDL_RendererFlip.SDL_FLIP_NONE)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_RenderCopyEx"))
            End If
        End Sub

        Public Sub RenderTexture(ByVal texture As ITexture, ByVal positionX As Single, ByVal positionY As Single, ByVal sourceWidth As Integer, ByVal sourceHeight As Integer) Implements IRenderer.RenderTexture
            Dim source As Rectangle = New Rectangle(0, 0, sourceWidth, sourceHeight)
            RenderTexture(texture, positionX, positionY, source)
        End Sub

        Public Sub RenderTexture(ByVal texture As ITexture, ByVal positionX As Single, ByVal positionY As Single, ByVal source As Rectangle) Implements IRenderer.RenderTexture
            If texture.Handle = IntPtr.Zero Then
                Throw New ArgumentNullException(NameOf(texture.Handle))
            End If

            Dim width As Integer = source.Width
            Dim height As Integer = source.Height
            Dim destinationRectangle As SDL.SDL_Rect = New SDL.SDL_Rect() With {
                .x = CInt(positionX),
                .y = CInt(positionY),
                .w = width,
                .h = height
            }
            Dim sourceRectangle As SDL.SDL_Rect = New SDL.SDL_Rect() With {
                .x = source.X,
                .y = source.Y,
                .w = width,
                .h = height
            }
            Dim result As Integer = SDL.SDL_RenderCopy(Handle, texture.Handle, sourceRectangle, destinationRectangle)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_RenderCopy"))
            End If
        End Sub

        Public Sub RenderPresent() Implements IRenderer.RenderPresent
            SDL.SDL_RenderPresent(Handle)
        End Sub

        Public Sub ResetRenderTarget() Implements IRenderer.ResetRenderTarget
            Dim result As Integer = SDL2.SDL.SDL_SetRenderTarget(Handle, IntPtr.Zero)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetRenderTarget"))
            End If
        End Sub

        Public Sub SetRenderTarget(ByVal renderTarget As ITexture) Implements IRenderer.SetRenderTarget
            If Not mFlags.Contains(RendererFlags.SupportRenderTargets) Then
                Throw New InvalidOperationException("This renderer does not support render targets. Did you create the renderer with the RendererFlags.SupportRenderTargets flag?")
            End If

            Dim result As Integer = SDL2.SDL.SDL_SetRenderTarget(Handle, renderTarget.Handle)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetRenderTarget"))
            End If
        End Sub

        Public Sub SetBlendMode(ByVal blendMode As BlendMode) Implements IRenderer.SetBlendMode
            Dim result As Integer = SDL2.SDL.SDL_SetRenderDrawBlendMode(Handle, CType(blendMode, SDL2.SDL.SDL_BlendMode))

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetRenderDrawBlendMode"))
            End If
        End Sub

        Public Sub SetDrawColor(ByVal r As Byte, ByVal g As Byte, ByVal b As Byte, ByVal a As Byte) Implements IRenderer.SetDrawColor
            Dim result As Integer = SDL.SDL_SetRenderDrawColor(Handle, r, g, b, a)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetRenderDrawColor"))
            End If
        End Sub

        Public Sub SetRenderLogicalSize(ByVal width As Integer, ByVal height As Integer) Implements IRenderer.SetRenderLogicalSize
            If width < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(width))
            End If

            If height < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(height))
            End If

            Dim result As Integer = SDL2.SDL.SDL_RenderSetLogicalSize(Handle, width, height)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_RenderSetLogicalSize"))
            End If
        End Sub

        Public Sub Dispose() Implements IRenderer.Dispose
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
