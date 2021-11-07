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
				Id = 1,
				Name = "王老师",
				Age = 50
			};
			lee = new Teacher
			{
				Id = 2,
				Name = "李老师",
				Age = 30

			};
			zhang = new Teacher
			{
				Id = 3,
				Name = "张老师",
				Age = 23
			};
			teachers = new List<Teacher> { wang, lee, zhang };

			Csharp = new Major()
			{
				Name = "C#",
				Teacher = wang,
				TeacherId = 1,
				TeacherAge = 50
			};
			SQL = new Major
			{
				Name = "SQL",
				Teacher = wang,
				TeacherId = 1,
				TeacherAge = 23
			};
			Javascript = new Major
			{
				Name = "Javascript",
				Teacher = wang,
				TeacherId = 1,
				TeacherAge = 50
			};
			UI = new Major
			{
				Name = "UI",
				Teacher = lee,
				TeacherId = 2,
				TeacherAge = 30
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
		public void LinqTest_001()
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

		[Test]
		public void LinqTest_002()
		{
			var innermt = from m in majors
						  join t in teachers
						  on m.TeacherId equals t.Id
						  where t.Name == "王老师"
						  select new
						  {
							  majorName = m.Name,
							  teacherName = t.Name
						  };
			foreach (var item in innermt)
			{
				Console.WriteLine(item.majorName + ":" + item.teacherName);
			}

			var crossmt = from m in majors
						  from t in teachers
						  select new
						  {
							  majorName = m.Name,
							  m.TeacherId,
							  t.Id,
							  teacherName = t.Name
						  };
			foreach (var item in crossmt)
			{
				Console.WriteLine($"{item.majorName}:{item.TeacherId}:{item.Id}:{item.teacherName}");
			}

			var TeacherMajor = from t in teachers
							   join m in majors
							   on t equals m.Teacher
							   into ms
							   from m in ms.DefaultIfEmpty()
							   select new
							   {
								   t.Id,
								   teacherName = t.Name,
								   majorName = m?.Name ?? "没有课程"
							   };
			foreach (var item in TeacherMajor)
			{
				Console.WriteLine($"{item.Id}:{item.teacherName}:{item.majorName}");
			}

			var teacherAgeMajor = from t in teachers
								  join m in majors
								  on new
								  {
									  TeacherId = t.Id,
									  TeacherAge = t.Age
								  }
								  equals new
								  {
									  m.TeacherId,
									  m.TeacherAge
								  }
								  select new
								  {
									  t.Id,
									  t.Name,
									  t.Age,
									  majorName = m.Name
								  };
			foreach (var item in teacherAgeMajor)
			{
				Console.WriteLine($"编号为{item.Id}的{item.Name}（{item.Age}岁）教“{item.majorName}”课");
			}

			var studentMajor = from s in students
							   let ms = s.Majors
							   from m in ms
							   select new
							   {
								   s.Name,
								   Major = m.Name
							   };
			foreach (var item in studentMajor)
			{
				Console.WriteLine(item.Name + ":" + item.Major);
			}

			var crosssm = from s in students
						  from m in majors
						  where s.Majors.Contains(m)
						  select new
						  {
							  s.Name,
							  Major = m.Name 
						  };
			foreach (var item in crosssm)
			{
				Console.WriteLine(item.Name + ":::" + item.Major);
			}

		}



	}
}
