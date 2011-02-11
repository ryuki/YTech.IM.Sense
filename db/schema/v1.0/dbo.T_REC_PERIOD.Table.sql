﻿USE [DB_IM_SENSE]
GO
/****** Object:  Table [dbo].[T_REC_PERIOD]    Script Date: 01/09/2011 13:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_REC_PERIOD](
	[REC_PERIOD_ID] [nvarchar](50) NOT NULL,
	[PERIOD_FROM] [datetime] NOT NULL,
	[PERIOD_TO] [datetime] NOT NULL,
	[PERIOD_TYPE] [nvarchar](50) NOT NULL,
	[PERIOD_STATUS] [nvarchar](50) NULL,
	[PERIOD_DESC] [nvarchar](max) NULL,
	[DATA_STATUS] [nvarchar](50) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [nvarchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ROW_VERSION] [timestamp] NULL,
 CONSTRAINT [PK_T_REC_PERIOD] PRIMARY KEY CLUSTERED 
(
	[REC_PERIOD_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
