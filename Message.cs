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
    public partial class Message : Form
    {
        public bool istrue = false;
        public Message(string msg)
        {
            InitializeComponent();
            label1.Text = msg;
            button1.Text = "OK";
            button2.Visible = false;
        }

        public Message(string msg, bool isyesno)
        {
            InitializeComponent();
            label1.Text = msg;
            if (isyesno == true)
            {
                button1.Text = "Yes";
                button2.Visible = true;
            }
            else
            {
                button1.Text = "OK";
                button2.Visible = false;
            }
        }

        public Message(string msg, string msg2)
        {
            InitializeComponent();
            label1.Text = msg;
            label2.Text = msg2;
            button1.Text = "OK";
            button2.Visible = false;
        }

        public Message(string msg, string msg2, bool isyesno)
        {
            InitializeComponent();
            label1.Text = msg;
            label2.Text = msg2;
            if (isyesno == true)
            {
                button1.Text = "Yes";
                button2.Visible = true;
            }
            else
            {
                button1.Text = "OK";
                button2.Visible = false;
            }
        }

        private void Message_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            istrue = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            istrue = false;
            this.Close();
        }
    }
}
