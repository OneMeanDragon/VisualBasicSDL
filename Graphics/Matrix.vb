
Namespace VisualBasicSDL.Graphics

    Public Structure Matrix
        Public Property Row1Col1 As Single
        Public Property Row1Col2 As Single
        Public Property Row2Col1 As Single
        Public Property Row2Col2 As Single

        Public Sub New(ByVal row1col1 As Single, ByVal row1col2 As Single, ByVal row2col1 As Single, ByVal row2col2 As Single)
            Me.New()
            row1col1 = row1col1
            row1col2 = row1col2
            row2col1 = row2col1
            row2col2 = row2col2
        End Sub

        Default Public Property Item(ByVal index As Integer) As Single
            Get

                Select Case index
                    Case 0
                        Return Row1Col1
                    Case 1
                        Return Row1Col2
                    Case 2
                        Return Row2Col1
                    Case 3
                        Return Row2Col2
                    Case Else
                        Throw New ArgumentOutOfRangeException()
                End Select
            End Get
            Set(ByVal value As Single)

                Select Case index
                    Case 0
                        Row1Col1 = value
                    Case 1
                        Row1Col2 = value
                    Case 2
                        Row2Col1 = value
                    Case 3
                        Row2Col2 = value
                    Case Else
                        Throw New ArgumentOutOfRangeException()
                End Select
            End Set
        End Property

        Default Public Property Item(ByVal row As Integer, ByVal column As Integer) As Single
            Get
                Return Me(row * 2 + column)
            End Get
            Set(ByVal value As Single)
                Me(row * 2 + column) = value
            End Set
        End Property

        Public Shared Function Invert(ByVal matrix As Matrix) As Matrix
            Dim determinant As Single = 1 / ((matrix.Row1Col1 * matrix.Row2Col2) - (matrix.Row1Col2 * matrix.Row2Col1))
            Dim newRow1Col1 As Single = matrix.Row2Col2
            Dim newRow1Col2 As Single = matrix.Row1Col2 * -1
            Dim newRow2Col1 As Single = matrix.Row2Col1 * -1
            Dim newRow2Col2 As Single = matrix.Row1Col1

            newRow1Col1 /= determinant
            newRow1Col2 /= determinant
            newRow2Col1 /= determinant
            newRow2Col2 /= determinant

            Return New Matrix(newRow1Col1, newRow1Col2, newRow2Col1, newRow2Col2)
        End Function

        Public Shared Function CreateScale(ByVal scaleX As Single, ByVal scaleY As Single) As Matrix
            Return New Matrix() With {
                .Row1Col1 = scaleX,
                .Row1Col2 = 0,
                .Row2Col1 = 0,
                .Row2Col2 = scaleY
            }
        End Function
    End Structure
End Namespace
