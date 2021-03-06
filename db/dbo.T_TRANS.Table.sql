USE [DB_IM_SENSE]
GO
/****** Object:  Table [dbo].[T_TRANS]    Script Date: 10/19/2013 02:43:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_TRANS](
	[TRANS_ID] [nvarchar](50) NOT NULL,
	[WAREHOUSE_ID] [nvarchar](50) NULL,
	[WAREHOUSE_ID_TO] [nvarchar](50) NULL,
	[TRANS_DATE] [datetime] NULL,
	[TRANS_BY] [nvarchar](50) NULL,
	[TRANS_REF_ID] [nvarchar](50) NULL,
	[TRANS_FACTUR] [nvarchar](50) NULL,
	[EMPLOYEE_ID] [nvarchar](50) NULL,
	[TRANS_DUE_DATE] [datetime] NULL,
	[TRANS_PAYMENT_METHOD] [nvarchar](50) NULL,
	[TRANS_SUB_TOTAL] [numeric](18, 5) NULL,
	[TRANS_DISC] [numeric](18, 5) NULL,
	[TRANS_TAX] [numeric](18, 5) NULL,
	[TRANS_STATUS] [nvarchar](50) NULL,
	[TRANS_DESC] [nvarchar](max) NULL,
	[DATA_STATUS] [nvarchar](50) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [nvarchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ROW_VERSION] [timestamp] NULL,
	[PROMO_ID] [nvarchar](50) NULL,
	[PROMO_VALUE] [decimal](18, 5) NULL,
 CONSTRAINT [PK_T_TRANS_1] PRIMARY KEY CLUSTERED 
(
	[TRANS_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[T_TRANS]  WITH CHECK ADD  CONSTRAINT [FK_T_TRANS_M_EMPLOYEE] FOREIGN KEY([EMPLOYEE_ID])
REFERENCES [dbo].[M_EMPLOYEE] ([EMPLOYEE_ID])
GO
ALTER TABLE [dbo].[T_TRANS] CHECK CONSTRAINT [FK_T_TRANS_M_EMPLOYEE]
GO
ALTER TABLE [dbo].[T_TRANS]  WITH CHECK ADD  CONSTRAINT [FK_T_TRANS_M_PROMO] FOREIGN KEY([PROMO_ID])
REFERENCES [dbo].[M_PROMO] ([PROMO_ID])
GO
ALTER TABLE [dbo].[T_TRANS] CHECK CONSTRAINT [FK_T_TRANS_M_PROMO]
GO
ALTER TABLE [dbo].[T_TRANS]  WITH CHECK ADD  CONSTRAINT [FK_T_TRANS_M_WAREHOUSE] FOREIGN KEY([WAREHOUSE_ID])
REFERENCES [dbo].[M_WAREHOUSE] ([WAREHOUSE_ID])
GO
ALTER TABLE [dbo].[T_TRANS] CHECK CONSTRAINT [FK_T_TRANS_M_WAREHOUSE]
GO
ALTER TABLE [dbo].[T_TRANS]  WITH CHECK ADD  CONSTRAINT [FK_T_TRANS_M_WAREHOUSE1] FOREIGN KEY([WAREHOUSE_ID_TO])
REFERENCES [dbo].[M_WAREHOUSE] ([WAREHOUSE_ID])
GO
ALTER TABLE [dbo].[T_TRANS] CHECK CONSTRAINT [FK_T_TRANS_M_WAREHOUSE1]
GO
ALTER TABLE [dbo].[T_TRANS]  WITH CHECK ADD  CONSTRAINT [FK_T_TRANS_T_TRANS] FOREIGN KEY([TRANS_REF_ID])
REFERENCES [dbo].[T_TRANS] ([TRANS_ID])
GO
ALTER TABLE [dbo].[T_TRANS] CHECK CONSTRAINT [FK_T_TRANS_T_TRANS]
GO
