using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;
using System.Threading;
using Memory;

namespace ETS2_DualSenseAT_Mod
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            var Settings = new IniFile("Settings.ini");

            string is_installed = Settings.Read("is_installed");

            if (is_installed == "true")
            {
                statusLbl.Text = "Installed";
                statusLbl.ForeColor = Color.Green;
                uninstallBtn.Enabled = true;
                installBtn.Enabled = false;
            }
            else
            {
                statusLbl.Text = "Not installed";
                statusLbl.ForeColor = Color.Red;
                uninstallBtn.Enabled = false;
                installBtn.Enabled = true;
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/zelmer69/");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filepath = Application.StartupPath;
            DirectoryInfo d = new DirectoryInfo(filepath);

            var Settings = new IniFile("Settings.ini");

            string game_path = Settings.Read("game_path");

            if (!Directory.Exists(game_path + "\\Scripts"))
            {
                Directory.CreateDirectory(game_path + "\\Scripts");
            }


            try
            {
                File.Copy(Application.StartupPath + @"\dinput8.dll", game_path + @"\dinput8.dll", true);
                File.Copy(Application.StartupPath + @"\NativeTrainer.asi", game_path + @"\NativeTrainer.asi", true);
                File.Copy(Application.StartupPath + @"\ScriptHookV.dll", game_path + @"\ScriptHookV.dll", true);
                File.Copy(Application.StartupPath + @"\ScriptHookVDotNet.asi", game_path + @"\ScriptHookVDotNet.asi", true);
                File.Copy(Application.StartupPath + @"\ScriptHookVDotNet.ini", game_path + @"\ScriptHookVDotNet.ini", true);
                File.Copy(Application.StartupPath + @"\ScriptHookVDotNet2.dll", game_path + @"\ScriptHookVDotNet2.dll", true);
                File.Copy(Application.StartupPath + @"\ScriptHookVDotNet3.dll", game_path + @"\ScriptHookVDotNet3.dll", true);

                File.Copy(Application.StartupPath + @"\DusalSsanse4gtav.dll", game_path + @"\Scripts\DusalSsanse4gtav.dll", true);
                File.Copy(Application.StartupPath + @"\Newtonsoft.Json.dll", game_path + @"\Scripts\Newtonsoft.Json.dll", true);

                Settings.Write("is_installed", "true");

                statusLbl.Text = "Installed, you can close this Windows!";
                statusLbl.ForeColor = Color.Green;
                
                installBtn.Enabled = false;
                uninstallBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DualSenseAT Mod Installer Error Handling");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/josealissonbr");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filepath = Application.StartupPath;
            DirectoryInfo d = new DirectoryInfo(filepath);

            var Settings = new IniFile("Settings.ini");

            string game_path = Settings.Read("game_path");

            if (!Directory.Exists(game_path + "\\Scripts"))
            {
                Directory.CreateDirectory(game_path + "\\Scripts");
            }

            try
            {
                File.Delete(game_path + @"\dinput8.dll");
                File.Delete(game_path + @"\NativeTrainer.asi");
                File.Delete(game_path + @"\ScriptHookV.dll");
                File.Delete(game_path + @"\ScriptHookVDotNet.asi");
                File.Delete(game_path + @"\ScriptHookVDotNet.ini");
                File.Delete(game_path + @"\ScriptHookVDotNet2.dll");
                File.Delete(game_path + @"\ScriptHookVDotNet3.dll");

                File.Delete(game_path + @"\Scripts\DusalSsanse4gtav.dll");
                File.Delete(game_path + @"\Scripts\Newtonsoft.Json.dll");

                if (Directory.Exists(game_path + "\\Scripts"))
                {
                    Directory.Delete(game_path + "\\Scripts");
                }

                Settings.Write("is_installed", "false");

                statusLbl.Text = "Not installed";
                statusLbl.ForeColor = Color.Red;
                uninstallBtn.Enabled = false;
                installBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DualSenseAT Mod Installer Error Handling");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
