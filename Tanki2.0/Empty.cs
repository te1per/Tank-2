using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        class Empty : Cell
        {
            public Empty() : base(ConsoleColor.White, ConsoleColor.Black, ' ') {}
        }
    }
}