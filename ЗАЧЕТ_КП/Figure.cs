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
	public abstract class Figure
	{
		public float x, y;
		public float w, h;
		public Color color;
		public Color line_color;
		public bool chosen;

		public Figure(float ax, float ay, float aw, float ah, Color acolor)
		{
			x = ax; y = ay;
			w = aw; h = ah;
			color = acolor;
			line_color = Color.FromArgb(255-color.R, 255-color.G,255-color.B);
			chosen = false;
		}

		public abstract void Draw(Graphics g);
		public abstract bool Touch(float ax, float ay);
		public abstract void Fill(Graphics g);
		public abstract void Move(float ax, float ay);
		public abstract void Redraw();
	}
}
