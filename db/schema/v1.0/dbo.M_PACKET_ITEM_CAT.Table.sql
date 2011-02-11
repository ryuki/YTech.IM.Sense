﻿USE [DB_IM_SENSE]
GO
/****** Object:  Table [dbo].[M_PACKET_ITEM_CAT]    Script Date: 01/09/2011 13:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_PACKET_ITEM_CAT](
	[PACKET_ITEM_CAT_ID] [nvarchar](50) NOT NULL,
	[PACKET_ID] [nvarchar](50) NULL,
	[ITEM_CAT_ID] [nvarchar](50) NULL,
	[ITEM_CAT_QTY] [decimal](18, 5) NULL,
	[PACKET_ITEM_CAT_STATUS] [nvarchar](50) NULL,
	[PACKET_ITEM_CAT_DESC] [nvarchar](max) NULL,
	[DATA_STATUS] [nvarchar](50) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [nvarchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ROW_VERSION] [timestamp] NULL,
 CONSTRAINT [PK_M_PACKET_ITEM_CAT] PRIMARY KEY CLUSTERED 
(
	[PACKET_ITEM_CAT_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[M_PACKET_ITEM_CAT]  WITH CHECK ADD  CONSTRAINT [FK_M_PACKET_ITEM_CAT_M_ITEM_CAT] FOREIGN KEY([ITEM_CAT_ID])
REFERENCES [dbo].[M_ITEM_CAT] ([ITEM_CAT_ID])
GO
ALTER TABLE [dbo].[M_PACKET_ITEM_CAT] CHECK CONSTRAINT [FK_M_PACKET_ITEM_CAT_M_ITEM_CAT]
GO
ALTER TABLE [dbo].[M_PACKET_ITEM_CAT]  WITH CHECK ADD  CONSTRAINT [FK_M_PACKET_ITEM_CAT_M_PACKET] FOREIGN KEY([PACKET_ID])
REFERENCES [dbo].[M_PACKET] ([PACKET_ID])
GO
ALTER TABLE [dbo].[M_PACKET_ITEM_CAT] CHECK CONSTRAINT [FK_M_PACKET_ITEM_CAT_M_PACKET]
GO
