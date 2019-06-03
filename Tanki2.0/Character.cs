using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        enum Direction
        {
            Left,
            Up,
            Right,
            Down
        }

        class Character : Cell
        {
            protected Direction direction;
            public int X { get; set; }
            public int Y { get; set; }
            public int Lifes;
            
            public Direction CurrentDirection
            {
                get { return direction; }
            }

            public Character(int x, int y, 
                ConsoleColor foregroundColor = ConsoleColor.Red,
                ConsoleColor backgroundColor = ConsoleColor.Black,
                char symbol = 'v') 
                : base(foregroundColor, backgroundColor, symbol)
            {
                direction = Direction.Down;
                X = x;
                Y = y;
            }

            public override void Draw()
            {
                switch (direction)
                {
                    case Direction.Left:
                        symbol = '<';
                        break;
                    case Direction.Up:
                        symbol = '^';
                        break;
                    case Direction.Right:
                        symbol = '>';
                        break;
                    case Direction.Down:
                        symbol = 'v';
                        break;
                }
                base.Draw();
            }

            public void Rotate(int dx, int dy)
            {
                if (dx == -1)
                    direction = Direction.Left;
                else if (dx == 1)
                    direction = Direction.Right;
                else if (dy == -1)
                    direction = Direction.Up;
                else if (dy == 1)
                    direction = Direction.Down;
            }
            
            public void MakeStep(int dx, int dy)
            {
                X += dx;
                Y += dy;
            }
        }
    }
}