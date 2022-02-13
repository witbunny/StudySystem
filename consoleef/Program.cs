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

			var db = context.Database;
			db.EnsureDeleted();
			db.EnsureCreated();

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

			//context.AddRange(/*leo, huk, suz, pio,*/ tee, mee);

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



			Console.Read();
		}
	}
}
