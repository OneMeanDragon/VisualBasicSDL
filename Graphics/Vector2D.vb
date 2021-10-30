Imports System

Namespace VisualBasicSDL.Graphics

    Public Class Vector2D
        Public Property X As Single
        Public Property Y As Single

        Public Shared ReadOnly Property One As Vector2D
            Get
                Return New Vector2D(1, 1)
            End Get
        End Property

        Public Shared ReadOnly Property Zero As Vector2D
            Get
                Return New Vector2D(0, 0)
            End Get
        End Property

        Public Sub New(ByVal x As Single, ByVal y As Single)
            x = x
            y = y
        End Sub

        Public Function Transform(ByVal matrix As Matrix) As Vector2D
            Return New Vector2D((X * matrix.Row1Col1) + (Y * matrix.Row2Col1), (X * matrix.Row2Col1) + (Y * matrix.Row2Col2))
        End Function

        Public Function Add(ByVal vector As Vector2D) As Vector2D
            Dim x As Single = x + vector.X
            Dim y As Single = y + vector.Y
            Return New Vector2D(x, y)
        End Function

        Public Function Subtract(ByVal vector As Vector2D) As Vector2D
            Dim x As Single = x - vector.X
            Dim y As Single = y - vector.Y
            Return New Vector2D(x, y)
        End Function

        Public Shared Operator -(value1 As Vector2D, value2 As Vector2D) As Vector2D
            Return value1.Subtract(value2)
        End Operator

        Public Shared Operator +(value1 As Vector2D, value2 As Vector2D) As Vector2D
            Return value1.Add(value2)
        End Operator

        Public Shared Operator =(value1 As Vector2D, value2 As Vector2D) As Boolean
            Return value1.X = value2.X AndAlso value1.Y = value2.Y
        End Operator

        Public Shared Operator <>(value1 As Vector2D, value2 As Vector2D) As Boolean
            Return value1.X <> value2.X OrElse value1.Y <> value2.Y
        End Operator

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is Vector2D Then
                Dim o = CType(obj, Vector2D)

                If Me.X = o.X AndAlso Me.Y = o.Y Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return MyBase.Equals(obj)
            End If
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return MyBase.GetHashCode()
        End Function

    End Class

End Namespace