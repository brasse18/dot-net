-- skriven av Björn Blomberg
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Competitions]') AND type in (N'U'))
BEGIN
    CREATE TABLE Competitions (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(100) NOT NULL
    );
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Participants]') AND type in (N'U'))
BEGIN
    CREATE TABLE Participants (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(100) NOT NULL,
        CompetitionId INT NOT NULL,
        FOREIGN KEY (CompetitionId) REFERENCES Competitions(Id)
    );
END