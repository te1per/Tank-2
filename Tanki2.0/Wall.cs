using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        class Wall : Cell
        {
            public Wall() : base(ConsoleColor.White, ConsoleColor.Black, '#') {}
        }
    }
}