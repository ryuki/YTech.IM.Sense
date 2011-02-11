﻿USE [DB_IM_SENSE]
GO
/****** Object:  Table [dbo].[T_REC_ACCOUNT]    Script Date: 01/09/2011 13:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_REC_ACCOUNT](
	[REC_ACCOUNT_ID] [nvarchar](50) NOT NULL,
	[REC_PERIOD_ID] [nvarchar](50) NOT NULL,
	[COST_CENTER_ID] [nvarchar](50) NULL,
	[ACCOUNT_ID] [nvarchar](50) NOT NULL,
	[ACCOUNT_STATUS] [nvarchar](50) NULL,
	[REC_ACCOUNT_START] [numeric](18, 5) NULL,
	[REC_ACCOUNT_END] [numeric](18, 5) NULL,
	[REC_ACCOUNT_DESC] [nvarchar](max) NULL,
	[DATA_STATUS] [nvarchar](50) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [nvarchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ROW_VERSION] [timestamp] NULL,
 CONSTRAINT [PK_T_REC_ACCOUNT] PRIMARY KEY CLUSTERED 
(
	[REC_ACCOUNT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_REC_ACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_T_REC_ACCOUNT_M_ACCOUNT] FOREIGN KEY([ACCOUNT_ID])
REFERENCES [dbo].[M_ACCOUNT] ([ACCOUNT_ID])
GO
ALTER TABLE [dbo].[T_REC_ACCOUNT] CHECK CONSTRAINT [FK_T_REC_ACCOUNT_M_ACCOUNT]
GO
ALTER TABLE [dbo].[T_REC_ACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_T_REC_ACCOUNT_M_COST_CENTER] FOREIGN KEY([COST_CENTER_ID])
REFERENCES [dbo].[M_COST_CENTER] ([COST_CENTER_ID])
GO
ALTER TABLE [dbo].[T_REC_ACCOUNT] CHECK CONSTRAINT [FK_T_REC_ACCOUNT_M_COST_CENTER]
GO
ALTER TABLE [dbo].[T_REC_ACCOUNT]  WITH CHECK ADD  CONSTRAINT [FK_T_REC_ACCOUNT_T_REC_PERIOD] FOREIGN KEY([REC_PERIOD_ID])
REFERENCES [dbo].[T_REC_PERIOD] ([REC_PERIOD_ID])
GO
ALTER TABLE [dbo].[T_REC_ACCOUNT] CHECK CONSTRAINT [FK_T_REC_ACCOUNT_T_REC_PERIOD]
GO
