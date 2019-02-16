using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace Project1Csharp
{
    public partial class Form1 : Form
    {
        int cat;
        int rdelay;
        int ydelay;
        int gdelay;
        int tdelay;

        SerialPort dataTx = new SerialPort();

        public Form1()
        {
            InitializeComponent();

            dataTx.BaudRate = 9600;
            dataTx.PortName = "COM3";
        }

        private async void button1_Click(object sender, EventArgs e)//this button will update lights with new times
        {
            cat = 0;
            ydelay = int.Parse(textBox2.Text) * 1000;
            gdelay = int.Parse(textBox3.Text) * 1000;
            tdelay = int.Parse(textBox4.Text) * 1000;
            while(cat == 0)
            {
                label4.BackColor = System.Drawing.Color.Green;
                label5.BackColor = System.Drawing.Color.Green;
                label1.BackColor = System.Drawing.Color.Red;
                label8.BackColor = System.Drawing.Color.Red;
                dataTx.Open();
                dataTx.Write("t");
                dataTx.Close();
                await Task.Delay(tdelay);
                label1.BackColor = System.Drawing.Color.White;
                label8.BackColor = System.Drawing.Color.White;
                label4.BackColor = System.Drawing.Color.White;
                label5.BackColor = System.Drawing.Color.White;
                label3.BackColor = System.Drawing.Color.Green;
                label6.BackColor = System.Drawing.Color.Green;
                dataTx.Open();
                dataTx.Write("g");
                dataTx.Close();
                await Task.Delay(gdelay);
                label3.BackColor = System.Drawing.Color.White;
                label6.BackColor = System.Drawing.Color.White;
                label2.BackColor = System.Drawing.Color.Yellow;
                label7.BackColor = System.Drawing.Color.Yellow;
                dataTx.Open();
                dataTx.Write("y");
                dataTx.Close();
                await Task.Delay(ydelay);
                label2.BackColor = System.Drawing.Color.White;
                label7.BackColor = System.Drawing.Color.White;
            }
        }

        private void button2_Click(object sender, EventArgs e)//this button will turn off all lights
        {
            dataTx.Open();

            dataTx.Write("x");

            dataTx.Close();

            cat =  1;
            label1.BackColor = System.Drawing.Color.White;
            label2.BackColor = System.Drawing.Color.White;
            label3.BackColor = System.Drawing.Color.White;
            label4.BackColor = System.Drawing.Color.White;
            label5.BackColor = System.Drawing.Color.White;
            label6.BackColor = System.Drawing.Color.White;
            label7.BackColor = System.Drawing.Color.White;
            label8.BackColor = System.Drawing.Color.White;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
