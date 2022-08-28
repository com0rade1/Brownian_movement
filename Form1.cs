using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        float x0;
        float y0;
        int Temperature;
        int Viscosity;
        int a;
        public Form1()
        {
            InitializeComponent();
        }

        private void BeginButton_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.White);
            this.Temperature = Convert.ToInt32(textBox1.Text);
            this.Viscosity = Convert.ToInt32(textBox2.Text);
            timer1.Interval = 1000-10*this.Temperature;
            timer1.Enabled = true;
            timer1.Start();
            this.x0 = (float)(this.rnd.Next(0, 780));
            this.y0 = (float)(this.rnd.Next(0, 360));


        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = pictureBox.CreateGraphics();
            this.a = this.rnd.Next(0, 360);
            float r = (float)(100/(this.Viscosity+1));
            float x1 = (float)(this.x0 + r * Math.Cos(this.a * (Math.PI) / 180));
            while (x1>=780 || x1<0)
            {
            x1 = (float)(this.x0 + r * Math.Cos(this.a * (Math.PI) / 180));
                this.a = this.rnd.Next(1, 360);
                r = (float)(this.rnd.Next(1, 100)/(this.Viscosity + 1));
            }
            float y1 = (float)(this.y0 + r * Math.Sin(this.a * (Math.PI) / 180));
            while (y1>=360 || y1<0)
            {
                y1 = (float)(this.y0 + r * Math.Sin(this.a * (Math.PI) / 180));
                this.a = this.rnd.Next(1, 360);
                r = (float)(this.rnd.Next(1, 100)/(this.Viscosity + 1));
            }
            g.DrawLine(new Pen(Color.Black), this.x0, this.y0, x1, y1);
            this.x0 = x1;
            this.y0 = y1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(rnd.Next(0, 100));
            textBox2.Text = Convert.ToString(rnd.Next(0, 10));
            this.BeginButton_Click(new object(), new EventArgs());
        }
    }
}
