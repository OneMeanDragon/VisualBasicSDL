Namespace Graphics
    Public Class Point
        Public Property X As Integer
        Public Property Y As Integer

        Public Sub New(ByVal x As Integer, ByVal y As Integer)
            x = x
            y = y
        End Sub

        Public Shared Operator =(ByVal value1 As Point, ByVal value2 As Point) As Boolean
            Return value1.X = value2.X AndAlso value1.Y = value2.Y
        End Operator

        Public Shared Operator <>(ByVal value1 As Point, ByVal value2 As Point) As Boolean
            Return value1.X <> value2.X OrElse value1.Y <> value2.Y
        End Operator

        Public Overrides Function Equals(ByVal obj As Object) As Boolean
            If TypeOf obj Is Point Then
                Dim o = CType(obj, Point)

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
