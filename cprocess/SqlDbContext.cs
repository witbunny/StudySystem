//#define PUBLISH

using cprocess.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	class SqlDbContext : DbContext
	{
		public DbSet<EfStudent> Students { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string connectionStr = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ssmsDemo;User ID=sa;Password=0117;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

			optionsBuilder
				.UseSqlServer(connectionStr)
#if PUBLISH
				.EnableSensitiveDataLogging()
#elif DEBUG
				.EnableSensitiveDataLogging()
#else
				.EnableSensitiveDataLogging(false)
#endif
				//.UseLoggerFactory(new LoggerFactory(new ILoggerProvider[] { 
				//	new DebugLoggerProvider(),
				//	//new ConsoleLoggerProvider()
				//}))
				.LogTo(
					(id, level) => level == LogLevel.Debug,
					data => Console.WriteLine(data)
				)
				;

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<EfStudent>()
				.ToTable("EF_Student")
				.HasCheckConstraint("CK_Age", "Age BETWEEN 0 AND 150")
				//.HasKey(s => s.Name)
				//.HasKey(s => new { s.Id, s.Name})
				.HasIndex(s => s.Name).IsUnique()
				;

			modelBuilder.Entity<EfStudent>()
				.Property(s => s.Name)
				.HasMaxLength(128)
				.IsRequired()
				.HasColumnName("StudentName");

			modelBuilder.Entity<EfStudent>()
				.Property(s => s.Oncall)
				.HasColumnType("NVARCHAR(50)");

			//modelBuilder.Entity<EfStudent>(s =>
			//{
			//	s.ToTable("");
			//	s.Property(s => s.Name)
			//	.HasMaxLength(128)
			//	.IsRequired();
			//	s.Property(s => s.Oncall)
			//	.HasMaxLength(100);
			//}).Entity<EfMajor>(m =>
			//{
				
			//});

			modelBuilder.Entity<EfMajor>()
				//.Ignore(m => m.Difficulty)
				//.Ignore(m => m.Teacher)
				;

			base.OnModelCreating(modelBuilder);
		}
	}
}
