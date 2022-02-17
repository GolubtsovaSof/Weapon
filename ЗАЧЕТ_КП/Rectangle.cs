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
	public class Rectangle : Figure
	{

		public Rectangle(float ax, float ay, float aw, float ah, Color acolor) : base(ax, ay, aw, ah, acolor) { }

		public override void Draw(Graphics g)
		{
			g.DrawRectangle(new Pen(line_color,5), x, y, w, h);
		}
		public override bool Touch(float ax, float ay)
		{
			return ax >= x && ax <= x + w && ay >= y && ay <= y + h;
		}
		public override void Fill(Graphics g)
		{
			SolidBrush brush = new SolidBrush(color);
			g.FillRectangle(brush, x, y, w, h);
		}
		public override void Move(float ax, float ay)
		{
			x = ax;
			y = ay;
		}
		public override void Redraw()
		{
		}
	}
}
