using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAME_JB
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\JB (BRYAN)\source\repos\GAME_JB\GAME_JB\gif5.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 xsD = new Form1();
            this.Hide();

            xsD.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 SxsD = new Form2();
            this.Hide();

            SxsD.Show();
        }
    }
}
