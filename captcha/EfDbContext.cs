using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace captcha
{
	class EfDbContext : DbContext
	{
		public EfDbContext()
			: base("ssef")
		{
			//Database.Log = Console.WriteLine;
			//Database.Log = s => Console.Write(s);
			//Database.Log = s => Debug.Write(s);
			//Database.Log = s => File.AppendAllText(@"E:\echo\zero\adn\adnWork\StudySystem\captcha\ef.log", s);
			Database.Log = s =>
			{
				Console.Write(s);
				Debug.Write(s);
				File.AppendAllText(@"E:\echo\zero\adn\adnWork\StudySystem\captcha\ef.log", s);
			};
		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Person> Persons { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Student>()
			//	.Property(s => s.Name).HasMaxLength(50)
			//	;

			//modelBuilder.Entity<Student>()
			//	.Property(s => s.Score).IsOptional()
			//	;

			//modelBuilder.Entity<Student>()
			//	.HasIndex(s => s.Score).IsUnique()
			//	;

			//modelBuilder.Entity<Student>().Map(m =>
			//{
			//	m.Property(s => s.Name);
			//	m.Property(s => s.Score);
			//});

			//modelBuilder.Entity<Person>().ToTable("Persons");
			//modelBuilder.Entity<Student>().ToTable("Students");
			//modelBuilder.Entity<Teacher>().ToTable("Teachers");

			modelBuilder.Entity<Student>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Students");
			});
			modelBuilder.Entity<Teacher>().Map(m =>
			{
				m.MapInheritedProperties();
				m.ToTable("Teachers");
			});

			//modelBuilder.Entity<Student>()
			//	//.HasRequired(s => s.Bed)
			//	//.WithRequiredDependent()
			//	.HasOptional(s => s.Bed)
			//	.WithOptionalDependent()
			//	;

			base.OnModelCreating(modelBuilder);
		}
	}
}
