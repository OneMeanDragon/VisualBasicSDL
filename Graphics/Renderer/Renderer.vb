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

        Friend Sub New(ByVal vWindow As IWindow, ByVal Optional vLogger As ILogger(Of Renderer) = Nothing)
            Me.New(vWindow, 0, RendererFlags.None)
        End Sub

        Friend Sub New(ByVal vWindow As IWindow, ByVal vIndex As Integer, ByVal vFlags As RendererFlags, ByVal Optional logger As ILogger(Of Renderer) = Nothing)
            If vWindow Is Nothing Then
                Throw New ArgumentNullException(NameOf(vWindow), "Window has not been initialized. You must first create a Window before creating a Renderer.")
            End If

            If vIndex < -1 Then
                Throw New ArgumentOutOfRangeException(NameOf(vIndex))
            End If

            Me.logger = logger
            Window = vWindow
            Index = vIndex
            Dim copyFlags As List(Of RendererFlags) = New List(Of RendererFlags)()

            For Each flag As RendererFlags In [Enum].GetValues(GetType(RendererFlags))

                If vFlags.HasFlag(flag) Then
                    Me.mFlags.Add(flag)
                End If
            Next

            Dim unsafeHandle As IntPtr = SDL.SDL_CreateRenderer(Window.Handle, Index, CType(vFlags, SDL.SDL_RendererFlags))

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_CreateRenderer"))
            End If

            Handle = unsafeHandle
        End Sub

        Public Sub ClearScreen() Implements IRenderer.ClearScreen
            Dim lResult As Integer = SDL.SDL_RenderClear(Handle)

            If Utilities.IsError(lResult) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_RenderClear"))
            End If
        End Sub

        Public Sub RenderTexture(ByVal vTexture As ITexture, ByVal vPositionX As Single, ByVal vPositionY As Single, ByVal vSourceWidth As Integer, ByVal vSourceHeight As Integer, ByVal vAngle As Double, ByVal vCenter As Vector2D) Implements IRenderer.RenderTexture
            If vTexture.Handle = IntPtr.Zero Then
                Throw New ArgumentNullException(NameOf(vTexture.Handle))
            End If

            Dim lDestinationRectangle As SDL.SDL_Rect = New SDL.SDL_Rect() With {
                .x = CInt(vPositionX),
                .y = CInt(vPositionY),
                .w = vSourceWidth,
                .h = vSourceHeight
            }
            Dim lSourceRectangle As SDL.SDL_Rect = New SDL.SDL_Rect() With {
                .x = 0,
                .y = 0,
                .w = vSourceWidth,
                .h = vSourceHeight
            }
            Dim lCenterPoint As SDL.SDL_Point = New SDL.SDL_Point() With {
                .x = CInt(vCenter.X),
                .y = CInt(vCenter.Y)
            }
            Dim lResult As Integer = SDL.SDL_RenderCopyEx(Handle, vTexture.Handle, lSourceRectangle, lDestinationRectangle, vAngle, lCenterPoint, SDL.SDL_RendererFlip.SDL_FLIP_NONE)

            If Utilities.IsError(lResult) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_RenderCopyEx"))
            End If
        End Sub

        Public Sub RenderTexture(ByVal vTexture As ITexture, ByVal vPositionX As Single, ByVal vPositionY As Single, ByVal vSourceWidth As Integer, ByVal vSourceHeight As Integer) Implements IRenderer.RenderTexture
            Dim lSource As Rectangle = New Rectangle(0, 0, vSourceWidth, vSourceHeight)
            RenderTexture(vTexture, vPositionX, vPositionY, lSource)
        End Sub

        Public Sub RenderTexture(ByVal vTexture As ITexture, ByVal vPositionX As Single,
                                 ByVal vPositionY As Single, ByVal vSource As Rectangle) Implements IRenderer.RenderTexture
            If vTexture.Handle = IntPtr.Zero Then
                Throw New ArgumentNullException(NameOf(vTexture.Handle))
            End If

            Dim lWidth As Integer = vSource.Width
            Dim lHeight As Integer = vSource.Height
            Dim lDestinationRectangle As SDL.SDL_Rect = New SDL.SDL_Rect() With {
                .x = CInt(vPositionX),
                .y = CInt(vPositionY),
                .w = lWidth,
                .h = lHeight
            }
            Dim lSourceRectangle As SDL.SDL_Rect = New SDL.SDL_Rect() With {
                .x = vSource.X,
                .y = vSource.Y,
                .w = lWidth,
                .h = lHeight
            }
            Dim lResult As Integer = SDL.SDL_RenderCopy(Handle, vTexture.Handle, lSourceRectangle, lDestinationRectangle)

            If Utilities.IsError(lResult) Then
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

        Public Sub SetRenderTarget(ByVal vRenderTarget As ITexture) Implements IRenderer.SetRenderTarget
            If Not mFlags.Contains(RendererFlags.SupportRenderTargets) Then
                Throw New InvalidOperationException("This renderer does not support render targets. Did you create the renderer with the RendererFlags.SupportRenderTargets flag?")
            End If

            Dim lResult As Integer = SDL2.SDL.SDL_SetRenderTarget(Handle, vRenderTarget.Handle)

            If Utilities.IsError(lResult) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetRenderTarget"))
            End If
        End Sub

        Public Sub SetBlendMode(ByVal vBlendMode As BlendMode) Implements IRenderer.SetBlendMode
            Dim result As Integer = SDL2.SDL.SDL_SetRenderDrawBlendMode(Handle, CType(vBlendMode, SDL2.SDL.SDL_BlendMode))

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetRenderDrawBlendMode"))
            End If
        End Sub

        Public Sub SetDrawColor(ByVal vR As Byte, ByVal vG As Byte,
                                ByVal vB As Byte, ByVal vA As Byte) Implements IRenderer.SetDrawColor
            Dim lResult As Integer = SDL.SDL_SetRenderDrawColor(Handle, vR, vG, vB, vA)

            If Utilities.IsError(lResult) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetRenderDrawColor"))
            End If
        End Sub

        Public Sub SetRenderLogicalSize(ByVal vWidth As Integer, ByVal vHeight As Integer) Implements IRenderer.SetRenderLogicalSize
            If vWidth < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vWidth))
            End If

            If vHeight < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vHeight))
            End If

            Dim lResult As Integer = SDL2.SDL.SDL_RenderSetLogicalSize(Handle, vWidth, vHeight)

            If Utilities.IsError(lResult) Then
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
