
Namespace VisualBasicSDL.Graphics

    Public Interface ISurfaceFactory

        ''' <summary>
        ''' Create a surface from an image on disk, ident from file path and file type
        ''' </summary>
        ''' <param name="vFilePath">Where the image is located</param>
        ''' <param name="vSurfaceType">Type of image being loaded</param>
        ''' <returns>In memory representation of loaded image to render</returns>
        Function CreateSurface(vFilePath As String, vSurfaceType As SurfaceType) As ISurface

        ''' <summary>
        ''' Blended Text
        ''' </summary>
        ''' <param name="vFont">Font to be used during rendering</param>
        ''' <param name="vText">Text to be rendered</param>
        ''' <param name="vColor">Color of the text</param>
        ''' <param name="vWrapLength"></param>
        ''' <returns>In memory representation of font/text to render</returns>
        Function CreateSurface(vFont As IFont, vText As String, vColor As SDLColor, vWrapLength As Integer) As ISurface
        ''' <summary>
        ''' Solid Text
        ''' </summary>
        ''' <param name="vFont">Font to be used during rendering</param>
        ''' <param name="vText">Text to be rendered</param>
        ''' <param name="vColor">Color of the text</param>
        ''' <returns>In memory representation of font/text to render</returns>
        Function CreateSurface(vFont As IFont, vText As String, vColor As SDLColor) As ISurface
        ''' <summary>
        ''' Shaded Text
        ''' </summary>
        ''' <param name="vFont">Font to be used during rendering</param>
        ''' <param name="vText">Text to be rendered</param>
        ''' <param name="vFGColor">Color of the text foreground</param>
        ''' <param name="vBGColor">Color of the text background</param>
        ''' <returns>In memory representation of font/text to render</returns>
        Function CreateSurface(vFont As IFont, vText As String, vFGColor As SDLColor, vBGColor As SDLColor) As ISurface

    End Interface

End Namespace