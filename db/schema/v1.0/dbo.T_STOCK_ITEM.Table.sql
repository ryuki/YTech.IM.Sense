USE [DB_IM_SENSE]
GO
/****** Object:  Table [dbo].[T_STOCK_ITEM]    Script Date: 01/09/2011 13:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_STOCK_ITEM](
	[ITEM_ID] [nvarchar](50) NOT NULL,
	[WAREHOUSE_ID] [nvarchar](50) NOT NULL,
	[ITEM_STOCK_MAX] [numeric](18, 5) NULL,
	[ITEM_STOCK_MIN] [numeric](18, 5) NULL,
	[ITEM_STOCK] [numeric](18, 5) NULL,
	[ITEM_STOCK_RACK] [nvarchar](50) NULL,
	[DATA_STATUS] [nvarchar](50) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [nvarchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ROW_VERSION] [timestamp] NULL,
	[STOCK_ITEM_ID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_T_STOCK_ITEM] PRIMARY KEY CLUSTERED 
(
	[STOCK_ITEM_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_STOCK_ITEM]  WITH CHECK ADD  CONSTRAINT [FK_T_STOCK_ITEM_M_ITEM] FOREIGN KEY([ITEM_ID])
REFERENCES [dbo].[M_ITEM] ([ITEM_ID])
GO
ALTER TABLE [dbo].[T_STOCK_ITEM] CHECK CONSTRAINT [FK_T_STOCK_ITEM_M_ITEM]
GO
ALTER TABLE [dbo].[T_STOCK_ITEM]  WITH CHECK ADD  CONSTRAINT [FK_T_STOCK_ITEM_M_WAREHOUSE] FOREIGN KEY([WAREHOUSE_ID])
REFERENCES [dbo].[M_WAREHOUSE] ([WAREHOUSE_ID])
GO
ALTER TABLE [dbo].[T_STOCK_ITEM] CHECK CONSTRAINT [FK_T_STOCK_ITEM_M_WAREHOUSE]
GO
