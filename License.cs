using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace TOHC
{
    public partial class License : UserControl
    {
        public License()
        {
            InitializeComponent();
        }

        ChromiumWebBrowser license = new ChromiumWebBrowser() { Dock=DockStyle.Fill};

        private void License_Load(object sender, EventArgs e)
        {
            license.LoadHtml(Properties.Resources.GNU_Affero_General_Public_License);
            this.Controls.Add(license);
        }
    }
}
