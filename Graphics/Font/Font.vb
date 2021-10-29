Imports SDL2

Namespace Graphics

    Public Class Font : Implements IFont
        Private mSafeHandle As SafeFontHandle = Nothing
        Private disposedValue As Boolean

        ' Property values
        Private mFilePath As String
        Private mPointSize As Integer
        Private mOutlineSize As Integer

        Public Property FilePath As String Implements IFont.FilePath
            Get
                Return mFilePath
            End Get
            Private Set(value As String)
                mFilePath = value
            End Set
        End Property
        Public Property PointSize As Integer Implements IFont.PointSize
            Get
                Return mPointSize
            End Get
            Private Set(value As Integer)
                mPointSize = value
            End Set
        End Property
        Public Property Handle As IntPtr Implements IFont.Handle
            Get
                Return mSafeHandle.DangerousGetHandle()
            End Get
            Private Set(value As IntPtr)
                If mSafeHandle Is Nothing Then
                    mSafeHandle = New SafeFontHandle(value)
                Else
                    Throw New NotImplementedException()
                End If
            End Set
        End Property
        Public Property OutlineSize As Integer Implements IFont.OutlineSize
            Get
                Return mOutlineSize
            End Get
            Private Set(value As Integer)
                mOutlineSize = value
            End Set
        End Property

        Public Sub SetOutlineSize(vOutlineSize As Integer) Implements IFont.SetOutlineSize
            SDL_ttf.TTF_SetFontOutline(Handle, OutlineSize)
        End Sub

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not disposedValue Then
                If disposing Then
                    ' TODO: dispose managed state (managed objects)
                    mSafeHandle.Dispose()
                End If

                ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
                ' TODO: set large fields to null
                disposedValue = True
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
            Dispose(disposing:=True)
            GC.SuppressFinalize(Me)
        End Sub

        Public Sub New(vFilePath As String, vFontPointSize As Integer)
            If String.IsNullOrWhiteSpace(vFilePath) Then
                Throw New ArgumentNullException(NameOf(vFilePath))
            End If
            If vFontPointSize < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vFontPointSize), "Font point size must be greater than or equal to 0.")
            End If
            Dim unsafeHandle As IntPtr = SDL_ttf.TTF_OpenFont(vFilePath, vFontPointSize)
            If unsafeHandle = IntPtr.Zero Then
                Throw New InvalidOperationException(String.Format("TTF_OpenFont: {0}", SDL.SDL_GetError()))
            End If
            Handle = unsafeHandle
            FilePath = vFilePath
            PointSize = vFontPointSize
        End Sub
    End Class

End Namespace
