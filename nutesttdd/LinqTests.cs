using cprocess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nutesttdd
{
	class LinqTests
	{
		Teacher wang, lee, zhang;
		IEnumerable<Teacher> teachers;
		Major Csharp, SQL, Javascript, UI;
		IEnumerable<Major> majors;
		Student jin, mu, shui, huo, tu;
		IEnumerable<Student> students;

		[SetUp]
		public void LinqInit()
		{
			wang = new Teacher()
			{
				Name = "王老师"
			};
			lee = new Teacher
			{
				Name = "李老师"
			};
			zhang = new Teacher
			{
				Name = "张老师"
			};
			teachers = new List<Teacher> { wang, lee, zhang };

			Csharp = new Major()
			{
				Name = "C#",
				Teacher = wang
			};
			SQL = new Major
			{
				Name = "SQL",
				Teacher = wang
			};
			Javascript = new Major
			{
				Name = "Javascript",
				Teacher = wang
			};
			UI = new Major
			{
				Name = "UI",
				Teacher = lee
			};
			majors = new List<Major> { Csharp, SQL, Javascript, UI };

			jin = new Student
			{
				Name = "jin",
				Score = 99,
				Majors = new List<Major> { Csharp, SQL }
			};
			mu = new Student
			{
				Name = "mu",
				Score = 96,
				Majors = new List<Major> { Javascript, Csharp, SQL }
			};
			shui = new Student
			{
				Name = "shui",
				Score = 78,
				Majors = new List<Major> { Csharp }
			};
			huo = new Student
			{
				Name = "huo",
				Score = 85,
				Majors = new List<Major> { Javascript, Csharp, SQL, UI }
			};
			tu = new Student
			{
				Name = "tu",
				Score = 98,
				Majors = new List<Major> { Javascript, Csharp }
			};
			students = new List<Student> { jin, mu, shui, huo, tu };
		}

		[Test]
		public void LinqTest()
		{
			var excellent = from s in students
							where s.Score > 90
							orderby s.Score descending
							select s;
			foreach (var item in excellent)
			{
				Console.WriteLine(item.Name + ":" + item.Score);
			}

			var groupedMajor = from m in majors
							   group m by m.Teacher;
			foreach (var item in groupedMajor)
			{
				Console.WriteLine(item.Key.GetType() + ":" + item.Key.Name);
				foreach (var i in item)
				{
					Console.WriteLine(i.GetType() + ":" + i.Name);
				}
			}

			var shadow = from s in students
						 select new
						 {
							 s.Name,
							 s.Score
						 };
			foreach (var item in shadow)
			{
				Console.WriteLine(item.Name + ":" + item.Score);
			}

			var statistics = from m in majors
							 group m by m.Teacher
							 into g
							 select new
							 {
								 g.Key.Name,
								 Count = g.Count()
							 };
			foreach (var item in statistics)
			{
				Console.WriteLine(item.Name + ":" + item.Count);
			}

			var dic = statistics.ToDictionary(s => s.Name, s => s.Count);
			foreach (var item in dic)
			{
				Console.WriteLine(item.Key + ":" + item.Value);
			}
		}
	}
}
