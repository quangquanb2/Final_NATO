using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NATO.GUI
{
    public partial class Message : Form
    {
        public static Message instance;
        public static Message Instance
        {
            get
            {
                if (instance == null)
                    instance = new Message();
                return instance;
            }
        }

        public Message()
        {
            InitializeComponent();
            
        }

        public void Show(string mss, int type)
        {
            button2.Visible = false;
            string tt = type == 1 ? "success" : "fail";
            Show(mss, tt);
            button2.Visible = true;
        }

        public bool Show(string mss, string icon)
        {
            label1.Text = mss;
            pictureBox1.ImageLocation = @"C:\Users\quang\source\repos\NATO\NATO\Images\" + icon + ".png";

            this.ShowDialog();
            return label2.Text == "YES";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "YES";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = "NO";
            this.Close();
        }
    }
}
