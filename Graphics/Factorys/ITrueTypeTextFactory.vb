
Namespace VisualBasicSDL.Graphics
    Interface ITrueTypeTextFactory
        Function CreateTrueTypeText(ByVal renderer As IRenderer, ByVal fontPath As String, ByVal text As String, ByVal fontSize As Integer) As ITrueTypeText
        Function CreateTrueTypeText(ByVal renderer As IRenderer, ByVal fontPath As String, ByVal text As String, ByVal fontSize As Integer, ByVal color As SDLColor) As ITrueTypeText
        Function CreateTrueTypeText(ByVal renderer As IRenderer, ByVal fontPath As String, ByVal text As String, ByVal fontSize As Integer, ByVal color As SDLColor, ByVal wrapLength As Integer) As ITrueTypeText
    End Interface
End Namespace
