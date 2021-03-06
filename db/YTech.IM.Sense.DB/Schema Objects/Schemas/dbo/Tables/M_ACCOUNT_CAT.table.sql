﻿CREATE TABLE [dbo].[M_ACCOUNT_CAT] (
    [ACCOUNT_CAT_ID]     NVARCHAR (50)  NOT NULL,
    [ACCOUNT_CAT_NAME]   NVARCHAR (50)  NULL,
    [ACCOUNT_CAT_TYPE]   NVARCHAR (50)  NULL,
    [ACCOUNT_CAT_STATUS] NVARCHAR (50)  NULL,
    [ACCOUNT_CAT_DESC]   NVARCHAR (MAX) NULL,
    [DATA_STATUS]        NVARCHAR (50)  NULL,
    [CREATED_BY]         NVARCHAR (50)  NULL,
    [CREATED_DATE]       DATETIME       NULL,
    [MODIFIED_BY]        NVARCHAR (50)  NULL,
    [MODIFIED_DATE]      DATETIME       NULL,
    [ROW_VERSION]        TIMESTAMP      NULL
);

