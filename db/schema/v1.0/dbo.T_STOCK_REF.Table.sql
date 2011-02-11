﻿USE [DB_IM_SENSE]
GO
/****** Object:  Table [dbo].[T_STOCK_REF]    Script Date: 01/09/2011 13:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_STOCK_REF](
	[STOCK_ID] [nvarchar](50) NOT NULL,
	[STOCK_REF_ID] [nvarchar](50) NOT NULL,
	[STOCK_REF_QTY] [numeric](18, 5) NULL,
	[STOCK_REF_DESC] [nvarchar](max) NULL,
	[DATA_STATUS] [nvarchar](50) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [nvarchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ROW_VERSION] [timestamp] NULL,
 CONSTRAINT [PK_T_STOCK_REF_1] PRIMARY KEY CLUSTERED 
(
	[STOCK_ID] ASC,
	[STOCK_REF_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_STOCK_REF]  WITH CHECK ADD  CONSTRAINT [FK_T_STOCK_REF_T_STOCK] FOREIGN KEY([STOCK_ID])
REFERENCES [dbo].[T_STOCK] ([STOCK_ID])
GO
ALTER TABLE [dbo].[T_STOCK_REF] CHECK CONSTRAINT [FK_T_STOCK_REF_T_STOCK]
GO
