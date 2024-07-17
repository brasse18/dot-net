// skriven av Björn Blomberg
using DataAccess;
class Program
{
    static void Main(string[] args)
    {
        var competitionRepository = new CompetitionRepository();
        var participantRepository = new ParticipantRepository();

        if (!competitionRepository.GetAll().Any())
        {
            competitionRepository.Add(new Competition { Name = "VM in compiling" });
            competitionRepository.Add(new Competition { Name = "SM in memming" });
        }

        if (!participantRepository.GetAll().Any())
        {
            participantRepository.Add(new Participant { Name = "Gostav", CompetitionId = 1 });
            participantRepository.Add(new Participant { Name = "Björn", CompetitionId = 1 });
            participantRepository.Add(new Participant { Name = "Nadja", CompetitionId = 2 });
        }

        var competitions = competitionRepository.GetAll();

        foreach (var competition in competitions)
        {
            Console.WriteLine($"ID: {competition.Id}, Name: {competition.Name}");
            var participantsOfcompetition = participantRepository.GetAllOfCompetition(competition.Id);
            foreach (var participant in participantsOfcompetition)
            {
                Console.WriteLine($"    ID: {participant.Id}, Name: {participant.Name}");
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}