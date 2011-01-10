CREATE TABLE [dbo].[T_TRANS_REF]
(
	[TRANS_ID] [nvarchar](50) NOT NULL,
	[TRANS_ID_REF] [nvarchar](50) NOT NULL,
	[TRANS_REF_STATUS] [nvarchar](50) NULL,
	[TRANS_REF_DESC] [nvarchar](max) NULL,
	[DATA_STATUS] [nvarchar](50) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[MODIFIED_BY] [nvarchar](50) NULL,
	[MODIFIED_DATE] [datetime] NULL,
	[ROW_VERSION] [timestamp] NULL,
	[TRANS_REF_ID] [nvarchar](50) NOT NULL
)
