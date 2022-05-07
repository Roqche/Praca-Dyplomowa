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
    [Migration("20210806170419_ProgrammerWorkingTimeInitial")]
    partial class ProgrammerWorkingTimeInitial
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("EstimatedDuration")
                        .HasColumnType("int");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Time")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ProgrammerWorkingTime");
                });
#pragma warning restore 612, 618
        }
    }
}
