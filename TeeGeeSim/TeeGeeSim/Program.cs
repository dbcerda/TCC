using System;

namespace TeeGeeSim
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            var form = new SimForm();
            form.Show();
            form.game = new Game1(
                form.player1Surface.Handle,
                form,
                form.player1Surface
            );
            form.game.Run();
        }
    }
#endif
}

