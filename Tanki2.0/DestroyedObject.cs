using System;

namespace Tanki2._0
{
    internal partial class Program
    {
        class DestroyedObject : Cell
        {
            public DestroyedObject() : base(ConsoleColor.White, ConsoleColor.Black, 'o') {}
        }
    }
}