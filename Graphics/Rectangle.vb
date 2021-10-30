
Namespace Graphics
    Public Structure Rectangle
        Public Property X As Integer
        Public Property Y As Integer
        Public Property Width As Integer
        Public Property Height As Integer

        Public ReadOnly Property Bottom As Integer
            Get
                Return Y + Height
            End Get
        End Property

        Public ReadOnly Property Top As Integer
            Get
                Return Y
            End Get
        End Property

        Public ReadOnly Property Left As Integer
            Get
                Return X
            End Get
        End Property

        Public ReadOnly Property Right As Integer
            Get
                Return X + Width
            End Get
        End Property

        Public Shared ReadOnly Property Empty As Rectangle
            Get
                Return New Rectangle(0, 0, 0, 0)
            End Get
        End Property

        Public ReadOnly Property IsEmpty As Boolean
            Get
                Return Width = 0 AndAlso Height = 0
            End Get
        End Property

        Public ReadOnly Property Location As Point
            Get
                Return New Point(X, Y)
            End Get
        End Property

        Public ReadOnly Property Center As Point
            Get
                Return New Point(Me.X + (Me.Width / 2), Me.Y + (Me.Height / 2))
            End Get
        End Property

        Public Sub New(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer)
            Me.New()

            If width < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(width), "Width must be greater than or equal to 0.")
            End If

            If height < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(height), "Height must be greater than or equal to 0.")
            End If

            x = x
            y = y
            width = width
            height = height
        End Sub

        Public Function Contains(ByVal point As Point) As Boolean
            Return (Left <= point.X) AndAlso (Right >= point.X) AndAlso (Top <= point.Y) AndAlso (Bottom >= point.Y)
        End Function

        Public Function Contains(ByVal rectangle As Rectangle) As Boolean
            Return (Left <= rectangle.Left) AndAlso (Right >= rectangle.Right) AndAlso (Top <= rectangle.Top) AndAlso (Bottom >= rectangle.Bottom)
        End Function

        Public Function Contains(ByVal vector As Vector2D) As Boolean
            Return (Left <= vector.X) AndAlso (Right >= vector.X) AndAlso (Top <= vector.Y) AndAlso (Bottom >= vector.Y)
        End Function

        Public Function Intersects(ByVal rectangle As Rectangle) As Boolean
            Return (rectangle.Left <= Right) AndAlso (Left <= rectangle.Right) AndAlso (rectangle.Top <= Bottom) AndAlso (Top <= rectangle.Bottom)
        End Function

        Public Function GetIntersectionDepth(ByVal rectangle As Rectangle) As Vector2D
            Dim halfWidthA As Single = Me.Width / 2.0F
            Dim halfHeightA As Single = Me.Height / 2.0F
            Dim halfWidthB As Single = rectangle.Width / 2.0F
            Dim halfHeightB As Single = rectangle.Height / 2.0F
            Dim centerA As Vector2D = New Vector2D(Me.Left + halfWidthA, Me.Top + halfHeightA)
            Dim centerB As Vector2D = New Vector2D(rectangle.Left + halfWidthB, rectangle.Top + halfHeightB)
            Dim distanceX As Single = centerA.X - centerB.X
            Dim distanceY As Single = centerA.Y - centerB.Y
            Dim minDistanceX As Single = halfWidthA + halfWidthB
            Dim minDistanceY As Single = halfHeightA + halfHeightB
            If Math.Abs(distanceX) >= minDistanceX OrElse Math.Abs(distanceY) >= minDistanceY Then Return Vector2D.Zero
            Dim depthX As Single = If(distanceX > 0, minDistanceX - distanceX, -minDistanceX - distanceX)
            Dim depthY As Single = If(distanceY > 0, minDistanceY - distanceY, -minDistanceY - distanceY)
            Return New Vector2D(depthX, depthY)
        End Function
    End Structure
End Namespace
