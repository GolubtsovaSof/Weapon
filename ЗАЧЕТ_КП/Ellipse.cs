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
	public class Ellipse : Figure
	{

		public Ellipse(float ax, float ay, float aw, float ah, Color acolor) : base(ax, ay, aw, ah, acolor) { }

		public override void Draw(Graphics g)
		{
			g.DrawEllipse(new Pen(line_color, 5), x, y, w, h);
		}
		public override bool Touch(float ax, float ay)
		{
			return ((ax - x - w/2) * (ax - x - w/2)) / (w*w/4) + ((ay - y - h/2) * (ay - y - h/2)) / (h*h/4) <= 1;
		}
		public override void Fill(Graphics g)
		{
			SolidBrush brush = new SolidBrush(color);
			g.FillEllipse(brush, x, y, w, h);
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
