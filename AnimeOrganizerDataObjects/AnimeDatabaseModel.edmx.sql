
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2025 22:49:58
-- Generated from EDMX file: W:\Anime-Organizer\AnimeOrganizer\Database\AnimeDatabaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AnimeDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AnimeRecords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AnimeRecords];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AnimeRecords'
CREATE TABLE [dbo].[AnimeRecords] (
    [title] varchar(255)  NOT NULL,
    [numberOfEpisodes] int  NOT NULL,
    [rating] int  NULL,
    [description] varchar(max)  NOT NULL,
    [lastUpdate] datetimeoffset  NOT NULL,
    [year] int  NULL,
    [season] varchar(15)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [title] in table 'AnimeRecords'
ALTER TABLE [dbo].[AnimeRecords]
ADD CONSTRAINT [PK_AnimeRecords]
    PRIMARY KEY CLUSTERED ([title] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------