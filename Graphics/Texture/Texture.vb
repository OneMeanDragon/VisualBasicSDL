Imports SDL2
Imports VisualBasicSDL.Shared 'Root Namespace = ""

Namespace VisualBasicSDL.Graphics
    Public Class Texture
        Implements ITexture

        Private mRenderer As IRenderer
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

        Friend Sub New(ByVal vRenderer As IRenderer, ByVal vWidth As Integer, ByVal vHeight As Integer, ByVal vPixelFormat As PixelFormat, ByVal vAccessMode As TextureAccessMode)
            If vRenderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(vRenderer))
            End If

            If vWidth < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vWidth))
            End If

            If vHeight < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vHeight))
            End If

            Me.mRenderer = vRenderer
            Dim unsafeHandle As IntPtr = CreateTexture(vWidth, vHeight, vPixelFormat, vAccessMode)
            Handle = unsafeHandle
            QueryTexture(unsafeHandle)
        End Sub

        Friend Sub New(ByVal vRenderer As IRenderer, ByVal vSurface As ISurface)
            If vRenderer Is Nothing Then
                Throw New ArgumentNullException(NameOf(vRenderer))
            End If

            If vSurface Is Nothing Then
                Throw New ArgumentNullException(NameOf(vSurface))
            End If

            Me.mRenderer = vRenderer
            CreateTextureAndCleanup(vSurface)
        End Sub

        Friend Function CreateTexture(ByVal vWidth As Integer, ByVal vHeight As Integer, ByVal vPixelFormat As PixelFormat, ByVal vAccessMode As TextureAccessMode) As IntPtr
            Dim mappedPixelFormat As UInteger = PixelFormatMap.EnumToSDL(vPixelFormat)
            Dim unsafeHandle As IntPtr = SDL.SDL_CreateTexture(mRenderer.Handle, mappedPixelFormat, CInt(vAccessMode), vWidth, vHeight)

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_CreateTextureFromSurface"))
            End If

            Return unsafeHandle
        End Function

        Friend Function CreateTextureFromSurface(ByVal vSurface As ISurface) As IntPtr
            Dim unsafeHandle As IntPtr = SDL.SDL_CreateTextureFromSurface(mRenderer.Handle, vSurface.Handle)

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_CreateTextureFromSurface"))
            End If

            Return unsafeHandle
        End Function

        Private Sub QueryTexture(ByVal vTextureHandle As IntPtr)
            Dim lformat As UInteger = Nothing, laccess As Integer = Nothing, lwidth As Integer = Nothing, lheight As Integer = Nothing
            SDL.SDL_QueryTexture(vTextureHandle, lformat, laccess, lwidth, lheight)
            PixelFormat = PixelFormatMap.SDLToEnum(lformat)
            AccessMode = CType(laccess, TextureAccessMode)
            Width = lwidth
            Height = lheight
        End Sub

        Public Sub UpdateSurfaceAndTexture(ByVal vSurface As ISurface) Implements ITexture.UpdateSurfaceAndTexture
            If vSurface Is Nothing Then
                Throw New ArgumentNullException(NameOf(vSurface))
            End If

            safeHandle.Dispose()
            CreateTextureAndCleanup(vSurface)
        End Sub

        Private Sub CreateTextureAndCleanup(ByVal vSurface As ISurface)
            Dim unsafeHandle As IntPtr = CreateTextureFromSurface(vSurface)
            Handle = unsafeHandle
            vSurface.Dispose()
            QueryTexture(unsafeHandle)
        End Sub

        Public Sub SetBlendMode(ByVal vBlendMode As BlendMode) Implements ITexture.SetBlendMode
            Dim lResult As Integer = SDL2.SDL.SDL_SetTextureBlendMode(Handle, CType(vBlendMode, SDL.SDL_BlendMode))

            If Utilities.IsError(lResult) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetTextureBlendMode"))
            End If
        End Sub

        Public Sub SetColorMod(ByVal vR As Byte, ByVal vG As Byte, ByVal vB As Byte)
            Dim lResult As Integer = SDL.SDL_SetTextureColorMod(Handle, vR, vG, vB)

            If Utilities.IsError(lResult) Then
                Throw New InvalidOperationException(Utilities.GetErrorMessage("SDL_SetTextureColorMod: {0}"))
            End If
        End Sub

        Public Sub Draw(ByVal vX As Integer, ByVal vY As Integer, ByVal vAngle As Double, ByVal vCenter As Vector2D) Implements ITexture.Draw
            If mRenderer Is Nothing Then
                Throw New InvalidOperationException("Renderer is null. Has it been disposed?")
            End If

            mRenderer.RenderTexture(Me, vX, vY, Width, Height, vAngle, vCenter)
        End Sub

        Public Sub Draw(ByVal vX As Integer, ByVal vY As Integer, ByVal vSourceBounds As Rectangle) Implements ITexture.Draw
            If mRenderer Is Nothing Then
                Throw New InvalidOperationException("Renderer is null. Has it been disposed?")
            End If

            mRenderer.RenderTexture(Me, vX, vY, vSourceBounds)
        End Sub

        Public Sub Draw(ByVal vX As Single, ByVal vY As Single, ByVal vSourceBounds As Rectangle) Implements ITexture.Draw
            Draw(CInt(vX), CInt(vY), vSourceBounds)
        End Sub

        Public Sub Draw(ByVal vX As Integer, ByVal vY As Integer) Implements ITexture.Draw
            If mRenderer Is Nothing Then
                Throw New InvalidOperationException("Renderer is null. Has it been disposed?")
            End If

            mRenderer.RenderTexture(Me, vX, vY, Width, Height)
        End Sub

        Public Sub Draw(ByVal vX As Single, ByVal vY As Single) Implements ITexture.Draw
            Draw(CInt(vX), CInt(vY))
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