
Namespace Graphics

    Public Class SurfaceFactory : Implements ISurfaceFactory

        Public Function CreateSurface(vFilePath As String, vSurfaceType As SurfaceType) As ISurface Implements ISurfaceFactory.CreateSurface
            Try
                Dim surface = New Surface(vFilePath, vSurfaceType)
                Return surface
            Catch ex As Exception
                Throw New ArgumentNullException(ex.Message)
            End Try
        End Function

        Public Function CreateSurface(vFont As IFont, vText As String, vColor As SDLColor, vWrapLength As Integer) As ISurface Implements ISurfaceFactory.CreateSurface
            Try
                Dim surface = New Surface(vFont, vText, vColor, vWrapLength)
                Return surface
            Catch ex As Exception
                Throw New ArgumentNullException(ex.Message)
            End Try
        End Function

        Public Function CreateSurface(vFont As IFont, vText As String, vColor As SDLColor) As ISurface Implements ISurfaceFactory.CreateSurface
            Try
                Dim surface = New Surface(vFont, vText, vColor)
                Return surface
            Catch ex As Exception
                Throw New ArgumentNullException(ex.Message)
            End Try
        End Function

        Public Function CreateSurface(vFont As IFont, vText As String, vFGColor As SDLColor, vBGColor As SDLColor) As ISurface Implements ISurfaceFactory.CreateSurface
            Try
                Dim surface = New Surface(vFont, vText, vFGColor, vBGColor)
                Return surface
            Catch ex As Exception
                Throw New ArgumentNullException(ex.Message)
            End Try
        End Function

        Public Function CreateSurface(vFont As IFont, vText As String) As ISurface
            Return CreateSurface(vFont, vText, Colors.Black)
        End Function

    End Class

End Namespace