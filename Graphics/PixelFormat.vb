Imports SDL2

Namespace VisualBasicSDL.Graphics
    Public Enum PixelFormat As UInteger
        Unknown
        RGBA5551
        ARGB1555
        BGRA4444
        ABGR4444
        RGBA4444
        ARGB4444
        BGR555
        RGB555
        ABGR1555
        BGR444
        RGB332
        INDEX8
        INDEX4MSB
        INDEX4LSB
        INDEX1MSB
        INDEX1LSB
        RGB444
        BGRA5551
        BGR565
        RGB565
        YVYU
        YUY2
        YV12
        ARGB2101010
        BGRA8888
        UYVY
        RGBA8888
        ARGB8888
        RGB24
        BGRX8888
        BGR24
        BGR888
        RGBX8888
        RGB888
        ABGR8888
    End Enum

    Friend Module PixelFormatMap
        Function SDLToEnum(ByVal vPixelFormat As UInteger) As PixelFormat
            If vPixelFormat = SDL.SDL_PIXELFORMAT_ABGR1555 Then
                Return PixelFormat.ABGR1555
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_ABGR4444 Then
                Return PixelFormat.ABGR4444
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_ARGB2101010 Then
                Return PixelFormat.ARGB2101010
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_ARGB4444 Then
                Return PixelFormat.ARGB4444
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_ARGB8888 Then
                Return PixelFormat.ARGB8888
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_BGR24 Then
                Return PixelFormat.BGR24
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_BGR444 Then
                Return PixelFormat.BGR444
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_BGR555 Then
                Return PixelFormat.BGR555
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_BGR565 Then
                Return PixelFormat.BGR565
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_BGR888 Then
                Return PixelFormat.BGR888
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_BGRA4444 Then
                Return PixelFormat.BGRA4444
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_BGRA5551 Then
                Return PixelFormat.BGRA5551
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_BGRA8888 Then
                Return PixelFormat.BGRA8888
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_BGRX8888 Then
                Return PixelFormat.BGRX8888
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_INDEX1LSB Then
                Return PixelFormat.INDEX1LSB
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_INDEX1MSB Then
                Return PixelFormat.INDEX1MSB
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_INDEX4LSB Then
                Return PixelFormat.INDEX4LSB
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_INDEX4MSB Then
                Return PixelFormat.INDEX4MSB
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_INDEX8 Then
                Return PixelFormat.INDEX8
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGB24 Then
                Return PixelFormat.RGB24
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGB332 Then
                Return PixelFormat.RGB332
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGB444 Then
                Return PixelFormat.RGB444
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGB555 Then
                Return PixelFormat.RGB555
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGB565 Then
                Return PixelFormat.RGB565
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGB888 Then
                Return PixelFormat.RGB888
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGBA4444 Then
                Return PixelFormat.RGBA4444
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGBA5551 Then
                Return PixelFormat.RGBA5551
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGBA8888 Then
                Return PixelFormat.RGBA8888
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_RGBX8888 Then
                Return PixelFormat.RGBX8888
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_UNKNOWN Then
                Return PixelFormat.Unknown
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_UYVY Then
                Return PixelFormat.UYVY
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_YUY2 Then
                Return PixelFormat.YUY2
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_YV12 Then
                Return PixelFormat.YV12
            End If

            If vPixelFormat = SDL.SDL_PIXELFORMAT_YVYU Then
                Return PixelFormat.YVYU
            Else
                Return PixelFormat.Unknown
            End If
        End Function

        Function EnumToSDL(ByVal vPixelFormat As PixelFormat) As UInteger
            Select Case vPixelFormat
                Case PixelFormat.ABGR1555
                    Return SDL.SDL_PIXELFORMAT_ABGR1555
                Case PixelFormat.ABGR4444
                    Return SDL.SDL_PIXELFORMAT_ABGR4444
                Case PixelFormat.ABGR8888
                    Return SDL.SDL_PIXELFORMAT_ABGR8888
                Case PixelFormat.ARGB1555
                    Return SDL.SDL_PIXELFORMAT_ARGB1555
                Case PixelFormat.ARGB2101010
                    Return SDL.SDL_PIXELFORMAT_ARGB2101010
                Case PixelFormat.ARGB4444
                    Return SDL.SDL_PIXELFORMAT_ARGB4444
                Case PixelFormat.ARGB8888
                    Return SDL.SDL_PIXELFORMAT_ARGB8888
                Case PixelFormat.BGR24
                    Return SDL.SDL_PIXELFORMAT_BGR24
                Case PixelFormat.BGR444
                    Return SDL.SDL_PIXELFORMAT_BGR444
                Case PixelFormat.BGR555
                    Return SDL.SDL_PIXELFORMAT_BGR555
                Case PixelFormat.BGR565
                    Return SDL.SDL_PIXELFORMAT_BGR565
                Case PixelFormat.BGR888
                    Return SDL.SDL_PIXELFORMAT_BGR888
                Case PixelFormat.BGRA4444
                    Return SDL.SDL_PIXELFORMAT_BGRA4444
                Case PixelFormat.BGRA5551
                    Return SDL.SDL_PIXELFORMAT_BGRA5551
                Case PixelFormat.BGRA8888
                    Return SDL.SDL_PIXELFORMAT_BGRA8888
                Case PixelFormat.BGRX8888
                    Return SDL.SDL_PIXELFORMAT_BGRX8888
                Case PixelFormat.INDEX1LSB
                    Return SDL.SDL_PIXELFORMAT_INDEX1LSB
                Case PixelFormat.INDEX1MSB
                    Return SDL.SDL_PIXELFORMAT_INDEX1MSB
                Case PixelFormat.INDEX4LSB
                    Return SDL.SDL_PIXELFORMAT_INDEX4LSB
                Case PixelFormat.INDEX4MSB
                    Return SDL.SDL_PIXELFORMAT_INDEX4MSB
                Case PixelFormat.INDEX8
                    Return SDL.SDL_PIXELFORMAT_INDEX8
                Case PixelFormat.RGB24
                    Return SDL.SDL_PIXELFORMAT_RGB24
                Case PixelFormat.RGB332
                    Return SDL.SDL_PIXELFORMAT_RGB332
                Case PixelFormat.RGB444
                    Return SDL.SDL_PIXELFORMAT_RGB444
                Case PixelFormat.RGB555
                    Return SDL.SDL_PIXELFORMAT_RGB555
                Case PixelFormat.RGB565
                    Return SDL.SDL_PIXELFORMAT_RGB565
                Case PixelFormat.RGB888
                    Return SDL.SDL_PIXELFORMAT_RGB888
                Case PixelFormat.RGBA4444
                    Return SDL.SDL_PIXELFORMAT_RGBA4444
                Case PixelFormat.RGBA5551
                    Return SDL.SDL_PIXELFORMAT_RGBA5551
                Case PixelFormat.RGBA8888
                    Return SDL.SDL_PIXELFORMAT_RGBA8888
                Case PixelFormat.RGBX8888
                    Return SDL.SDL_PIXELFORMAT_RGBX8888
                Case PixelFormat.Unknown
                    Return SDL.SDL_PIXELFORMAT_UNKNOWN
                Case PixelFormat.UYVY
                    Return SDL.SDL_PIXELFORMAT_UYVY
                Case PixelFormat.YUY2
                    Return SDL.SDL_PIXELFORMAT_YUY2
                Case PixelFormat.YV12
                    Return SDL.SDL_PIXELFORMAT_YV12
                Case PixelFormat.YVYU
                    Return SDL.SDL_PIXELFORMAT_YVYU
                Case Else
                    Return SDL.SDL_PIXELFORMAT_UNKNOWN
            End Select
        End Function
    End Module
End Namespace