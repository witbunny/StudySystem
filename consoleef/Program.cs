using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace consoleef
{
	class Program
	{
		static void Main(string[] args)
		{
			EfDbContext context = new EfDbContext();

			//var db = context.Database;
			//db.EnsureDeleted();
			//db.EnsureCreated();

			//context.AddRange(
			//	new Person() { Name = "leo" },
			//	new Student() { Name = "tik", Score = 99, Major = "ss" },
			//	new Teacher() { Name = "suz", Salary = 1000, Major = "tt" }
			//);

			//context.Add(
			//	new Student()
			//	{
			//		Name = "huk",
			//		Bed = new Bed() { Location = "8818" }
			//	}
			//);

			//context.Add(
			//	new Teacher()
			//	{
			//		Name = "tee",
			//		Students = new List<Student>()
			//		{
			//			new Student() { Name = "leo" },
			//			new Student() { Name = "suz" }
			//		}
			//	}
			//);

			//Student leo = new Student() { Name = "leo" };
			//Student huk = new Student() { Name = "huk" };
			//Student suz = new Student() { Name = "suz" };
			//Student pio = new Student() { Name = "pio" };

			//Teacher tee = new Teacher() { Name = "tee" };
			//Teacher mee = new Teacher() { Name = "mee" };

			//tee.Students = new List<Student>() { leo, huk, suz, pio };
			//mee.Students = new List<Student>() { leo, huk, suz, pio };
			////leo.Teachers = new List<Teacher> { tee, mee };
			////huk.Teachers = new List<Teacher> { tee, mee };
			////suz.Teachers = new List<Teacher> { tee, mee };
			////pio.Teachers = new List<Teacher> { tee, mee };

			//Classroom csharp = new Classroom() { Name = "csharp" };
			//Classroom sql = new Classroom() { Name = "sql" };

			//csharp.Students = new List<Student> { leo, suz };
			//sql.Students = new List<Student> { huk, pio };

			//Bed big = new Bed { Location = "big" };
			//Bed duo = new Bed { Location = "duo" };

			//leo.Bed = big;
			//suz.Bed = duo;

			//context.AddRange(/*leo, huk, suz, pio,*/ tee, mee);
			//context.AddRange(csharp, sql);

			//context.SaveChanges();

			//Student student = context.Students.Where(s => s.Name == "tik").SingleOrDefault();
			//Person person = context.Persons.Where(t => t.Name == "suz").SingleOrDefault();


			//Bed bed = new Bed();
			//Student leo = new Student { Name = "leo", Bed = bed };
			//EfDbContext context1 = new EfDbContext();
			//context1.Add(leo);
			//context1.SaveChanges();

			//bed = context.Find<Bed>(bed.Id);
			//Student suz = new Student { Name = "suz", Bed = bed };
			//context.Add(suz);
			//context.SaveChanges();


			//Student s2 = context.Students
			//	.Include(s => s.Bed)
			//	.Where(s => s.Id == 2).SingleOrDefault();

			//Teacher tee = context.Teachers
			//	.Include(t => t.Students)
			//		.ThenInclude(s => s.Bed)
			//	.Where(t => t.Name == "tee").SingleOrDefault();

			//Student leo = context.Students
			//	.Where(s => s.Name == "leo").SingleOrDefault();
			//var entry = context.Entry(leo);
			//entry.Collection(s => s.Teachers).Load();
			//entry.Reference(s => s.Bed).Load();

			//Student leo = context.Students
			//	.Where(s => s.Name == "leo").SingleOrDefault();
			////Console.WriteLine(leo.Bed.Location);

			//foreach (var item in leo.Teachers)
			//{
			//	Console.WriteLine(item.Name);
			//}


			//Classroom c1 = context.Classrooms
			//	.Include(c => c.Students.Where(s => s.Name.Contains("l")))
			//	.Where(c => c.Id == 1).SingleOrDefault();

			////context.Entry(c1)
			////	.Collection(c => c.Students)
			////		.Query().Where(s => s.Name.Contains("l"))
			////	.Load();

			//foreach (var item in c1.Students)
			//{
			//	Console.WriteLine(item.Name);
			//}


			//foreach (var room in context.Classrooms
			//	.Include(c => c.Students)
			//	.ToList())
			//{
			//	Console.WriteLine(room.Name);
			//	foreach (var student in room.Students)
			//	{
			//		Console.WriteLine($"    {student.Name}");
			//	}
			//}


			//Classroom c2 = context.Classrooms.Find(2);
			//context.Entry(c2).Collection(c => c.Students).Load();
			//context.Remove(c2);
			//context.SaveChanges();

			//Student student = context.Students
			//	.Include(s => s.Teachers)	//加--EF删除，不加--数据库删除
			//	.Where(s => s.Name == "huk").SingleOrDefault();
			//context.Remove(student);
			//context.SaveChanges();

			//Bed b2 = context.Find<Bed>(2);
			//context.Entry(b2).Reference(b => b.Student).Load();
			//context.Remove(b2);
			//context.SaveChanges();


			//Student leo = context.Students.Find(2);

			//////leo.Teachers = null;
			////leo.Teachers.Remove(context.Teachers.Find(1));

			//context.Entry(leo).Reference(s => s.Classroom).Load();
			//leo.Classroom = null;


			//IList<Student> students = context.Students
			//	.Where(s => s.Id < 5).ToList();

			//Classroom c2 = context.Classrooms.Find(2);
			//c2.Students.Clear();	//加载Students，并不清空再加，根据跟踪判断如何执行；若无该语句，一对多，必然执行update
			//c2.Students = students;

			////Teacher mee = context.Teachers.Find(6);
			////mee.Students.Clear();	//加载Students，并不清空再加，根据跟踪判断如何执行；若无该语句，多对多，必然执行insert
			////mee.Students = students;

			//context.SaveChanges();



			Console.Read();
		}
	}
}
