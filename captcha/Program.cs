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
			/*
			//draw
			Bitmap image = new Bitmap(500, 200);
			Graphics g = Graphics.FromImage(image);
			g.Clear(Color.AliceBlue);

			g.DrawLine(new Pen(Color.Black), new Point(0, 0), new Point(300, 150));
			g.DrawString("qwrt",
				new Font("宋体", 12),
				new SolidBrush(Color.DarkGray),
				new Point(20, 30));

			image.SetPixel(100, 100, Color.Orange);

			image.Save(@"E:\echo\zero\adn\test\testing\hello.jpg", ImageFormat.Jpeg);
			*/


			/*
			Captcha code = new Captcha(500, 200);
			code.SetBackgroundColor();

			for (int i = 0; i < 50; i++)
			{
				code.DrawRandomLine();
			}

			code.DrawRandomWords(Captcha.GetRandomColor());

			for (int i = 0; i < 500; i++)
			{
				code.DrawRandomPixel();
			}

			code.ImageSave(@"E:\echo\zero\adn\test\testing\hello.jpg");

			Console.WriteLine("请输入验证码：");
			string inputCode = Console.ReadLine();
			Console.WriteLine("您的验证码：" + code.VerifyCode(inputCode));
			*/

			CaptchaService cs = new CaptchaService(300);
			cs.CreateCaptcha(@"E:\echo\zero\adn\test\testing\hello.jpg");
			cs.VerifyInput();

			Console.Read();
		}
	}
}
