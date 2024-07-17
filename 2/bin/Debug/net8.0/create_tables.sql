IF OBJECT_ID('Participants', 'U') IS NULL 
BEGIN
    CREATE TABLE Participants (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(100) NOT NULL,
        CompetitionId INT NOT NULL,
        FOREIGN KEY (CompetitionId) REFERENCES Competitions(Id)
    );
END

IF OBJECT_ID('Competitions', 'U') IS NULL 
BEGIN
    CREATE TABLE Competitions (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(100) NOT NULL
    );
END