using System;
using System.Collections.Generic;
using System.Data.Entity;
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
			#region capcha

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

			//CaptchaService cs = new CaptchaService(300);
			//cs.CreateCaptcha(@"E:\echo\zero\adn\test\testing\hello.jpg");
			//cs.VerifyInput();

			#endregion

			EfDbContext context = new EfDbContext();

			//var db = context.Database;
			//db.Delete();
			//db.Create();

			//context.Database.Delete();
			//context.Database.Create();

			//context.Students.Add(new Student() { Id = Guid.NewGuid(), Name = "leo" });
			//context.Teachers.Add(new Teacher() { Id = Guid.NewGuid(), Name = "tee" });
			//context.SaveChanges();

			//Person person = context.Persons.Where(p => p.Name == "leo").SingleOrDefault();
			//Console.WriteLine(person.Id);

			//Student student = context.Students.Where(s => s.Name == "leo").SingleOrDefault();
			//Console.WriteLine(student.Id);

			//Student student = context.Students.Find(1);

			//string sql = @"SELECT * FROM Students WHERE Id = @p0";
			//Student student = context.Students
			//	.SqlQuery(sql, 1).SingleOrDefault();

			//Console.WriteLine(student.Name);

			//Bed bed = context.Set<Bed>()
			//	.Where(b => b.Location == "").SingleOrDefault();

			Teacher teacher = context.Set<Teacher>()
				.Include(t => t.Students
					.Select(s => s.Bed))
				.Where(t => t.Name == "tee").SingleOrDefault();

			Console.Read();
		}
	}
}
