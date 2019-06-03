using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        class Bullet : Character
        {
            public bool EnemySource;
            
            public Bullet(int x, int y, Direction direction, bool enemySource = false) 
                : base(x, y, ConsoleColor.White, ConsoleColor.Black, '.')
            {
                EnemySource = enemySource;
                this.direction = direction;
            }

            public override void Draw()
            {
                Console.SetCursorPosition(X, Y);
                Console.ForegroundColor = foregroundColor;
                Console.BackgroundColor = backgroundColor;
                Console.Write(symbol);
            }

            public void MakeStep()
            {
                switch (direction)
                {
                    case Direction.Up:
                        Y--;
                        break;
                    case Direction.Down:
                        Y++;
                        break;
                    case Direction.Left:
                        X--;
                        break;
                    case Direction.Right:
                        X++;
                        break;
                }
            }
            
        }
    }
}