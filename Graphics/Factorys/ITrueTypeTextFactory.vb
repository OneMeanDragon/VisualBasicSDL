
Namespace VisualBasicSDL.Graphics
    Public Interface ITrueTypeTextFactory
        Function CreateTrueTypeText(ByVal vRenderer As IRenderer, ByVal vFontPath As String, ByVal vText As String, ByVal vFontSize As Integer) As ITrueTypeText
        Function CreateTrueTypeText(ByVal vRenderer As IRenderer, ByVal vFontPath As String, ByVal vText As String, ByVal vFontSize As Integer, ByVal vColor As SDLColor) As ITrueTypeText
        Function CreateTrueTypeText(ByVal vRenderer As IRenderer, ByVal vFontPath As String, ByVal vText As String, ByVal vFontSize As Integer, ByVal vColor As SDLColor, ByVal vWrapLength As Integer) As ITrueTypeText
    End Interface
End Namespace
