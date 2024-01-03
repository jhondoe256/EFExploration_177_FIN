using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EF_Exploration.Domain;
using EF_Exploration.Domain.CoachModels;
namespace EF_Exploration.Data
{
    public class NFLDbContext : DbContext
    {
        public NFLDbContext() { }

        //! We are settnig this up for demo purposes only!!!!
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //! We are settnig this up for demo purposes only!!!!
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder
            .UseSqlServer("Server=127.0.0.1;Database=NFL_EF_Exploration01;User Id=SA;Password=teachEFA@317;Trust Server Certificate=true;")
            .LogTo(Console.WriteLine, LogLevel.Information) // we want the console to log out all of the information
            .EnableSensitiveDataLogging() //Eduational usage only can show things that need to be hidden
            .EnableDetailedErrors(); //Eduational usage only
        }

        public DbSet<Conference> Conferences { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<AssistantCoach> AssistantCoaches { get; set; }
        public DbSet<HeadCoach> HeadCoaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conference>().HasData(
                new Conference
                {
                    Id = 1,
                    Name = "American Football Conference"
                },
                new Conference
                {
                    Id = 2,
                    Name = "National Football Conference"
                }
            );

            modelBuilder.Entity<Division>().HasData(
                new Division()
                {
                    Id = 1,
                    Name = "AFC EAST",
                    ConferenceId = 1
                },
                new Division()
                {
                    Id = 2,
                    Name = "AFC North",
                    ConferenceId = 1
                },
                new Division()
                {
                    Id = 3,
                    Name = "AFC SOUTH",
                    ConferenceId = 1
                },
                new Division()
                {
                    Id = 4,
                    Name = "AFC WEST",
                    ConferenceId = 1
                },
                 new Division()
                 {
                     Id = 5,
                     Name = "NFC EAST",
                     ConferenceId = 2
                 },
                 new Division()
                 {
                     Id = 6,
                     Name = "NFC NORTH",
                     ConferenceId = 2
                 },
                new Division()
                {
                    Id = 7,
                    Name = "NFC SOUTH",
                    ConferenceId = 2
                },
                new Division()
                {
                    Id = 8,
                    Name = "NFC WEST",
                    ConferenceId = 2
                }
            );

            modelBuilder.Entity<Team>().HasData(
                new Team()
                {
                    Id = 1,
                    Name = "Miami Dolphins",
                    Wins = 11,
                    Losses = 5,
                    Ties = 0,
                    HomeRecord = "7-1-0",
                    RoadRecord = "4-4-0",
                    DivisionId = 1
                },
                new Team()
                {
                    Id = 2,
                    Name = "Buffalo Bills",
                    Wins = 10,
                    Losses = 6,
                    Ties = 0,
                    HomeRecord = "7-2-0",
                    RoadRecord = "3-4-0",
                    DivisionId = 1
                },
                new Team()
                {
                    Id = 3,
                    Name = "New York Jets",
                    Wins = 6,
                    Losses = 10,
                    Ties = 0,
                    HomeRecord = "4-5-0",
                    RoadRecord = "2-5-0",
                    DivisionId = 1
                },
                new Team()
                {
                    Id = 4,
                    Name = "New England Patriots",
                    Wins = 4,
                    Losses = 12,
                    Ties = 0,
                    HomeRecord = "1-7-0",
                    RoadRecord = "3-5-0",
                    DivisionId = 1
                },
                new Team()
                {
                    Id = 5,
                    Name = "Baltimore Ravens",
                    Wins = 13,
                    Losses = 3,
                    Ties = 0,
                    HomeRecord = "6-2-0",
                    RoadRecord = "7-1-0",
                    DivisionId = 2
                },
                new Team()
                {
                    Id = 6,
                    Name = "Cleveland Browns",
                    Wins = 11,
                    Losses = 5,
                    Ties = 0,
                    HomeRecord = "8-1-0",
                    RoadRecord = "3-4-0",
                    DivisionId = 2
                },
                new Team()
                {
                    Id = 7,
                    Name = "Pittsburgh Steelers",
                    Wins = 9,
                    Losses = 7,
                    Ties = 0,
                    HomeRecord = "5-4-0",
                    RoadRecord = "4-3-0",
                    DivisionId = 2
                },
                new Team()
                {
                    Id = 8,
                    Name = "Cincinnati Bengals",
                    Wins = 8,
                    Losses = 8,
                    Ties = 0,
                    HomeRecord = "5-3-0",
                    RoadRecord = "3-5-0",
                    DivisionId = 2
                }
            );
        }
    }
}