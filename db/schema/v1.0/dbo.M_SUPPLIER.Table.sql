﻿USE [DB_IM_SENSE]
GO
/****** Object:  Table [dbo].[M_SUPPLIER]    Script Date: 01/09/2011 13:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_SUPPLIER](
	[SUPPLIER_ID] [nvarchar](50) NOT NULL,
	[SUPPLIER_NAME] [nvarchar](50) NOT NULL,
	[ADDRESS_ID] [nvarchar](50) NULL,
	[SUPPLIER_STATUS] [nvarchar](50) NULL,
	[SUPPLIER_MAX_DEBT] [numeric](18, 5) NULL,
	[SUPPLIER_DESC] [nvarchar](max) NULL,
	[DATA_STATUS] [nvarchar](50) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [nvarchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ROW_VERSION] [timestamp] NULL,
 CONSTRAINT [PK_M_SUPPLIER] PRIMARY KEY CLUSTERED 
(
	[SUPPLIER_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[M_SUPPLIER]  WITH CHECK ADD  CONSTRAINT [FK_M_SUPPLIER_REF_ADDRESS] FOREIGN KEY([ADDRESS_ID])
REFERENCES [dbo].[REF_ADDRESS] ([ADDRESS_ID])
GO
ALTER TABLE [dbo].[M_SUPPLIER] CHECK CONSTRAINT [FK_M_SUPPLIER_REF_ADDRESS]
GO
