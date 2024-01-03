﻿// <auto-generated />
using System;
using EF_Exploration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_Exploration.Data.Migrations
{
    [DbContext(typeof(NFLDbContext))]
    partial class NFLDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF_Exploration.Domain.CoachModels.AssistantCoach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("AssistantCoaches");
                });

            modelBuilder.Entity("EF_Exploration.Domain.CoachModels.HeadCoach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique()
                        .HasFilter("[TeamId] IS NOT NULL");

                    b.ToTable("HeadCoaches");
                });

            modelBuilder.Entity("EF_Exploration.Domain.Conference", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Conferences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "American Football Conference"
                        },
                        new
                        {
                            Id = 2,
                            Name = "National Football Conference"
                        });
                });

            modelBuilder.Entity("EF_Exploration.Domain.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ConferenceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConferenceId");

                    b.ToTable("Divisions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConferenceId = 1,
                            Name = "AFC EAST"
                        },
                        new
                        {
                            Id = 2,
                            ConferenceId = 1,
                            Name = "AFC North"
                        },
                        new
                        {
                            Id = 3,
                            ConferenceId = 1,
                            Name = "AFC SOUTH"
                        },
                        new
                        {
                            Id = 4,
                            ConferenceId = 1,
                            Name = "AFC WEST"
                        },
                        new
                        {
                            Id = 5,
                            ConferenceId = 2,
                            Name = "NFC EAST"
                        },
                        new
                        {
                            Id = 6,
                            ConferenceId = 2,
                            Name = "NFC NORTH"
                        },
                        new
                        {
                            Id = 7,
                            ConferenceId = 2,
                            Name = "NFC SOUTH"
                        },
                        new
                        {
                            Id = 8,
                            ConferenceId = 2,
                            Name = "NFC WEST"
                        });
                });

            modelBuilder.Entity("EF_Exploration.Domain.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EF_Exploration.Domain.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DivisionId")
                        .HasColumnType("int");

                    b.Property<int>("HeadCoachId")
                        .HasColumnType("int");

                    b.Property<string>("HomeRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Losses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PercentWins")
                        .HasColumnType("float");

                    b.Property<string>("RoadRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ties")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DivisionId = 1,
                            HeadCoachId = 0,
                            HomeRecord = "7-1-0",
                            Losses = 5,
                            Name = "Miami Dolphins",
                            PercentWins = 0.0,
                            RoadRecord = "4-4-0",
                            Ties = 0,
                            Wins = 11
                        },
                        new
                        {
                            Id = 2,
                            DivisionId = 1,
                            HeadCoachId = 0,
                            HomeRecord = "7-2-0",
                            Losses = 6,
                            Name = "Buffalo Bills",
                            PercentWins = 0.0,
                            RoadRecord = "3-4-0",
                            Ties = 0,
                            Wins = 10
                        },
                        new
                        {
                            Id = 3,
                            DivisionId = 1,
                            HeadCoachId = 0,
                            HomeRecord = "4-5-0",
                            Losses = 10,
                            Name = "New York Jets",
                            PercentWins = 0.0,
                            RoadRecord = "2-5-0",
                            Ties = 0,
                            Wins = 6
                        },
                        new
                        {
                            Id = 4,
                            DivisionId = 1,
                            HeadCoachId = 0,
                            HomeRecord = "1-7-0",
                            Losses = 12,
                            Name = "New England Patriots",
                            PercentWins = 0.0,
                            RoadRecord = "3-5-0",
                            Ties = 0,
                            Wins = 4
                        },
                        new
                        {
                            Id = 5,
                            DivisionId = 2,
                            HeadCoachId = 0,
                            HomeRecord = "6-2-0",
                            Losses = 3,
                            Name = "Baltimore Ravens",
                            PercentWins = 0.0,
                            RoadRecord = "7-1-0",
                            Ties = 0,
                            Wins = 13
                        },
                        new
                        {
                            Id = 6,
                            DivisionId = 2,
                            HeadCoachId = 0,
                            HomeRecord = "8-1-0",
                            Losses = 5,
                            Name = "Cleveland Browns",
                            PercentWins = 0.0,
                            RoadRecord = "3-4-0",
                            Ties = 0,
                            Wins = 11
                        },
                        new
                        {
                            Id = 7,
                            DivisionId = 2,
                            HeadCoachId = 0,
                            HomeRecord = "5-4-0",
                            Losses = 7,
                            Name = "Pittsburgh Steelers",
                            PercentWins = 0.0,
                            RoadRecord = "4-3-0",
                            Ties = 0,
                            Wins = 9
                        },
                        new
                        {
                            Id = 8,
                            DivisionId = 2,
                            HeadCoachId = 0,
                            HomeRecord = "5-3-0",
                            Losses = 8,
                            Name = "Cincinnati Bengals",
                            PercentWins = 0.0,
                            RoadRecord = "3-5-0",
                            Ties = 0,
                            Wins = 8
                        });
                });

            modelBuilder.Entity("EF_Exploration.Domain.CoachModels.AssistantCoach", b =>
                {
                    b.HasOne("EF_Exploration.Domain.Team", "Team")
                        .WithMany("AssistantCoaches")
                        .HasForeignKey("TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EF_Exploration.Domain.CoachModels.HeadCoach", b =>
                {
                    b.HasOne("EF_Exploration.Domain.Team", "Team")
                        .WithOne("HeadCoach")
                        .HasForeignKey("EF_Exploration.Domain.CoachModels.HeadCoach", "TeamId");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EF_Exploration.Domain.Division", b =>
                {
                    b.HasOne("EF_Exploration.Domain.Conference", "Conference")
                        .WithMany("Divisions")
                        .HasForeignKey("ConferenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conference");
                });

            modelBuilder.Entity("EF_Exploration.Domain.Player", b =>
                {
                    b.HasOne("EF_Exploration.Domain.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EF_Exploration.Domain.Team", b =>
                {
                    b.HasOne("EF_Exploration.Domain.Division", "Division")
                        .WithMany("Teams")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");
                });

            modelBuilder.Entity("EF_Exploration.Domain.Conference", b =>
                {
                    b.Navigation("Divisions");
                });

            modelBuilder.Entity("EF_Exploration.Domain.Division", b =>
                {
                    b.Navigation("Teams");
                });

            modelBuilder.Entity("EF_Exploration.Domain.Team", b =>
                {
                    b.Navigation("AssistantCoaches");

                    b.Navigation("HeadCoach")
                        .IsRequired();

                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
