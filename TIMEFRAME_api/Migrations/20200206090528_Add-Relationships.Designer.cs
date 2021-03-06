﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TIMEFRAME_api.Data;

namespace TIMEFRAME_api.Migrations
{
    [DbContext(typeof(TimeframeContext))]
    [Migration("20200206090528_Add-Relationships")]
    partial class AddRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TIMEFRAME_api.MODELS.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TIMEFRAME_api.MODELS.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("TIMEFRAME_api.MODELS.TaskEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<int?>("ProjectId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("TaskEntry");
                });

            modelBuilder.Entity("TIMEFRAME_api.MODELS.TimeEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("Date");

                    b.Property<DateTime>("Start");

                    b.Property<DateTime>("Stop");

                    b.Property<int?>("TaskEntryId");

                    b.HasKey("Id");

                    b.HasIndex("TaskEntryId");

                    b.ToTable("TimeEntry");
                });

            modelBuilder.Entity("TIMEFRAME_api.MODELS.Project", b =>
                {
                    b.HasOne("TIMEFRAME_api.MODELS.Customer", "Customer")
                        .WithMany("Projects")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("TIMEFRAME_api.MODELS.TaskEntry", b =>
                {
                    b.HasOne("TIMEFRAME_api.MODELS.Project", "Project")
                        .WithMany("TaskEntries")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("TIMEFRAME_api.MODELS.TimeEntry", b =>
                {
                    b.HasOne("TIMEFRAME_api.MODELS.TaskEntry", "TaskEntry")
                        .WithMany("TimeEntries")
                        .HasForeignKey("TaskEntryId");
                });
#pragma warning restore 612, 618
        }
    }
}
