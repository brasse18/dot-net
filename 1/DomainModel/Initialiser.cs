using System.Data.Entity;

namespace DomainModel
{
    public class Initialiser : DropCreateDatabaseAlways<CompetitionDbContext>
    {

        protected override void Seed(CompetitionDbContext context)
        {
            var competitions = new List<Competition>
        {
            new Competition { Name = "VM in compiling" },
            new Competition { Name = "SM in memming" }
        };

            competitions.ForEach(c => context.Competitions.Add(c));
            context.SaveChanges();

            var participants = new List<Participant>
        {
            new Participant { Name = "Gustav", CompetitionId = competitions[0].Id },
            new Participant { Name = "Björn", CompetitionId = competitions[0].Id },
            new Participant { Name = "Nadja", CompetitionId = competitions[1].Id }
        };

            participants.ForEach(p => context.Participants.Add(p));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
