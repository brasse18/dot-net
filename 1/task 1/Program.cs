// skriven av Björn Blomberg
class Program
{
    static void Main(string[] args)
    {
        using (var context = new CompetitionDbContext())
        {
            //context.Database.Initialize(force: true);

            var competitions = context.Competitions.ToList();

            foreach (var competition in competitions)
            {
                Console.WriteLine($"Competition: {competition.Name}");
                var participants = context.Participants.Where(p => p.CompetitionId == competition.Id).ToList();
                foreach (var participant in participants)
                {
                    Console.WriteLine($"    Participant Name: {participant.Name}");
                }
                Console.WriteLine("");
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}