Imports SDL2
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace VisualBasicSDL.Input
    Public Structure MouseState
        Public ButtonsPressed As IEnumerable(Of MouseButtonCode)
        Public X As Integer
        Public Y As Integer
    End Structure
End Namespace