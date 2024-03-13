﻿// <auto-generated />
using MUC_School;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MUC_School.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MUC_School.Models.ClassName", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Division")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Standard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClassNames");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Division = "A",
                            Standard = "6th"
                        },
                        new
                        {
                            Id = 2,
                            Division = "B",
                            Standard = "7th"
                        },
                        new
                        {
                            Id = 3,
                            Division = "C",
                            Standard = "8th"
                        },
                        new
                        {
                            Id = 4,
                            Division = "B",
                            Standard = "9th"
                        });
                });

            modelBuilder.Entity("MUC_School.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClassNameId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rollnumber")
                        .HasColumnType("float");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassNameId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MUC_School.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TeacherId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TeacherId = "13264521",
                            TeacherName = "Ali"
                        },
                        new
                        {
                            Id = 2,
                            TeacherId = "1345201",
                            TeacherName = "Abuzar"
                        },
                        new
                        {
                            Id = 3,
                            TeacherId = "13464120",
                            TeacherName = "Abdul"
                        });
                });

            modelBuilder.Entity("MUC_School.Models.Student", b =>
                {
                    b.HasOne("MUC_School.Models.ClassName", "ClassName")
                        .WithMany()
                        .HasForeignKey("ClassNameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MUC_School.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassName");

                    b.Navigation("Teacher");
                });
#pragma warning restore 612, 618
        }
    }
}
