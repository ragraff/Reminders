﻿CREATE TABLE [dbo].[Reminder]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Text] [VARCHAR](MAX) NOT NULL,
	[Priority] [SMALLINT] NOT NULL DEFAULT(0),
	[DueDate] [DATETIME] NULL
)