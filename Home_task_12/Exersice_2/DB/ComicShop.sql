
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/07/2023 18:47:11
-- Generated from EDMX file: D:\Ostap\SSWU\Homeworks\DB\Task2\DB\ComicsShop.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ComicsShopPartDB];
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

-- Creating table 'ComicSet'
CREATE TABLE [dbo].[ComicSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Price] decimal(18,0)  NOT NULL,
    [Barcode] nvarchar(max)  NOT NULL,
    [DateOfPublish] datetime  NOT NULL,
    [CategoryId] int  NOT NULL,
    [PublisherId] int  NOT NULL,
    [ComicParams_Id] int  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'PublisherSet'
CREATE TABLE [dbo].[PublisherSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [WEB_Site_Link] nvarchar(max)  NULL,
    [Country] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ComicParamsSet'
CREATE TABLE [dbo].[ComicParamsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Language] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NOT NULL,
    [Country] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ComicSet'
ALTER TABLE [dbo].[ComicSet]
ADD CONSTRAINT [PK_ComicSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PublisherSet'
ALTER TABLE [dbo].[PublisherSet]
ADD CONSTRAINT [PK_PublisherSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComicParamsSet'
ALTER TABLE [dbo].[ComicParamsSet]
ADD CONSTRAINT [PK_ComicParamsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryId] in table 'ComicSet'
ALTER TABLE [dbo].[ComicSet]
ADD CONSTRAINT [FK_CategoryItem]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryItem'
CREATE INDEX [IX_FK_CategoryItem]
ON [dbo].[ItemSet]
    ([CategoryId]);
GO

-- Creating foreign key on [ComicParams_Id] in table 'ComicSet'
ALTER TABLE [dbo].[ComicSet]
ADD CONSTRAINT [FK_ComicComicParams]
    FOREIGN KEY ([ComicParams_Id])
    REFERENCES [dbo].[ComicmParamsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ComicComicParams'
CREATE INDEX [IX_FK_ComicComicParams]
ON [dbo].[ComicSet]
    ([ComicParams_Id]);
GO

-- Creating foreign key on [PublisherId] in table 'ComicSet'
ALTER TABLE [dbo].[ComicSet]
ADD CONSTRAINT [FK_PublisherItem]
    FOREIGN KEY ([PublisherId])
    REFERENCES [dbo].[PublisherSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublisherItem'
CREATE INDEX [IX_FK_PublisherItem]
ON [dbo].[ItemSet]
    ([PublisherId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------