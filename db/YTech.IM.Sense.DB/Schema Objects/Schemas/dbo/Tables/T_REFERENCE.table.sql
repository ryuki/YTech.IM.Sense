﻿CREATE TABLE [dbo].[T_REFERENCE] (
    [REFERENCE_ID]     NVARCHAR (50) NOT NULL,
    [REFERENCE_TYPE]   NVARCHAR (50) NOT NULL,
    [REFERENCE_VALUE]  NVARCHAR (50) NULL,
    [REFERENCE_DESC]   NVARCHAR (50) NULL,
    [DATA_STATUS]      NVARCHAR (50) NULL,
    [CREATED_BY]       NVARCHAR (50) NULL,
    [MODIFIED_BY]      NVARCHAR (50) NULL,
    [MODIFIED_DATE]    DATETIME      NULL,
    [ROW_VERSION]      TIMESTAMP     NULL,
    [REFERENCE_STATUS] NVARCHAR (50) NULL,
    [CREATED_DATE]     DATETIME      NULL
);
