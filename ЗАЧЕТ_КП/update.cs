using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЗАЧЕТ_КП
{
	public partial class update : Form
	{
		public Figure fig;
		public Figure orig_fig;
		public decimal stop1, stop2;
		public Form1 m_parent;

		public update(Form1 frm1)
		{
			InitializeComponent();
			m_parent = frm1;
		}

		private void update_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			fig.x = Width / 2 - fig.w / 2;
			fig.y = Height / 2 - fig.h / 2 - 50;
			if (fig is Truck && numericUpDown1.Value > numericUpDown2.Value / 2)
			{
				fig.Move(Width / 2 - fig.w / 2, Height / 2 - fig.h / 8 - 50);
			}
			fig.Fill(e.Graphics);
		}

		private void update_Load(object sender, EventArgs e)
		{
			Timer timer1 = new Timer();
			timer1.Interval = 1;
			timer1.Start();
			timer1.Tick += new EventHandler(timer1_Tick);
		}

		private void update_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			Hide();
		}

		private void update_FormClosed(object sender, FormClosedEventArgs e)
		{
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			decimal last = numericUpDown2.Value;
			if (orig_fig.color.A != 40)
			{

				if (fig is Truck && (float)numericUpDown1.Value > (float)numericUpDown2.Value / 2 + 5)
				{
					orig_fig.h = (float)numericUpDown2.Value;
					fig.h = (float)numericUpDown2.Value;
					orig_fig.Redraw();
					fig.Redraw();
					stop2 = numericUpDown2.Value;
				}
				else if (fig is Truck && (float)numericUpDown1.Value <= (float)numericUpDown2.Value / 2 + 5)
				{
					numericUpDown2.Value = stop2;
				}
				else
				{
					orig_fig.h = (float)numericUpDown2.Value;
					fig.h = (float)numericUpDown2.Value;
				}

			}

			Refresh();
			m_parent.Refresh();
		}

		private void update_MouseDown(object sender, MouseEventArgs e)
		{

		}

		private void update_MouseClick(object sender, MouseEventArgs e)
		{
			if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && fig.Touch(e.X, e.Y) && orig_fig.color.A!=40) 
			{
				if (fig is Truck)
				{
					if ((fig as Truck).body.Touch(e.X, e.Y))
					{
						ColorDialog cd = new ColorDialog();
						if (cd.ShowDialog() == DialogResult.OK)
						{
							(fig as Truck).body.color = cd.Color;
							(fig as Truck).body.line_color = Color.FromArgb(255 - (fig as Truck).body.color.R, 255 - (fig as Truck).body.color.G, 255 - (fig as Truck).body.color.B);
							(fig as Truck).body.Draw(CreateGraphics());
							(orig_fig as Truck).body.color = cd.Color;
							(orig_fig as Truck).body.line_color = Color.FromArgb(255 - (orig_fig as Truck).body.color.R, 255 - (orig_fig as Truck).body.color.G, 255 - (orig_fig as Truck).body.color.B);
							(orig_fig as Truck).body.Draw(CreateGraphics());
						}
					}
					if ((fig as Truck).cab.Touch(e.X, e.Y))
					{
						ColorDialog cd = new ColorDialog();
						if (cd.ShowDialog() == DialogResult.OK)
						{
							(fig as Truck).cab.color = cd.Color;
							(fig as Truck).cab.line_color = Color.FromArgb(255 - (fig as Truck).cab.color.R, 255 - (fig as Truck).cab.color.G, 255 - (fig as Truck).cab.color.B);
							(fig as Truck).cab.Draw(CreateGraphics());
							(orig_fig as Truck).cab.color = cd.Color;
							(orig_fig as Truck).cab.line_color = Color.FromArgb(255 - (orig_fig as Truck).cab.color.R, 255 - (orig_fig as Truck).cab.color.G, 255 - (orig_fig as Truck).cab.color.B);
							(orig_fig as Truck).cab.Draw(CreateGraphics());
						}
					}
					if ((fig as Truck).wheel1.Touch(e.X, e.Y) )
					{
						ColorDialog cd = new ColorDialog();
						if (cd.ShowDialog() == DialogResult.OK )
						{
							(fig as Truck).wheel1.color = cd.Color;
							(fig as Truck).wheel1.line_color = Color.FromArgb(255 - (fig as Truck).wheel1.color.R, 255 - (fig as Truck).wheel1.color.G, 255 - (fig as Truck).wheel1.color.B);
							(fig as Truck).wheel1.Draw(CreateGraphics());
							(orig_fig as Truck).wheel1.color = cd.Color;
							(orig_fig as Truck).wheel1.line_color = Color.FromArgb(255 - (orig_fig as Truck).wheel1.color.R, 255 - (orig_fig as Truck).wheel1.color.G, 255 - (orig_fig as Truck).wheel1.color.B);
							(orig_fig as Truck).wheel1.Draw(CreateGraphics());
						}
					}
					if ((fig as Truck).wheel2.Touch(e.X, e.Y) )
					{
						ColorDialog cd = new ColorDialog();
						if (cd.ShowDialog() == DialogResult.OK)
						{
							(fig as Truck).wheel2.color = cd.Color;
							(fig as Truck).wheel2.line_color = Color.FromArgb(255 - (fig as Truck).wheel2.color.R, 255 - (fig as Truck).wheel2.color.G, 255 - (fig as Truck).wheel2.color.B);
							(fig as Truck).wheel2.Draw(CreateGraphics());
							(orig_fig as Truck).wheel2.color = cd.Color;
							(orig_fig as Truck).wheel2.line_color = Color.FromArgb(255 - (orig_fig as Truck).wheel2.color.R, 255 - (orig_fig as Truck).wheel2.color.G, 255 - (orig_fig as Truck).wheel2.color.B);
							(orig_fig as Truck).wheel2.Draw(CreateGraphics());
						}
					}
				}
				else
				{
					ColorDialog cd = new ColorDialog();
					if (cd.ShowDialog() == DialogResult.OK && orig_fig.color.A != 40)
					{
						fig.color = cd.Color;
						orig_fig.color = cd.Color;
					}
				}
				Refresh();    
				m_parent.Refresh();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (fig is Truck && orig_fig.color.A != 40)
			{
				ColorDialog cd = new ColorDialog();
				if (cd.ShowDialog() == DialogResult.OK && (orig_fig as Truck).color.A != 40)
				{
					(fig as Truck).body.color = cd.Color;
					(fig as Truck).cab.color = cd.Color;
					(fig as Truck).wheel1.color = cd.Color;
					(fig as Truck).wheel2.color = cd.Color;
					(orig_fig as Truck).body.color = cd.Color;
					(orig_fig as Truck).cab.color = cd.Color;
					(orig_fig as Truck).wheel1.color = cd.Color;
					(orig_fig as Truck).wheel2.color = cd.Color;
					(orig_fig as Truck).body.line_color = Color.FromArgb(255 - (fig as Truck).body.color.R, 255 - (fig as Truck).body.color.G, 255 - (fig as Truck).body.color.B);
					(orig_fig as Truck).cab.line_color = Color.FromArgb(255 - (fig as Truck).body.color.R, 255 - (fig as Truck).body.color.G, 255 - (fig as Truck).body.color.B);
					(orig_fig as Truck).wheel1.line_color = Color.FromArgb(255 - (fig as Truck).body.color.R, 255 - (fig as Truck).body.color.G, 255 - (fig as Truck).body.color.B);
					(orig_fig as Truck).wheel2.line_color = Color.FromArgb(255 - (fig as Truck).body.color.R, 255 - (fig as Truck).body.color.G, 255 - (fig as Truck).body.color.B);
					(orig_fig as Truck).body.Draw(CreateGraphics());
					(orig_fig as Truck).cab.Draw(CreateGraphics());
					(orig_fig as Truck).wheel1.Draw(CreateGraphics());
					(orig_fig as Truck).wheel2.Draw(CreateGraphics());
				}
				
			}
			else if (orig_fig.color.A != 40)
			{
				ColorDialog cd = new ColorDialog();
				if (cd.ShowDialog() == DialogResult.OK)
				{
					fig.color = cd.Color;
					orig_fig.color = cd.Color;
				}
			}
			Refresh();
			m_parent.Refresh();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (orig_fig.color.A == 40)
			{
				numericUpDown1.Enabled = false;
				numericUpDown2.Enabled = false;
				button1.Enabled = false;
			}
			else
			{
				numericUpDown1.Enabled = true;
				numericUpDown2.Enabled = true;
				button1.Enabled = true;
			}
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			if (orig_fig.color.A != 40)
			{

				if (fig is Truck && (float)numericUpDown1.Value > (float)numericUpDown2.Value / 2 + 5 )
				{
					orig_fig.w = (float)numericUpDown1.Value;
					fig.w = (float)numericUpDown1.Value;
					orig_fig.Redraw();
					fig.Redraw();
					stop1 = numericUpDown1.Value;
				}
				else if (fig is Truck && (float)numericUpDown1.Value <= (float)numericUpDown2.Value / 2 + 5)
				{
					numericUpDown1.Value = stop1;
				}
				else
				{
					orig_fig.w = (float)numericUpDown1.Value;
					fig.w = (float)numericUpDown1.Value;
				}
			}

			Refresh();
			m_parent.Refresh();
		}
	}
}
