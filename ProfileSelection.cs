using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TOHC
{
    public partial class ProfileSelection : UserControl
    {
        public ProfileSelection(string profilename)
        {
            InitializeComponent();
            label1.Text = profilename;
        }

        private void ProfileSelection_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Message msg = new Message("Are you sure you want to delete the profile '" + label1.Text + "'?", "This CAN NOT be undone!",true);
            msg.ShowDialog();
            if (msg.istrue == true)
            {
                if (Properties.Settings.Default.Selected == label1.Text)
                {
                    Properties.Settings.Default.Selected = "None";
                }
                string profilepath = "%appdata%\\TOHC\\" + label1.Text;
                profilepath = Environment.ExpandEnvironmentVariables(profilepath);
                string[] filesinprofile = Directory.GetFiles(profilepath);
                foreach (string file in filesinprofile)
                    File.Delete(file);
                Directory.Delete(profilepath, true);

                Properties.Settings.Default.Profiles.Remove(label1.Text);
                Properties.Settings.Default.Save();
                ((Panel)this.Parent).Controls.Remove(this);
            }  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Selected = label1.Text;
        }
    }
}
