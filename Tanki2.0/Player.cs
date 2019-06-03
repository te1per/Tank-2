using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        class Player : Character
        {
            public Player(int x, int y) : base(x, y, ConsoleColor.Green)
            {
                Lifes = 5;
            }

            public override void Draw()
            {
                Console.SetCursorPosition(X, Y);
                base.Draw();
            }
        }
    }
}