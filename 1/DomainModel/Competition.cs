// skiven av Björn Blomberg
using System.Data.Entity;

public class CompetitionDbContext : DbContext
{

    public CompetitionDbContext()
        : base("name=CompetitionDbContext")
    {
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CompetitionDbContext>());
    }

    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Participant> Participants { get; set; }

}

public class Competition
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Participant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompetitionId { get; set; }
}
