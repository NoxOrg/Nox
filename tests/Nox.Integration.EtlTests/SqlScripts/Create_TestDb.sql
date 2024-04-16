USE master;
GO    
CREATE DATABASE TestIntegrationDb;
GO
USE TestIntegrationDb;
GO    
CREATE TABLE Integration.MergeStates(
    Id uniqueidentifier NOT NULL, 
    Integration varchar(30) NOT NULL,
    [Property] varchar(30) NOT NULL,
    LastDateLoadedUtc datetime2 NOT NULL,
    IsUpdated bit NOT NULL,
    CONSTRAINT PK_MergeStates_Id PRIMARY KEY NONCLUSTERED (Id)
    );
GO
USE master;
GO    
CREATE DATABASE TestTargetDb;
GO       
USE TestTargetDb;
GO    
CREATE TABLE SqlToSql(
    Id int NOT NULL PRIMARY KEY,
    Name varchar(50) NOT NULL,
    Population int NOT NULL,
    CreateDate datetime2,
    EditDate datetime2
);
GO
CREATE TABLE JsonToSql(
     Id int NOT NULL PRIMARY KEY,
     Name varchar(50) NOT NULL,
     Population int NOT NULL,
     CreateDate datetime2,
     EditDate datetime2
);