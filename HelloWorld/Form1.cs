using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorld
{
    public partial class Form1 : Form
    {
        // Make a big red pen.
        private BufferedGraphics bufferedGraphics;
        Pen p = new Pen(Color.Red,7);
        int y = 7;
        public Form1()
        {
            InitializeComponent();
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(640, 480);
            this.Text = "Fun with graphics";
            //this.Resize += new System.EventHandler(this.Form1_Resize);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);

            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            bufferedGraphics = context.Allocate(this.CreateGraphics(),
            new Rectangle(0, 0, this.Width, this.Height));


            Timer timer = new Timer();
            timer.Interval = 33;
            timer.Tick += OnTimer;
            timer.Start();
 
        }

        private void MainForm_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
           
        }

        private void OnTimer(object sender, System.EventArgs e)
        {
            Graphics g = bufferedGraphics.Graphics;
            g.Clear(Color.Black);

            g.DrawLine(p, 1, 1, 100, y++);
            y = (y > 400 ? 1 : y);
            //g.FillRectangle(Brushes.Azure, -100, -100, 200, 200);
            bufferedGraphics.Render(Graphics.FromHwnd(this.Handle));
        }

    }
}