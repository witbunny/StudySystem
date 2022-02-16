using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Text;

namespace consoleef
{
	class EfDbContext : DbContext
	{
		public DbSet<Classroom> Classrooms { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Person> Persons { get; set; }
		//public DbSet<Entity> Entities { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionstr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ssmsEF;User ID=sa;Password=0117;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

			optionsBuilder
				.UseSqlServer(connectionstr)
				.UseLazyLoadingProxies()
				.EnableSensitiveDataLogging()
				.UseLoggerFactory(new LoggerFactory(new ILoggerProvider[] { 
					new DebugLoggerProvider()
				}));

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Student>()
			//	//.HasBaseType<Person>()
			//	//.HasBaseType((Type)null)
			//	.Property(s => s.Major)
			//	.HasColumnName("Major")
			//	;

			//modelBuilder.Entity<Teacher>()
			//	//.HasBaseType((Type)null)
			//	.Property(t => t.Major)
			//	.HasColumnName("Major")
			//	;

			modelBuilder.Entity<Student>(s =>
			{
				s.ToTable("Students");
			}).Entity<Teacher>(t =>
			{
				t.ToTable("Teachers");
			});

			modelBuilder.Entity<Student>()
				.HasOne<Bed>(s => s.Bed)
				.WithOne(b => b.Student)
				.HasForeignKey<Student>(s => s.BedId)
				.OnDelete(DeleteBehavior.SetNull)
				;

			base.OnModelCreating(modelBuilder);
		}
	}
}
