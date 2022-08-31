﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stroom.Server.Contexts;

#nullable disable

namespace Stroom.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220831140514_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectDtoUser", b =>
                {
                    b.Property<int>("AssignedUsersUserID")
                        .HasColumnType("int");

                    b.Property<int>("ProjectsProjectID")
                        .HasColumnType("int");

                    b.HasKey("AssignedUsersUserID", "ProjectsProjectID");

                    b.HasIndex("ProjectsProjectID");

                    b.ToTable("ProjectDtoUser");
                });

            modelBuilder.Entity("Stroom.Shared.Models.CommentDto", b =>
                {
                    b.Property<int?>("TaskID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("CommentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime");

                    b.HasKey("TaskID", "UserID")
                        .HasName("Comment_PK");

                    b.HasIndex("UserID");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("Stroom.Shared.Models.ProjectDto", b =>
                {
                    b.Property<int>("ProjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ProjectID")
                        .HasName("Project_PK");

                    b.ToTable("Project", (string)null);
                });

            modelBuilder.Entity("Stroom.Shared.Models.TaskDto", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskID"), 1L, 1);

                    b.Property<int>("AssigneeUserID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<DateTime?>("DueDate")
                        .HasColumnType("datetime");

                    b.Property<float>("EstimatedTime")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectID")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("SubmitionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TaskID")
                        .HasName("Task_PK");

                    b.HasIndex("AssigneeUserID");

                    b.HasIndex("ProjectID");

                    b.ToTable("Task", (string)null);
                });

            modelBuilder.Entity("Stroom.Shared.Models.TimeEntry", b =>
                {
                    b.Property<int>("TimeEntryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeEntryID"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime");

                    b.Property<float>("Hours")
                        .HasColumnType("real");

                    b.Property<int?>("TaskID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("TimeEntryID")
                        .HasName("TimeEntry_PK");

                    b.HasIndex("TaskID");

                    b.HasIndex("UserID");

                    b.ToTable("TimeEntry", (string)null);
                });

            modelBuilder.Entity("Stroom.Shared.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("ProjectDtoUser", b =>
                {
                    b.HasOne("Stroom.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("AssignedUsersUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stroom.Shared.Models.ProjectDto", null)
                        .WithMany()
                        .HasForeignKey("ProjectsProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Stroom.Shared.Models.CommentDto", b =>
                {
                    b.HasOne("Stroom.Shared.Models.TaskDto", "Task")
                        .WithMany("Comments")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Stroom.Shared.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Stroom.Shared.Models.TaskDto", b =>
                {
                    b.HasOne("Stroom.Shared.Models.User", "Assignee")
                        .WithMany("Tasks")
                        .HasForeignKey("AssigneeUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stroom.Shared.Models.ProjectDto", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Stroom.Shared.Models.TimeEntry", b =>
                {
                    b.HasOne("Stroom.Shared.Models.TaskDto", "Task")
                        .WithMany("TimeEntries")
                        .HasForeignKey("TaskID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Stroom.Shared.Models.User", "User")
                        .WithMany("TimeEntries")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Stroom.Shared.Models.ProjectDto", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Stroom.Shared.Models.TaskDto", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("TimeEntries");
                });

            modelBuilder.Entity("Stroom.Shared.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Tasks");

                    b.Navigation("TimeEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
