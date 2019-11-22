using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using CefSharp;
using System.IO;

namespace TOHC
{
    public partial class Game : Form
    {
        public Game(string theprofile)
        {
            Profile = theprofile;
            InitializeComponent();
        }

        ChromiumWebBrowser game;
        string Profile;

        private void Game_Load(object sender, EventArgs e)
        {
            var newsettings = new BrowserSettings();

            CefSettings Settings = new CefSettings();
            string CachePath = "%appdata%\\TOHC\\" + Profile;
            CachePath = Environment.ExpandEnvironmentVariables(CachePath);
            Settings.CachePath = CachePath;  //always set the cachePath, else this wont work

            //add an if statement to initialize the settings once. else the app is going to crash
            if (CefSharp.Cef.IsInitialized == false)
                CefSharp.Cef.Initialize(Settings);

            var game = new ChromiumWebBrowser("https://www.tankionline.com/play/") { Dock = DockStyle.Fill };
            this.Controls.Add(game);
        }
    }
}
