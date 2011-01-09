﻿CREATE TABLE [dbo].[T_SHIFT] (
    [SHIFT_ID]        NVARCHAR (50)  NOT NULL,
    [EMPLOYEE_ID]     NVARCHAR (50)  NULL,
    [SHIFT_DATE]      DATETIME       NULL,
    [SHIFT_NO]        INT            NULL,
    [SHIFT_DATE_FROM] DATETIME       NULL,
    [SHIFT_DATE_TO]   DATETIME       NULL,
    [SHIFT_STATUS]    NVARCHAR (50)  NULL,
    [SHIFT_DESC]      NVARCHAR (MAX) NULL,
    [DATA_STATUS]     NVARCHAR (50)  NULL,
    [CREATED_BY]      NVARCHAR (50)  NULL,
    [CREATED_DATE]    DATETIME       NULL,
    [MODIFIED_BY]     NVARCHAR (50)  NULL,
    [MODIFIED_DATE]   DATETIME       NULL,
    [ROW_VERSION]     TIMESTAMP      NULL
);

