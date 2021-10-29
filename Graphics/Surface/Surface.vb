Imports SDL2
Imports System
Imports System.Runtime.InteropServices

Namespace Graphics

    Public Class Surface : Implements ISurface

        Private disposedValue As Boolean
        Private safeHandle As SafeSurfaceHandle = Nothing

        ' storage values
        Private mFilePath As String = ""
        Private mWidth As Integer = 0
        Private mHeight As Integer = 0
        Private mType As SurfaceType

        ''' <summary>
        ''' Create surface from an image file.
        ''' </summary>
        ''' <param name="vFilePath"> File direct path. </param>
        ''' <param name="vSurfaceType"> Type of surface </param>
        Public Sub New(vFilePath As String, vSurfaceType As SurfaceType)
            If String.IsNullOrEmpty(vFilePath) Then
                Throw New ArgumentNullException(NameOf(FilePath))
            End If

            FilePath = vFilePath
            Type = vSurfaceType

            Dim unsafeHandle As IntPtr = SDL_image.IMG_Load(FilePath)
            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException($"Error while loading image surface: {SDL.SDL_GetError()}")
            End If

            Handle = unsafeHandle

            GetSurfaceMetaData()
        End Sub

        ''' <summary>
        ''' Blended text Surface
        ''' </summary>
        ''' <returns></returns>
        Public Sub New(vFont As IFont, vText As String, vColor As SDLColor, vWrapLength As Integer)
            If vFont Is Nothing Then
                Throw New ArgumentNullException(NameOf(vFont))
            End If
            If String.IsNullOrEmpty(vText) Then
                'if its not empty then its a null
                If vText.Length <> 0 Then
                    Throw New ArgumentNullException(NameOf(vText))
                End If
            End If
            If vColor Is Nothing Then
                Throw New ArgumentNullException(NameOf(vColor))
            End If
            If vWrapLength < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vWrapLength), "Wrap length must be greater than or equal to 0.")
            End If


            Type = SurfaceType.Text
            Dim unsafeHandle As IntPtr = IntPtr.Zero

            If vWrapLength > 0 Then
                unsafeHandle = SDL_ttf.TTF_RenderText_Blended_Wrapped(vFont.Handle, vText, vColor.RawColor, vWrapLength)
            Else
                unsafeHandle = SDL_ttf.TTF_RenderText_Blended(vFont.Handle, vText, vColor.RawColor)
            End If

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException($"Error while loading text surface: {SDL.SDL_GetError()}")
            End If

            Handle = unsafeHandle

            GetSurfaceMetaData()
        End Sub

        ''' <summary>
        ''' Solid text Surface
        ''' </summary>
        ''' <returns></returns>
        Public Sub New(vFont As IFont, vText As String, vColor As SDLColor)
            If vFont Is Nothing Then
                Throw New ArgumentNullException(NameOf(vFont))
            End If
            If String.IsNullOrEmpty(vText) Then
                'if its not empty then its a null
                If vText.Length <> 0 Then
                    Throw New ArgumentNullException(NameOf(vText))
                End If
            End If
            If vColor Is Nothing Then
                Throw New ArgumentNullException(NameOf(vColor))
            End If

            Type = SurfaceType.Text
            Dim unsafeHandle As IntPtr = IntPtr.Zero

            unsafeHandle = SDL_ttf.TTF_RenderText_Solid(vFont.Handle, vText, vColor.RawColor)

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException($"Error while loading text surface: {SDL.SDL_GetError()}")
            End If

            Handle = unsafeHandle

            GetSurfaceMetaData()
        End Sub

        ''' <summary>
        ''' Shaded text Surface
        ''' </summary>
        ''' <returns></returns>
        Public Sub New(vFont As IFont, vText As String, vForeColor As SDLColor, vShadowColor As SDLColor)
            If vFont Is Nothing Then
                Throw New ArgumentNullException(NameOf(vFont))
            End If
            If String.IsNullOrEmpty(vText) Then
                'if its not empty then its a null
                If vText.Length <> 0 Then
                    Throw New ArgumentNullException(NameOf(vText))
                End If
            End If
            If vForeColor Is Nothing Then
                Throw New ArgumentNullException(NameOf(vForeColor))
            End If
            If vShadowColor Is Nothing Then
                Throw New ArgumentNullException(NameOf(vShadowColor))
            End If

            Type = SurfaceType.Text
            Dim unsafeHandle As IntPtr = IntPtr.Zero

            unsafeHandle = SDL_ttf.TTF_RenderText_Shaded(vFont.Handle, vText, vForeColor.RawColor, vShadowColor.RawColor)

            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException($"Error while loading text surface: {SDL.SDL_GetError()}")
            End If

            Handle = unsafeHandle

            GetSurfaceMetaData()
        End Sub


        Public Property FilePath As String Implements ISurface.FilePath
            Get
                Return mFilePath
            End Get
            Private Set(ByVal value As String)
                mFilePath = value
            End Set
        End Property
        Public Property Width As Integer Implements ISurface.Width
            Get
                Return mWidth
            End Get
            Private Set(ByVal value As Integer)
                mWidth = value
            End Set
        End Property
        Public Property Height As Integer Implements ISurface.Height
            Get
                Return mHeight
            End Get
            Private Set(ByVal value As Integer)
                mHeight = value
            End Set
        End Property
        Public Property Type As SurfaceType Implements ISurface.Type
            Get
                Return mType
            End Get
            Private Set(ByVal value As SurfaceType)
                mType = value
            End Set
        End Property
        Public Property Handle As IntPtr Implements ISurface.Handle
            Get
                Return safeHandle.DangerousGetHandle()
            End Get
            Private Set(ByVal value As IntPtr)
                If safeHandle Is Nothing Then
                    safeHandle = New SafeSurfaceHandle(value)
                Else
                    ' if we are going to update this handle
                    ' we need to destroy the previous one
                    Throw New InvalidOperationException($"Error: Attempted to overwrite an existing pointer (Surface.Handle)")
                End If
            End Set
        End Property

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    safeHandle.Dispose()
                End If
                disposedValue = True
            End If
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub

        Private Sub GetSurfaceMetaData()
            Dim rawSurface As SDL.SDL_Surface = CType(Marshal.PtrToStructure(Handle, GetType(SDL.SDL_Surface)), SDL.SDL_Surface)
            Width = rawSurface.w
            Height = rawSurface.h
        End Sub

    End Class

End Namespace