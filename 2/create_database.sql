IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'Competition')
BEGIN
    CREATE DATABASE Competition;
END