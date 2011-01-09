USE [DB_IM_SENSE]
GO
/****** Object:  Table [dbo].[M_EMPLOYEE]    Script Date: 01/09/2011 13:55:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[M_EMPLOYEE](
	[EMPLOYEE_ID] [nvarchar](50) NOT NULL,
	[PERSON_ID] [nvarchar](50) NULL,
	[DEPARTMENT_ID] [nvarchar](50) NULL,
	[EMPLOYEE_STATUS] [nvarchar](50) NULL,
	[EMPLOYEE_DESC] [nvarchar](max) NULL,
	[DATA_STATUS] [nvarchar](50) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [nvarchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ROW_VERSION] [timestamp] NULL,
	[EMPLOYEE_COMMISSION_PRODUCT_VAL] [decimal](18, 5) NULL,
	[EMPLOYEE_COMMISSION_SERVICE_VAL] [decimal](18, 5) NULL,
	[EMPLOYEE_COMMISSION_PRODUCT_TYPE] [nvarchar](50) NULL,
	[EMPLOYEE_COMMISSION_SERVICE_TYPE] [nvarchar](50) NULL,
 CONSTRAINT [PK_M_EMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[EMPLOYEE_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[M_EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_M_EMPLOYEE_M_DEPARTMENT] FOREIGN KEY([DEPARTMENT_ID])
REFERENCES [dbo].[M_DEPARTMENT] ([DEPARTMENT_ID])
GO
ALTER TABLE [dbo].[M_EMPLOYEE] CHECK CONSTRAINT [FK_M_EMPLOYEE_M_DEPARTMENT]
GO
ALTER TABLE [dbo].[M_EMPLOYEE]  WITH CHECK ADD  CONSTRAINT [FK_M_EMPLOYEE_REF_PERSON] FOREIGN KEY([PERSON_ID])
REFERENCES [dbo].[REF_PERSON] ([PERSON_ID])
GO
ALTER TABLE [dbo].[M_EMPLOYEE] CHECK CONSTRAINT [FK_M_EMPLOYEE_REF_PERSON]
GO
