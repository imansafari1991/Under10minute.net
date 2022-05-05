using GenFu;
using Linq_dotnet6_features;
using Spectre.Console;

//Data Initialization

var people = A.ListOf<Person>(50);

var table = new Table();

// Add some columns
table.AddColumn(new TableColumn("TeamId").Centered());
table.AddColumn(new TableColumn("Members").Centered());
table.AddColumn(new TableColumn("Youngest-{age}").Centered());
table.AddColumn(new TableColumn("Oldest-{age}").Centered());

var teamId = 1;
foreach (var teamItem in people.Chunk(8))
{
    var team = new Team
    {
        Id = teamId++,
        Members = teamItem.ToList(),
        Oldest = teamItem.MaxBy(p => p.Age),
        Youngest = teamItem.MinBy(p => p.Age)
    };
    table.AddRow(new Markup($"[red]{team.Id}[/]"),
        new Markup(string.Join(',', team.Members.Select(p => p.FullName))),
        new Markup($"{team.Youngest.FullName}-[green]{team.Youngest.Age}[/]"), new Markup($"{team.Oldest.FullName}-[purple]{team.Oldest.Age}[/]"));
    table.AddEmptyRow();
}

// Render the table to the console
AnsiConsole.Write(table);


var teams = people.Chunk(6).Select(chunk =>
{
    var team = new Team
    {
        Id = teamId++,
        Members = chunk.ToList(),
        Oldest = chunk.MaxBy(p => p.Age),
        Youngest = chunk.MinBy(p => p.Age)
    };



    return team;
});

Console.WriteLine();
