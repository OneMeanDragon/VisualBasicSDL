
Namespace VisualBasicSDL.Graphics
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

        Public Sub New(ByVal vX As Integer, ByVal vY As Integer, ByVal vWidth As Integer, ByVal vHeight As Integer)
            Me.New()

            If vWidth < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vWidth), "Width must be greater than or equal to 0.")
            End If

            If vHeight < 0 Then
                Throw New ArgumentOutOfRangeException(NameOf(vHeight), "Height must be greater than or equal to 0.")
            End If

            X = vX
            Y = vY
            Width = vWidth
            Height = vHeight
        End Sub

        Public Function Contains(ByVal vPoint As Point) As Boolean
            Return (Left <= vPoint.X) AndAlso (Right >= vPoint.X) AndAlso (Top <= vPoint.Y) AndAlso (Bottom >= vPoint.Y)
        End Function

        Public Function Contains(ByVal vRectangle As Rectangle) As Boolean
            Return (Left <= vRectangle.Left) AndAlso (Right >= vRectangle.Right) AndAlso (Top <= vRectangle.Top) AndAlso (Bottom >= vRectangle.Bottom)
        End Function

        Public Function Contains(ByVal vVector As Vector2D) As Boolean
            Return (Left <= vVector.X) AndAlso (Right >= vVector.X) AndAlso (Top <= vVector.Y) AndAlso (Bottom >= vVector.Y)
        End Function

        Public Function Intersects(ByVal vRectangle As Rectangle) As Boolean
            Return (vRectangle.Left <= Right) AndAlso (Left <= vRectangle.Right) AndAlso (vRectangle.Top <= Bottom) AndAlso (Top <= vRectangle.Bottom)
        End Function

        Public Function GetIntersectionDepth(ByVal vRectangle As Rectangle) As Vector2D
            Dim lHalfWidthA As Single = Me.Width / 2.0F
            Dim lHalfHeightA As Single = Me.Height / 2.0F
            Dim lHalfWidthB As Single = vRectangle.Width / 2.0F
            Dim lHalfHeightB As Single = vRectangle.Height / 2.0F
            Dim lCenterA As Vector2D = New Vector2D(Me.Left + lHalfWidthA, Me.Top + lHalfHeightA)
            Dim lCenterB As Vector2D = New Vector2D(vRectangle.Left + lHalfWidthB, vRectangle.Top + lHalfHeightB)
            Dim lDistanceX As Single = lCenterA.X - lCenterB.X
            Dim lDistanceY As Single = lCenterA.Y - lCenterB.Y
            Dim lMinDistanceX As Single = lHalfWidthA + lHalfWidthB
            Dim lMinDistanceY As Single = lHalfHeightA + lHalfHeightB
            If Math.Abs(lDistanceX) >= lMinDistanceX OrElse Math.Abs(lDistanceY) >= lMinDistanceY Then Return Vector2D.Zero
            Dim lDepthX As Single = If(lDistanceX > 0, lMinDistanceX - lDistanceX, -lMinDistanceX - lDistanceX)
            Dim lDepthY As Single = If(lDistanceY > 0, lMinDistanceY - lDistanceY, -lMinDistanceY - lDistanceY)
            Return New Vector2D(lDepthX, lDepthY)
        End Function
    End Structure
End Namespace
