Imports SDL2
Imports VisualBasicSDL.Shared 'Root Namespace = ""

Namespace Graphics
    Public Class Texture
        Implements ITexture

        Private renderer As IRenderer
        Private safeHandle As SafeTextureHandle
        Public Property Width As Integer Implements ITexture.Width
        Public Property Height As Integer Implements ITexture.Height
        Public Property PixelFormat As PixelFormat Implements ITexture.PixelFormat
        Public Property AccessMode As TextureAccessMode Implements ITexture.AccessMode

        Public Property Handle As IntPtr Implements ITexture.Handle
            Get
                Return safeHandle.DangerousGetHandle()
            End Get
            Private Set(value As IntPtr)
                safeHandle = New SafeTextureHandle(value)
            End Set
        End Property

        Friend Sub New(ByVal renderer As IRenderer, ByVal width As Integer, ByVal height As Integer, ByVal pixelFormat As PixelFormat, ByVal accessMode As TextureAccessMode)
            If renderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(renderer))
            End If

            If width < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(width))
            End If

            If height < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(height))
            End If

            Me.renderer = renderer
            Dim unsafeHandle As IntPtr = CreateTexture(width, height, pixelFormat, accessMode)
            Handle = unsafeHandle
            QueryTexture(unsafeHandle)
        End Sub

        Friend Sub New(ByVal renderer As IRenderer, ByVal surface As ISurface)
            If renderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(renderer))
            End If

            If surface Is Nothing Then
                Throw New ArgumentNullException(NameOf(surface))
            End If

            Me.renderer = renderer
            CreateTextureAndCleanup(surface)
        End Sub

        Friend Function CreateTexture(ByVal width As Integer, ByVal height As Integer, ByVal pixelFormat As PixelFormat, ByVal accessMode As TextureAccessMode) As IntPtr
            Dim mappedPixelFormat As UInteger = PixelFormatMap.EnumToSDL(pixelFormat)
            Dim unsafeHandle As IntPtr = SDL.SDL_CreateTexture(renderer.Handle, mappedPixelFormat, CInt(accessMode), width, height)

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_CreateTextureFromSurface"))
            End If

            Return unsafeHandle
        End Function

        Friend Function CreateTextureFromSurface(ByVal surface As ISurface) As IntPtr
            Dim unsafeHandle As IntPtr = SDL.SDL_CreateTextureFromSurface(renderer.Handle, surface.Handle)

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_CreateTextureFromSurface"))
            End If

            Return unsafeHandle
        End Function

        Private Sub QueryTexture(ByVal textureHandle As IntPtr)
            Dim format As UInteger = Nothing, access As Integer = Nothing, width As Integer = Nothing, height As Integer = Nothing
            SDL.SDL_QueryTexture(textureHandle, format, access, width, height)
            PixelFormat = PixelFormatMap.SDLToEnum(format)
            AccessMode = CType(access, TextureAccessMode)
            width = width
            height = height
        End Sub

        Public Sub UpdateSurfaceAndTexture(ByVal surface As ISurface) Implements ITexture.UpdateSurfaceAndTexture
            If surface Is Nothing Then
                Throw New ArgumentNullException(NameOf(surface))
            End If

            safeHandle.Dispose()
            CreateTextureAndCleanup(surface)
        End Sub

        Private Sub CreateTextureAndCleanup(ByVal surface As ISurface)
            Dim unsafeHandle As IntPtr = CreateTextureFromSurface(surface)
            Handle = unsafeHandle
            surface.Dispose()
            QueryTexture(unsafeHandle)
        End Sub

        Public Sub SetBlendMode(ByVal blendMode As BlendMode) Implements ITexture.SetBlendMode
            Dim result As Integer = SDL2.SDL.SDL_SetTextureBlendMode(Handle, CType(blendMode, SDL.SDL_BlendMode))

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetTextureBlendMode"))
            End If
        End Sub

        Public Sub SetColorMod(ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
            Dim result As Integer = SDL.SDL_SetTextureColorMod(Handle, r, g, b)

            If Utilities.IsError(result) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetTextureColorMod: {0}"))
            End If
        End Sub

        Public Sub Draw(ByVal x As Integer, ByVal y As Integer, ByVal angle As Double, ByVal center As Vector2D) Implements ITexture.Draw
            If renderer Is Nothing Then
                Throw New InvalidOperationException("Renderer is null. Has it been disposed?")
            End If

            renderer.RenderTexture(Me, x, y, Width, Height, angle, center)
        End Sub

        Public Sub Draw(ByVal x As Integer, ByVal y As Integer, ByVal sourceBounds As Rectangle) Implements ITexture.Draw
            If renderer Is Nothing Then
                Throw New InvalidOperationException("Renderer is null. Has it been disposed?")
            End If

            renderer.RenderTexture(Me, x, y, sourceBounds)
        End Sub

        Public Sub Draw(ByVal x As Single, ByVal y As Single, ByVal sourceBounds As Rectangle) Implements ITexture.Draw
            Draw(CInt(x), CInt(y), sourceBounds)
        End Sub

        Public Sub Draw(ByVal x As Integer, ByVal y As Integer) Implements ITexture.Draw
            If renderer Is Nothing Then
                Throw New InvalidOperationException("Renderer is null. Has it been disposed?")
            End If

            renderer.RenderTexture(Me, x, y, Width, Height)
        End Sub

        Public Sub Draw(ByVal x As Single, ByVal y As Single) Implements ITexture.Draw
            Draw(CInt(x), CInt(y))
        End Sub

        Public Sub Dispose() Implements ITexture.Dispose
            Dispose(True)
            GC.SuppressFinalize(True)
        End Sub

        Private Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                safeHandle.Dispose()
            End If
        End Sub
    End Class

End Namespace