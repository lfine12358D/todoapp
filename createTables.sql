USE [CodeChallange]
GO

/****** Object:  Table [dbo].[priorityTypes]    Script Date: 7/8/2016 5:06:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[priorityTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PriorityType] [nchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

USE [CodeChallange]
GO

/****** Object:  Table [dbo].[toDos]    Script Date: 7/8/2016 5:06:46 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[toDos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[priorityTypeId] [int] NOT NULL,
	[remindMeDate] [datetimeoffset](7) NOT NULL,
	[toDoDesc] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[toDos] ADD  DEFAULT ((1)) FOR [priorityTypeId]
GO

ALTER TABLE [dbo].[toDos] ADD  DEFAULT ('12/31/9999') FOR [remindMeDate]
GO

ALTER TABLE [dbo].[toDos]  WITH CHECK ADD  CONSTRAINT [FK_ToDos_PriorityTypes] FOREIGN KEY([priorityTypeId])
REFERENCES [dbo].[priorityTypes] ([Id])
GO

ALTER TABLE [dbo].[toDos] CHECK CONSTRAINT [FK_ToDos_PriorityTypes]
GO


