using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace captcha
{
	class Program
	{
		static void Main(string[] args)
		{
			Bitmap image = new Bitmap(500, 200);
			Graphics g = Graphics.FromImage(image);
			g.Clear(Color.AliceBlue);

			g.DrawLine(new Pen(Color.Black), new Point(0, 0), new Point(300, 150));
			g.DrawString("qwrt", 
				new Font("宋体", 12), 
				new SolidBrush(Color.DarkGray), 
				new PointF(20, 30));

			image.SetPixel(100, 100, Color.Orange);

			image.Save(@"E:\echo\zero\adn\test\testing\hello.jpg", ImageFormat.Jpeg);

		}
	}
}
