// skriven av Björn Blomberg
namespace DataAccess
{
    public class CompetitionRepository
    {
        private readonly CompetitionDbContext _context;

        public CompetitionRepository()
        {
            _context = new CompetitionDbContext();
        }

        public IEnumerable<Competition> GetAll()
        {
            return _context.Competitions.ToList();
        }

        public IEnumerable<Competition> GetById(int id)
        {
            return _context.Competitions.Where(c => c.Id == id).ToList();
        }

        public void Add(Competition competition)
        {
            _context.Competitions.Add(competition);
            _context.SaveChanges();
        }
    }
}
