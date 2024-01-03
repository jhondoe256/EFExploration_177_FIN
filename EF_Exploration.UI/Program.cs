using System.Reflection.Metadata;
using EF_Exploration.Data;
using EF_Exploration.Domain;
using EF_Exploration.Domain.CoachModels;
using Microsoft.EntityFrameworkCore;

Console.Clear();

NFLDbContext context = new NFLDbContext();

//todo: select all teams in the Database
// await GetAllTeams();

//todo: Get single team by Id
// await GetTeam(1);

//todo: GetTheFistTeam
// await GetFirstTeam();

//todo: Filtering -> select all the records that meet a condition (&&, ||, !=, ==, >=, <=, <, >)
// await FilterByName();
// await FilterTeamByContainingValue();

//todo: Aggregate Methods
// await GetTeamCount();
// await FilterUsingCountMethod();

//todo: Max
// await GetMaxTeamId();
//todo: Min
// await GetMinTeamId();
//todo: Average
// await AverageWinsForAllTeams();
//todo: Sum
// await SumOfAllLosses();

//todo: Grouping and Aggregating
// await GroupingAndAggregating();

//todo: OrderBy
// await OrderByMethods();

//todo: Pagination (Skip and Take)
// await SkipAndTake();

//todo: ViewModels -> Projections
// await DisplayTeamNames();
// await DisplayAnonymousDataType();

//todo: AsNoTracking
// await AsNoTracking();

//todo: Database Insert(s)
// await AddCoach();
// await MultiCoachesUsingForLoop();
// await MultiAssistantCoachesUsingAddRange();
// await UpdateWithTrackingRemoveCoachFromTeam();
// await UpdateUsingAsNoTracking();
// await DeleteHeadCoach();
// await InsertParentAndChildObjs();
// await EagerLoading();
// await ExplicitLoading();

#region Database Methods

async Task GetAllTeams()
{
    List<Team> teams = await context.Teams.ToListAsync();

    foreach (var team in teams)
    {
        DisplayTeamData(team);
    }
}

async Task GetTeam(int v)
{
    var team = await context.FindAsync<Team>(v);
    if (team != null)
    {
        DisplayTeamData(team);
    }
    else
    {
        DisplayError("Team could not be found.");
    }
}

async Task GetFirstTeam()
{
    var team = await context.Teams.FirstOrDefaultAsync(t => t.Name == "Buffalo Bills");
    if (team != null)
        DisplayTeamData(team);
    else
        DisplayError("Team could not be found!");
}

async Task FilterByName()
{
    Console.Clear();

    System.Console.WriteLine("Please enter a name");

    var teamName = Console.ReadLine();

    var teams = await context.Teams.Where(t => t.Name == teamName).ToListAsync();

    foreach (var team in teams)
    {
        System.Console.WriteLine($"TeamName: {team.Name}");
    }
}

async Task FilterTeamByContainingValue()
{
    var teams = await context.Teams.Where(t => EF.Functions.Like(t.Name, "%i%")).ToListAsync();
    if (teams != null)
        teams.ForEach(t => DisplayTeamData(t));
    else
        System.Console.WriteLine("Sorry, No teams available.");
}

async Task GetTeamCount()
{
    var numberOfTeams = await context.Teams.CountAsync();
    System.Console.WriteLine($"Total Teams: {numberOfTeams}");
}

async Task FilterUsingCountMethod()
{
    var numberOfTeams = await context.Teams.CountAsync(t => t.Name.Contains("i"));
    System.Console.WriteLine($"Team count with the letter 'i': {numberOfTeams}");
}

async Task GetMaxTeamId()
{
    var maxId = await context.Teams.MaxAsync(t => t.Id);
    System.Console.WriteLine("Highest TeamId Value: " + maxId);
}

async Task GetMinTeamId()
{
    var minTeamId = await context.Teams.MinAsync(t => t.Id);
    System.Console.WriteLine("Highest TeamId Value: " + minTeamId);
}

async Task AverageWinsForAllTeams()
{
    var totalAverageWins = await context.Teams.AverageAsync(t => t.Wins);
    System.Console.WriteLine("The Total Average: " + totalAverageWins);
}

async Task SumOfAllLosses()
{
    var sumOfAllLosses = await context.Teams.SumAsync(t => t.Losses);
    System.Console.WriteLine("Total Losses: " + sumOfAllLosses);
}

async Task GroupingAndAggregating()
{
    var teamsByLossesAndWins = context.Teams.GroupBy(t => new { t.Losses, t.Wins });

    foreach (var group in teamsByLossesAndWins)
    {
        System.Console.WriteLine(group.Key); //what we're 'grouped' on
        System.Console.WriteLine("Sum of values of TeamId's: " + group.Sum(g => g.Id));
        foreach (var team in group)
        {
            DisplayTeamData(team);
        }
    }
}

async Task OrderByMethods()
{
    //display teams in order by name
    var listTeamInOrder = await context.Teams.OrderBy(t => t.Name).ToListAsync();
    listTeamInOrder.ForEach(t => System.Console.WriteLine(t.Name));

    //reverse order
    System.Console.WriteLine("Reverse Order");
    var listTeamReverseOrder = await context.Teams.OrderByDescending(t => t.Name).ToListAsync();
    listTeamReverseOrder.ForEach(t => System.Console.WriteLine(t.Name));

    //get the listing of teams starting with the highest Id value .OrderByDescending()
    var maxByDecendingOrderList = await context.Teams.OrderByDescending(t => t.Id).ToListAsync();
    maxByDecendingOrderList.ForEach(t => System.Console.WriteLine($"{t.Id} - {t.Name}"));

    //easier way...
    var maxByDecending = await context.Teams.MaxAsync(t => t.Id);
    System.Console.WriteLine($"maxId: {maxByDecending}");

    var minByDecending = await context.Teams.OrderBy(t => t.Id).FirstOrDefaultAsync();
    System.Console.WriteLine($"minDecending: {minByDecending.Id}");

    //easier?
    var minBy = await context.Teams.MinAsync(t => t.Id);
    System.Console.WriteLine($"minBy: {minBy}");

}

async Task SkipAndTake()
{
    //number of records that we want to be shown on the screen
    var displayedItemCount = 2;

    //we need the page to start from (we want to start from zero)
    var startingPage = 0;

    var next = true;

    while (next)
    {
        //first number is how many we want to 'skip' past
        // 0 * 3 = page 1
        // '.Take()' -> shows how many on each page
        var teams = await context.Teams.Skip(startingPage * displayedItemCount).Take(displayedItemCount).ToListAsync();
        teams.ForEach(t => System.Console.WriteLine(t.Name));
        System.Console.WriteLine("Type 'true' for the next set of teams, 'false' to exit the App.");
        next = Convert.ToBoolean(Console.ReadLine());
        if (!next)
            break;
        else
            startingPage++;
    }
}

async Task DisplayTeamNames()
{
    var teams = await context.Teams.Select(t => t.Name).ToListAsync();
    teams.ForEach(t => System.Console.WriteLine(t));
}

async Task DisplayAnonymousDataType()
{
    var teamNameAndId = await context.Teams.Select(t => new { t.Id, t.Wins, t.Name }).ToListAsync();
    teamNameAndId.ForEach(t => System.Console.WriteLine($"{t.Id} - {t.Wins} -{t.Name}"));
}

async Task AsNoTracking()
{
    //this allows EF not to 'track' any of the entities that are being returned.
    //works if you are getting an item by its 'Id' and your trying to 'update' it,
    //EF wont let you update it because its being tracked(the entity) in the initial query,
    //So you need to use '.AsNoTracking()'
    var teams = await context.Teams.AsNoTracking().ToListAsync();

    teams.ForEach(t => DisplayTeamData(t));
}

async Task AddCoach()
{
    try
    {
        var headCoachData = new HeadCoach()
        {
            Name = "Mike McDaniel",
            TeamId = 1
        };

        await context.HeadCoaches.AddAsync(headCoachData);
        await context.SaveChangesAsync(); // headCoachData gets an Id assigned here! (if things work out)

        //check if the headCoachData.TeamId is ligit!
        var team = await context.Teams.FindAsync(headCoachData.TeamId);
        if (team != null)
        {
            team.HeadCoachId = headCoachData.Id;
            await context.SaveChangesAsync();
        }
    }
    catch (Exception ex)
    {
        DisplayError(ex.Message);
    }
}

async Task MultiCoachesUsingForLoop()
{
    try
    {
        var seanM = new HeadCoach
        {
            Name = "Sean McDermott",
            TeamId = 2
        };

        var robertS = new HeadCoach
        {
            Name = "Robert Saleh",
            TeamId = 3
        };

        var billB = new HeadCoach
        {
            Name = "Bill Belicheck",
            TeamId = 4
        };

        List<HeadCoach> coaches = new List<HeadCoach>() { seanM, robertS, billB };
        foreach (var coach in coaches)
        {
            await context.HeadCoaches.AddAsync(coach);
            await context.SaveChangesAsync();
            //team check
            var team = await context.Teams.FindAsync(coach.TeamId);
            if (team != null)
            {
                team.HeadCoachId = coach.Id;
                await context.SaveChangesAsync();
            }
        }
    }
    catch (Exception ex)
    {
        DisplayError(ex.Message);
    }
}

async Task MultiAssistantCoachesUsingAddRange()
{
    try
    {
        var asstCoaches = new List<AssistantCoach>
        {
            new AssistantCoach
            {
                Name = "Frank Smith",
                Title = "Offensive Coordinator",
                TeamId = 1
            },
            new AssistantCoach
            {
                Name = "Ricardo Allen",
                Title = "Offensive Assistant",
                TeamId = 1
            },
            new AssistantCoach
            {
                Name = "Butch Barry",
                Title = "Offensive Line",
                TeamId = 1
            },
            new AssistantCoach
            {
                Name = "Darrel Bevell",
                Title = "Quarterbacks / Passing Game Coordinator",
                TeamId = 1
            },
            new AssistantCoach
            {
                Name = "Josh Grizzard",
                Title = "Quality Control",
                TeamId = 1
            }
        };

        await context.AssistantCoaches.AddRangeAsync(asstCoaches);
        await context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        DisplayError(ex.Message);
    }
}

async Task UpdateWithTrackingRemoveCoachFromTeam()
{
    try
    {
        var coach = await context.HeadCoaches.FindAsync(1);
        System.Console.WriteLine("Do you want to REMOVE  the coach from the team? y/n");
        var userInput = Console.ReadLine();
        if (userInput.ToLower() == "y")
        {
            var team = await context.Teams.FindAsync(coach.TeamId);
            if (team != null)
            {
                team.HeadCoachId = 0;
            }
            coach.TeamId = null;
            await context.SaveChangesAsync();
        }
        System.Console.WriteLine("Closing App, Press any key to continue.");
        Console.ReadKey();
    }
    catch (Exception ex)
    {
        DisplayError(ex.Message);
    }
}

async Task UpdateUsingAsNoTracking()
{
    // var coach = await context.HeadCoaches.FirstOrDefaultAsync(x=>x.Id == 1);
    var coach = await context.HeadCoaches.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 1);

    coach.Name = "Mike McDaniel";
    System.Console.WriteLine(context.ChangeTracker.DebugView.LongView);
    // context.Update(coach);

    context.Entry(coach).State = EntityState.Modified;
    System.Console.WriteLine(context.ChangeTracker.DebugView.LongView);

    await context.SaveChangesAsync();
    System.Console.WriteLine(context.ChangeTracker.DebugView.LongView);

}

async Task DeleteHeadCoach()
{
    try
    {
        var coach = await context.HeadCoaches.FindAsync(5);
        if (coach != null)
        {
            var team = await context.Teams.FindAsync(coach.TeamId);
            if (team != null)
            {
                team.HeadCoachId = 0;
            }
            //context.Remove(coach)
            //also...
            context.Entry(coach).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }

    }
    catch (Exception ex)
    {
        DisplayError(ex.Message);
    }
}

async Task InsertParentAndChildObjs()
{
    try
    {
        //make the team first!
        var team = new Team
        {
            Name = "Indianapolis Colts",
            HeadCoach = new HeadCoach
            {
                Name = "Shane Stichen"
            },
            DivisionId = 3,
            Wins = 9,
            Losses = 7,
            HomeRecord = "4-4-0",
            RoadRecord = "5-3-0",
            Players = new List<Player>
            {
                  new Player()
                {
                    Name = "Adetomiwa Adebawore",
                    Position = "DT",
                    Number = 95
                },
                new Player()
                {
                    Name = "Mo Alie-Cox",
                    Position = "TE",
                    Number = 81
                },
                new Player()
                {
                    Name = "Jonathan Taylor",
                    Position = "RB",
                    Number = 28
                }
            }
        };

        await context.AddAsync(team);
        await context.SaveChangesAsync();
    }
    catch (Exception ex)
    {
        DisplayError(ex.Message);
    }
}

async Task EagerLoading()
{
    var divisions = await context.Divisions.Include(d => d.Teams).ToListAsync();

    foreach (var division in divisions)
    {
        System.Console.WriteLine($"{division.Id} - {division.Name}");
        if (division.Teams.Count() > 0)
        {
            foreach (var team in division.Teams)
            {
                DisplayTeamData(team);
            }
        }
    }
}

async Task ExplicitLoading()
{
    var division = await context.FindAsync<Division>(2);

    if (!division.Teams.Any())
    {
        System.Console.WriteLine("No loaded teams!");
    }

    await context.Entry(division).Collection(d => d.Teams).LoadAsync();
    if (division.Teams.Any())
    {
        division.Teams.ForEach(t => System.Console.WriteLine($"TeamName: {t.Name}"));
    }
}

//helper methods
void DisplayError(string v)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    System.Console.WriteLine(v);
    Console.ResetColor();
}

void DisplayTeamData(Team team)
{
    System.Console.WriteLine($"\nTeamId: {team.Id}\nTeamName: {team.Name}\nWins: {team.Wins}\nLosses:{team.Losses}\nHomeRecord: {team.HomeRecord}\nRoadRecord: {team.RoadRecord}\n--------\n");
}

#endregion