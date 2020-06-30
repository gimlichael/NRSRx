CREATE TABLE [dbo].[Items]
(
  [Id] UNIQUEIDENTIFIER NOT NULL,
  [Value] NVARCHAR (50) NOT NULL,
  
  [CreatedBy] NVARCHAR (250) NOT NULL,
  [UpdatedBy] NVARCHAR (250) NULL,
  [CreatedOnUtc] DATETIMEOFFSET (7) NOT NULL,
  [UpdatedOnUtc] DATETIMEOFFSET (7) NULL,
  CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([Id] ASC)
);


