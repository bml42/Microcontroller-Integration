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

namespace Project2Csharp
{
    public partial class Form1 : Form
    {

        SerialPort dataTx = new SerialPort();

        public Form1()
        {
            InitializeComponent();

            dataTx.BaudRate = 9600;
            dataTx.PortName = "COM5";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataTx.Open();      //open communication
            dataTx.Write("o");  //turn on LED
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataTx.Write("x");  //turn off LED
            dataTx.Close();     //close communication
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataTx.Write("d");  //request distance
            textBox1.Text = dataTx.ReadLine();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataTx.Write("t");  //request temperature
            textBox2.Text = dataTx.ReadLine();
        }

        /*private void button5_Click(object sender, EventArgs e)
        {
            dataTx.Write("v");  //request voltage
            textBox3.Text = dataTx.ReadLine();
        }*/

        private void button6_Click(object sender, EventArgs e)
        {
            dataTx.Write("r");  //request resistance
            textBox4.Text = dataTx.ReadLine();
        }
    }
}
