using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        class Field
        {
            private Cell[,] field;

            public int Width
            {
                get { return field.GetLength(1); }
            }

            public int Height
            {
                get { return field.GetLength(0); }
            }

            public Field(int width, int height)
            {
                field = new Cell[height, width];
            }

            public void Print()
            {
                Console.SetCursorPosition(0, 0);
                for (int y = 0; y < Height; y++)
                {
                    for (int x = 0; x < Width; x++)
                    {
                        this[x, y].Draw();
                    }
                    Console.WriteLine();
                }
            }

            public Cell this[int x, int y]
            {
                get { return field[y, x]; }
                set { field[y, x] = value; }
            }

            public bool CanMakeStep(int x, int y)
            {
                return NotOutOfField(x, y) && this[x, y] is Empty;
            }

            public bool NotOutOfField(int x, int y)
            {
                return x >= 0 && x < Width && y >= 0 && y < Height;
            }

            public void MakeDestroyed(int x, int y)
            {
                this[x, y] = new DestroyedObject();
            }

            public void MakeEmpty(int x, int y)
            {
                this[x, y] = new Empty();
            }
        }
    }
}