using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TeeGee;

namespace TeeGeeForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var form = new Form1();
            form.Show();
            form.game = new Game1(form.pictureBox1.Handle, form, form.pictureBox1);
            form.game.Run();
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form);*/
        }
    }
}
