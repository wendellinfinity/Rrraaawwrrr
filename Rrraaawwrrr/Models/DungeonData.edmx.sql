
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/28/2008 11:13:02
-- Generated from EDMX file: C:\Users\Admin\Desktop\Rrraaawwrrr\Rrraaawwrrr\Models\DungeonData.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TextDungeon];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_HeroHeroAttributes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Heroes] DROP CONSTRAINT [FK_HeroHeroAttributes];
GO
IF OBJECT_ID(N'[dbo].[FK_DungeonMapDungeonGridEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DungeonGridEvents] DROP CONSTRAINT [FK_DungeonMapDungeonGridEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_DungeonGridEventEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_DungeonGridEventEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterEventMonster]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Monsters] DROP CONSTRAINT [FK_MonsterEventMonster];
GO
IF OBJECT_ID(N'[dbo].[FK_TreasureEventTreasure]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Treasures] DROP CONSTRAINT [FK_TreasureEventTreasure];
GO
IF OBJECT_ID(N'[dbo].[FK_MonsterEvent_inherits_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events_MonsterEvent] DROP CONSTRAINT [FK_MonsterEvent_inherits_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_TreasureEvent_inherits_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events_TreasureEvent] DROP CONSTRAINT [FK_TreasureEvent_inherits_Event];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Heroes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Heroes];
GO
IF OBJECT_ID(N'[dbo].[HeroAttributes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HeroAttributes];
GO
IF OBJECT_ID(N'[dbo].[DungeonMaps]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DungeonMaps];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[DungeonGridEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DungeonGridEvents];
GO
IF OBJECT_ID(N'[dbo].[Monsters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Monsters];
GO
IF OBJECT_ID(N'[dbo].[Treasures]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Treasures];
GO
IF OBJECT_ID(N'[dbo].[Events_MonsterEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events_MonsterEvent];
GO
IF OBJECT_ID(N'[dbo].[Events_TreasureEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events_TreasureEvent];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Heroes'
CREATE TABLE [dbo].[Heroes] (
    [HeroId] int IDENTITY(1,1) NOT NULL,
    [HeroName] nvarchar(max)  NOT NULL,
    [Class] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [HeroAttribute_HeroId] int  NOT NULL
);
GO

-- Creating table 'HeroAttributes'
CREATE TABLE [dbo].[HeroAttributes] (
    [HeroId] int IDENTITY(1,1) NOT NULL,
    [Life] int  NOT NULL,
    [Strength] int  NOT NULL,
    [Agility] int  NOT NULL,
    [Intelligence] int  NOT NULL,
    [Wisdom] int  NOT NULL,
    [Charm] int  NOT NULL
);
GO

-- Creating table 'DungeonMaps'
CREATE TABLE [dbo].[DungeonMaps] (
    [GridId] bigint IDENTITY(1,1) NOT NULL,
    [IsDark] bit  NOT NULL,
    [IsTrapped] bit  NOT NULL,
    [NorthGridId] bigint  NOT NULL,
    [SouthGridId] bigint  NOT NULL,
    [EastGridId] bigint  NOT NULL,
    [WestGridId] bigint  NOT NULL,
    [NorthFeature] nvarchar(max)  NULL,
    [SouthFeature] nvarchar(max)  NULL,
    [EastFeature] nvarchar(max)  NULL,
    [WestFeature] nvarchar(max)  NULL,
    [X] int  NOT NULL,
    [Y] int  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [EventId] int IDENTITY(1,1) NOT NULL,
    [EventName] nvarchar(max)  NOT NULL,
    [DungeonGridEventDungeonGridEventId] int  NOT NULL,
    [DungeonGridEventDungeonGridEventId1] int  NOT NULL
);
GO

-- Creating table 'DungeonGridEvents'
CREATE TABLE [dbo].[DungeonGridEvents] (
    [DungeonGridEventId] int IDENTITY(1,1) NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [DungeonMapGridId] bigint  NOT NULL,
    [DungeonMap_GridId] bigint  NOT NULL
);
GO

-- Creating table 'Monsters'
CREATE TABLE [dbo].[Monsters] (
    [MonsterId] int IDENTITY(1,1) NOT NULL,
    [MonsterName] nvarchar(max)  NOT NULL,
    [Attack] int  NOT NULL,
    [Defense] int  NOT NULL,
    [Alignment] int  NOT NULL,
    [MonsterEventEventId] int  NOT NULL
);
GO

-- Creating table 'Treasures'
CREATE TABLE [dbo].[Treasures] (
    [TreasureId] int IDENTITY(1,1) NOT NULL,
    [TreasureName] nvarchar(max)  NOT NULL,
    [TreasureEventEventId] int  NOT NULL
);
GO

-- Creating table 'Events_MonsterEvent'
CREATE TABLE [dbo].[Events_MonsterEvent] (
    [EventId] int  NOT NULL
);
GO

-- Creating table 'Events_TreasureEvent'
CREATE TABLE [dbo].[Events_TreasureEvent] (
    [EventId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [HeroId] in table 'Heroes'
ALTER TABLE [dbo].[Heroes]
ADD CONSTRAINT [PK_Heroes]
    PRIMARY KEY CLUSTERED ([HeroId] ASC);
GO

-- Creating primary key on [HeroId] in table 'HeroAttributes'
ALTER TABLE [dbo].[HeroAttributes]
ADD CONSTRAINT [PK_HeroAttributes]
    PRIMARY KEY CLUSTERED ([HeroId] ASC);
GO

-- Creating primary key on [GridId] in table 'DungeonMaps'
ALTER TABLE [dbo].[DungeonMaps]
ADD CONSTRAINT [PK_DungeonMaps]
    PRIMARY KEY CLUSTERED ([GridId] ASC);
GO

-- Creating primary key on [EventId] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [DungeonGridEventId] in table 'DungeonGridEvents'
ALTER TABLE [dbo].[DungeonGridEvents]
ADD CONSTRAINT [PK_DungeonGridEvents]
    PRIMARY KEY CLUSTERED ([DungeonGridEventId] ASC);
GO

-- Creating primary key on [MonsterId] in table 'Monsters'
ALTER TABLE [dbo].[Monsters]
ADD CONSTRAINT [PK_Monsters]
    PRIMARY KEY CLUSTERED ([MonsterId] ASC);
GO

-- Creating primary key on [TreasureId] in table 'Treasures'
ALTER TABLE [dbo].[Treasures]
ADD CONSTRAINT [PK_Treasures]
    PRIMARY KEY CLUSTERED ([TreasureId] ASC);
GO

-- Creating primary key on [EventId] in table 'Events_MonsterEvent'
ALTER TABLE [dbo].[Events_MonsterEvent]
ADD CONSTRAINT [PK_Events_MonsterEvent]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- Creating primary key on [EventId] in table 'Events_TreasureEvent'
ALTER TABLE [dbo].[Events_TreasureEvent]
ADD CONSTRAINT [PK_Events_TreasureEvent]
    PRIMARY KEY CLUSTERED ([EventId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [HeroAttribute_HeroId] in table 'Heroes'
ALTER TABLE [dbo].[Heroes]
ADD CONSTRAINT [FK_HeroHeroAttributes]
    FOREIGN KEY ([HeroAttribute_HeroId])
    REFERENCES [dbo].[HeroAttributes]
        ([HeroId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HeroHeroAttributes'
CREATE INDEX [IX_FK_HeroHeroAttributes]
ON [dbo].[Heroes]
    ([HeroAttribute_HeroId]);
GO

-- Creating foreign key on [DungeonMap_GridId] in table 'DungeonGridEvents'
ALTER TABLE [dbo].[DungeonGridEvents]
ADD CONSTRAINT [FK_DungeonMapDungeonGridEvent]
    FOREIGN KEY ([DungeonMap_GridId])
    REFERENCES [dbo].[DungeonMaps]
        ([GridId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DungeonMapDungeonGridEvent'
CREATE INDEX [IX_FK_DungeonMapDungeonGridEvent]
ON [dbo].[DungeonGridEvents]
    ([DungeonMap_GridId]);
GO

-- Creating foreign key on [DungeonGridEventDungeonGridEventId1] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_DungeonGridEventEvent]
    FOREIGN KEY ([DungeonGridEventDungeonGridEventId1])
    REFERENCES [dbo].[DungeonGridEvents]
        ([DungeonGridEventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DungeonGridEventEvent'
CREATE INDEX [IX_FK_DungeonGridEventEvent]
ON [dbo].[Events]
    ([DungeonGridEventDungeonGridEventId1]);
GO

-- Creating foreign key on [MonsterEventEventId] in table 'Monsters'
ALTER TABLE [dbo].[Monsters]
ADD CONSTRAINT [FK_MonsterEventMonster]
    FOREIGN KEY ([MonsterEventEventId])
    REFERENCES [dbo].[Events_MonsterEvent]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_MonsterEventMonster'
CREATE INDEX [IX_FK_MonsterEventMonster]
ON [dbo].[Monsters]
    ([MonsterEventEventId]);
GO

-- Creating foreign key on [TreasureEventEventId] in table 'Treasures'
ALTER TABLE [dbo].[Treasures]
ADD CONSTRAINT [FK_TreasureEventTreasure]
    FOREIGN KEY ([TreasureEventEventId])
    REFERENCES [dbo].[Events_TreasureEvent]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TreasureEventTreasure'
CREATE INDEX [IX_FK_TreasureEventTreasure]
ON [dbo].[Treasures]
    ([TreasureEventEventId]);
GO

-- Creating foreign key on [EventId] in table 'Events_MonsterEvent'
ALTER TABLE [dbo].[Events_MonsterEvent]
ADD CONSTRAINT [FK_MonsterEvent_inherits_Event]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [EventId] in table 'Events_TreasureEvent'
ALTER TABLE [dbo].[Events_TreasureEvent]
ADD CONSTRAINT [FK_TreasureEvent_inherits_Event]
    FOREIGN KEY ([EventId])
    REFERENCES [dbo].[Events]
        ([EventId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------