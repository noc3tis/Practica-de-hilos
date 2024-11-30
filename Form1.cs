using System.Runtime.Intrinsics.X86;

namespace Hilos4
{
    public partial class Form1 : Form
    {
        int r, g, b;
        bool b1, b2, b3;
        private Thread proceso1;
        private Thread proceso2;
        private Thread proceso3;
        private Thread proceso4;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            r = 0; g = 255; b = 0; b1 = false; b2 = true; b3 = false;
        }

        private void hilo1()
        {
            while (true)
            {
                Thread.Sleep(20);
                if (r >= 0 && r <= 255 && b1 == false)
                {
                    r++;
                    if (r == 255)
                    {
                        b1 = true;
                    }
                }
                if (r >= 0 && r <= 255 && b1 == true)
                {
                    r--;
                    if (r == 0)
                    {
                        b1 = false;
                        proceso2 = new Thread(new ThreadStart(hilo2));
                        proceso2.Start();
                        return;
                    }
                }
                pictureBox1.BackColor = Color.FromArgb(r, 80, 100);
            }
        }

        private void hilo2()
        {
            while (true)
            {
                Thread.Sleep(20);
                if (g >= 0 && g <= 255 && b2 == false)
                {
                    g++;
                    if (g == 255)
                    {
                        b2 = true;
                    }
                }
                if (g >= 0 && g <= 255 && b2 == true)
                {
                    g--;
                    if (g == 0)
                    {
                        b2 = false;
                        proceso3 = new Thread(new ThreadStart(hilo3));
                        proceso3.Start();
                        return;
                    }
                }
                pictureBox2.BackColor = Color.FromArgb(100, g, 100);
            }
        }

        private void hilo3()
        {
            while (true)
            {
                Thread.Sleep(20);
                if (b >= 0 && b <= 255 && b3 == false)
                {
                    b++;
                    if (b == 255)
                    {
                        b3 = true;
                    }
                }
                if (b >= 0 && b <= 255 && b3 == true)
                {
                    b--;
                    if (b == 0)
                    {
                        b3 = false;
                        proceso4 = new Thread(new ThreadStart(hilo4));
                        proceso4.Start();
                        return;
                    }
                }
                pictureBox3.BackColor = Color.FromArgb(100, 100, b);
            }
        }

        private void hilo4()
        {
            while (true)
            {
                Thread.Sleep(20);
                if (b >= 0 && b <= 255 && b3 == false)
                {
                    b++;
                    if (b == 255)
                    {
                        b3 = true;
                    }
                }
                if (b >= 0 && b <= 255 && b3 == true)
                {
                    b--;
                    if (b == 0)
                    {
                        b3 = false;
                        proceso1 = new Thread(new ThreadStart(hilo1));
                        proceso1.Start();
                        return;
                    }
                }
                pictureBox4.BackColor = Color.FromArgb(50, 10, b);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            proceso1 = new Thread(new ThreadStart(hilo1));
            proceso1.Start();
        }
    }
}

