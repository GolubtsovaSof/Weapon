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
	public class Truck : Figure
	{
		public Rectangle body;
		public Rectangle cab;
		public Ellipse wheel1;
		public Ellipse wheel2;

		public Truck(float ax, float ay, float aw, float ah, Color acolor) : base(ax, ay, aw, ah, acolor)
		{
			body = new Rectangle(x, y, w, h / 4, color);
			cab = new Rectangle(x, y - h / 4 - 1, w / 3, h / 4, color);
			wheel1 = new Ellipse(x, y + h / 4 + 1, h / 4, h / 4, color);
			wheel2 = new Ellipse(x + w - h / 4, y + h / 4 + 1, h / 4, h / 4, color);
		}
		public override void Draw(Graphics g)
		{
			body.Draw(g);
			cab.Draw(g);
			wheel1.Draw(g);
			wheel2.Draw(g);
		}
		public override bool Touch(float ax, float ay)
		{
			return body.Touch(ax, ay) || cab.Touch(ax, ay) || wheel1.Touch(ax, ay) || wheel2.Touch(ax, ay);
		}
		public override void Move(float ax, float ay)
		{
			x = ax;
			y = ay;
			body.x = ax; body.y = ay;
			cab.x = ax; cab.y = ay - h / 4 - 1;
			wheel1.x = ax; wheel1.y = ay + h / 4 + 1;
			wheel2.x = ax + w - h / 4; wheel2.y = ay + h / 4 + 1;
		}
		public override void Fill(Graphics g)
		{
			body.Fill(g);
			cab.Fill(g);
			wheel1.Fill(g);
			wheel2.Fill(g);
		}
		public override void Redraw()
		{
			body = new Rectangle(x, y, w, h / 4, body.color);
			cab = new Rectangle(x, y - h / 4 - 1, w / 3, h / 4, cab.color);
			wheel1 = new Ellipse(x, y + h / 4 + 1, h / 4, h / 4, wheel1.color);
			wheel2 = new Ellipse(x + w - h / 4, y + h / 4 + 1, h / 4, h / 4, wheel2.color);
		}
	}
}
