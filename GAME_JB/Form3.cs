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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = Image.FromFile(@"C:\Users\JB (BRYAN)\source\repos\GAME_JB\GAME_JB\gif2.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 xsDD = new Form1();
            this.Hide();

            xsDD.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 xsDDdd = new Form2();
            this.Hide();

            xsDDdd.Show();
        }
    }
}
