using System;

namespace BreakoutStep1
{
    //Code provided by Jeff Meyers
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
