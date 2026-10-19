CREATE TABLE [Role] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Name ] VARCHAR (80) NOT NULL,
    [Slug]  VARCHAR (80) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Role_Slug] UNIQUE ([Slug])
);

CREATE NONCLUSTERED INDEX [IX_Role_Slug]
    ON [Role]([Slug]);

CREATE TABLE [UserRole] (
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,
    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId])
);

CREATE TABLE [Category] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Name ] VARCHAR (80) NOT NULL,
    [Slug]  VARCHAR (80) NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Category_Slug] UNIQUE ([Slug])
);

CREATE NONCLUSTERED INDEX [IX_Category_Slug]
    ON [Category]([Slug]);

CREATE TABLE [Post] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [CategoryId]     INT           NOT NULL,
    [AuthorId]       INT           NOT NULL,
    [Title]          VARCHAR (160) NOT NULL,
    [Summary]        VARCHAR (255) NOT NULL,
    [Body ]          TEXT          NOT NULL,
    [Slug]           VARCHAR (80)  NOT NULL,
    [CreateDate]     DATETIME      DEFAULT (GETDATE()) NOT NULL,
    [LastUpdateDate] DATETIME      DEFAULT (GETDATE()) NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Post_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category] ([Id]),
    CONSTRAINT [FK_Post_Author] FOREIGN KEY ([AuthorId]) REFERENCES [User] ([Id]),
    CONSTRAINT [UQ_Post_Slug] UNIQUE ([Slug])
);

CREATE NONCLUSTERED INDEX [IX_Post_Slug]
    ON [Post]([Slug]);

CREATE TABLE [Tag] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (80) NOT NULL,
    [Slug] VARCHAR (80) NOT NULL,
    CONSTRAINT [PK_Tag] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_Tag_Slug] UNIQUE ([Slug])
);

CREATE NONCLUSTERED INDEX [IX_Tag_Slug]
    ON [Tag]([Slug]);

CREATE TABLE [PostTag] (
    [PostId] INT NOT NULL,
    [TagId]  INT NOT NULL,
    CONSTRAINT PK_PostTag PRIMARY KEY ([PostId], [TagId])
);