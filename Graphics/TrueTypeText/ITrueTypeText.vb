Imports System

Namespace VisualBasicSDL.Graphics
    Public Interface ITrueTypeText
        Inherits IDisposable

        Property Text As String
        Property Font As IFont
        Property Color As SDLColor
        Property Texture As ITexture
        Property OutlineSize As Integer
        Property IsWrapped As Boolean
        Property WrapLength As Integer
        Sub SetOutlineSize(ByVal outlineSize As Integer)
        Sub UpdateText(ByVal text As String)
        Sub UpdateText(ByVal text As String, ByVal wrapLength As Integer)
    End Interface
End Namespace