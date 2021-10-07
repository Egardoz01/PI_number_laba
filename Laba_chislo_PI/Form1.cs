using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_chislo_PI
{
    public partial class Form1 : Form
    {
        string PI;
        char digit = '0';
        int cur = 2;
        public Form1()
        {
            InitializeComponent();


        }


        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            PI = File.ReadAllText(@"..\..\..\CountPI\bin\Release\netcoreapp3.1\pi.txt");
        }

        void drawPixel(Graphics g, int x, int y)
        {
            g.DrawRectangle(new Pen(Color.Black), x, y, 1, 1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            int len = 1;
            int x = panel1.Width / 2, y = panel1.Height / 2;
            cur = 2;

            while (cur < PI.Length)
            {

                for (int i = 0; i < len; i++)
                {
                    if (cur < PI.Length && PI[cur++] == digit)
                        if (x >= 0 && x < panel1.Width && y >= 0 && y < panel1.Height)
                            drawPixel(e.Graphics, x, y);
                    x++;
                }
                for (int i = 0; i < len; i++)
                {
                    if (cur < PI.Length && PI[cur++] == digit)
                        if (x >= 0 && x < panel1.Width && y >= 0 && y < panel1.Height)
                            drawPixel(e.Graphics, x, y);
                    y--;
                }
                len++;

                for (int i = 0; i < len; i++)
                {
                    if (cur < PI.Length && PI[cur++] == digit)
                        if (x >= 0 && x < panel1.Width && y >= 0 && y < panel1.Height)
                            drawPixel(e.Graphics, x, y);
                    x--;
                }
                for (int i = 0; i < len; i++)
                {
                    if (cur < PI.Length && PI[cur++] == digit)
                        if (x >= 0 && x < panel1.Width && y >= 0 && y < panel1.Height)
                            drawPixel(e.Graphics, x, y);
                    y++;
                }
                len++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = (string)comboBox1.SelectedItem;

            digit = str[0];
            panel1.Refresh();
        }
    }
}
