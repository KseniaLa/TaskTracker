﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskMicroservice.DataAccess;

namespace TaskTracker.DataAccess.Migrations
{
    [DbContext(typeof(TaskTrackerContext))]
    [Migration("20200119125540_DeleteWidgets")]
    partial class DeleteWidgets
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskTracker.DataAccess.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Priority");

                    b.Property<int>("State");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Tasks");

                    b.HasData(
                        new { Id = 1, DateTime = new DateTime(2020, 1, 19, 15, 55, 39, 674, DateTimeKind.Local), Description = "Test task description", Priority = 0, State = 0, Title = "Test task" },
                        new { Id = 2, DateTime = new DateTime(2020, 1, 19, 15, 55, 39, 676, DateTimeKind.Local), Description = "description", Priority = 1, State = 1, Title = "Hello task" },
                        new { Id = 3, DateTime = new DateTime(2020, 1, 19, 15, 55, 39, 676, DateTimeKind.Local), Description = "task description", Priority = 3, State = 1, Title = "Critical task" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
