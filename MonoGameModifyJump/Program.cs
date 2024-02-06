using System;

namespace MonoGameModifyJump
{
    // Credit to Jeff Meyers
    // From GameProgrammingI github, SimpleMovementJump
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