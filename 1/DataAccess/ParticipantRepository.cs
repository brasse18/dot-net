// skriven av Björn Blomberg
namespace DataAccess
{
    public class ParticipantRepository
    {
        private readonly CompetitionDbContext _context;

        public ParticipantRepository()
        {
            _context = new CompetitionDbContext();
        }

        public IEnumerable<Participant> GetAll()
        {
            return _context.Participants.ToList();
        }

        public IEnumerable<Participant> GetAllOfCompetition(int competitionId)
        {
            return _context.Participants.Where(p => p.CompetitionId == competitionId).ToList();
        }

        public void Add(Participant participant)
        {
            _context.Participants.Add(participant);
            _context.SaveChanges();
        }
    }
}
