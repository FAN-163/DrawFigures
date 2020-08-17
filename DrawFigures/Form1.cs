using DrawFigures.Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DrawFigures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Display display = new Display();
            display.PreparingDisplay(textBox1);
            display.StartView(textBox1, pictureBox1);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                g.Clear(Color.FromArgb(240, 240, 240));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "-n circle -p [400, 200] -r1 150 -c rgb(255, 255, 0) -b rgb(255, 255, 0);" +
                            "-n circle -p [475, 125] -r1 20 -c rgb(0, 0, 0, 1.0) -b rgba(0, 0, 0, 1.0);" +
                            "-n circle -p [570, 200] -r1 10 -c rgb(255, 255, 0) -b rgb(255, 255, 0);" +
                            "-n circle -p [620, 200] -r1 10 -c rgb(255, 255, 0) -b rgb(255, 255, 0);" +
                            "-n circle -p [670, 200] -r1 10 -c rgb(255, 255, 0) -b rgb(255, 255, 0);" +
                            "-n circle -p [720, 200] -r1 10 -c rgb(255, 255, 0) -b rgb(255, 255, 0);" +
                            "-n circle -p [770, 200] -r1 10 -c rgb(255, 255, 0) -b rgb(255, 255, 0);" +
                            "-n triangle -p [400, 200] [550, 230] [550, 170] -c rgb(240, 240, 240) -b rgb(240, 240, 240)";
        }
    }
}
