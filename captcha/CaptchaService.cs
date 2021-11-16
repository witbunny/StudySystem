using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace captcha
{
	public class CaptchaService
	{
		private Captcha _captcha;

		public CaptchaService()
		{
			_captcha = new Captcha();
		}
		public CaptchaService(int size)
		{
			_captcha = new Captcha(size, size / 2);
		}

		public void CreateCaptcha(string path)
		{
			_captcha.SetBackgroundColor(Captcha.GetRandomColor(255, 255, 255, 255, 255, 255, 255, 255));

			for (int i = 0; i < _captcha.Width / 10; i++)
			{
				_captcha.DrawRandomLine();
			}

			_captcha.DrawRandomWords();

			for (int i = 0; i < _captcha.Width; i++)
			{
				_captcha.DrawRandomPixel();
			}

			_captcha.ImageSave(path);
		}
		public void VerifyInput()
		{
			Console.WriteLine("请输入验证码：");
			string inputCode = Console.ReadLine();
			Console.WriteLine("您的验证码：");
			Console.WriteLine(_captcha.VerifyCode(inputCode));
		}
	}
}
