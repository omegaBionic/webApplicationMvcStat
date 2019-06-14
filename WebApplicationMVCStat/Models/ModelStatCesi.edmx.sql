
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2019 09:46:50
-- Generated from EDMX file: c:\users\boulanti\documents\visual studio 2015\Projects\WebApplicationMVCStat\WebApplicationMVCStat\Models\ModelStatCesi.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DatabaseStat];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AcademySet'
CREATE TABLE [dbo].[AcademySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Area] nvarchar(1)  NOT NULL
);
GO

-- Creating table 'StatisticsSet'
CREATE TABLE [dbo].[StatisticsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AcademyId] int  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Score] decimal(18,0)  NOT NULL,
    [DateAdded] datetime  NOT NULL,
    [DateUpdated] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AcademySet'
ALTER TABLE [dbo].[AcademySet]
ADD CONSTRAINT [PK_AcademySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StatisticsSet'
ALTER TABLE [dbo].[StatisticsSet]
ADD CONSTRAINT [PK_StatisticsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AcademyId] in table 'StatisticsSet'
ALTER TABLE [dbo].[StatisticsSet]
ADD CONSTRAINT [FK_AcademyStatistics]
    FOREIGN KEY ([AcademyId])
    REFERENCES [dbo].[AcademySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AcademyStatistics'
CREATE INDEX [IX_FK_AcademyStatistics]
ON [dbo].[StatisticsSet]
    ([AcademyId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------