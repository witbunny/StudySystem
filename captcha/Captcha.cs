using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace captcha
{
	public class Captcha
	{
		private int _width;
		private int _height;
		private Bitmap _bitmap;
		private Graphics _graphics;
		private string _code;

		private static string _word = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		private static Random _random = new Random();

		public Captcha() : this(53, 22) { }
		public Captcha(int width, int height)
		{
			if (width <= 0 || height <= 0)
			{
				throw new ArgumentOutOfRangeException("_width或_height", "参数必须大于0");
			}
			_width = width;
			_height = height;
			_bitmap = new Bitmap(_width, _height);
			_graphics = Graphics.FromImage(_bitmap);
		}

		public int Width => _width;
		public int Height => _height;

		public void BitmapIsNotNull()
		{
			if (_bitmap == null)
			{
				throw new NullReferenceException("_bitmap为null");
			}
		}
		public void GraphicsIsNotNull()
		{
			if (_graphics == null)
			{
				throw new NullReferenceException("_graphics为null");
			}
		}
		public void CodeIsNotNull()
		{
			if (_code == null)
			{
				throw new NullReferenceException("_code为null");
			}
		}

		public static Color GetRandomColor()
		{
			return GetRandomColor(0, 255, 0, 255, 0, 255, 0, 255);
		}
		public static Color GetRandomColor(int minA, int maxA, int minR, int maxR, int minG, int maxG, int minB, int maxB)
		{
			return Color.FromArgb(_random.Next(minA, maxA),
				_random.Next(minR, maxR),
				_random.Next(minG, maxG),
				_random.Next(minB, maxB));
		}
		public Point GetRandomPoint()
		{
			return GetRandomPoint(0, _width, 0, _height);
		}
		public Point GetRandomPoint(int minX, int maxX, int minY, int maxY)
		{
			return new Point(_random.Next(minX, maxX), _random.Next(minY, maxY));
		}

		public static string GetRandomWord()
		{
			return _word.Substring(_random.Next(_word.Length - 1), 1);
		}

		public void SetBackgroundColor()
		{
			SetBackgroundColor(Captcha.GetRandomColor());
		}
		public void SetBackgroundColor(Color color)
		{
			GraphicsIsNotNull();

			_graphics.Clear(color);
		}

		public void DrawRandomLine()
		{
			DrawRandomLine(Captcha.GetRandomColor(), GetRandomPoint(), GetRandomPoint());
		}
		public void DrawRandomLine(Color color, Point start, Point end)
		{
			GraphicsIsNotNull();

			_graphics.DrawLine(new Pen(color), start, end);
		}

		
		public void DrawRandomWord(string s, string familyName, float size, Color color, PointF point)
		{
			GraphicsIsNotNull();

			_graphics.DrawString(s, new Font(familyName, size), new SolidBrush(color), point);
		}
		public void DrawRandomWords()
		{
			string[] strs = new string[4];
			for (int i = 0; i < 4; i++)
			{
				strs[i] = Captcha.GetRandomWord();
				float h = Math.Min((_width - 10) / 4, _height - 10);
				int x = 5 + (_width - 10) / 4 * i;
				DrawRandomWord(strs[i], "Verdana", h, 
					Captcha.GetRandomColor(255, 255, 0, 255, 0, 255, 0, 255), 
					GetRandomPoint(x, x, 5, 5));
			}
			_code = string.Join("", strs);
		}

		public bool VerifyCode(string input)
		{
			CodeIsNotNull();

			return _code == input;
		}


		public void DrawRandomPixel()
		{
			DrawRandomPixel(Captcha.GetRandomColor());
		}
		public void DrawRandomPixel(Color color)
		{
			BitmapIsNotNull();

			_bitmap.SetPixel(_random.Next(0, _width), _random.Next(0, _height), color);
		}

		public void ImageSave(string path)
		{
			BitmapIsNotNull();

			_bitmap.Save(path, ImageFormat.Jpeg);
		}




	}
}
