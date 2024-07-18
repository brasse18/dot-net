// skriven av Björn Blomberg
using DomainModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

public class CompetitionDbContext : DbContext
{
    public CompetitionDbContext()
        : base("name=CompetitionDbContext")
    {
        Database.SetInitializer(new Initialiser());
    }

    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Participant> Participants { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Competition>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Competition>()
            .Property(e => e.Name)
            .IsRequired();

        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    }
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
