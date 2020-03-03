using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenColorPicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap s;
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            ScreenCapturer sc = new ScreenCapturer();
          s = sc.Capture(enmScreenCaptureMode.Screen);
            this.Show();
            this.BackgroundImage = s;
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 50;
            this.Cursor = Cursors.Default;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Color c = s.GetPixel(e.X, e.Y);
            Form colorshower = new Form();
            colorshower.Height = 50;
            colorshower.Width = 50;
            colorshower.BackColor = c;
            colorshower.Show();
            Label l = new Label();
            l.Text = c.R + "," + c.G + "," + c.B + ",A" + c.A;
            colorshower.Height = 50;
            colorshower.Width = l.Text.Length * 5;
            colorshower.Controls.Add(l);
        }
    }
}
