using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TOHC
{
    public partial class ProfileCreation : Form
    {
        public bool created = false;
        public string name = "name";
        public ProfileCreation()
        {
            InitializeComponent();
        }

        private void ProfileCreation_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                Message msg = new Message("You need to enter a name!");
                msg.ShowDialog();
            }
            else
            {
                bool hassamename = false;
                if(Properties.Settings.Default.Profiles.Count > 1)
                {
                    for (int i = 1; i < Properties.Settings.Default.Profiles.Count; i++)
                    {
                        if (textBox1.Text == Properties.Settings.Default.Profiles[i])
                        {
                            hassamename = true;
                        }
                    }
                }
                if (hassamename == true)
                {
                    Message msg = new Message("There's already a profile with that name!");
                    msg.ShowDialog();
                }
                else 
                {
                    created = true;
                    name = textBox1.Text;
                    Properties.Settings.Default.Profiles.Add(name);
                    Properties.Settings.Default.Save();
                    string mainfolder = "%appdata%\\TOHC";
                    string profilefolder = "%appdata%\\TOHC\\" + name;
                    mainfolder = Environment.ExpandEnvironmentVariables(mainfolder);
                    profilefolder = Environment.ExpandEnvironmentVariables(profilefolder);
                    if (!Directory.Exists(mainfolder))
                    {
                        Directory.CreateDirectory(mainfolder);
                    }
                    if (!Directory.Exists(profilefolder))
                    {
                        Directory.CreateDirectory(profilefolder);
                    }


                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
