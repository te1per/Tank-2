using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        class Cell
        {
            protected ConsoleColor foregroundColor;
            protected ConsoleColor backgroundColor;
            protected char symbol;

            public Cell(ConsoleColor foregroundColor = ConsoleColor.White,
                        ConsoleColor backgroundColor = ConsoleColor.Black,
                        char symbol = ' ')
            {
                this.foregroundColor = foregroundColor;
                this.backgroundColor = backgroundColor;
                this.symbol = symbol;
            }

            public virtual void Draw()
            {
                Console.ForegroundColor = foregroundColor;
                Console.BackgroundColor = backgroundColor;
                Console.Write(symbol);
            }
        }
    }
}