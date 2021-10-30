Imports System

Namespace VisualBasicSDL
    Public Class GameTime
        Public Property TotalGameTime As TimeSpan
        Public Property ElapsedGameTime As TimeSpan

        Public Sub New()
            TotalGameTime = TimeSpan.Zero
            ElapsedGameTime = TimeSpan.Zero
        End Sub

        Public Sub New(ByVal totalGameTime As TimeSpan, ByVal elapsedGameTime As TimeSpan)
            totalGameTime = totalGameTime
            elapsedGameTime = elapsedGameTime
        End Sub
    End Class
End Namespace