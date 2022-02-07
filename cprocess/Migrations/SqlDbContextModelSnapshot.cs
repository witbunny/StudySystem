﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cprocess;

namespace cprocess.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    partial class SqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("cprocess.EF.EfMajor", b =>
                {
                    b.Property<int>("EfMajorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MajorId")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("EfMajorId");

                    b.HasIndex("TeacherId");

                    b.ToTable("EF_Major");
                });

            modelBuilder.Entity("cprocess.EF.EfStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Enroll")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsFemale")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)")
                        .HasColumnName("StudentName");

                    b.Property<string>("Oncall")
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("EF_Student");

                    b.HasCheckConstraint("CK_Age", "Age BETWEEN 0 AND 150");
                });

            modelBuilder.Entity("cprocess.EF.EfTeacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EF_Teacher");
                });

            modelBuilder.Entity("cprocess.EF.EfMajor", b =>
                {
                    b.HasOne("cprocess.EF.EfTeacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
