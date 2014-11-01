
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/01/2014 13:12:31
-- Generated from EDMX file: C:\Users\ViZa\Documents\Visual Studio 2013\Projects\tskmProject\tskmProject\Models\tskm.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [tskmDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DepartmentUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_DepartmentUser];
GO
IF OBJECT_ID(N'[dbo].[FK_CatagoryKnowledgebase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Knowledgebases] DROP CONSTRAINT [FK_CatagoryKnowledgebase];
GO
IF OBJECT_ID(N'[dbo].[FK_CatagoryTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_CatagoryTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_StatusTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_StatusTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketTicketReply]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketReplies] DROP CONSTRAINT [FK_TicketTicketReply];
GO
IF OBJECT_ID(N'[dbo].[FK_KnowledgebaseKnowledgeComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KnowledgeComments] DROP CONSTRAINT [FK_KnowledgebaseKnowledgeComment];
GO
IF OBJECT_ID(N'[dbo].[FK_UserKnowledgeComment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KnowledgeComments] DROP CONSTRAINT [FK_UserKnowledgeComment];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTicket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_UserTicket];
GO
IF OBJECT_ID(N'[dbo].[FK_UserTicketReply]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketReplies] DROP CONSTRAINT [FK_UserTicketReply];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoles_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRoles_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserRoles_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketFiles_Ticket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketFiles] DROP CONSTRAINT [FK_TicketFiles_Ticket];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketFiles_File]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketFiles] DROP CONSTRAINT [FK_TicketFiles_File];
GO
IF OBJECT_ID(N'[dbo].[FK_FileKnowledgebases_File]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileKnowledgebases] DROP CONSTRAINT [FK_FileKnowledgebases_File];
GO
IF OBJECT_ID(N'[dbo].[FK_FileKnowledgebases_Knowledgebase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileKnowledgebases] DROP CONSTRAINT [FK_FileKnowledgebases_Knowledgebase];
GO
IF OBJECT_ID(N'[dbo].[FK_UserKnowledgebase]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Knowledgebases] DROP CONSTRAINT [FK_UserKnowledgebase];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketTicketHistory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketHistories] DROP CONSTRAINT [FK_TicketTicketHistory];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketHistoryOldAssignee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketHistories] DROP CONSTRAINT [FK_TicketHistoryOldAssignee];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketUserAssignee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tickets] DROP CONSTRAINT [FK_TicketUserAssignee];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketHistoryNewAssignee]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketHistories] DROP CONSTRAINT [FK_TicketHistoryNewAssignee];
GO
IF OBJECT_ID(N'[dbo].[FK_TicketHistoryCreatedByUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TicketHistories] DROP CONSTRAINT [FK_TicketHistoryCreatedByUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Tickets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tickets];
GO
IF OBJECT_ID(N'[dbo].[Catagories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Catagories];
GO
IF OBJECT_ID(N'[dbo].[Status]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Status];
GO
IF OBJECT_ID(N'[dbo].[Knowledgebases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Knowledgebases];
GO
IF OBJECT_ID(N'[dbo].[TicketReplies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketReplies];
GO
IF OBJECT_ID(N'[dbo].[KnowledgeComments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KnowledgeComments];
GO
IF OBJECT_ID(N'[dbo].[Files]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[TicketHistories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketHistories];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[TicketFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketFiles];
GO
IF OBJECT_ID(N'[dbo].[FileKnowledgebases]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileKnowledgebases];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [departmentID] int IDENTITY(1,1) NOT NULL,
    [departmentName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [userID] int IDENTITY(1,1) NOT NULL,
    [userFname] nvarchar(max)  NOT NULL,
    [userLname] nvarchar(max)  NOT NULL,
    [userTel] nvarchar(max)  NOT NULL,
    [userEmail] nvarchar(max)  NOT NULL,
    [userPosition] nvarchar(max)  NOT NULL,
    [username] nvarchar(max)  NOT NULL,
    [password] nvarchar(max)  NOT NULL,
    [departmentID] int  NOT NULL,
    [userCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tickets'
CREATE TABLE [dbo].[Tickets] (
    [ticketID] int IDENTITY(1,1) NOT NULL,
    [ticketTitle] nvarchar(max)  NOT NULL,
    [ticketDetail] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [catagoryID] int  NOT NULL,
    [statusID] int  NOT NULL,
    [userID] int  NOT NULL,
    [Place] nvarchar(max)  NOT NULL,
    [Tel] nvarchar(max)  NOT NULL,
    [AssigneeID] int  NULL,
    [UpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Catagories'
CREATE TABLE [dbo].[Catagories] (
    [catagoryID] int IDENTITY(1,1) NOT NULL,
    [catagoryName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Status'
CREATE TABLE [dbo].[Status] (
    [statusID] int IDENTITY(1,1) NOT NULL,
    [statusName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Knowledgebases'
CREATE TABLE [dbo].[Knowledgebases] (
    [knowledgeID] int IDENTITY(1,1) NOT NULL,
    [knowledgeTitle] nvarchar(max)  NOT NULL,
    [knowledgeDetail] nvarchar(max)  NOT NULL,
    [knowledgeDate] datetime  NOT NULL,
    [catagoryID] int  NOT NULL,
    [userID] int  NOT NULL
);
GO

-- Creating table 'TicketReplies'
CREATE TABLE [dbo].[TicketReplies] (
    [replyID] int IDENTITY(1,1) NOT NULL,
    [replyDetail] nvarchar(max)  NOT NULL,
    [replyDate] datetime  NOT NULL,
    [ticketID] int  NOT NULL,
    [userID] int  NOT NULL
);
GO

-- Creating table 'KnowledgeComments'
CREATE TABLE [dbo].[KnowledgeComments] (
    [commentID] int IDENTITY(1,1) NOT NULL,
    [knowledgeID] int  NOT NULL,
    [commentDetail] nvarchar(max)  NOT NULL,
    [commentDate] datetime  NOT NULL,
    [userID] int  NOT NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [fileID] int IDENTITY(1,1) NOT NULL,
    [fileName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [roleID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TicketHistories'
CREATE TABLE [dbo].[TicketHistories] (
    [TicketID] int  NOT NULL,
    [OldAssigneeID] int  NULL,
    [NewAssigneeID] int  NULL,
    [Comment] nvarchar(max)  NOT NULL,
    [CreatedByID] int  NOT NULL,
    [CreatedDateTime] datetime  NOT NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [Users_userID] int  NOT NULL,
    [Roles_roleID] int  NOT NULL
);
GO

-- Creating table 'TicketFiles'
CREATE TABLE [dbo].[TicketFiles] (
    [Tickets_ticketID] int  NOT NULL,
    [Files_fileID] int  NOT NULL
);
GO

-- Creating table 'FileKnowledgebases'
CREATE TABLE [dbo].[FileKnowledgebases] (
    [Files_fileID] int  NOT NULL,
    [Knowledgebases_knowledgeID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [departmentID] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([departmentID] ASC);
GO

-- Creating primary key on [userID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([userID] ASC);
GO

-- Creating primary key on [ticketID] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [PK_Tickets]
    PRIMARY KEY CLUSTERED ([ticketID] ASC);
GO

-- Creating primary key on [catagoryID] in table 'Catagories'
ALTER TABLE [dbo].[Catagories]
ADD CONSTRAINT [PK_Catagories]
    PRIMARY KEY CLUSTERED ([catagoryID] ASC);
GO

-- Creating primary key on [statusID] in table 'Status'
ALTER TABLE [dbo].[Status]
ADD CONSTRAINT [PK_Status]
    PRIMARY KEY CLUSTERED ([statusID] ASC);
GO

-- Creating primary key on [knowledgeID] in table 'Knowledgebases'
ALTER TABLE [dbo].[Knowledgebases]
ADD CONSTRAINT [PK_Knowledgebases]
    PRIMARY KEY CLUSTERED ([knowledgeID] ASC);
GO

-- Creating primary key on [replyID] in table 'TicketReplies'
ALTER TABLE [dbo].[TicketReplies]
ADD CONSTRAINT [PK_TicketReplies]
    PRIMARY KEY CLUSTERED ([replyID] ASC);
GO

-- Creating primary key on [commentID] in table 'KnowledgeComments'
ALTER TABLE [dbo].[KnowledgeComments]
ADD CONSTRAINT [PK_KnowledgeComments]
    PRIMARY KEY CLUSTERED ([commentID] ASC);
GO

-- Creating primary key on [fileID] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([fileID] ASC);
GO

-- Creating primary key on [roleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([roleID] ASC);
GO

-- Creating primary key on [TicketID], [CreatedDateTime] in table 'TicketHistories'
ALTER TABLE [dbo].[TicketHistories]
ADD CONSTRAINT [PK_TicketHistories]
    PRIMARY KEY CLUSTERED ([TicketID], [CreatedDateTime] ASC);
GO

-- Creating primary key on [Users_userID], [Roles_roleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([Users_userID], [Roles_roleID] ASC);
GO

-- Creating primary key on [Tickets_ticketID], [Files_fileID] in table 'TicketFiles'
ALTER TABLE [dbo].[TicketFiles]
ADD CONSTRAINT [PK_TicketFiles]
    PRIMARY KEY CLUSTERED ([Tickets_ticketID], [Files_fileID] ASC);
GO

-- Creating primary key on [Files_fileID], [Knowledgebases_knowledgeID] in table 'FileKnowledgebases'
ALTER TABLE [dbo].[FileKnowledgebases]
ADD CONSTRAINT [PK_FileKnowledgebases]
    PRIMARY KEY CLUSTERED ([Files_fileID], [Knowledgebases_knowledgeID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [departmentID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_DepartmentUser]
    FOREIGN KEY ([departmentID])
    REFERENCES [dbo].[Departments]
        ([departmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DepartmentUser'
CREATE INDEX [IX_FK_DepartmentUser]
ON [dbo].[Users]
    ([departmentID]);
GO

-- Creating foreign key on [catagoryID] in table 'Knowledgebases'
ALTER TABLE [dbo].[Knowledgebases]
ADD CONSTRAINT [FK_CatagoryKnowledgebase]
    FOREIGN KEY ([catagoryID])
    REFERENCES [dbo].[Catagories]
        ([catagoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatagoryKnowledgebase'
CREATE INDEX [IX_FK_CatagoryKnowledgebase]
ON [dbo].[Knowledgebases]
    ([catagoryID]);
GO

-- Creating foreign key on [catagoryID] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_CatagoryTicket]
    FOREIGN KEY ([catagoryID])
    REFERENCES [dbo].[Catagories]
        ([catagoryID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CatagoryTicket'
CREATE INDEX [IX_FK_CatagoryTicket]
ON [dbo].[Tickets]
    ([catagoryID]);
GO

-- Creating foreign key on [statusID] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_StatusTicket]
    FOREIGN KEY ([statusID])
    REFERENCES [dbo].[Status]
        ([statusID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StatusTicket'
CREATE INDEX [IX_FK_StatusTicket]
ON [dbo].[Tickets]
    ([statusID]);
GO

-- Creating foreign key on [ticketID] in table 'TicketReplies'
ALTER TABLE [dbo].[TicketReplies]
ADD CONSTRAINT [FK_TicketTicketReply]
    FOREIGN KEY ([ticketID])
    REFERENCES [dbo].[Tickets]
        ([ticketID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketTicketReply'
CREATE INDEX [IX_FK_TicketTicketReply]
ON [dbo].[TicketReplies]
    ([ticketID]);
GO

-- Creating foreign key on [knowledgeID] in table 'KnowledgeComments'
ALTER TABLE [dbo].[KnowledgeComments]
ADD CONSTRAINT [FK_KnowledgebaseKnowledgeComment]
    FOREIGN KEY ([knowledgeID])
    REFERENCES [dbo].[Knowledgebases]
        ([knowledgeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KnowledgebaseKnowledgeComment'
CREATE INDEX [IX_FK_KnowledgebaseKnowledgeComment]
ON [dbo].[KnowledgeComments]
    ([knowledgeID]);
GO

-- Creating foreign key on [userID] in table 'KnowledgeComments'
ALTER TABLE [dbo].[KnowledgeComments]
ADD CONSTRAINT [FK_UserKnowledgeComment]
    FOREIGN KEY ([userID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserKnowledgeComment'
CREATE INDEX [IX_FK_UserKnowledgeComment]
ON [dbo].[KnowledgeComments]
    ([userID]);
GO

-- Creating foreign key on [userID] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_UserTicket]
    FOREIGN KEY ([userID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTicket'
CREATE INDEX [IX_FK_UserTicket]
ON [dbo].[Tickets]
    ([userID]);
GO

-- Creating foreign key on [userID] in table 'TicketReplies'
ALTER TABLE [dbo].[TicketReplies]
ADD CONSTRAINT [FK_UserTicketReply]
    FOREIGN KEY ([userID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTicketReply'
CREATE INDEX [IX_FK_UserTicketReply]
ON [dbo].[TicketReplies]
    ([userID]);
GO

-- Creating foreign key on [Users_userID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_User]
    FOREIGN KEY ([Users_userID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_roleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRoles_Role]
    FOREIGN KEY ([Roles_roleID])
    REFERENCES [dbo].[Roles]
        ([roleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRoles_Role'
CREATE INDEX [IX_FK_UserRoles_Role]
ON [dbo].[UserRoles]
    ([Roles_roleID]);
GO

-- Creating foreign key on [Tickets_ticketID] in table 'TicketFiles'
ALTER TABLE [dbo].[TicketFiles]
ADD CONSTRAINT [FK_TicketFiles_Ticket]
    FOREIGN KEY ([Tickets_ticketID])
    REFERENCES [dbo].[Tickets]
        ([ticketID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Files_fileID] in table 'TicketFiles'
ALTER TABLE [dbo].[TicketFiles]
ADD CONSTRAINT [FK_TicketFiles_File]
    FOREIGN KEY ([Files_fileID])
    REFERENCES [dbo].[Files]
        ([fileID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketFiles_File'
CREATE INDEX [IX_FK_TicketFiles_File]
ON [dbo].[TicketFiles]
    ([Files_fileID]);
GO

-- Creating foreign key on [Files_fileID] in table 'FileKnowledgebases'
ALTER TABLE [dbo].[FileKnowledgebases]
ADD CONSTRAINT [FK_FileKnowledgebases_File]
    FOREIGN KEY ([Files_fileID])
    REFERENCES [dbo].[Files]
        ([fileID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Knowledgebases_knowledgeID] in table 'FileKnowledgebases'
ALTER TABLE [dbo].[FileKnowledgebases]
ADD CONSTRAINT [FK_FileKnowledgebases_Knowledgebase]
    FOREIGN KEY ([Knowledgebases_knowledgeID])
    REFERENCES [dbo].[Knowledgebases]
        ([knowledgeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileKnowledgebases_Knowledgebase'
CREATE INDEX [IX_FK_FileKnowledgebases_Knowledgebase]
ON [dbo].[FileKnowledgebases]
    ([Knowledgebases_knowledgeID]);
GO

-- Creating foreign key on [userID] in table 'Knowledgebases'
ALTER TABLE [dbo].[Knowledgebases]
ADD CONSTRAINT [FK_UserKnowledgebase]
    FOREIGN KEY ([userID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserKnowledgebase'
CREATE INDEX [IX_FK_UserKnowledgebase]
ON [dbo].[Knowledgebases]
    ([userID]);
GO

-- Creating foreign key on [TicketID] in table 'TicketHistories'
ALTER TABLE [dbo].[TicketHistories]
ADD CONSTRAINT [FK_TicketTicketHistory]
    FOREIGN KEY ([TicketID])
    REFERENCES [dbo].[Tickets]
        ([ticketID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [OldAssigneeID] in table 'TicketHistories'
ALTER TABLE [dbo].[TicketHistories]
ADD CONSTRAINT [FK_TicketHistoryOldAssignee]
    FOREIGN KEY ([OldAssigneeID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketHistoryOldAssignee'
CREATE INDEX [IX_FK_TicketHistoryOldAssignee]
ON [dbo].[TicketHistories]
    ([OldAssigneeID]);
GO

-- Creating foreign key on [AssigneeID] in table 'Tickets'
ALTER TABLE [dbo].[Tickets]
ADD CONSTRAINT [FK_TicketUserAssignee]
    FOREIGN KEY ([AssigneeID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketUserAssignee'
CREATE INDEX [IX_FK_TicketUserAssignee]
ON [dbo].[Tickets]
    ([AssigneeID]);
GO

-- Creating foreign key on [NewAssigneeID] in table 'TicketHistories'
ALTER TABLE [dbo].[TicketHistories]
ADD CONSTRAINT [FK_TicketHistoryNewAssignee]
    FOREIGN KEY ([NewAssigneeID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketHistoryNewAssignee'
CREATE INDEX [IX_FK_TicketHistoryNewAssignee]
ON [dbo].[TicketHistories]
    ([NewAssigneeID]);
GO

-- Creating foreign key on [CreatedByID] in table 'TicketHistories'
ALTER TABLE [dbo].[TicketHistories]
ADD CONSTRAINT [FK_TicketHistoryCreatedByUser]
    FOREIGN KEY ([CreatedByID])
    REFERENCES [dbo].[Users]
        ([userID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TicketHistoryCreatedByUser'
CREATE INDEX [IX_FK_TicketHistoryCreatedByUser]
ON [dbo].[TicketHistories]
    ([CreatedByID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------