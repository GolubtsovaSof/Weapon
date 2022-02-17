using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ЗАЧЕТ_КП
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			DoubleBuffered = true;

		}

		Random rnd = new Random();
		int numb_of_rects = 0;
		int numb_of_elli = 0;
		int numb_of_trucks = 0;

		float dx, dy;

		List<Rectangle> rectangles = new List<Rectangle>();
		List<Ellipse> ellipses = new List<Ellipse>();
		List<Truck> trucks = new List<Truck>();
		List<Figure> figures = new List<Figure>();

		List<CheckBox> checkBoxes_r = new List<CheckBox>();
		List<CheckBox> checkBoxes_e = new List<CheckBox>();
		List<CheckBox> checkBoxes_t = new List<CheckBox>();

		update update;

		private void Form1_Load(object sender, EventArgs e)
		{
			
			update = new update(this);
			Hide();
			DialogResult r = MessageBox.Show("Оружие запущено!!!", "!!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			if (r == DialogResult.Cancel)
			{
				Close();
			}
			else
			{
				Show();
			}
		}


		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			int x = numb_of_rects;
			if (numericUpDown1.Value > numb_of_rects)
			{
				for (int i=0; i< numericUpDown1.Value-x; i++)
				{
					Rectangle r = new Rectangle(rnd.Next(ClientSize.Width), rnd.Next(ClientSize.Height), rnd.Next(10, 200), rnd.Next(10, 200), Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
					rectangles.Add(r);
					figures.Add(r);
					Refresh();
					CheckBox c = new CheckBox();
					c.Checked = true;
					c.CheckedChanged += new EventHandler(c1_CheckedChanged);
					c.Size = new Size(20, 20);
					c.Location = new Point(pictureBox1.Width + 40 + numericUpDown1.Width + 20 * numb_of_rects, 10);
					Controls.Add(c);
					checkBoxes_r.Add(c);
					numb_of_rects += 1;
				}
			}
			else
			{
				for (int i = 0; i < x- numericUpDown1.Value; i++)
				{
					figures.Remove(rectangles[numb_of_rects - 1]);
					rectangles.RemoveAt(numb_of_rects - 1);
					Controls.Remove(checkBoxes_r[numb_of_rects - 1]);
					checkBoxes_r.RemoveAt(numb_of_rects - 1);
					Refresh();
					numb_of_rects -= 1;
				}
			}
		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{
			int x = numb_of_elli;
			if (numericUpDown2.Value > numb_of_elli)
			{
				for (int i = 0; i < numericUpDown2.Value - x; i++)
				{
					Ellipse el = new Ellipse(rnd.Next(ClientSize.Width), rnd.Next(ClientSize.Height), rnd.Next(10, 200), rnd.Next(10, 200), Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
					ellipses.Add(el);
					figures.Add(el);
					Refresh();
					CheckBox c = new CheckBox();
					c.Checked = true;
					c.CheckedChanged += new EventHandler(c_CheckedChanged);
					c.Size = new Size(20, 20);
					c.Location = new Point(pictureBox1.Width + 40 + numericUpDown1.Width + 20 * numb_of_elli, 32);
					Controls.Add(c);
					checkBoxes_e.Add(c);
					numb_of_elli += 1;
				}
			}
			else
			{
				for (int i = 0; i < x - numericUpDown2.Value; i++)
				{
					figures.Remove(ellipses[numb_of_elli - 1]);
					ellipses.RemoveAt(numb_of_elli - 1);
					Controls.Remove(checkBoxes_e[numb_of_elli - 1]);
					checkBoxes_e.RemoveAt(numb_of_elli - 1);
					Refresh();
					numb_of_elli -= 1;
				}
			}
		}

		private void numericUpDown3_ValueChanged(object sender, EventArgs e)
		{
			int x = numb_of_trucks;
			if (numericUpDown3.Value > numb_of_trucks)
			{
				for (int i = 0; i < numericUpDown3.Value - x; i++)
				{
					Truck t = new Truck(rnd.Next(ClientSize.Width), rnd.Next(ClientSize.Height), rnd.Next(100, 200), rnd.Next(70, 200), Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)));
					trucks.Add(t);
					figures.Add(t);
					Refresh();
					CheckBox c2 = new CheckBox();
					c2.Checked = true;
					c2.CheckedChanged += new EventHandler(c2_CheckedChanged);
					c2.Size = new Size(20, 20);
					c2.Location = new Point(pictureBox1.Width + 40 + numericUpDown1.Width + 20 * numb_of_trucks, 55);
					Controls.Add(c2);
					checkBoxes_t.Add(c2);
					numb_of_trucks += 1;
				}
			}
			else
			{
				for (int i = 0; i < x - numericUpDown3.Value; i++)
				{
					figures.Remove(trucks[numb_of_trucks - 1]);
					trucks.RemoveAt(numb_of_trucks - 1);
					Controls.Remove(checkBoxes_t[numb_of_trucks - 1]);
					checkBoxes_t.RemoveAt(numb_of_trucks - 1);
					Refresh();
					numb_of_trucks -= 1;
				}
			}
		}


		void c_CheckedChanged(object sender, EventArgs e)
		{
			if (!(sender as CheckBox).Checked)
			{
				var index = checkBoxes_e.IndexOf(sender as CheckBox);
				Color index_color = ellipses[index].color;
				ellipses[index].color = Color.FromArgb(40, index_color.R, index_color.G, index_color.B);
				ellipses[index].chosen = false;
				Refresh();
			}
			else
			{
				var index = checkBoxes_e.IndexOf(sender as CheckBox);
				Color index_color = ellipses[index].color;
				ellipses[index].color = Color.FromArgb(index_color.R, index_color.G, index_color.B);
				Refresh();
			}
		}
		void c1_CheckedChanged(object sender, EventArgs e)
		{
			if (!(sender as CheckBox).Checked)
			{
				var index = checkBoxes_r.IndexOf(sender as CheckBox);
				Color index_color = rectangles[index].color;
				rectangles[index].color = Color.FromArgb(40, index_color.R, index_color.G, index_color.B);
				rectangles[index].chosen = false;
				Refresh();
			}
			else
			{
				var index = checkBoxes_r.IndexOf(sender as CheckBox);
				Color index_color = rectangles[index].color;
				rectangles[index].color = Color.FromArgb(index_color.R, index_color.G, index_color.B);
				Refresh();
			}
		}

		void c2_CheckedChanged(object sender, EventArgs e)
		{
			if (!(sender as CheckBox).Checked)
			{
				var index = checkBoxes_t.IndexOf(sender as CheckBox);
				Color index_b_color = trucks[index].body.color;
				Color index_c_color = trucks[index].cab.color;
				Color index_w1_color = trucks[index].wheel1.color;
				Color index_w2_color = trucks[index].wheel2.color;

				trucks[index].body.color = Color.FromArgb(40, index_b_color.R, index_b_color.G, index_b_color.B);
				trucks[index].cab.color = Color.FromArgb(40, index_c_color.R, index_c_color.G, index_c_color.B);
				trucks[index].wheel1.color = Color.FromArgb(40, index_w1_color.R, index_w1_color.G, index_w1_color.B);
				trucks[index].wheel2.color = Color.FromArgb(40, index_w2_color.R, index_w2_color.G, index_w2_color.B);
				trucks[index].color = Color.FromArgb(40, index_w2_color.R, index_w2_color.G, index_w2_color.B);
				trucks[index].chosen = false;
				Refresh();
			}
			else
			{
				var index = checkBoxes_t.IndexOf(sender as CheckBox);
				Color index_b_color = trucks[index].body.color;
				Color index_c_color = trucks[index].cab.color;
				Color index_w1_color = trucks[index].wheel1.color;
				Color index_w2_color = trucks[index].wheel2.color;
				trucks[index].body.color = Color.FromArgb(index_b_color.R, index_b_color.G, index_b_color.B);
				trucks[index].cab.color = Color.FromArgb(index_c_color.R, index_c_color.G, index_c_color.B);
				trucks[index].wheel1.color = Color.FromArgb(index_w1_color.R, index_w1_color.G, index_w1_color.B);
				trucks[index].wheel2.color = Color.FromArgb(index_w2_color.R, index_w2_color.G, index_w2_color.B);
				trucks[index].color = Color.FromArgb(index_w2_color.R, index_w2_color.G, index_w2_color.B);
				Refresh();
			}
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			foreach (var fig in figures)
			{
				fig.Fill(e.Graphics);
				fig.line_color = Color.Transparent;
				if (fig.chosen)
				{
					fig.line_color = Color.FromArgb(255 - fig.color.R, 255 - fig.color.G, 255 - fig.color.B);
					fig.Draw(e.Graphics);
				}

			}
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			int count = 0;
			for (int i = figures.Count - 1; i >= 0; i--)
			{
				figures[i].chosen = false;
				if (figures[i].Touch(e.X, e.Y) && count == 0 && figures[i].color.A != 40)
				{
					dx = e.X - figures[i].x;
					dy = e.Y - figures[i].y;
					figures[i].chosen = !figures[i].chosen;
					count += 1;
				}
				if (e.Button == MouseButtons.Right && figures[i].Touch(e.X, e.Y) && figures[i].chosen)
				{
					update.orig_fig = figures[i];
					update.Show();

					if (figures[i] is Rectangle)
					{
						update.fig = new Rectangle(figures[i].x, figures[i].y, figures[i].w, figures[i].h, figures[i].color);
					}
					if (figures[i] is Ellipse)
					{
						update.fig = new Ellipse(figures[i].x, figures[i].y, figures[i].w, figures[i].h, figures[i].color);
					}
					if (figures[i] is Truck)
					{
						update.fig = new Truck(figures[i].x, figures[i].y, figures[i].w, figures[i].h, figures[i].color);
						(update.fig as Truck).body.color = (figures[i] as Truck).body.color;
						(update.fig as Truck).cab.color = (figures[i] as Truck).cab.color;
						(update.fig as Truck).wheel1.color = (figures[i] as Truck).wheel1.color;
						(update.fig as Truck).wheel2.color = (figures[i] as Truck).wheel2.color;
					}
					update.numericUpDown1.Value = (decimal)figures[i].w;
					update.numericUpDown2.Value = (decimal)figures[i].h;
				}
				update.Refresh();
			}
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				foreach (var fig in figures)
				{
					if (fig.chosen && fig.color.A != 40)
					{
						fig.Move(e.X - dx, e.Y - dy);
					}
				}
			}
			Refresh();
		}
		public void Save(string path)
		{
			StreamWriter sw = new StreamWriter(path);

			foreach (var fig in figures)
			{
				if (fig is Rectangle)
				{
					sw.WriteLine("1");
				}
				if (fig is Ellipse)
				{
					sw.WriteLine("2");
				}
				if (fig is Truck)
				{
					sw.WriteLine("3");
				}
				sw.WriteLine(fig.x);
				sw.WriteLine(fig.y);
				sw.WriteLine(fig.w);
				sw.WriteLine(fig.h);
				if (fig is Truck)
				{

					sw.WriteLine((fig as Truck).body.color.ToArgb());
					sw.WriteLine((fig as Truck).cab.color.ToArgb());
					sw.WriteLine((fig as Truck).wheel1.color.ToArgb());
					sw.WriteLine((fig as Truck).wheel2.color.ToArgb());
				}
				else
				{
					sw.WriteLine(fig.color.ToArgb());
				}
				if (fig.color.A == 40) sw.WriteLine("0");
				else sw.WriteLine("1");
			}
			sw.Close();
		}


		private void button2_Click(object sender, EventArgs e)
		{
			LoadPic();
			Refresh();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Save("save.txt");
		}

		private void button3_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Поставьте зачет, пожалуйста))))))))");
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			
			if (figures.Count != 0)
			{
				if (File.Exists("save.txt"))
				{
					Save("save_to_compare.txt");
					string firstFile = File.ReadAllText("save.txt");
					string secondFile = File.ReadAllText("save_to_compare.txt");
					if (firstFile != secondFile)
					{
						DialogResult r = MessageBox.Show("Сохранить?", "?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						if (r == DialogResult.Yes)
						{
							Save("save.txt");
						}
						else if (r == DialogResult.Cancel)
						{
							e.Cancel = true;
						}
					}
				}
				else if (figures.Count != 0)
				{
					DialogResult r = MessageBox.Show("Сохранить?", "?", MessageBoxButtons.YesNoCancel);
					if (r == DialogResult.Yes)
					{
						Save("save.txt");
					}
					else if (r == DialogResult.Cancel)
					{
						e.Cancel = true;
					}
				}
			}
		}

		public void LoadPic()
		{
			if (File.Exists("save.txt"))
			{

				numericUpDown1.Value = 0;
				numericUpDown2.Value = 0;
				numericUpDown3.Value = 0;
				Refresh();


				StreamReader sr = new StreamReader("save.txt");
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					if (line == "1")
					{
						numericUpDown1.Value += 1;
						rectangles[numb_of_rects - 1].x = (float)Convert.ToDouble(sr.ReadLine());
						rectangles[numb_of_rects - 1].y = (float)Convert.ToDouble(sr.ReadLine());
						rectangles[numb_of_rects - 1].w = (float)Convert.ToDouble(sr.ReadLine());
						rectangles[numb_of_rects - 1].h = (float)Convert.ToDouble(sr.ReadLine());
						rectangles[numb_of_rects - 1].color = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
						figures[figures.Count - 1] = rectangles[numb_of_rects - 1];
						Refresh();

						if (sr.ReadLine() == "0")
						{
							checkBoxes_r[numb_of_rects-1].Checked = false;
						}
						

					}
					if (line == "2")
					{
						numericUpDown2.Value += 1;
						ellipses[numb_of_elli - 1].x = (float)Convert.ToDouble(sr.ReadLine());
						ellipses[numb_of_elli - 1].y = (float)Convert.ToDouble(sr.ReadLine());
						ellipses[numb_of_elli - 1].w = (float)Convert.ToDouble(sr.ReadLine());
						ellipses[numb_of_elli - 1].h = (float)Convert.ToDouble(sr.ReadLine());
						ellipses[numb_of_elli - 1].color = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
						figures[figures.Count - 1] = ellipses[numb_of_elli - 1];
						Refresh();

						if (sr.ReadLine() == "0")
						{
							checkBoxes_e[numb_of_elli - 1].Checked = false;
						}
					}
					if (line == "3")
					{
						numericUpDown3.Value += 1;
						trucks[numb_of_trucks - 1].x = (float)Convert.ToDouble(sr.ReadLine());
						trucks[numb_of_trucks - 1].y = (float)Convert.ToDouble(sr.ReadLine());
						trucks[numb_of_trucks - 1].w = (float)Convert.ToDouble(sr.ReadLine());
						trucks[numb_of_trucks - 1].h = (float)Convert.ToDouble(sr.ReadLine());
						trucks[numb_of_trucks - 1].body.color = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
						trucks[numb_of_trucks - 1].cab.color = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
						trucks[numb_of_trucks - 1].wheel1.color = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
						trucks[numb_of_trucks - 1].wheel2.color = Color.FromArgb(Convert.ToInt32(sr.ReadLine()));
						trucks[numb_of_trucks - 1].Redraw();
						figures[figures.Count - 1] = trucks[numb_of_trucks - 1];
						Refresh();

						if (sr.ReadLine() == "0")
						{
							checkBoxes_t[numb_of_trucks - 1].Checked = false;
						}
					}
				}
				sr.Close();
			}
			else
			{
				MessageBox.Show("Нет сохраненных файлов");
			}
		}
	}
}
