using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

public class CompetitionDbContext : DbContext
{

    public CompetitionDbContext()
        : base("name=CompetitionDbContext")
    {
        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CompetitionDbContext>());
    }

    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Participant> Participants { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        // Configure Competition entity
        modelBuilder.Entity<Competition>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<Competition>()
            .Property(e => e.Name)
            .IsRequired();

        // Configure one-to-many relationship with Participants
        modelBuilder.Entity<Competition>()
            .HasMany(c => c.Participants)
            .WithRequired(p => p.Competition)
            .HasForeignKey(p => p.CompetitionId);

        // Disable cascading delete for Participants
        modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
    }

}

public class Competition
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Participant> Participants { get; set; }
}

public class Participant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CompetitionId { get; set; }
    public Competition Competition { get; set; }
}
