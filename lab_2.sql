CREATE TABLE [dbo].[Clients] (
    [Id]   INT            NOT NULL IDENTITY,
    [Name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Reqs] (
    [Id]        INT NOT NULL IDENTITY,
    [ClientId]  INT NOT NULL,
    [ServiceId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[Services] (
    [Id]   INT            NOT NULL IDENTITY,
    [Name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
