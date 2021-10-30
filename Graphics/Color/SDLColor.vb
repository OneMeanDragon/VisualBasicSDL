Imports SDL2

Namespace VisualBasicSDL.Graphics
    Public Structure Colors
        Private Shared mBlack As SDLColor
        Private Shared mWhite As SDLColor
        Private Shared mRed As SDLColor
        Private Shared mGreen As SDLColor
        Private Shared mBlue As SDLColor

        Private Shared mInitialized As Boolean = False

        Private Shared Sub Init()
            mBlack = New SDLColor(0, 0, 0)
            mWhite = New SDLColor(255, 255, 255)
            mRed = New SDLColor(255, 0, 0)
            mGreen = New SDLColor(0, 255, 0)
            mBlue = New SDLColor(0, 0, 255)

            mInitialized = True
        End Sub

        Public Shared ReadOnly Property Black() As SDLColor
            Get
                If mInitialized = False Then
                    Init()
                End If
                Return mBlack
            End Get
        End Property
        Public Shared ReadOnly Property White() As SDLColor
            Get
                If mInitialized = False Then
                    Init()
                End If
                Return mWhite
            End Get
        End Property
        Public Shared ReadOnly Property Red() As SDLColor
            Get
                If mInitialized = False Then
                    Init()
                End If
                Return mRed
            End Get
        End Property
        Public Shared ReadOnly Property Green() As SDLColor
            Get
                If mInitialized = False Then
                    Init()
                End If
                Return mGreen
            End Get
        End Property
        Public Shared ReadOnly Property Blue() As SDLColor
            Get
                If mInitialized = False Then
                    Init()
                End If
                Return mBlue
            End Get
        End Property

    End Structure

    Public Class SDLColor
        Private RawValue As New SDL.SDL_Color

        Public Property Red() As Integer
            Get
                Return RawValue.r
            End Get
            Set(value As Integer)
                RawValue.r = value
            End Set
        End Property
        Public Property Green() As Integer
            Get
                Return RawValue.g
            End Get
            Set(value As Integer)
                RawValue.g = value
            End Set
        End Property
        Public Property Blue() As Integer
            Get
                Return RawValue.b
            End Get
            Set(value As Integer)
                RawValue.b = value
            End Set
        End Property
        Public Property Alpha() As Integer
            Get
                Return RawValue.a
            End Get
            Set(value As Integer)
                RawValue.a = value
            End Set
        End Property

        Public ReadOnly Property RawColor() As SDL.SDL_Color
            Get
                Return RawValue
            End Get
        End Property

        Public Sub New()
            Red = 0
            Green = 0
            Blue = 0
        End Sub

        Public Sub New(r As Byte, g As Byte, b As Byte)
            Red = r
            Green = g
            Blue = b
        End Sub

    End Class

End Namespace