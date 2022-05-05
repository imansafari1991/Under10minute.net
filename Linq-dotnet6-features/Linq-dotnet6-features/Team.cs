using Linq_dotnet6_features;

internal class Team
{
    public Team()
    {
    }

    public int Id { get; set; }
    public Person? Oldest { get; set; }
    public Person? Youngest { get; set; }
    public List<Person> Members { get; set; }
}