using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOHC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string x = Properties.Settings.Default.Profiles[0];
            }
            catch
            {
                Properties.Settings.Default.Profiles = new List<string>();
                Properties.Settings.Default.Profiles.Add("Profiles");
                Properties.Settings.Default.Save();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Launcher());
            if (Properties.Settings.Default.ClickedPlay == true)
            {
                Application.Run(new Game(Properties.Settings.Default.Selected));
            }
            Environment.Exit(0);
        }
    }
}
