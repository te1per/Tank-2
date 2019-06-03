using System;
using System.Threading;

namespace Tanki2._0
{
    internal partial class Program
    {
        public static void Main(string[] args)
        {
            Level level = new Level(0);
            while (level.Game)
            {
                level.PrintLevel();
                level.UpdateField(); 
            }
            Console.ReadKey();
        }
    }
}