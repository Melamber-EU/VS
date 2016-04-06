USE [Tracker]
GO

/****** Object:  Table [dbo].[attendance]    Script Date: 06/04/2016 10:32:45 ******/
DROP TABLE [dbo].[attendance]
GO

/****** Object:  Table [dbo].[attendance]    Script Date: 06/04/2016 10:32:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[attendance](
	[userid] [int] NULL,
	[eventid] [int] NULL,
	[present] [bit] NULL
) ON [PRIMARY]

GO


