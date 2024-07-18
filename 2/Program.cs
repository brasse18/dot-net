// skriven av Björn Blomberg
using System.Data;
using System.Data.SqlClient;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string masterConnectionString = @"Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        string competitionConnectionString = @"Server=localhost\SQLEXPRESS;Database=Competition;Trusted_Connection=True;";

        using (SqlConnection masterConnection = new SqlConnection(masterConnectionString))
        {
            masterConnection.Open();
            ExecuteSqlFromFile(masterConnection, "create_database.sql");
        }

        using (SqlConnection connection = new SqlConnection(competitionConnectionString))
        {
            connection.Open();
            ExecuteSqlFromFile(connection, "create_tables.sql");
            ExecuteSqlFromFile(connection, "insert_data.sql");
            string query = @"
                SELECT 
                    c.Id AS CompetitionId,
                    c.Name AS CompetitionName,
                    p.Id AS ParticipantId,
                    p.Name AS ParticipantName
                FROM 
                    Competitions c
                JOIN 
                    Participants p ON c.Id = p.CompetitionId
                ORDER BY 
                    c.Id";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();

            try
            {
                adapter.Fill(dataTable);

                int currentCompetitionId = -1;
                foreach (DataRow row in dataTable.Rows)
                {
                    int competitionId = (int)row["CompetitionId"];
                    string competitionName = (string)row["CompetitionName"];
                    string participantName = (string)row["ParticipantName"];

                    if (competitionId != currentCompetitionId)
                    {
                        if (currentCompetitionId != -1)
                        {
                            Console.WriteLine();
                        }

                        Console.WriteLine($"Competition: {competitionName}");
                        currentCompetitionId = competitionId;
                    }

                    Console.WriteLine($"  Participant: {participantName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
    static void ExecuteSqlFromFile(SqlConnection connection, string filePath)
    {
        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
        string sql = File.ReadAllText(path, Encoding.UTF8);
        using (SqlCommand command = new SqlCommand(sql, connection))
        {
            command.ExecuteNonQuery();
        }
    }
}