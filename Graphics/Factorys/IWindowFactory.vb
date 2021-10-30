
Namespace VisualBasicSDL.Graphics

    Interface IWindowFactory
        Function CreateWindow(ByVal title As String) As IWindow
        Function CreateWindow(ByVal title As String, ByVal x As Integer, ByVal y As Integer) As IWindow
        Function CreateWindow(ByVal title As String, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer) As IWindow
        Function CreateWindow(ByVal title As String, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal flags As WindowFlags) As IWindow
    End Interface

End Namespace
