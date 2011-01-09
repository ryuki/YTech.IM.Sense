﻿CREATE TABLE [dbo].[T_MENU_ACCESS] (
    [MENU_ACCESS_ID] NVARCHAR (50) NOT NULL,
    [USER_NAME]      NVARCHAR (50) NOT NULL,
    [MENU_ID]        NVARCHAR (50) NOT NULL,
    [MENU_ACCESS]    BIT           NULL,
    [DATA_STATUS]    NVARCHAR (50) NULL,
    [CREATED_BY]     NVARCHAR (50) NULL,
    [MODIFIED_BY]    NVARCHAR (50) NULL,
    [MODIFIED_DATE]  DATETIME      NULL,
    [ROW_VERSION]    TIMESTAMP     NULL
);

