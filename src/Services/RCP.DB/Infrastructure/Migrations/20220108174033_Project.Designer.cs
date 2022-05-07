﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RCP.DB.Infrastructure;

namespace RCP.DB.Infrastructure.Migrations
{
    [DbContext(typeof(RcpContext))]
    [Migration("20220108174033_Project")]
    partial class Project
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.HasSequence("jenkins_job_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("programmer_working_time_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("project_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("RCP.DB.Model.JenkinsJob", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "jenkins_job_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BuildNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("BuildTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Culprit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("EstimatedDuration")
                        .HasColumnType("int");

                    b.Property<string>("JobName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("JenkinsJob");
                });

            modelBuilder.Entity("RCP.DB.Model.ProgrammerWorkingTime", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "programmer_working_time_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<string>("ProgrammerLogin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<double>("Time")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProgrammerWorkingTime");
                });

            modelBuilder.Entity("RCP.DB.Model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:HiLoSequenceName", "project_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("RCP.DB.Model.JenkinsJob", b =>
                {
                    b.HasOne("RCP.DB.Model.Project", "Project")
                        .WithMany("JenkinsJobs")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("RCP.DB.Model.ProgrammerWorkingTime", b =>
                {
                    b.HasOne("RCP.DB.Model.Project", "Project")
                        .WithMany("ProgrammersWorkingTime")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("RCP.DB.Model.Project", b =>
                {
                    b.Navigation("JenkinsJobs");

                    b.Navigation("ProgrammersWorkingTime");
                });
#pragma warning restore 612, 618
        }
    }
}