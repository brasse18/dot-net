-- skriven av Björn Blomberg
IF NOT EXISTS (SELECT 1 FROM Competitions)
BEGIN
    INSERT INTO Competitions (Name) VALUES ('VM in Compiling');
    INSERT INTO Competitions (Name) VALUES ('SM in Memmeing');
END

IF NOT EXISTS (SELECT 1 FROM Participants)
BEGIN
    INSERT INTO Participants (Name, CompetitionId) VALUES ('Björn', 1);
    INSERT INTO Participants (Name, CompetitionId) VALUES ('Gustav', 1);
    INSERT INTO Participants (Name, CompetitionId) VALUES ('Bob', 2);
    INSERT INTO Participants (Name, CompetitionId) VALUES ('Nadja', 2);
END