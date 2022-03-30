using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ETS2_DualSenseAT_Mod
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var Settings = new IniFile("Settings.ini");

            string game_path = Settings.Read("game_path");

            if (!File.Exists(game_path + @"\GTA5.exe"))
            {
                Application.Run(new Setup());
            }
            else
            {
                Application.Run(new Form1());
            }

            //if (!Directory.Exists(Settings.Read("game_path")))
            //    Application.Run(new Setup());
            //else
            //    Application.Run(new Form1());

            
        }
    }
}
