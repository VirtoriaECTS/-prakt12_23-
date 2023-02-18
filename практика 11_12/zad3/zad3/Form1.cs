using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zad3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                robot robot1 = new robot();
                robot robot2 = new robot();
                robot robot3 = new robot();
                Random rn = new Random();
                int b = rn.Next(0, 100);
                robot1.min(b);
                robot1.kollife = Convert.ToInt32(textBox1.Text);
                label1.Text = " Количество жизней робота1 в начале игры " +robot1.kollife;
                robot2.kollife = Convert.ToInt32(textBox2.Text);
                label6.Text = "Количество жизней робота2 в начале игры " +robot2.kollife;
                robot3.kollife = Convert.ToInt32(textBox3.Text);
                label7.Text = "Количество жизней робота3 в начале игры " +robot3.kollife;
                int a = robot1.kollife;
                robot1.min(robot1.kollife);
                label2.Text = "Количество жизней робота1 в конце игры " + Convert.ToString(robot1.getlife());
                robot2.kol(a, robot1.kollife);
                label8.Text = "Количество жизней робота2 в конце игры " + Convert.ToString(robot2.getlife());
                robot3.kol(a, robot1.kollife);
                label9.Text = "Количество жизней робота3 в конце игры " + Convert.ToString(robot3.getlife());
        }
    }
}
