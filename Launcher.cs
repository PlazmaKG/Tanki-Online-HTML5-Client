using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TOHC
{
    public partial class Launcher : Form
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Launcher_Load(object sender, EventArgs e)
        {
            UpdateProfileList();
            Properties.Settings.Default.Selected = "None";
            Properties.Settings.Default.ClickedPlay = false;
        }

        private void UpdateProfileList()
        {
            panel1.Controls.Clear();
            if (Properties.Settings.Default.Profiles.Count == 1)
            {
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
                for (int i = 1; i < Properties.Settings.Default.Profiles.Count; i++)
                {
                    panel1.Controls.Add(new ProfileSelection(Properties.Settings.Default.Profiles[i]) { Dock = DockStyle.Top });
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Selected == "None")
            {
                Message msg = new Message("You must select a profile!");
                msg.ShowDialog();
            }
            else
            {
                Properties.Settings.Default.ClickedPlay = true;
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProfileCreation createprofile = new ProfileCreation();
            createprofile.ShowDialog();
            if (createprofile.created == true)
            {
                UpdateProfileList();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Selected Profile: " + Properties.Settings.Default.Selected;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Credits credits = new Credits();
            credits.ShowDialog();
        }
    }
}
